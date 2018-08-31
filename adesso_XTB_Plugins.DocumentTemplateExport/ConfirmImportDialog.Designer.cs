namespace adesso_XTB_Plugins.DocumentTemplateExport
{
    partial class ConfirmImportDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfirmImportDialog));
            this.btnConfirmImport = new System.Windows.Forms.Button();
            this.btnConfirmCancel = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btnConfirmImport
            // 
            this.btnConfirmImport.Location = new System.Drawing.Point(110, 186);
            this.btnConfirmImport.Name = "btnConfirmImport";
            this.btnConfirmImport.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmImport.TabIndex = 0;
            this.btnConfirmImport.Text = "Continue";
            this.btnConfirmImport.UseVisualStyleBackColor = true;
            this.btnConfirmImport.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnConfirmCancel
            // 
            this.btnConfirmCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnConfirmCancel.Location = new System.Drawing.Point(205, 186);
            this.btnConfirmCancel.Name = "btnConfirmCancel";
            this.btnConfirmCancel.Size = new System.Drawing.Size(75, 23);
            this.btnConfirmCancel.TabIndex = 1;
            this.btnConfirmCancel.Text = "Cancel";
            this.btnConfirmCancel.UseVisualStyleBackColor = true;
            this.btnConfirmCancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(350, 168);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "You are about to update the selected Document Templates in your CRM organization." +
    "\n\nThe matching datasets from your organization will be permanently overridden.\n\n" +
    "Do you wish to continue?";
            // 
            // ConfirmImportDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnConfirmCancel;
            this.ClientSize = new System.Drawing.Size(374, 221);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.btnConfirmCancel);
            this.Controls.Add(this.btnConfirmImport);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfirmImportDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Import";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnConfirmImport;
        private System.Windows.Forms.Button btnConfirmCancel;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}