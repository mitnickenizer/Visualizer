using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.DebuggerVisualizers;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using DataSetVisualizer.ObjectSource;
using DataSetVisualizer.Forms;

[assembly: System.Diagnostics.DebuggerVisualizer(
			typeof(DataSetVisualizer.DataSetVisualizer),
			typeof(VisualizerObjectSource),
			Target = typeof(System.Data.DataSet),
			Description = "My Data Set Visualizer")]

namespace DataSetVisualizer
{
	public class DataSetVisualizer : DialogDebuggerVisualizer
	{
		override protected void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
		{
			DSVisualizer myVisualizer = new DSVisualizer();
			Thread loadDataThread = new Thread(() =>
				{
					try
					{
						Stream myObjectStream = objectProvider.GetData();
						BinaryFormatter formatter = new BinaryFormatter();
						DataSet tempSet = (System.Data.DataSet)formatter.Deserialize(myObjectStream);
						myVisualizer.NewDataSetPosted(tempSet);
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