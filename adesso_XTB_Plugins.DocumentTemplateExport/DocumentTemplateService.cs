using System;
using System.IO;

using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using System.Collections.Generic;

namespace adesso_XTB_Plugins.DocumentTemplateExport
{
    public class DocumentTemplateService
    {
        public class Documents
        {
            public ICollection<DocumentTemplateModel> Personal { get; set; }
            public ICollection<DocumentTemplateModel> General { get; set; }
        }

        private IOrganizationService Service;
        private string _personalPrefix;
        private string _generalPrefix;
        private string baseDirectory;

        public DocumentTemplateService(IOrganizationService service, string personalPrefix, string generalPrefix, string baseDirectory)
        {
            Service = service;
            _personalPrefix = personalPrefix;
            _generalPrefix = generalPrefix;
            this.baseDirectory = baseDirectory;
        }

        public DocumentTemplateService(IOrganizationService service, SettingsService settingsService)
        {
            Service = service;
            var setting = settingsService.LoadOrInitializeSettings();

            _personalPrefix = setting.PrefixPersonalDocumentTemplate;
            _generalPrefix = setting.PrefixDocumentTemplate;
            this.baseDirectory = setting.LastDirectoryPath;
        }

        public Documents QueryDocuments()
        {
            return new Documents
            {
                Personal = GetDTObjectsListFromEntityCollection(RetrievePersonalDocumentTemplates()),
                General = GetDTObjectsListFromEntityCollection(RetrieveDocumentTemplates())
            };
        }


        private EntityCollection RetrieveDocumentTemplates()
        {
            QueryExpression qe = new QueryExpression()
            {
                EntityName = "documenttemplate",
                ColumnSet = new ColumnSet("name", "documenttype", "modifiedon", "modifiedby", "description", "content")
            };
            qe.AddOrder("name", OrderType.Ascending);

            EntityCollection retrieved = Service.RetrieveMultiple(qe);

            return retrieved;
        }

        private EntityCollection RetrievePersonalDocumentTemplates()
        {
            QueryExpression qe = new QueryExpression()
            {
                EntityName = "personaldocumenttemplate",
                ColumnSet = new ColumnSet("name", "documenttype", "modifiedon", "modifiedby", "description", "content")
            };
            qe.AddOrder("name", OrderType.Ascending);

            EntityCollection retrieved = Service.RetrieveMultiple(qe);

            return retrieved;
        }


        private List<DocumentTemplateModel> GetDTObjectsListFromEntityCollection(EntityCollection entities)
        {
            var list = new List<DocumentTemplateModel>();

            foreach (var e in entities.Entities)
            {
                var doctype = string.Empty;
                switch (((OptionSetValue)e["documenttype"]).Value)
                {
                    case 1:
                        doctype = ".xlsx";
                        break;
                    case 2:
                        doctype = ".docx";
                        break;
                }

                var prefix = string.Empty;
                switch (e.LogicalName)
                {
                    case "documenttemplate":
                        prefix = _generalPrefix;
                        break;
                    case "personaldocumenttemplate":
                        prefix = _personalPrefix;
                        break;
                }

                var modifiedBy = Service.Retrieve("systemuser",
                                                ((EntityReference)e["modifiedby"]).Id,
                                                new ColumnSet("fullname")
                                                );

                var dto = new DocumentTemplateModel
                {
                    Id = e.Id,
                    Description = e.GetAttributeValue<string>("description"),
                    ModifiedBy = (string)modifiedBy["fullname"],
                    ModifiedOn = ((DateTime)e.GetAttributeValue<DateTime?>("modifiedon")).ToLocalTime(),
                    Name = (string)e["name"],
                    Content = (string)e["content"],
                    Prefix = prefix,
                    DocumentType = doctype,
                    EntityType = e.LogicalName,
                    CreatedNew = false
                };
                dto.FilePath = Path.Combine(baseDirectory, dto.GetFileName());

                list.Add(dto);
            }

            return list;
        }

        public void UpdateFile(DocumentTemplateModel t)
        {
            string importFile = Convert.ToBase64String(File.ReadAllBytes(t.FilePath));

            var template = new Entity(t.EntityType);

            template.Id = t.Id;
            template["content"] = importFile;
            template["description"] = t.Description;

            Service.Update(template);
        }

