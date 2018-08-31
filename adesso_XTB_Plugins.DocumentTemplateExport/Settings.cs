using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adesso_XTB_Plugins.DocumentTemplateExport
{
    public class Settings
    {
        public string PrefixDocumentTemplate { get; set; }
        public string PrefixPersonalDocumentTemplate { get; set; }
        public string NotificationUriAddress { get; set; }
        public string DirectoryErrorText { get; set; }
        public string LastDirectoryPath{ get; set; }
        public string NotificationDirectoryEmpty { get; set; }
        public string NotifcationDirectoryExists { get; set; }
    }
}
