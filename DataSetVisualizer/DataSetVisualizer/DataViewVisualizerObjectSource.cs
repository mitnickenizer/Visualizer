using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.DebuggerVisualizers;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataSetVisualizer
{
	class DataViewVisualizerObjectSource : VisualizerObjectSource
	{
		public override void GetData(object target, System.IO.Stream outgoingData)
		{
			if(target != null && target is DataView)
			{
				DataView view = target as DataView;

				if (view == null)
				{
					view = new DataView();
				}

				BinaryFormatter formatter = new BinaryFormatter();
				DataTable tempTable = view.Table;
				formatter.Serialize(outgoingData, tempTable);
			}
		}
	}
}
