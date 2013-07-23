using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Microsoft.VisualStudio.DebuggerVisualizers;

namespace ConsoleApplication1
{
	class Program
	{
		public class testClass
		{
			public string hello;
			public string world;
		}
		static void Main(string[] args)
		{
			//DataTable mine = new DataTable();
			//mine.Columns.Add("Test", typeof(string));
			//DataRow myRow = mine.NewRow();
			//myRow["Test"] = "Hello World";
			//mine.Rows.Add(myRow);
			//myRow = mine.NewRow();
			//myRow["Test"] = "I said hello world";
			//mine.Rows.Add(myRow);
			//mine.AcceptChanges();
			//TestShowVisualizer(mine);
			//DataSet myDataset = new DataSet();
			//myDataset.Tables.Add(mine);
			//TestShowVisualizer(myRow);

			List<testClass> testClassList = new List<testClass>();
			testClass item = new testClass() { hello = "hi", world = "my name is" };
			testClassList.Add(item);
			TestShowListVisualizer(testClassList);
		}

		public static void TestShowVisualizer(object objectToVisualize)
		{
			VisualizerDevelopmentHost myHost = new VisualizerDevelopmentHost(objectToVisualize, typeof(DataSetVisualizer.DataRowVisualizer));
			myHost.ShowVisualizer();
		}
		public static void TestShowListVisualizer(object objectToVisualize)
		{
			VisualizerDevelopmentHost myHost = new VisualizerDevelopmentHost(objectToVisualize, typeof(DataSetVisualizer.ListVisualizer));
			myHost.ShowVisualizer();
		}
	}
}
