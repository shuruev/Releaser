namespace Releaser.CommandManager
{
	partial class SendCommand
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
			this.lblEventType = new System.Windows.Forms.Label();
			this.cmbCommandTypes = new System.Windows.Forms.ComboBox();
			this.textJson = new System.Windows.Forms.RichTextBox();
			this.btnSend = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblEventType
			// 
			this.lblEventType.AutoSize = true;
			this.lblEventType.Location = new System.Drawing.Point(12, 15);
			this.lblEventType.Name = "lblEventType";
			this.lblEventType.Size = new System.Drawing.Size(80, 13);
			this.lblEventType.TabIndex = 2;
			this.lblEventType.Text = "Command type:";
			// 
			// cmbCommandTypes
			// 
			this.cmbCommandTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.cmbCommandTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCommandTypes.FormattingEnabled = true;
			this.cmbCommandTypes.Location = new System.Drawing.Point(98, 12);
			this.cmbCommandTypes.Name = "cmbCommandTypes";
			this.cmbCommandTypes.Size = new System.Drawing.Size(274, 21);
			this.cmbCommandTypes.Sorted = true;
			this.cmbCommandTypes.TabIndex = 3;
			this.cmbCommandTypes.TabStop = false;
			this.cmbCommandTypes.SelectedIndexChanged += new System.EventHandler(this.cmbCommandTypes_SelectedIndexChanged);
			// 
			// textJson
			// 
			this.textJson.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textJson.Location = new System.Drawing.Point(15, 39);
			this.textJson.Name = "textJson";
			this.textJson.Size = new System.Drawing.Size(357, 231);
			this.textJson.TabIndex = 4;
			this.textJson.Text = "";
			// 
			// btnSend
			// 
			this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSend.Location = new System.Drawing.Point(216, 279);
			this.btnSend.Name = "btnSend";
			this.btnSend.Size = new System.Drawing.Size(75, 23);
			this.btnSend.TabIndex = 5;
			this.btnSend.Text = "Send";
			this.btnSend.UseVisualStyleBackColor = true;
			this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(297, 279);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// SendCommand
			// 
			this.AcceptButton = this.btnSend;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(384, 314);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSend);
			this.Controls.Add(this.textJson);
			this.Controls.Add(this.cmbCommandTypes);
			this.Controls.Add(this.lblEventType);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(400, 350);
			this.Name = "SendCommand";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Send Command";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblEventType;
		private System.Windows.Forms.ComboBox cmbCommandTypes;
		private System.Windows.Forms.RichTextBox textJson;
		private System.Windows.Forms.Button btnSend;
		private System.Windows.Forms.Button btnCancel;
	}
}