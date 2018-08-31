
using System;
using XrmToolBox.Extensibility;

namespace adesso_XTB_Plugins.DocumentTemplateExport
{
    public class SettingsService
    {
        public Settings LoadOrInitializeSettings()
        {
            Settings loadedSetting;

            if (!SettingsManager.Instance.TryLoad(typeof(DocumentTemplateExport), out loadedSetting))
            {
                var initalSettings = new Settings
                {
                    PrefixDocumentTemplate = "prfDT",
                    PrefixPersonalDocumentTemplate = "prfPDT",
                    NotificationUriAddress = "http://github.com/MscrmTools/XrmToolBox",
                    DirectoryErrorText = "File Path is not set or does not exist!",
                    NotificationDirectoryEmpty = "The given directoy contains no valid templates!",
                    NotifcationDirectoryExists = "Directory was found!"
                };

                SettingsManager.Instance.Save(typeof(DocumentTemplateExport), initalSettings);

                loadedSetting = initalSettings;
            }

            return loadedSetting;
        }

        internal void Save(Settings mySettings)
        {
            SettingsManager.Instance.Save(typeof(DocumentTemplateExport), mySettings);
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