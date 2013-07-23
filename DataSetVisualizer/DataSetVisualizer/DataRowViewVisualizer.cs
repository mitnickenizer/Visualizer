using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.DebuggerVisualizers;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using DataSetVisualizer;
using DataSetVisualizer.ObjectSource;
using DataSetVisualizer.Forms;

[assembly: System.Diagnostics.DebuggerVisualizer(
		    typeof(DataRowViewVisualizer),
			typeof(DataRowVisualizerObjectSource),
			Target = typeof(System.Data.DataRowView),
			Description = "My Data Row Visualizer")]

namespace DataSetVisualizer
{
	public class DataRowViewVisualizer : DialogDebuggerVisualizer
	{
		override protected void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
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
	}
}