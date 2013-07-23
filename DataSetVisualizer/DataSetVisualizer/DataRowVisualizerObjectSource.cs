using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.DebuggerVisualizers;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;

namespace DataSetVisualizer
{
	class DataRowVisualizerObjectSource : VisualizerObjectSource
	{
		public override void GetData(object target, System.IO.Stream outgoingData)
		{
			if (target != null)
			{
				if (target is DataRow)
				{
					DataTable tableToBeSerialized;
					DataRow row = target as DataRow;

					if (row.Table == null)
					{
						tableToBeSerialized = new DataTable();
						int inc = 0;
						foreach (object item in row.ItemArray)
						{
							tableToBeSerialized.Columns.Add("Column" + inc++, item.GetType());
						}
					}
					else
					{
						tableToBeSerialized = row.Table.Clone();
					}

					tableToBeSerialized.LoadDataRow(row.ItemArray, true);

					BinaryFormatter formatter = new BinaryFormatter();
					formatter.Serialize(outgoingData, tableToBeSerialized);
				}
				else if (target is DataRowView)
				{
					DataTable tableToBeSerialized;
					DataRow row = ((DataRowView)target).Row;

					if (row.Table == null)
					{
						tableToBeSerialized = new DataTable();
						int inc = 0;
						foreach (object item in row.ItemArray)
						{
							tableToBeSerialized.Columns.Add("Column" + inc++, item.GetType());
						}
					}
					else
					{
						tableToBeSerialized = row.Table.Clone();
					}

					tableToBeSerialized.LoadDataRow(row.ItemArray, true);

					BinaryFormatter formatter = new BinaryFormatter();
					formatter.Serialize(outgoingData, tableToBeSerialized);
				}
				else if (target is DataRow[])
				{
					DataTable tableToBeSerialized = new DataTable();
					DataRow[] rows = target as DataRow[];

					if (rows != null && rows.Length > 0)
					{
						if (rows[0].Table == null)
						{
							int inc = 0;
							foreach (object item in rows[0].ItemArray)
							{
								tableToBeSerialized.Columns.Add("Column" + inc++, item.GetType());
							}
						}
						else
						{
							tableToBeSerialized = rows[0].Table.Clone();
						}

						foreach (DataRow row in rows)
						{
							tableToBeSerialized.LoadDataRow(row.ItemArray, true);
						}
					}

					BinaryFormatter formatter = new BinaryFormatter();
				}
			}
		}
	}
}
