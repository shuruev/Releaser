namespace Releaser.CommandManager
{
	partial class MainForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.listEvents = new System.Windows.Forms.ListView();
			this.eventType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.eventDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.rawData = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.textTotalEvents = new System.Windows.Forms.TextBox();
			this.lblTotalEvents = new System.Windows.Forms.Label();
			this.lblPage = new System.Windows.Forms.Label();
			this.lblTotalPages = new System.Windows.Forms.Label();
			this.numPage = new System.Windows.Forms.NumericUpDown();
			this.mainToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.btnSendCommand = new System.Windows.Forms.Button();
			this.btnRefresh = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numPage)).BeginInit();
			this.SuspendLayout();
			// 
			// listEvents
			// 
			this.listEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.listEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.eventType,
            this.eventDate,
            this.rawData});
			this.listEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.listEvents.FullRowSelect = true;
			this.listEvents.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listEvents.Location = new System.Drawing.Point(12, 46);
			this.listEvents.Name = "listEvents";
			this.listEvents.ShowItemToolTips = true;
			this.listEvents.Size = new System.Drawing.Size(760, 398);
			this.listEvents.TabIndex = 0;
			this.listEvents.UseCompatibleStateImageBehavior = false;
			this.listEvents.View = System.Windows.Forms.View.Details;
			this.listEvents.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listEvents_MouseDoubleClick);
			// 
			// eventType
			// 
			this.eventType.DisplayIndex = 1;
			this.eventType.Text = "Event type";
			this.eventType.Width = 250;
			// 
			// eventDate
			// 
			this.eventDate.DisplayIndex = 0;
			this.eventDate.Text = "Event Date";
			this.eventDate.Width = 180;
			// 
			// rawData
			// 
			this.rawData.Text = "Raw Data";
			this.rawData.Width = 450;
			// 
			// textTotalEvents
			// 
			this.textTotalEvents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.textTotalEvents.Location = new System.Drawing.Point(134, 17);
			this.textTotalEvents.Name = "textTotalEvents";
			this.textTotalEvents.ReadOnly = true;
			this.textTotalEvents.Size = new System.Drawing.Size(76, 20);
			this.textTotalEvents.TabIndex = 5;
			this.textTotalEvents.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lblTotalEvents
			// 
			this.lblTotalEvents.AutoSize = true;
			this.lblTotalEvents.Location = new System.Drawing.Point(9, 20);
			this.lblTotalEvents.Name = "lblTotalEvents";
			this.lblTotalEvents.Size = new System.Drawing.Size(119, 13);
			this.lblTotalEvents.TabIndex = 4;
			this.lblTotalEvents.Text = "Total number of events:";
			// 
			// lblPage
			// 
			this.lblPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblPage.AutoSize = true;
			this.lblPage.Location = new System.Drawing.Point(11, 455);
			this.lblPage.Name = "lblPage";
			this.lblPage.Size = new System.Drawing.Size(35, 13);
			this.lblPage.TabIndex = 7;
			this.lblPage.Text = "Page:";
			// 
			// lblTotalPages
			// 
			this.lblTotalPages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblTotalPages.AutoSize = true;
			this.lblTotalPages.Location = new System.Drawing.Point(92, 455);
			this.lblTotalPages.Name = "lblTotalPages";
			this.lblTotalPages.Size = new System.Drawing.Size(28, 13);
			this.lblTotalPages.TabIndex = 8;
			this.lblTotalPages.Text = "of ...";
			// 
			// numPage
			// 
			this.numPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.numPage.Location = new System.Drawing.Point(50, 452);
			this.numPage.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.numPage.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numPage.Name = "numPage";
			this.numPage.Size = new System.Drawing.Size(36, 20);
			this.numPage.TabIndex = 9;
			this.numPage.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numPage.ValueChanged += new System.EventHandler(this.numPage_ValueChanged);
			// 
			// btnSendCommand
			// 
			this.btnSendCommand.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSendCommand.BackgroundImage = global::Releaser.CommandManager.Properties.Resources.SendCommand;
			this.btnSendCommand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnSendCommand.Location = new System.Drawing.Point(710, 12);
			this.btnSendCommand.Name = "btnSendCommand";
			this.btnSendCommand.Size = new System.Drawing.Size(28, 28);
			this.btnSendCommand.TabIndex = 11;
			this.mainToolTip.SetToolTip(this.btnSendCommand, "Send command");
			this.btnSendCommand.UseVisualStyleBackColor = true;
			this.btnSendCommand.Click += new System.EventHandler(this.btnSendCommand_Click);
			// 
			// btnRefresh
			// 
			this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefresh.BackgroundImage")));
			this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.btnRefresh.Location = new System.Drawing.Point(744, 12);
			this.btnRefresh.Name = "btnRefresh";
			this.btnRefresh.Size = new System.Drawing.Size(28, 28);
			this.btnRefresh.TabIndex = 10;
			this.mainToolTip.SetToolTip(this.btnRefresh, "Refresh");
			this.btnRefresh.UseVisualStyleBackColor = true;
			this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(784, 484);
			this.Controls.Add(this.btnSendCommand);
			this.Controls.Add(this.btnRefresh);
			this.Controls.Add(this.numPage);
			this.Controls.Add(this.lblTotalPages);
			this.Controls.Add(this.lblPage);
			this.Controls.Add(this.textTotalEvents);
			this.Controls.Add(this.lblTotalEvents);
			this.Controls.Add(this.listEvents);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(600, 500);
			this.Name = "MainForm";
			this.Text = "Command Manager";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			((System.ComponentModel.ISupportInitialize)(this.numPage)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView listEvents;
		private System.Windows.Forms.TextBox textTotalEvents;
		private System.Windows.Forms.Label lblTotalEvents;
		private System.Windows.Forms.ColumnHeader eventType;
		private System.Windows.Forms.ColumnHeader rawData;
		private System.Windows.Forms.ColumnHeader eventDate;
		private System.Windows.Forms.Label lblTotalPages;
		private System.Windows.Forms.Label lblPage;
		private System.Windows.Forms.NumericUpDown numPage;
		private System.Windows.Forms.Button btnRefresh;
		private System.Windows.Forms.ToolTip mainToolTip;
		private System.Windows.Forms.Button btnSendCommand;
	}
}

