using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataSetVisualizer
{
	public partial class Visualizer : Form
	{
		DataView sourceView;
		public Visualizer()
		{
			InitializeComponent();
			this.Text = "Data Visualizer";
			_dgvOnly.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(_dgvOnly_DataBindingComplete);
		}
		public Visualizer(DataTable sourceTable)
		{
			InitializeComponent();
			sourceView = sourceTable.DefaultView;
			_dgvOnly.DataSource = sourceTable;
			this.Text = "Data Visualizer " + sourceView.Count + " Rows";

			_dgvOnly.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(_dgvOnly_DataBindingComplete);
		}

		public delegate void UpdateDataTablePostedDelegate(DataTable sourceTable);
		public void NewDataTablePosted(DataTable sourceTable)
		{
			this.sourceView = sourceTable.DefaultView;
			UpdateDataView(sourceTable);
		}
		public void UpdateDataView(DataTable sourceTable)
		{
			if (_dgvOnly.InvokeRequired)
			{
				UpdateDataTablePostedDelegate myDelegate = new UpdateDataTablePostedDelegate(UpdateDataView);
				_dgvOnly.Invoke(myDelegate, new object[] { sourceTable });
			}
			else
			{
				_dgvOnly.DataSource = sourceTable;
			}
		}

		void _dgvOnly_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			int counter = 0;
			foreach (DataGridViewRow row in _dgvOnly.Rows)
			{
				row.HeaderCell.Value = "" + counter++;
			}
			this.Text = "Data Visualizer " + _dgvOnly.Rows.Count + " Rows";
			_dgvOnly.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
		}

		private void _btnFilter_Click(object sender, EventArgs e)
		{
			sourceView.RowFilter = _txtFilter.Text.Trim();
			_dgvOnly.DataSource = sourceView.ToTable();
			this.Text = "Data Visualizer " + sourceView.Count + " Rows";
		}

		private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				_dgvOnly.SelectAll();
			}
			catch (Exception)
			{
			}
		}

		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Clipboard.SetDataObject(_dgvOnly.GetClipboardContent(), true);
			}
			catch (Exception)
			{
			}
		}
	}
}