using adesso_XTB_Plugins.DocumentTemplateExport.Exceptions;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adesso_XTB_Plugins.DocumentTemplateExport
{
    public class BindingSourceService
    {
        private IOrganizationService service;
        private Settings settings;

        public BindingSourceService(IOrganizationService service, Settings settings)
        {
            this.service = service;
            this.settings = settings;
        }

        private BindingSource FillBindingSourceWithTemplates(BindingSource bs, IEnumerable<DocumentTemplateModel> templateList)
        {
            foreach (var t in templateList)
            {
                bs.Add(t);
            }

            return bs;
        }

        public BindingSource LoadCrmTemplatesToBindingSource(BindingSource bs)
        {
            bs.Clear();

            var crmService = new DocumentTemplateService(service, new SettingsService());

            var documents = crmService.QueryDocuments();

            var templateList = documents.General;

            FillBindingSourceWithTemplates(bs, documents.General);

            FillBindingSourceWithTemplates(bs, documents.Personal);

            return bs;
        }

        public BindingSource AddNewTemplateToBindingSourceFromFile(DataGridView dgv, BindingSource bs, string filePath)
        {
            var fileInfo = new FileInfo(filePath);

            string regexp = @"[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}";
            var id = Guid.Empty;

            if (Regex.IsMatch(filePath, regexp))
            {
                id = new Guid(Regex.Match(filePath, regexp).Value);
            }
            if (!CheckMethods.DoesGridviewContainGuid(dgv, "idDataGridViewTextBoxColumn", id))
            {
                var entityType = string.Empty;

                if (filePath.Contains(settings.PrefixDocumentTemplate))
                {
                    entityType = "documenttemplate";
                }
                if (filePath.Contains(settings.PrefixPersonalDocumentTemplate))
                {
                    entityType = "personaldocumenttemplate";
                }

                var template = new DocumentTemplateModel
                {
                    Id = id,
                    DocumentType = fileInfo.Extension,
                    Name = fileInfo.Name.Replace(fileInfo.Extension, string.Empty),
                    FilePath = filePath,
                    EntityType = entityType,
                    CreatedNew = true
                };

                bs.Add(template);
            }
            else
            {
                var ex = new DuplicateException("Duplicate detected! A dataset with the given id " + id.ToString() + " was already added to this list!");
                throw ex;
            }

            return bs;
        }

        public BindingSource CopySelectedTemplate(DataGridViewRow selectedRow, BindingSource bs, string directoryPath)
        {
            var current = (DocumentTemplateModel)selectedRow.DataBoundItem;
            var newTemplate = new DocumentTemplateModel
            {
                Content = string.Empty,
                Description = current.Description,
                DocumentType = current.DocumentType,
                Prefix = current.Prefix,
                Id = Guid.Empty,
                ModifiedBy = string.Empty,
                Name = current.Name,
                EntityType = string.Empty,
                CreatedNew = true
            };
            
            var fileExists = false;
            var searchPattern = @"\(\d*\)";
            do
            {
                newTemplate.FilePath = Path.Combine(directoryPath, newTemplate.GetFileName());

                if (File.Exists(newTemplate.FilePath))
                {
                    fileExists = true;
                    if (Regex.IsMatch(newTemplate.Name, searchPattern))
                    {
                        var matches = Regex.Matches(newTemplate.Name, searchPattern);
                        var lastOccurence = matches[matches.Count - 1];
                        var numberString = lastOccurence.Value;
                        numberString = numberString.Replace(")", "");
                        numberString = numberString.Replace("(", "");
                        var highestCount = Convert.ToInt32(numberString);

                        newTemplate.Name = Regex.Replace(newTemplate.Name, searchPattern, $"({highestCount + 1})");
                        newTemplate.FilePath = Path.Combine(directoryPath, newTemplate.GetFileName());
                    }
                    else
                    {
                        newTemplate.Name = newTemplate.Name + "(1)";
                        newTemplate.FilePath = Path.Combine(directoryPath, newTemplate.GetFileName());
                    }
                }
                else
                {
                    fileExists = false;
                }
            }
            while (fileExists);

            File.Copy(current.FilePath, newTemplate.FilePath);
            bs.Add(newTemplate);

            return bs;
        }
    }
}
