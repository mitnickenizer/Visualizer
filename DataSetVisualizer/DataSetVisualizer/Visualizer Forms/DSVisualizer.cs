using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataSetVisualizer.Forms
{
	public partial class DSVisualizer : Form
	{
		DataSet currentSet;
		DataView currentView;

		public DSVisualizer()
		{
			InitializeComponent();
			this.Text = "Data Set Visualizer";
			_dgvView.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(_dgvView_DataBindingComplete);
		}

		public DSVisualizer(DataSet currentSet)
		{
			InitializeComponent();
			this.currentSet = currentSet;
			foreach (DataTable table in currentSet.Tables)
			{
				_tableList.Items.Add(table.TableName);
			}
			if (currentSet.Tables.Count > 0)
			{
				_tableList.SelectedIndex = 0;
				currentView = currentSet.Tables[0].DefaultView;
				_dgvView.DataSource = currentView;
				this.Text = "Data Set Visualizer " + currentView.Count + " Rows";
			}

			_dgvView.DataBindingComplete += new DataGridViewBindingCompleteEventHandler(_dgvView_DataBindingComplete);
		}

		public delegate void UpdateDataSetPostedDelegate(DataSet currentSet);
		public void NewDataSetPosted(DataSet currentSet)
		{

			this.currentSet = currentSet;
			UpdateTableList(currentSet);
			if (currentSet.Tables.Count > 0)
			{
				currentView = currentSet.Tables[0].DefaultView;
			}
				
		}
		public void UpdateTableList(DataSet currentSet)
		{
			if (_tableList.InvokeRequired)
			{
				UpdateDataSetPostedDelegate myDelegate = new UpdateDataSetPostedDelegate(UpdateTableList);
				_tableList.Invoke(myDelegate, new object[] { currentSet });
			}
			else
			{
				foreach (DataTable table in currentSet.Tables)
				{
					_tableList.Items.Add(table.TableName);
				}
				if (currentSet.Tables.Count > 0)
				{
					_tableList.SelectedIndex = 0;
				}
			}
		}
		public void UpdateDataView(DataSet currentSet)
		{
			if (_dgvView.InvokeRequired)
			{
				UpdateDataSetPostedDelegate myDelegate = new UpdateDataSetPostedDelegate(UpdateDataView);
				_dgvView.Invoke(myDelegate, new object[] { currentSet });
			}
			else
			{
				if (currentSet.Tables.Count > 0)
				{
					_dgvView.DataSource = currentView;
				}
			}
		}

		void _dgvView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
		{
			int counter = 0;
			foreach (DataGridViewRow row in _dgvView.Rows)
			{
				row.HeaderCell.Value = counter++;
			}
		}

		private void _tableList_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				currentView = currentSet.Tables[_tableList.SelectedIndex].DefaultView;
				_dgvView.DataSource = currentView.ToTable();
				this.Text = "Data Set Visualizer " + currentView.Count + " Rows";
				int counter = 0;
			}
			catch (Exception)
			{
			}
		}

		private void _btnFilter_Click(object sender, EventArgs e)
		{
			try
			{
				currentView.RowFilter = _txtFilter.Text;
				_dgvView.DataSource = currentView.ToTable();
				this.Text = "Data Set Visualizer " + currentView.Count + " Rows";
				int counter = 0;
			}
			catch (Exception)
			{
			}
		}

		private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				_dgvView.SelectAll();
			}
			catch(Exception)
			{
			}
		}

		private void copyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Clipboard.SetDataObject(_dgvView.GetClipboardContent(), true);
			}
			catch (Exception)
			{
			}
		}
	}
}