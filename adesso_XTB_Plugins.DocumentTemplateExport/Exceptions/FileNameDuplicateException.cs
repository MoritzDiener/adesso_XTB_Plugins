using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adesso_XTB_Plugins.DocumentTemplateExport.Exceptions
{
    public class FileNameDuplicateException : Exception
    {
        public FileNameDuplicateException(string message) : base(message)
        {
        }
    }
}
