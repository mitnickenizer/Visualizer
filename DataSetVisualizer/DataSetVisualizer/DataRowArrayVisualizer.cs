
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.DebuggerVisualizers;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;

[assembly: System.Diagnostics.DebuggerVisualizer(
		    typeof(DataSetVisualizer.DataRowArrayVisualizer),
		    typeof(DataSetVisualizer.DataRowVisualizerObjectSource),
			Target = typeof(DataRow[]),
			Description = "My Data Row Visualizer")]

namespace DataSetVisualizer
{
	public class DataRowArrayVisualizer : DialogDebuggerVisualizer
	{
		override protected void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
		{
			try
			{
				DataTable myTable = new DataTable();
				using (System.IO.Stream stream = objectProvider.GetData())
				{
					BinaryFormatter frm = new BinaryFormatter();
					myTable = frm.Deserialize(stream) as DataTable;
				}


				Visualizer myVisualizer = new Visualizer(myTable);
				windowService.ShowDialog((Form)myVisualizer);
			}
			catch (Exception)
			{
				try
				{
					DataTable tempTable = (System.Data.DataTable)objectProvider.GetObject();
					Visualizer myVisualizer = new Visualizer(tempTable);
					windowService.ShowDialog((Form)myVisualizer);
				}
				catch (Exception) { }
			}
		}
	}
}