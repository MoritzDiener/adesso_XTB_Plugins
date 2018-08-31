namespace adesso_XTB_Plugins.DocumentTemplateExport
{
    partial class DocumentTemplateExport
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LblFilePath = new System.Windows.Forms.Label();
            this.FbdDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.TxtDirectoryPath = new System.Windows.Forms.TextBox();
            this.TabCtrlDocumentTemplate = new System.Windows.Forms.TabControl();
            this.TabCrmDocumentTemplates = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.DgvCrmDocumentTemplates = new System.Windows.Forms.DataGridView();
            this.DgvDocumentTemplates = new System.Windows.Forms.DataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.btnDlDisk = new System.Windows.Forms.Button();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.btnSvDisk = new System.Windows.Forms.Button();
            this.TtBtnDirectoryFolderDialog = new System.Windows.Forms.ToolTip(this.components);
            this.TtBtnOpenDirectory = new System.Windows.Forms.ToolTip(this.components);
            this.TtBtnExport = new System.Windows.Forms.ToolTip(this.components);
            this.TtBtnImport = new System.Windows.Forms.ToolTip(this.components);
            this.TtTabCtrlDocumentTemplate = new System.Windows.Forms.ToolTip(this.components);
            this.TsDocumentTemplateExport = new System.Windows.Forms.ToolStrip();
            this.TsbtnClose = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TsbtnLoadTemplates = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TsprgbLoadUpdate = new System.Windows.Forms.ToolStripProgressBar();
            this.OfdAddTemplates = new System.Windows.Forms.OpenFileDialog();
            this.BtnDirectoryFolderDialog = new System.Windows.Forms.Button();
            this.DsEntityTypeComboBoxBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DocumentTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifiedOnDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifiedByDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BsCrmTemplates = new System.Windows.Forms.BindingSource(this.components);
            this.DocumentTypeDataGridViewTextboxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifiedOnDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ModifiedByDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BsDocumentTemplateObject = new System.Windows.Forms.BindingSource(this.components);
            this.TabCtrlDocumentTemplate.SuspendLayout();
            this.TabCrmDocumentTemplates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCrmDocumentTemplates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDocumentTemplates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.TsDocumentTemplateExport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DsEntityTypeComboBoxBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BsCrmTemplates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsDocumentTemplateObject)).BeginInit();
            this.SuspendLayout();
            // 
            // LblFilePath
            // 
            this.LblFilePath.AutoSize = true;
            this.LblFilePath.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblFilePath.Location = new System.Drawing.Point(13, 36);
            this.LblFilePath.Name = "LblFilePath";
            this.LblFilePath.Size = new System.Drawing.Size(48, 13);
            this.LblFilePath.TabIndex = 0;
            this.LblFilePath.Text = "File Path";
            // 
            // TxtDirectoryPath
            // 
            this.TxtDirectoryPath.Location = new System.Drawing.Point(68, 33);
            this.TxtDirectoryPath.Name = "TxtDirectoryPath";
            this.TxtDirectoryPath.ReadOnly = true;
            this.TxtDirectoryPath.Size = new System.Drawing.Size(246, 20);
            this.TxtDirectoryPath.TabIndex = 7;
            this.TxtDirectoryPath.TextChanged += new System.EventHandler(this.TxtDirectoryPath_TextChanged);
            this.TxtDirectoryPath.Leave += new System.EventHandler(this.TxtDirectoryPath_Leave);
            // 
            // TabCtrlDocumentTemplate
            // 
            this.TabCtrlDocumentTemplate.AllowDrop = true;
            this.TabCtrlDocumentTemplate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabCtrlDocumentTemplate.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.TabCtrlDocumentTemplate.Controls.Add(this.TabCrmDocumentTemplates);
            this.TabCtrlDocumentTemplate.ItemSize = new System.Drawing.Size(0, 1);
            this.TabCtrlDocumentTemplate.Location = new System.Drawing.Point(16, 76);
            this.TabCtrlDocumentTemplate.Name = "TabCtrlDocumentTemplate";
            this.TabCtrlDocumentTemplate.SelectedIndex = 0;
            this.TabCtrlDocumentTemplate.Size = new System.Drawing.Size(750, 579);
            this.TabCtrlDocumentTemplate.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.TabCtrlDocumentTemplate.TabIndex = 8;
            this.TabCtrlDocumentTemplate.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabCtrlDocumentTemplate_Selecting);
            // 
            // TabCrmDocumentTemplates
            // 
            this.TabCrmDocumentTemplates.Controls.Add(this.splitContainer1);
            this.TabCrmDocumentTemplates.Location = new System.Drawing.Point(4, 5);
            this.TabCrmDocumentTemplates.Name = "TabCrmDocumentTemplates";
            this.TabCrmDocumentTemplates.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.TabCrmDocumentTemplates.Size = new System.Drawing.Size(742, 570);
            this.TabCrmDocumentTemplates.TabIndex = 2;
            this.TabCrmDocumentTemplates.Text = "CRM Data";
            this.TabCrmDocumentTemplates.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.DgvCrmDocumentTemplates);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.DgvDocumentTemplates);
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(738, 566);
            this.splitContainer1.SplitterDistance = 246;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 4;
            // 
            // DgvCrmDocumentTemplates
            // 
            this.DgvCrmDocumentTemplates.AllowUserToAddRows = false;
            this.DgvCrmDocumentTemplates.AllowUserToDeleteRows = false;
            this.DgvCrmDocumentTemplates.AllowUserToResizeRows = false;
            this.DgvCrmDocumentTemplates.AutoGenerateColumns = false;
            this.DgvCrmDocumentTemplates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvCrmDocumentTemplates.ColumnHeadersHeight = 21;
            this.DgvCrmDocumentTemplates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvCrmDocumentTemplates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DocumentTypeDataGridViewTextBoxColumn,
            this.NameDataGridViewTextBoxColumn2,
            this.ModifiedOnDataGridViewTextBoxColumn2,
            this.ModifiedByDataGridViewTextBoxColumn2});
            this.DgvCrmDocumentTemplates.DataSource = this.BsCrmTemplates;
            this.DgvCrmDocumentTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvCrmDocumentTemplates.Location = new System.Drawing.Point(0, 0);
            this.DgvCrmDocumentTemplates.Name = "DgvCrmDocumentTemplates";
            this.DgvCrmDocumentTemplates.ReadOnly = true;
            this.DgvCrmDocumentTemplates.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.DgvCrmDocumentTemplates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvCrmDocumentTemplates.Size = new System.Drawing.Size(246, 566);
            this.DgvCrmDocumentTemplates.TabIndex = 0;
            this.DgvCrmDocumentTemplates.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvCrmDocumentTemplates_CellDoubleClick);
            this.DgvCrmDocumentTemplates.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DgvCrmDocumentTemplates_MouseDown);
            // 
            // DgvDocumentTemplates
            // 
            this.DgvDocumentTemplates.AllowDrop = true;
            this.DgvDocumentTemplates.AllowUserToAddRows = false;
            this.DgvDocumentTemplates.AllowUserToDeleteRows = false;
            this.DgvDocumentTemplates.AllowUserToResizeRows = false;
            this.DgvDocumentTemplates.AutoGenerateColumns = false;
            this.DgvDocumentTemplates.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvDocumentTemplates.ColumnHeadersHeight = 21;
            this.DgvDocumentTemplates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.DgvDocumentTemplates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DocumentTypeDataGridViewTextboxColumn3,
            this.NameDataGridViewTextBoxColumn3,
            this.ModifiedOnDataGridViewTextBoxColumn3,
            this.ModifiedByDataGridViewTextBoxColumn3});
            this.DgvDocumentTemplates.DataSource = this.BsDocumentTemplateObject;
            this.DgvDocumentTemplates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvDocumentTemplates.Location = new System.Drawing.Point(55, 0);
            this.DgvDocumentTemplates.Name = "DgvDocumentTemplates";
            this.DgvDocumentTemplates.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.DgvDocumentTemplates.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvDocumentTemplates.Size = new System.Drawing.Size(434, 566);
            this.DgvDocumentTemplates.TabIndex = 1;
            this.DgvDocumentTemplates.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvDocumentTemplate_CellDoubleClick);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer2.Size = new System.Drawing.Size(55, 566);
            this.splitContainer2.SplitterDistance = 207;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 4;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btnDlDisk);
            this.splitContainer3.Size = new System.Drawing.Size(55, 207);
            this.splitContainer3.SplitterDistance = 25;
            this.splitContainer3.SplitterWidth = 3;
            this.splitContainer3.TabIndex = 4;
            // 
            // btnDlDisk
            // 
            this.btnDlDisk.AutoSize = true;
            this.btnDlDisk.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDlDisk.Image = global::adesso_XTB_Plugins.DocumentTemplateExport.Properties.Resources.arrowleft;
            this.btnDlDisk.Location = new System.Drawing.Point(0, 118);
            this.btnDlDisk.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDlDisk.Name = "btnDlDisk";
            this.btnDlDisk.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.btnDlDisk.Size = new System.Drawing.Size(55, 61);
            this.btnDlDisk.TabIndex = 3;
            this.btnDlDisk.UseVisualStyleBackColor = true;
            this.btnDlDisk.Click += new System.EventHandler(this.btnDlDisk_Click);
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.btnSvDisk);
            this.splitContainer4.Size = new System.Drawing.Size(55, 356);
            this.splitContainer4.SplitterDistance = 200;
            this.splitContainer4.SplitterWidth = 3;
            this.splitContainer4.TabIndex = 4;
            // 
            // btnSvDisk
            // 
            this.btnSvDisk.AutoSize = true;
            this.btnSvDisk.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSvDisk.Image = global::adesso_XTB_Plugins.DocumentTemplateExport.Properties.Resources.arrowright;
            this.btnSvDisk.Location = new System.Drawing.Point(0, 0);
            this.btnSvDisk.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSvDisk.Name = "btnSvDisk";
            this.btnSvDisk.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
            this.btnSvDisk.Size = new System.Drawing.Size(55, 61);
            this.btnSvDisk.TabIndex = 2;
            this.btnSvDisk.UseVisualStyleBackColor = true;
            this.btnSvDisk.Click += new System.EventHandler(this.btnSvDisk_Click);
            // 
            // TsDocumentTemplateExport
            // 
            this.TsDocumentTemplateExport.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.TsDocumentTemplateExport.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsbtnClose,
            this.ToolStripSeparator1,
            this.TsbtnLoadTemplates,
            this.ToolStripSeparator2,
            this.TsprgbLoadUpdate});
            this.TsDocumentTemplateExport.Location = new System.Drawing.Point(0, 0);
            this.TsDocumentTemplateExport.Name = "TsDocumentTemplateExport";
            this.TsDocumentTemplateExport.Size = new System.Drawing.Size(827, 27);
            this.TsDocumentTemplateExport.TabIndex = 14;
            this.TsDocumentTemplateExport.Text = "toolStrip1";
            // 
            // TsbtnClose
            // 
            this.TsbtnClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsbtnClose.Image = global::adesso_XTB_Plugins.DocumentTemplateExport.Properties.Resources.tsbClose_Image;
            this.TsbtnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbtnClose.Name = "TsbtnClose";
            this.TsbtnClose.Size = new System.Drawing.Size(24, 24);
            this.TsbtnClose.Text = "Close Application";
            this.TsbtnClose.Click += new System.EventHandler(this.TsbtnClose_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // TsbtnLoadTemplates
            // 
            this.TsbtnLoadTemplates.Image = global::adesso_XTB_Plugins.DocumentTemplateExport.Properties.Resources.CRMOnlineLive_16;
            this.TsbtnLoadTemplates.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TsbtnLoadTemplates.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsbtnLoadTemplates.Name = "TsbtnLoadTemplates";
            this.TsbtnLoadTemplates.Size = new System.Drawing.Size(109, 24);
            this.TsbtnLoadTemplates.Text = "&Load Template";
            this.TsbtnLoadTemplates.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.TsbtnLoadTemplates.ToolTipText = "Load Templates";
            this.TsbtnLoadTemplates.Click += new System.EventHandler(this.TsbtnLoadTemplates_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // TsprgbLoadUpdate
            // 
            this.TsprgbLoadUpdate.Name = "TsprgbLoadUpdate";
            this.TsprgbLoadUpdate.Size = new System.Drawing.Size(100, 24);
            // 
            // OfdAddTemplates
            // 
            this.OfdAddTemplates.Multiselect = true;
            // 
            // BtnDirectoryFolderDialog
            // 
            this.BtnDirectoryFolderDialog.BackgroundImage = global::adesso_XTB_Plugins.DocumentTemplateExport.Properties.Resources.Folder_16x;
            this.BtnDirectoryFolderDialog.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.BtnDirectoryFolderDialog.Location = new System.Drawing.Point(320, 32);
            this.BtnDirectoryFolderDialog.Name = "BtnDirectoryFolderDialog";
            this.BtnDirectoryFolderDialog.Size = new System.Drawing.Size(28, 24);
            this.BtnDirectoryFolderDialog.TabIndex = 3;
            this.BtnDirectoryFolderDialog.UseVisualStyleBackColor = true;
            this.BtnDirectoryFolderDialog.Click += new System.EventHandler(this.BtnDirectoryFolderDialog_Click);
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.label2);
            this.splitContainer5.Size = new System.Drawing.Size(827, 535);
            this.splitContainer5.SplitterDistance = 308;
            this.splitContainer5.SplitterWidth = 3;
            this.splitContainer5.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 63);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "CRM System";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 63);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Local ( for editing)";
            // 
            // DocumentTypeDataGridViewTextBoxColumn
            // 
            this.DocumentTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DocumentTypeDataGridViewTextBoxColumn.DataPropertyName = "DocumentType";
            this.DocumentTypeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.DocumentTypeDataGridViewTextBoxColumn.Name = "DocumentTypeDataGridViewTextBoxColumn";
            this.DocumentTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.DocumentTypeDataGridViewTextBoxColumn.Width = 56;
            // 
            // NameDataGridViewTextBoxColumn2
            // 
            this.NameDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NameDataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.NameDataGridViewTextBoxColumn2.HeaderText = "Name";
            this.NameDataGridViewTextBoxColumn2.Name = "NameDataGridViewTextBoxColumn2";
            this.NameDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // ModifiedOnDataGridViewTextBoxColumn2
            // 
            this.ModifiedOnDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ModifiedOnDataGridViewTextBoxColumn2.DataPropertyName = "ModifiedOn";
            this.ModifiedOnDataGridViewTextBoxColumn2.HeaderText = "Modified On";
            this.ModifiedOnDataGridViewTextBoxColumn2.Name = "ModifiedOnDataGridViewTextBoxColumn2";
            this.ModifiedOnDataGridViewTextBoxColumn2.ReadOnly = true;
            this.ModifiedOnDataGridViewTextBoxColumn2.Width = 89;
            // 
            // ModifiedByDataGridViewTextBoxColumn2
            // 
            this.ModifiedByDataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ModifiedByDataGridViewTextBoxColumn2.DataPropertyName = "ModifiedBy";
            this.ModifiedByDataGridViewTextBoxColumn2.HeaderText = "Modified By";
            this.ModifiedByDataGridViewTextBoxColumn2.Name = "ModifiedByDataGridViewTextBoxColumn2";
            this.ModifiedByDataGridViewTextBoxColumn2.ReadOnly = true;
            this.ModifiedByDataGridViewTextBoxColumn2.Width = 87;
            // 
            // BsCrmTemplates
            // 
            this.BsCrmTemplates.DataSource = typeof(adesso_XTB_Plugins.DocumentTemplateExport.DocumentTemplateModel);
            // 
            // DocumentTypeDataGridViewTextboxColumn3
            // 
            this.DocumentTypeDataGridViewTextboxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DocumentTypeDataGridViewTextboxColumn3.DataPropertyName = "DocumentType";
            this.DocumentTypeDataGridViewTextboxColumn3.HeaderText = "Type";
            this.DocumentTypeDataGridViewTextboxColumn3.Name = "DocumentTypeDataGridViewTextboxColumn3";
            this.DocumentTypeDataGridViewTextboxColumn3.Width = 56;
            // 
            // NameDataGridViewTextBoxColumn3
            // 
            this.NameDataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NameDataGridViewTextBoxColumn3.DataPropertyName = "Name";
            this.NameDataGridViewTextBoxColumn3.HeaderText = "Name";
            this.NameDataGridViewTextBoxColumn3.Name = "NameDataGridViewTextBoxColumn3";
            // 
            // ModifiedOnDataGridViewTextBoxColumn3
            // 
            this.ModifiedOnDataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ModifiedOnDataGridViewTextBoxColumn3.DataPropertyName = "ModifiedOn";
            this.ModifiedOnDataGridViewTextBoxColumn3.HeaderText = "Modified On";
            this.ModifiedOnDataGridViewTextBoxColumn3.Name = "ModifiedOnDataGridViewTextBoxColumn3";
            this.ModifiedOnDataGridViewTextBoxColumn3.Width = 89;
            // 
            // ModifiedByDataGridViewTextBoxColumn3
            // 
            this.ModifiedByDataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ModifiedByDataGridViewTextBoxColumn3.DataPropertyName = "ModifiedBy";
            this.ModifiedByDataGridViewTextBoxColumn3.HeaderText = "Modified By";
            this.ModifiedByDataGridViewTextBoxColumn3.Name = "ModifiedByDataGridViewTextBoxColumn3";
            this.ModifiedByDataGridViewTextBoxColumn3.Width = 87;
            // 
            // BsDocumentTemplateObject
            // 
            this.BsDocumentTemplateObject.DataSource = typeof(adesso_XTB_Plugins.DocumentTemplateExport.DocumentTemplateModel);
            // 
            // DocumentTemplateExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.TabCtrlDocumentTemplate);
            this.Controls.Add(this.TsDocumentTemplateExport);
            this.Controls.Add(this.TxtDirectoryPath);
            this.Controls.Add(this.BtnDirectoryFolderDialog);
            this.Controls.Add(this.LblFilePath);
            this.Controls.Add(this.splitContainer5);
            this.Name = "DocumentTemplateExport";
            this.Size = new System.Drawing.Size(827, 535);
            this.Load += new System.EventHandler(this.DocumentTemplateExport_Load);
            this.TabCtrlDocumentTemplate.ResumeLayout(false);
            this.TabCrmDocumentTemplates.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvCrmDocumentTemplates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DgvDocumentTemplates)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.TsDocumentTemplateExport.ResumeLayout(false);
            this.TsDocumentTemplateExport.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DsEntityTypeComboBoxBindingSource)).EndInit();
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel1.PerformLayout();
            this.splitContainer5.Panel2.ResumeLayout(false);
            this.splitContainer5.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BsCrmTemplates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BsDocumentTemplateObject)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label LblFilePath;
        private System.Windows.Forms.Button BtnDirectoryFolderDialog;
        private System.Windows.Forms.TextBox TxtDirectoryPath;
        private System.Windows.Forms.TabControl TabCtrlDocumentTemplate;
        private System.Windows.Forms.FolderBrowserDialog FbdDirectory;
        private System.Windows.Forms.ToolTip TtBtnDirectoryFolderDialog;
        private System.Windows.Forms.ToolTip TtBtnOpenDirectory;
        private System.Windows.Forms.ToolTip TtBtnExport;
        private System.Windows.Forms.ToolTip TtBtnImport;
        private System.Windows.Forms.ToolTip TtTabCtrlDocumentTemplate;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn1;
        private System.Windows.Forms.ToolStrip TsDocumentTemplateExport;
        private System.Windows.Forms.ToolStripButton TsbtnClose;
        private System.Windows.Forms.TabPage TabCrmDocumentTemplates;
        private System.Windows.Forms.DataGridView DgvCrmDocumentTemplates;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn2;
        private System.Windows.Forms.BindingSource BsCrmTemplates;
        private System.Windows.Forms.ToolStripButton TsbtnLoadTemplates;
        private System.Windows.Forms.ToolStripProgressBar TsprgbLoadUpdate;
        private System.Windows.Forms.BindingSource BsDocumentTemplateObject;
        private System.Windows.Forms.BindingSource DsEntityTypeComboBoxBindingSource;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
        private System.Windows.Forms.OpenFileDialog OfdAddTemplates;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModifiedOnDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModifiedByDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridView DgvDocumentTemplates;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocumentTypeDataGridViewTextboxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModifiedOnDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn ModifiedByDataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button btnDlDisk;
        private System.Windows.Forms.Button btnSvDisk;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