        public void CreateFile(DocumentTemplateModel t)
        {
            string importFile = Convert.ToBase64String(File.ReadAllBytes(t.FilePath));

            var doctype = new OptionSetValue();
            switch (t.DocumentType)
            {
                case ".xlsx":
                    doctype.Value = 1;
                    break;
                case ".docx":
                    doctype.Value = 2;
                    break;
            }

            var template = new DocumentTemplate
            {
                Name = t.Name,
                Content = importFile,
                DocumentType = doctype,
                Description = t.Description
            };
            Service.Create(template);
        }
    }
}

//private void BtnExport_Click(object sender, EventArgs e)
//{
//    if (!string.IsNullOrEmpty(txtDirectoryPath.Text) && Directory.Exists(txtDirectoryPath.Text))
//    {
//        BsDocumentTemplateObject.Clear();
//        BsPersonalDocumentTemplateObject.Clear();

//        var retrievedDT = new EntityCollection();
//        var retrievedPDT = new EntityCollection();

//        //WorkAsync(new WorkAsyncInfo
//        //{
//        //    Message = "Exporting Document Templates to the selected directory",
//        //    Work = (worker, eArgs) =>
//        //    {
//        //        retrievedDT = RetrieveDocumentTemplates();
//        //        retrievedPDT = RetrievePersonalDocumentTemplates();

//        //        //var watcher = new FileSystemWatcher(txtDirectoryPath.Text);
//        //        //watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
//        //        //                       | NotifyFilters.FileName | NotifyFilters.DirectoryName;
//        //        //watcher.Filter = "*.*";
//        //        //watcher.Changed += new FileSystemEventHandler(OnChanged);
//        //        //watcher.EnableRaisingEvents = true;

//        //    },
//        //    AsyncArgument = null,
//        //    IsCancelable = false,
//        //    MessageWidth = 340,
//        //    MessageHeight = 150
//        //});

//        retrievedDT = RetrieveDocumentTemplates(false);
//        pgrbExportImport.Value = 12;

//        retrievedPDT = RetrieveDocumentTemplates(true);
//        pgrbExportImport.Value = 24;

//        var templateList = GetDTObjectsListFromEntityCollection(retrievedDT);
//        pgrbExportImport.Value = 36;

//        FillBindingSourceWithTemplates(BsDocumentTemplateObject, templateList);
//        pgrbExportImport.Value = 48;

//        SaveFilesToDisk(templateList);
//        pgrbExportImport.Value = 60;

//        templateList = GetDTObjectsListFromEntityCollection(retrievedPDT);
//        pgrbExportImport.Value = 72;

//        FillBindingSourceWithTemplates(BsPersonalDocumentTemplateObject, templateList);
//        pgrbExportImport.Value = 84;

//        SaveFilesToDisk(templateList);
//        pgrbExportImport.Value = 100;

//        retrievedDT = null;
//        retrievedPDT = null;
//        templateList = null;

//        ShowInfoNote("Export finished!");

//        Task.Factory.StartNew(() =>
//        {
//            Thread.Sleep(3500);
//            pgrbExportImport.Value = 0;
//        });

//    }
//    else // txtDirectoryPath.Text == null or empty && directory exists
//    {
//        ShowErrorNote(MySettings.DirectoryErrorText);
//    }
//}

//private void BtnImport_Click(object sender, EventArgs e)
//{
//    if (!string.IsNullOrEmpty(txtDirectoryPath.Text) && Directory.Exists(txtDirectoryPath.Text))
//    {
//        var dialog = new ConfirmImportDialog();
//        DialogResult result = dialog.ShowDialog();

//        if (result == DialogResult.OK)
//        {
//            if (ImportFiles())
//            {
//                ShowInfoNote("Import finished!");
//                Task.Factory.StartNew(() =>
//                {
//                    Thread.Sleep(3500);
//                    pgrbExportImport.Value = 0;
//                });
//            }
//        }
//    }
//    else // txtDirectoryPath.Text == null or empty && directory exists
//    {
//        ShowErrorNote(MySettings.DirectoryErrorText);
//    }
//}