namespace Releaser.CommandManager
{
	partial class EventView
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
			this.textEventType = new System.Windows.Forms.TextBox();
			this.textEventDate = new System.Windows.Forms.TextBox();
			this.lblEventDate = new System.Windows.Forms.Label();
			this.textJson = new System.Windows.Forms.RichTextBox();
			this.btnClose = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lblEventType
			// 
			this.lblEventType.AutoSize = true;
			this.lblEventType.Location = new System.Drawing.Point(12, 15);
			this.lblEventType.Name = "lblEventType";
			this.lblEventType.Size = new System.Drawing.Size(61, 13);
			this.lblEventType.TabIndex = 0;
			this.lblEventType.Text = "Event type:";
			// 
			// textEventType
			// 
			this.textEventType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textEventType.Location = new System.Drawing.Point(79, 12);
			this.textEventType.Name = "textEventType";
			this.textEventType.ReadOnly = true;
			this.textEventType.Size = new System.Drawing.Size(293, 20);
			this.textEventType.TabIndex = 1;
			this.textEventType.TabStop = false;
			// 
			// textEventDate
			// 
			this.textEventDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textEventDate.Location = new System.Drawing.Point(79, 38);
			this.textEventDate.Name = "textEventDate";
			this.textEventDate.ReadOnly = true;
			this.textEventDate.Size = new System.Drawing.Size(293, 20);
			this.textEventDate.TabIndex = 3;
			this.textEventDate.TabStop = false;
			// 
			// lblEventDate
			// 
			this.lblEventDate.AutoSize = true;
			this.lblEventDate.Location = new System.Drawing.Point(12, 41);
			this.lblEventDate.Name = "lblEventDate";
			this.lblEventDate.Size = new System.Drawing.Size(62, 13);
			this.lblEventDate.TabIndex = 2;
			this.lblEventDate.Text = "Event date:";
			// 
			// textJson
			// 
			this.textJson.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.textJson.Location = new System.Drawing.Point(15, 64);
			this.textJson.Name = "textJson";
			this.textJson.ReadOnly = true;
			this.textJson.Size = new System.Drawing.Size(357, 210);
			this.textJson.TabIndex = 4;
			this.textJson.TabStop = false;
			this.textJson.Text = "";
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(297, 280);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(75, 23);
			this.btnClose.TabIndex = 5;
			this.btnClose.Text = "Close ";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.button1_Click);
			// 
			// EventView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(384, 314);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.textJson);
			this.Controls.Add(this.textEventDate);
			this.Controls.Add(this.lblEventDate);
			this.Controls.Add(this.textEventType);
			this.Controls.Add(this.lblEventType);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.MinimumSize = new System.Drawing.Size(400, 350);
			this.Name = "EventView";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Event View";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lblEventType;
		private System.Windows.Forms.TextBox textEventType;
		private System.Windows.Forms.TextBox textEventDate;
		private System.Windows.Forms.Label lblEventDate;
		private System.Windows.Forms.RichTextBox textJson;
		private System.Windows.Forms.Button btnClose;
	}
}