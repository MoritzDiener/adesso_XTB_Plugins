using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Threading.Tasks;

using XrmToolBox.Extensibility;
using Microsoft.Xrm.Sdk;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using XrmToolBox.Extensibility.Args;
using System.Drawing;
using adesso_XTB_Plugins.DocumentTemplateExport.Exceptions;

namespace adesso_XTB_Plugins.DocumentTemplateExport
{

    public partial class DocumentTemplateExport : PluginControlBase
    {
        Settings MySettings;
        private SettingsService _settingsService;
        private FileOperationService _fileOperationService;
        private DocumentTemplateService _documentTemplateService;
        private BindingSourceService _bindingSourceService;

        public DocumentTemplateExport()
        {
            InitializeComponent();

            _settingsService = new SettingsService();

            MySettings = _settingsService.LoadOrInitializeSettings();

            
            //var xmls = new XElement("root",
            //    new XElement("value",
            //    new XAttribute("Attr", 1),
            //    "test")).ToString();

            //File.WriteAllText(@"c:\foo.xml", xmls.ToString());

            //var xml2 = new XElement("root", new[] { 1, 2, 3, 4, 5 }.Select(x => new XElement("value", x))).ToString();

        }

        private void DocumentTemplateExport_Load(object sender, EventArgs e)
        {
            _fileOperationService = new FileOperationService(MySettings);

            _documentTemplateService = new DocumentTemplateService(Service, _settingsService);

            _bindingSourceService = new BindingSourceService(Service, MySettings);

            //TxtDirectoryPath.Text = MySettings.LastDirectoryPath;

            SetToolTips();

            if (!string.IsNullOrEmpty(TxtDirectoryPath.Text) && Directory.Exists(TxtDirectoryPath.Text))
            {
                BsCrmTemplates = _bindingSourceService.LoadCrmTemplatesToBindingSource(BsCrmTemplates);
            }

            SetButtonLayoutTabCrmDocumentTemplates();

            foreach (DataGridViewColumn col in DgvDocumentTemplates.Columns)
            {
                switch (col.Name)
                {
                    case "EntityTypeDatagridViewComboBox":
                    case "DescriptionDataGridViewTextBoxColumn":
                        col.ReadOnly = false;
                        break;
                    default:
                        col.ReadOnly = true;
                        break;
                }
            }

            //EntityTypeDatagridViewComboBox.ReadOnly = false;
            //EntityTypeDatagridViewComboBox.Items.Add("documenttemplate");
            //EntityTypeDatagridViewComboBox.Items.Add("personaldocumenttemplate");
        }


