﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.Composition;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;
using System.Diagnostics;

namespace adesso_XTB_Plugins.DocumentTemplateExport
{
    [Export(typeof(IXrmToolBoxPlugin)),
    ExportMetadata("BackgroundColor", "White"),
    ExportMetadata("PrimaryFontColor", "Black"),
    ExportMetadata("SecondaryFontColor", "LightGray"),
    ExportMetadata("SmallImageBase64", "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"),
    ExportMetadata("BigImageBase64", "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"),
    ExportMetadata("Name", "Document Template Export"),
    ExportMetadata("Description", "This tool can export and import document templates")]


    public class Plugin : PluginBase
    {
        public override IXrmToolBoxPluginControl GetControl()
        {
            return new DocumentTemplateExport();
        }
    }
}