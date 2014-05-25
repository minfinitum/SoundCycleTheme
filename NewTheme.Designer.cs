namespace SoundCycle
{
    partial class newTheme
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblValue = new System.Windows.Forms.Label();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.lblAmbient = new System.Windows.Forms.Label();
            this.lbAmbient = new System.Windows.Forms.ListBox();
            this.lbEffects = new System.Windows.Forms.ListBox();
            this.lblEffects = new System.Windows.Forms.Label();
            this.btnSoundAdd = new System.Windows.Forms.Button();
            this.btnSoundRemove = new System.Windows.Forms.Button();
            this.btnAmbientRemove = new System.Windows.Forms.Button();
            this.btnAmbientAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(425, 366);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(506, 366);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblValue
            // 
            this.lblValue.Location = new System.Drawing.Point(12, 14);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(568, 13);
            this.lblValue.TabIndex = 0;
            this.lblValue.Text = "Name";
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(12, 30);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(188, 20);
            this.tbValue.TabIndex = 1;
            // 
            // lblAmbient
            // 
            this.lblAmbient.Location = new System.Drawing.Point(12, 195);
            this.lblAmbient.Name = "lblAmbient";
            this.lblAmbient.Size = new System.Drawing.Size(568, 13);
            this.lblAmbient.TabIndex = 18;
            this.lblAmbient.Text = "Ambient Sounds";
            // 
            // lbAmbient
            // 
            this.lbAmbient.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbAmbient.FormattingEnabled = true;
            this.lbAmbient.Location = new System.Drawing.Point(12, 211);
            this.lbAmbient.Name = "lbAmbient";
            this.lbAmbient.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbAmbient.Size = new System.Drawing.Size(568, 95);
            this.lbAmbient.TabIndex = 21;
            // 
            // lbEffects
            // 
            this.lbEffects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbEffects.FormattingEnabled = true;
            this.lbEffects.Location = new System.Drawing.Point(12, 69);
            this.lbEffects.Name = "lbEffects";
            this.lbEffects.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbEffects.Size = new System.Drawing.Size(568, 95);
            this.lbEffects.TabIndex = 17;
            // 
            // lblEffects
            // 
            this.lblEffects.Location = new System.Drawing.Point(12, 53);
            this.lblEffects.Name = "lblEffects";
            this.lblEffects.Size = new System.Drawing.Size(569, 13);
            this.lblEffects.TabIndex = 14;
            this.lblEffects.Text = "Effect Sounds";
            // 
            // btnSoundAdd
            // 
            this.btnSoundAdd.Location = new System.Drawing.Point(425, 170);
            this.btnSoundAdd.Name = "btnSoundAdd";
            this.btnSoundAdd.Size = new System.Drawing.Size(75, 23);
            this.btnSoundAdd.TabIndex = 22;
            this.btnSoundAdd.Text = "Add";
            this.btnSoundAdd.UseVisualStyleBackColor = true;
            this.btnSoundAdd.Click += new System.EventHandler(this.btnSoundAdd_Click);
            // 
            // btnSoundRemove
            // 
            this.btnSoundRemove.Location = new System.Drawing.Point(505, 170);
            this.btnSoundRemove.Name = "btnSoundRemove";
            this.btnSoundRemove.Size = new System.Drawing.Size(75, 23);
            this.btnSoundRemove.TabIndex = 23;
            this.btnSoundRemove.Text = "Remove";
            this.btnSoundRemove.UseVisualStyleBackColor = true;
            this.btnSoundRemove.Click += new System.EventHandler(this.btnSoundRemove_Click);
            // 
            // btnAmbientRemove
            // 
            this.btnAmbientRemove.Location = new System.Drawing.Point(505, 312);
            this.btnAmbientRemove.Name = "btnAmbientRemove";
            this.btnAmbientRemove.Size = new System.Drawing.Size(75, 23);
            this.btnAmbientRemove.TabIndex = 25;
            this.btnAmbientRemove.Text = "Remove";
            this.btnAmbientRemove.UseVisualStyleBackColor = true;
            this.btnAmbientRemove.Click += new System.EventHandler(this.btnAmbientRemove_Click);
            // 
            // btnAmbientAdd
            // 
            this.btnAmbientAdd.Location = new System.Drawing.Point(425, 312);
            this.btnAmbientAdd.Name = "btnAmbientAdd";
            this.btnAmbientAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAmbientAdd.TabIndex = 24;
            this.btnAmbientAdd.Text = "Add";
            this.btnAmbientAdd.UseVisualStyleBackColor = true;
            this.btnAmbientAdd.Click += new System.EventHandler(this.btnAmbientAdd_Click);
            // 
            // newTheme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 401);
            this.Controls.Add(this.btnAmbientRemove);
            this.Controls.Add(this.btnAmbientAdd);
            this.Controls.Add(this.btnSoundRemove);
            this.Controls.Add(this.btnSoundAdd);
            this.Controls.Add(this.lblAmbient);
            this.Controls.Add(this.lbAmbient);
            this.Controls.Add(this.lbEffects);
            this.Controls.Add(this.lblEffects);
            this.Controls.Add(this.tbValue);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "newTheme";
            this.Padding = new System.Windows.Forms.Padding(9);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Theme";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.Label lblAmbient;
        private System.Windows.Forms.ListBox lbAmbient;
        private System.Windows.Forms.ListBox lbEffects;
        private System.Windows.Forms.Label lblEffects;
        private System.Windows.Forms.Button btnSoundAdd;
        private System.Windows.Forms.Button btnSoundRemove;
        private System.Windows.Forms.Button btnAmbientRemove;
        private System.Windows.Forms.Button btnAmbientAdd;

    }
}
