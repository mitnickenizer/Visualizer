namespace DataSetVisualizer.Forms
{
	partial class Visualizer
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
			this._dgvOnly = new System.Windows.Forms.DataGridView();
			this._txtFilter = new System.Windows.Forms.TextBox();
			this._btnFilter = new System.Windows.Forms.Button();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			((System.ComponentModel.ISupportInitialize)(this._dgvOnly)).BeginInit();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// _dgvOnly
			// 
			this._dgvOnly.AllowUserToAddRows = false;
			this._dgvOnly.AllowUserToDeleteRows = false;
			this._dgvOnly.AllowUserToOrderColumns = true;
			this._dgvOnly.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._dgvOnly.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this._dgvOnly.ContextMenuStrip = this.contextMenuStrip1;
			this._dgvOnly.Location = new System.Drawing.Point(12, 38);
			this._dgvOnly.Name = "_dgvOnly";
			this._dgvOnly.Size = new System.Drawing.Size(517, 212);
			this._dgvOnly.TabIndex = 0;
			// 
			// _txtFilter
			// 
			this._txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this._txtFilter.Location = new System.Drawing.Point(12, 12);
			this._txtFilter.Name = "_txtFilter";
			this._txtFilter.Size = new System.Drawing.Size(436, 20);
			this._txtFilter.TabIndex = 1;
			// 
			// _btnFilter
			// 
			this._btnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this._btnFilter.Location = new System.Drawing.Point(454, 9);
			this._btnFilter.Name = "_btnFilter";
			this._btnFilter.Size = new System.Drawing.Size(75, 23);
			this._btnFilter.TabIndex = 2;
			this._btnFilter.Text = "Apply Filter";
			this._btnFilter.UseVisualStyleBackColor = true;
			this._btnFilter.Click += new System.EventHandler(this._btnFilter_Click);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectAllToolStripMenuItem,
            this.copyToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(165, 48);
			// 
			// selectAllToolStripMenuItem
			// 
			this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
			this.selectAllToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
			this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.selectAllToolStripMenuItem.Text = "Select All";
			this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.copyToolStripMenuItem.Text = "Copy";
			this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
			// 
			// Visualizer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(541, 262);
			this.Controls.Add(this._btnFilter);
			this.Controls.Add(this._txtFilter);
			this.Controls.Add(this._dgvOnly);
			this.Name = "Visualizer";
			this.Text = "Visualizer";
			((System.ComponentModel.ISupportInitialize)(this._dgvOnly)).EndInit();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView _dgvOnly;
		private System.Windows.Forms.TextBox _txtFilter;
		private System.Windows.Forms.Button _btnFilter;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
	}
}