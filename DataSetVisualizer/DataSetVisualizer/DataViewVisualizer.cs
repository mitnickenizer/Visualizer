using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.DebuggerVisualizers;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using DataSetVisualizer;
using DataSetVisualizer.ObjectSource;
using DataSetVisualizer.Forms;

[assembly: System.Diagnostics.DebuggerVisualizer(
			typeof(DataViewVisualizer),
			typeof(DataViewVisualizerObjectSource),
			Target = typeof(System.Data.DataView),
			Description = "My Data View Visualizer")]

namespace DataSetVisualizer
{
	public class DataViewVisualizer : DialogDebuggerVisualizer
	{
		override protected void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
		{
			Visualizer myVisualizer = new Visualizer();
			Thread loadDataThread = new Thread(() =>
			{
				try
				{
					Stream myObjectStream = objectProvider.GetData();
					BinaryFormatter formatter = new BinaryFormatter();
					DataTable tempTable = (System.Data.DataTable)formatter.Deserialize(myObjectStream);
					//Visualizer myVisualizer = new Visualizer(tempTable);
					myVisualizer.NewDataTablePosted(tempTable);
				}
				catch (Exception)
				{
					MessageBox.Show("Could not load please try using the standard debugger visualizer");
				}
			});
			loadDataThread.Start();
			windowService.ShowDialog((Form)myVisualizer);
		}
	}
}