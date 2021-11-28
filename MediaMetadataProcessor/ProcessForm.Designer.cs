
namespace MediaMetadataProcessor
{
    partial class ProcessForm
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
            this.pnlBase = new System.Windows.Forms.Panel();
            this.pnlMiddle = new System.Windows.Forms.Panel();
            this.btnProcess = new System.Windows.Forms.Button();
            this.grpBoxBtns = new System.Windows.Forms.GroupBox();
            this.radioBtnNew = new System.Windows.Forms.RadioButton();
            this.radioBtnDelete = new System.Windows.Forms.RadioButton();
            this.radioBtnMove = new System.Windows.Forms.RadioButton();
            this.radioBtnCopy = new System.Windows.Forms.RadioButton();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.listBoxDest = new System.Windows.Forms.ListBox();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.listBoxMetadata = new System.Windows.Forms.ListBox();
            this.txtBoxNew = new System.Windows.Forms.TextBox();
            this.pnlBase.SuspendLayout();
            this.pnlMiddle.SuspendLayout();
            this.grpBoxBtns.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBase
            // 
            this.pnlBase.Controls.Add(this.pnlMiddle);
            this.pnlBase.Controls.Add(this.pnlRight);
            this.pnlBase.Controls.Add(this.pnlLeft);
            this.pnlBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBase.Location = new System.Drawing.Point(0, 0);
            this.pnlBase.Name = "pnlBase";
            this.pnlBase.Size = new System.Drawing.Size(800, 450);
            this.pnlBase.TabIndex = 0;
            // 
            // pnlMiddle
            // 
            this.pnlMiddle.Controls.Add(this.txtBoxNew);
            this.pnlMiddle.Controls.Add(this.btnProcess);
            this.pnlMiddle.Controls.Add(this.grpBoxBtns);
            this.pnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMiddle.Location = new System.Drawing.Point(318, 0);
            this.pnlMiddle.Name = "pnlMiddle";
            this.pnlMiddle.Size = new System.Drawing.Size(164, 450);
            this.pnlMiddle.TabIndex = 2;
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Location = new System.Drawing.Point(7, 415);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(151, 23);
            this.btnProcess.TabIndex = 1;
            this.btnProcess.Text = "Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // grpBoxBtns
            // 
            this.grpBoxBtns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxBtns.Controls.Add(this.radioBtnNew);
            this.grpBoxBtns.Controls.Add(this.radioBtnDelete);
            this.grpBoxBtns.Controls.Add(this.radioBtnMove);
            this.grpBoxBtns.Controls.Add(this.radioBtnCopy);
            this.grpBoxBtns.Location = new System.Drawing.Point(7, 13);
            this.grpBoxBtns.Name = "grpBoxBtns";
            this.grpBoxBtns.Size = new System.Drawing.Size(151, 118);
            this.grpBoxBtns.TabIndex = 0;
            this.grpBoxBtns.TabStop = false;
            this.grpBoxBtns.Text = "Process";
            // 
            // radioBtnNew
            // 
            this.radioBtnNew.AutoSize = true;
            this.radioBtnNew.Location = new System.Drawing.Point(7, 92);
            this.radioBtnNew.Name = "radioBtnNew";
            this.radioBtnNew.Size = new System.Drawing.Size(76, 17);
            this.radioBtnNew.TabIndex = 3;
            this.radioBtnNew.TabStop = true;
            this.radioBtnNew.Text = "New value";
            this.radioBtnNew.UseVisualStyleBackColor = true;
            // 
            // radioBtnDelete
            // 
            this.radioBtnDelete.AutoSize = true;
            this.radioBtnDelete.Location = new System.Drawing.Point(7, 68);
            this.radioBtnDelete.Name = "radioBtnDelete";
            this.radioBtnDelete.Size = new System.Drawing.Size(56, 17);
            this.radioBtnDelete.TabIndex = 2;
            this.radioBtnDelete.TabStop = true;
            this.radioBtnDelete.Text = "Delete";
            this.radioBtnDelete.UseVisualStyleBackColor = true;
            // 
            // radioBtnMove
            // 
            this.radioBtnMove.AutoSize = true;
            this.radioBtnMove.Location = new System.Drawing.Point(7, 44);
            this.radioBtnMove.Name = "radioBtnMove";
            this.radioBtnMove.Size = new System.Drawing.Size(52, 17);
            this.radioBtnMove.TabIndex = 1;
            this.radioBtnMove.TabStop = true;
            this.radioBtnMove.Text = "Move";
            this.radioBtnMove.UseVisualStyleBackColor = true;
            // 
            // radioBtnCopy
            // 
            this.radioBtnCopy.AutoSize = true;
            this.radioBtnCopy.Location = new System.Drawing.Point(7, 20);
            this.radioBtnCopy.Name = "radioBtnCopy";
            this.radioBtnCopy.Size = new System.Drawing.Size(49, 17);
            this.radioBtnCopy.TabIndex = 0;
            this.radioBtnCopy.TabStop = true;
            this.radioBtnCopy.Text = "Copy";
            this.radioBtnCopy.UseVisualStyleBackColor = true;
            // 
            // pnlRight
            // 
            this.pnlRight.Controls.Add(this.listBoxDest);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlRight.Location = new System.Drawing.Point(482, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(318, 450);
            this.pnlRight.TabIndex = 1;
            // 
            // listBoxDest
            // 
            this.listBoxDest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxDest.Enabled = false;
            this.listBoxDest.FormattingEnabled = true;
            this.listBoxDest.Location = new System.Drawing.Point(0, 0);
            this.listBoxDest.Name = "listBoxDest";
            this.listBoxDest.Size = new System.Drawing.Size(318, 450);
            this.listBoxDest.TabIndex = 1;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.listBoxMetadata);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(318, 450);
            this.pnlLeft.TabIndex = 0;
            // 
            // listBoxMetadata
            // 
            this.listBoxMetadata.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMetadata.FormattingEnabled = true;
            this.listBoxMetadata.Location = new System.Drawing.Point(0, 0);
            this.listBoxMetadata.Name = "listBoxMetadata";
            this.listBoxMetadata.Size = new System.Drawing.Size(318, 450);
            this.listBoxMetadata.TabIndex = 0;
            // 
            // txtBoxNew
            // 
            this.txtBoxNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBoxNew.Location = new System.Drawing.Point(6, 151);
            this.txtBoxNew.Name = "txtBoxNew";
            this.txtBoxNew.Size = new System.Drawing.Size(152, 20);
            this.txtBoxNew.TabIndex = 2;
            // 
            // ProcessForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlBase);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProcessForm";
            this.Text = "Process Metadata";
            this.TopMost = true;
            this.pnlBase.ResumeLayout(false);
            this.pnlMiddle.ResumeLayout(false);
            this.pnlMiddle.PerformLayout();
            this.grpBoxBtns.ResumeLayout(false);
            this.grpBoxBtns.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlBase;
        private System.Windows.Forms.Panel pnlMiddle;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.GroupBox grpBoxBtns;
        private System.Windows.Forms.RadioButton radioBtnNew;
        private System.Windows.Forms.RadioButton radioBtnDelete;
        private System.Windows.Forms.RadioButton radioBtnMove;
        private System.Windows.Forms.RadioButton radioBtnCopy;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.ListBox listBoxDest;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.ListBox listBoxMetadata;
        private System.Windows.Forms.TextBox txtBoxNew;
    }
}