        private void TxtDirectoryPath_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtDirectoryPath.Text) && Directory.Exists(TxtDirectoryPath.Text))
            {
                if (!string.Equals(MySettings.LastDirectoryPath, TxtDirectoryPath.Text))
                {
                    MySettings.LastDirectoryPath = TxtDirectoryPath.Text;
                    _settingsService.Save(MySettings);
                }
            }
        }

        private void TxtDirectoryPath_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TxtDirectoryPath.Text) || !Directory.Exists(TxtDirectoryPath.Text))
            {
                ShowErrorNote(MySettings.DirectoryErrorText);
            }
        }


        private void BtnDirectoryFolderDialog_Click(object sender, EventArgs e)
        {
            FbdDirectory.RootFolder = Environment.SpecialFolder.MyComputer;
            FbdDirectory.SelectedPath = TxtDirectoryPath.Text;
            DialogResult result = FbdDirectory.ShowDialog();
            if (result == DialogResult.OK)
            {
                TxtDirectoryPath.Text = FbdDirectory.SelectedPath + "\\";
            }
        }


        private void TabCtrlDocumentTemplate_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage.Name == TabCrmDocumentTemplates.Name)
            {
                SetButtonLayoutTabCrmDocumentTemplates();
            }

            if (e.TabPage.Name == TabCrmDocumentTemplates.Name)
            {
                if (string.IsNullOrEmpty(TxtDirectoryPath.Text))
                {
                    ShowErrorNote(MySettings.DirectoryErrorText);
                    TabCtrlDocumentTemplate.SelectTab(TabCrmDocumentTemplates);
                }
                else
                {
                    SetButtonLayoutTabDocumentTemplate();
                }
            }
        }

        private void DgvCrmDocumentTemplates_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSvDisk_Click(sender, e);
        }

        private void DgvDocumentTemplate_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _fileOperationService.OpenDgvDocumentTemplateSelectedFile(DgvDocumentTemplates.SelectedRows);
        }

        private void DgvDocumentTemplate_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                var allowDrop = true;

                for (int i = 0; i < files.Length; i++)
                {
                    var fileInfo = new FileInfo(files[i]);

                    if (fileInfo.Extension != ".xlsx" && fileInfo.Extension != ".docx")
                    {
                        allowDrop = false;
                        break;
                    }
                }

                if (allowDrop)
                {
                    e.Effect = DragDropEffects.Move;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                    ShowErrorNote(@"Only documents of the type '.xlsx' and '.docx' are allowed!");
                }
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void DgvDocumentTemplate_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                for (int i = 0; i < files.Length; i++)
                {
                    try
                    {
                        BsDocumentTemplateObject = _bindingSourceService.AddNewTemplateToBindingSourceFromFile(DgvDocumentTemplates, BsDocumentTemplateObject, files[i]);
                    }
                    catch (DuplicateException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                DgvDocumentTemplates.ClearSelection();
            }
        }

        private void DgvDocumentTemplate_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            var row = DgvDocumentTemplates.Rows[e.RowIndex];

            if (!string.IsNullOrEmpty(row.Cells["EntityTypeDatagridViewComboBox"].Value.ToString()))
            {
                row.Cells["EntityTypeDatagridViewComboBox"].ReadOnly = true;
            }
            else
            {
                row.Cells["EntityTypeDatagridViewComboBox"].ReadOnly = false;
                row.Cells["NameDataGridViewTextBoxColumn"].ReadOnly = false;
                ColorAllCellsFromRow(row, Color.Yellow);
                ShowInfoNote("Please select 'Entity Type' for the highlighted datasets!");
            }

            if (string.IsNullOrEmpty(row.Cells["NameDataGridViewTextBoxColumn"].Value.ToString()))
            {
                ColorAllCellsFromRow(row, Color.Yellow);
                row.Cells["NameDataGridViewTextBoxColumn"].ReadOnly = false;
                ShowInfoNote("Please fill in the name field for each highlighted dataset!");
            }
        }

        private void DgvDocumentTemplate_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = DgvDocumentTemplates.Rows[e.RowIndex];

                if (!string.IsNullOrEmpty(row.Cells["EntityTypeDatagridViewComboBox"].Value.ToString()))
                {
                    switch (row.Cells["EntityTypeDatagridViewComboBox"].Value.ToString())
                    {
                        case "documenttemplate":
                            ((DocumentTemplateModel)row.DataBoundItem).Prefix = MySettings.PrefixDocumentTemplate;
                            break;
                        case "personaldocumenttemplate":
                            ((DocumentTemplateModel)row.DataBoundItem).Prefix = MySettings.PrefixPersonalDocumentTemplate;
                            break;
                    }

                    ColorAllCellsFromRow(row, Color.White);
                }

                if (!string.IsNullOrEmpty(row.Cells["EntityTypeDatagridViewComboBox"].Value.ToString())
                    && !string.IsNullOrEmpty(row.Cells["NameDataGridViewTextBoxColumn"].Value.ToString()))
                {
                    try
                    {
                        var current = (DocumentTemplateModel)row.DataBoundItem;
                        current = _fileOperationService.RenameFileFromDGV(current, TxtDirectoryPath.Text);
                    }
                    catch(FileNameDuplicateException ex)
                    {
                        ShowErrorNote(ex.Message);
                    }

                }
                    // TODO
                    //if (!string.IsNullOrEmpty(row.Cells["NameDataGridViewTextBoxColumn"].Value.ToString()))
                    //{
                    //    var current = (DocumentTemplateObject)row.DataBoundItem;
                    //    current.FilePath = Path.Combine(TxtDirectoryPath.Text, current.GetFileName());
                    //    SaveFilesToDisk(current);
                    //    ColorAllCellsFromRow(row, Color.White);
                    //}
                }
        }

        private void DgvCrmDocumentTemplates_MouseDown(object sender, MouseEventArgs e)
        {
            var ht = DgvCrmDocumentTemplates.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                DgvCrmDocumentTemplates.ClearSelection();
            }

        }

        private void DgvDocumentTemplate_MouseDown(object sender, MouseEventArgs e)
        {
            var ht = DgvDocumentTemplates.HitTest(e.X, e.Y);

            if (ht.Type == DataGridViewHitTestType.None)
            {
                DgvDocumentTemplates.ClearSelection();
            }
        }


        private void SetToolTips()
        {
            TtBtnDirectoryFolderDialog.SetToolTip(BtnDirectoryFolderDialog, "Select the target directory");
            TtBtnDirectoryFolderDialog.ShowAlways = true;

            TsbtnLoadTemplates.ToolTipText = "Retrieve all Document Templates from the specified CRM organization";

            //TsbtnSaveTemplates.ToolTipText = "Saves all selected Document Templates to the specified file path";

            //TsbtnUpdateTemplates.ToolTipText = "Update all selected Document Templates from the specified CRM organization";

            TtBtnOpenDirectory.ShowAlways = true;

            var ttTabCtrlDocumentTemplateText = @"DoubleClick a row in order to open the Document Template with the system default application";
            TtTabCtrlDocumentTemplate.SetToolTip(TabCtrlDocumentTemplate, ttTabCtrlDocumentTemplateText);
            //TtTabCtrlDocumentTemplate.SetToolTip(TabDocumentTemplate, ttTabCtrlDocumentTemplateText);
            TtTabCtrlDocumentTemplate.SetToolTip(TabCrmDocumentTemplates, ttTabCtrlDocumentTemplateText);
            TtTabCtrlDocumentTemplate.ShowAlways = true;
        }

        private void SetButtonLayoutTabCrmDocumentTemplates()
        {
            TsbtnLoadTemplates.Enabled = true;
            //TsbtnSaveTemplates.Enabled = true;

            //TsbtnUpdateTemplates.Enabled = false;
            //TsbtnRemoveDgvSelectedItems.Enabled = true;
            //TsbtnAddTemplates.Enabled = false;
            //TsbtnEditTemplate.Enabled = true;
            //TsbtnCopyTemplate.Enabled = false;
            TxtDirectoryPath.Enabled = false;
            BtnDirectoryFolderDialog.Enabled = false;
            TxtDirectoryPath.Enabled = true;
            BtnDirectoryFolderDialog.Enabled = true;
        }

        private void SetButtonLayoutTabDocumentTemplate()
        {
            TsbtnLoadTemplates.Enabled = false;
            //TsbtnSaveTemplates.Enabled = false;

            //TsbtnUpdateTemplates.Enabled = true;
            //TsbtnRemoveDgvSelectedItems.Enabled = true;
            //TsbtnAddTemplates.Enabled = true;
            //TsbtnEditTemplate.Enabled = true;
            //TsbtnCopyTemplate.Enabled = true;
            TxtDirectoryPath.Enabled = false;
            BtnDirectoryFolderDialog.Enabled = false;
        }


        public void ColorAllCellsFromRow(DataGridViewRow row, Color myColor)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                cell.Style.BackColor = myColor;
            }
        }


        private void ShowInfoNote(string message)
        {
            ShowInfoNotification(message, new Uri(MySettings.NotificationUriAddress));
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                Thread.Sleep(3500);
                HideNotification();
            });
        }

        private void ShowErrorNote(string message)
        {
            ShowErrorNotification(message, new Uri(MySettings.NotificationUriAddress));
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                Thread.Sleep(5000);
                HideNotification();
            });
        }


        private void ResetProgressBar(int sleepTime)
        {
            System.Threading.Tasks.Task.Factory.StartNew(() =>
            {
                Thread.Sleep(sleepTime);
                TsprgbLoadUpdate.Value = 0;
            });
        }


        private void TsbtnClose_Click(object sender, EventArgs e)
        {
            CloseTool();
        }

        private void TsbtnLoadTemplates_Click(object sender, EventArgs e)
        {
            if (TxtDirectoryPath.TextLength == 0)
            {
                FbdDirectory.RootFolder = Environment.SpecialFolder.MyComputer;
                FbdDirectory.SelectedPath = TxtDirectoryPath.Text;
                DialogResult result = FbdDirectory.ShowDialog();
                if (result == DialogResult.OK)
                {
                    TxtDirectoryPath.Text = FbdDirectory.SelectedPath + "\\";
                }
            }

            if (TxtDirectoryPath.TextLength > 0)
            {
                TsprgbLoadUpdate.Value = TsprgbLoadUpdate.Maximum;
                TsprgbLoadUpdate.Value = 25;
                TsprgbLoadUpdate.Value = TsprgbLoadUpdate.Maximum / 2;

                if (!string.IsNullOrEmpty(TxtDirectoryPath.Text) && Directory.Exists(TxtDirectoryPath.Text))
                {
                    BsCrmTemplates = _bindingSourceService.LoadCrmTemplatesToBindingSource(BsCrmTemplates);
                    TsprgbLoadUpdate.Value = TsprgbLoadUpdate.Maximum;
                    ResetProgressBar(3500);
                    ShowInfoNote("Loading completed!");
                }
                else
                {
                    ShowErrorNote(MySettings.DirectoryErrorText);
                    TxtDirectoryPath.Focus();
                    TsprgbLoadUpdate.Value = 0;
                    //ResetProgressBar(3500);
                }

            }
        }

        //private void TsbtnSaveTemplates_Click(object sender, EventArgs e)
        //{
        //    if (!string.IsNullOrEmpty(TxtDirectoryPath.Text) && Directory.Exists(TxtDirectoryPath.Text))
        //    {
        //        if (DgvCrmDocumentTemplates.SelectedRows.Count > 0)
        //        {
        //            var stepSize = Convert.ToInt32((100 / DgvCrmDocumentTemplates.SelectedRows.Count));
        //            TsprgbLoadUpdate.Value = 0;

        //            BsDocumentTemplateObject.Clear();
        //            var selectedRows = DgvCrmDocumentTemplates.SelectedRows;
        //            var list = new List<DocumentTemplateModel>();

        //            for (int i = selectedRows.Count - 1; i >= 0; i--)
        //            {
        //                var template = (DocumentTemplateModel)DgvCrmDocumentTemplates.SelectedRows[i].DataBoundItem;
        //                list.Add(template);
        //                BsDocumentTemplateObject.Add(template);
        //                TsprgbLoadUpdate.Value += stepSize;
        //            }

        //            foreach (var t in list)
        //            {
        //                try
        //                {
        //                    _fileOperationService.SaveFileToDisk(t);
        //                }
        //                catch (InvalidDirectoryException)
        //                {
        //                    ShowErrorNote(MySettings.DirectoryErrorText);
        //                }
        //            }
        //            TsprgbLoadUpdate.Value = TsprgbLoadUpdate.Maximum;
        //            ResetProgressBar(3500);

        //            TabCtrlDocumentTemplate.SelectTab(TabDocumentTemplate);
        //            ShowInfoNote("Save complete!");

        //            foreach (DataGridViewRow row in DgvDocumentTemplate.Rows)
        //            {
        //                if (row.Cells["EntityTypeDatagridViewComboBox"].Value != null)
        //                {
        //                    row.Cells["EntityTypeDatagridViewComboBox"].ReadOnly = true;
        //                }
        //                else
        //                {
        //                    row.Cells["EntityTypeDatagridViewComboBox"].ReadOnly = false;
        //                }
        //            }
        //        }
        //        else // SelectedRowCount = 0
        //        {
        //            ShowInfoNote("No templates selected!");
        //        }
        //    }
        //    else // txtDirectoryPath.Text == null or empty && directory exists
        //    {
        //        ShowErrorNote(MySettings.DirectoryErrorText);
        //        TxtDirectoryPath.Focus();
        //    }
        //}

        private void TsbtnUpdateTemplates_Click(object sender, EventArgs e)
        {
            if (DgvDocumentTemplates.SelectedRows.Count > 0)
            {
                if (!string.IsNullOrEmpty(TxtDirectoryPath.Text) && Directory.Exists(TxtDirectoryPath.Text))
                {
                    if (!CheckMethods.DoesGridviewContainString(DgvDocumentTemplates, "EntityTypeDatagridViewComboBox"))
                    {
                        var dialog = new ConfirmImportDialog();
                        DialogResult result = dialog.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            var stepSize = Convert.ToInt32((100 / DgvDocumentTemplates.SelectedRows.Count));
                            TsprgbLoadUpdate.Value = 0;

                            var selectedRows = DgvDocumentTemplates.SelectedRows;
                            var errors = new List<string>();

                            for (int i = 0; i < selectedRows.Count; i++)
                            {
                                var template = (DocumentTemplateModel)DgvDocumentTemplates.SelectedRows[i].DataBoundItem;

                                if (File.Exists(template.FilePath))
                                {
                                    if (template.CreatedNew)
                                    {
                                        _documentTemplateService.CreateFile(template);
                                    }
                                    else // Template already exists
                                    {
                                        _documentTemplateService.UpdateFile(template);
                                    }

                                    TsprgbLoadUpdate.Value += stepSize;
                                }
                                else // FilePath does not exist
                                {
                                    errors.Add(template.FilePath);
                                }
                            }

                            TsprgbLoadUpdate.Value = TsprgbLoadUpdate.Maximum;
                            ResetProgressBar(3500);
                            ShowInfoNote("Update complete!");
                            

                            //tabCtrlDocumentTemplate.SelectTab(tabCrmDocumentTemplates);

                            BsCrmTemplates = _bindingSourceService.LoadCrmTemplatesToBindingSource(BsCrmTemplates);

                            if (errors.Count > 0)
                            {
                                var message = "The Following files could not be found:\n\n";
                                foreach (var s in errors)
                                {
                                    message += s + "\n\n";
                                }
                                MessageBox.Show(message);
                            }
                        }
                    }
                    else //EntityType is empty
                    {
                        ShowErrorNote("The field 'Entity Type' must not be empty!");
                    }
                }
            }
            else // No rows selected
            {
                ShowInfoNote("No templates selected!");
            }
        }

        private void TsbtnRemoveDgvSelectedItems_Click(object sender, EventArgs e)
        {
            if (DgvDocumentTemplates.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in DgvDocumentTemplates.SelectedRows)
                {
                    BsDocumentTemplateObject.Remove(row.DataBoundItem);
                }
            }
            else // No rows selected
            {
                ShowInfoNote("No templates selected!");
            }
        }

        private void TsbtnAddTemplates_Click(object sender, EventArgs e)
        {
            OfdAddTemplates.InitialDirectory = TxtDirectoryPath.Text;
            OfdAddTemplates.Filter = "Office Files (*.xlsx; *.docx)|*.xlsx; *.docx";

            DialogResult result = OfdAddTemplates.ShowDialog();
            if (result == DialogResult.OK)
            {
                var files = OfdAddTemplates.FileNames;

                for (int i = 0; i < files.Length; i++)
                {
                    try
                    {
                        BsDocumentTemplateObject = _bindingSourceService.AddNewTemplateToBindingSourceFromFile(DgvDocumentTemplates, BsDocumentTemplateObject, files[i]);
                    }
                    catch (DuplicateException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }

            DgvDocumentTemplates.ClearSelection();
        }

        private void TsbtnEditTemplate_Click(object sender, EventArgs e)
        {
            if (DgvDocumentTemplates.SelectedRows.Count > 0)
            {
                var errors = _fileOperationService.OpenDgvDocumentTemplateSelectedFile(DgvDocumentTemplates.SelectedRows);

                if (errors.Count > 0)
                {
                    var message = "The Following files could not be found:\n\n";
                    foreach (var s in errors)
                    {
                        message += s + "\n\n";
                    }
                    MessageBox.Show(message);
                }
            }
            else
            {
                ShowInfoNote("No template selected!");
            }
        }

        private void TsbtnOpenFilePathFolder_Click(object sender, EventArgs e)
        {
            try
            {
                _fileOperationService.OpenFilePathFolder(TxtDirectoryPath.Text);
            }
            catch (InvalidDirectoryException)
            {
                ShowErrorNote(MySettings.DirectoryErrorText);
            }
        }

        private void TsbtnCopyTemplate_Click(object sender, EventArgs e)
        {
            if (DgvDocumentTemplates.SelectedRows.Count == 1)
            {
                foreach (DataGridViewRow row in DgvDocumentTemplates.SelectedRows)
                {
                    _bindingSourceService.CopySelectedTemplate(row, BsDocumentTemplateObject, TxtDirectoryPath.Text);
                }
            }
            else
            {
                ShowInfoNote("1 template must be selected to perform this action!");
            }
        }

        private void btnSvDisk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtDirectoryPath.Text) && Directory.Exists(TxtDirectoryPath.Text))
            {
                if (DgvCrmDocumentTemplates.SelectedRows.Count > 0)
                {
                    var stepSize = Convert.ToInt32((100 / DgvCrmDocumentTemplates.SelectedRows.Count));
                    TsprgbLoadUpdate.Value = 0;

                    //BsDocumentTemplateObject.Clear();
                    var selectedRows = DgvCrmDocumentTemplates.SelectedRows;
                    var list = new List<DocumentTemplateModel>();

                    //create List of DgvDocumentTemplate names
                    List<List<String>> DgvDocumentTemplateNamesList = new List<List<String>>();
                    foreach (DataGridViewRow row in DgvDocumentTemplates.Rows)
                    {
                        DgvDocumentTemplateNamesList.Add(new List<string>() { row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString()});                        
                    }

                    for (int i = selectedRows.Count - 1; i >= 0; i--)
                    {
                        var template = (DocumentTemplateModel)DgvCrmDocumentTemplates.SelectedRows[i].DataBoundItem;

                        if (DgvDocumentTemplateNamesList.Count > 0)
                        {
                            Boolean check = true;
                            foreach (List<String> listValue in DgvDocumentTemplateNamesList)
                            {
                                if (listValue.SequenceEqual(new List<String>() { DgvCrmDocumentTemplates.SelectedRows[i].Cells[0].Value.ToString(), DgvCrmDocumentTemplates.SelectedRows[i].Cells[1].Value.ToString() }))
                                {
                                    check = false;
                                }                                
                            }
                            if (check)
                            {
                                list.Add(template);
                                BsDocumentTemplateObject.Add(template);
                                TsprgbLoadUpdate.Value += stepSize;
                            }
                        }
                        else
                        {
                            list.Add(template);
                            BsDocumentTemplateObject.Add(template);
                            TsprgbLoadUpdate.Value += stepSize;
                        }
                    }

                    foreach (var t in list)
                    {
                        try
                        {
                            _fileOperationService.SaveFileToDisk(t);
                        }
                        catch (InvalidDirectoryException)
                        {
                            ShowErrorNote(MySettings.DirectoryErrorText);
                        }
                    }
                    TsprgbLoadUpdate.Value = TsprgbLoadUpdate.Maximum;
                    ResetProgressBar(3500);

                    //TabCtrlDocumentTemplate.SelectTab(TabDocumentTemplate);
                    TabCtrlDocumentTemplate.SelectTab(TabCrmDocumentTemplates);
                    ShowInfoNote("Save complete!");

                    //foreach (DataGridViewRow row in DgvDocumentTemplates.Rows)
                    //{
                    //    if (row.Cells["NameDataGridViewTextBoxColumn3"].Value != null)
                    //    {
                    //        row.Cells["NameDataGridViewTextBoxColumn3"].ReadOnly = true;
                    //    }
                    //    else
                    //    {
                    //        row.Cells["NameDataGridViewTextBoxColumn3"].ReadOnly = false;
                    //    }
                    //}
                }
                else // SelectedRowCount = 0
                {
                    ShowInfoNote("No templates selected!");
                }
            }
            else // txtDirectoryPath.Text == null or empty && directory exists
            {
                ShowErrorNote(MySettings.DirectoryErrorText);
                TxtDirectoryPath.Focus();
            }
        }

        private void btnDlDisk_Click(object sender, EventArgs e)
        {

            if (DgvDocumentTemplates.SelectedRows.Count > 0)
            {
                if (!string.IsNullOrEmpty(TxtDirectoryPath.Text) && Directory.Exists(TxtDirectoryPath.Text))
                {
                    if (!CheckMethods.DoesGridviewContainString(DgvDocumentTemplates, "NameDataGridViewTextBoxColumn3"))
                    {
                        var dialog = new ConfirmImportDialog();
                        DialogResult result = dialog.ShowDialog();

                        if (result == DialogResult.OK)
                        {
                            var stepSize = Convert.ToInt32((100 / DgvDocumentTemplates.SelectedRows.Count));
                            TsprgbLoadUpdate.Value = 0;

                            var selectedRows = DgvDocumentTemplates.SelectedRows;
                            var errors = new List<string>();

                            for (int i = 0; i < selectedRows.Count; i++)
                            {
                                var template = (DocumentTemplateModel)DgvDocumentTemplates.SelectedRows[i].DataBoundItem;

                                if (File.Exists(template.FilePath))
                                {
                                    if (template.CreatedNew)
                                    {
                                        _documentTemplateService.CreateFile(template);
                                    }
                                    else // Template already exists
                                    {
                                        _documentTemplateService.UpdateFile(template);
                                    }

                                    TsprgbLoadUpdate.Value += stepSize;
                                }
                                else // FilePath does not exist
                                {
                                    errors.Add(template.FilePath);
                                }
                            }

                            TsprgbLoadUpdate.Value = TsprgbLoadUpdate.Maximum;
                            ResetProgressBar(3500);
                            ShowInfoNote("Update complete!");
                            
                            

                            //tabCtrlDocumentTemplate.SelectTab(tabCrmDocumentTemplates);

                            BsCrmTemplates = _bindingSourceService.LoadCrmTemplatesToBindingSource(BsCrmTemplates);

                            if (errors.Count > 0)
                            {
                                var message = "The Following files could not be found:\n\n";
                                foreach (var s in errors)
                                {
                                    message += s + "\n\n";
                                }
                                MessageBox.Show(message);
                            }
                        }
                    }
                    else //EntityType is empty
                    {
                        ShowErrorNote("The field 'Entity Type' must not be empty!");
                    }
                }
            }
            else // No rows selected
            {
                ShowInfoNote("No templates selected!");
            }

            #region delete
            if (DgvDocumentTemplates.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in DgvDocumentTemplates.SelectedRows)
                {
                    BsDocumentTemplateObject.Remove(row.DataBoundItem);
                }
            }
            else // No rows selected
            {
                ShowInfoNote("No templates selected!");
            }
            #endregion


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