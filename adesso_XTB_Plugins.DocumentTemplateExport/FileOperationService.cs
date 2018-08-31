using adesso_XTB_Plugins.DocumentTemplateExport.Exceptions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adesso_XTB_Plugins.DocumentTemplateExport
{
    public class FileOperationService
    {
        private Settings settings;

        public FileOperationService(Settings settings)
        {
            this.settings = settings;
        }

        public void OpenFilePathFolder(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath) && Directory.Exists(filePath))
            {
                Process.Start(filePath);
            }
            else
            {
                var ex = new InvalidDirectoryException();

                throw ex;
            }
        }

        public void SaveFileToDisk(DocumentTemplateModel template)
        {
            if (!string.IsNullOrEmpty(template.FilePath))
            {
                File.WriteAllBytes(template.FilePath, Convert.FromBase64String(template.Content));
            }
            else
            {
                var ex = new InvalidDirectoryException();

                throw ex;
            }
        }

        public List<string> OpenDgvDocumentTemplateSelectedFile(DataGridViewSelectedRowCollection selectedRows)
        {
            var errorList = new List<string>();

            foreach (DataGridViewRow row in selectedRows)
            {
                var current = (DocumentTemplateModel)row.DataBoundItem;
                if (File.Exists(current.FilePath))
                {
                    Process.Start(current.FilePath);
                }
                else
                {
                    errorList.Add(current.FilePath);
                }
            }

            return errorList;
        }

        public DocumentTemplateModel RenameFileFromDGV(DocumentTemplateModel template, string directoryPath)
        {
            if (File.Exists(Path.Combine(directoryPath, template.GetFileName())))
            {
                throw new FileNameDuplicateException("Filename already exists!");
            }

            File.Move(template.FilePath, Path.Combine(directoryPath, template.GetFileName()));
            template.FilePath = Path.Combine(directoryPath, template.GetFileName());

            return template;
        }
    }
}
