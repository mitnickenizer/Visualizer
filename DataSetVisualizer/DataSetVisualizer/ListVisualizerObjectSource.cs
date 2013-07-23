using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Microsoft.VisualStudio.DebuggerVisualizers;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.Reflection;
using System.ComponentModel.Design;

namespace DataSetVisualizer
{
	class ListVisualizerObjectSource : VisualizerObjectSource
	{
		private List<object> ConvertToObjectList<T>(List<T> Source)
		{
			List<object> returnList = new List<object>();
			return returnList;
		}
		public override void GetData(object target, System.IO.Stream outgoingData)
		{
			if (target != null)
			{
				DataSet tempSet = new DataSet();
				DataTable workingTable = null;
				if (target is List<int>)
				{
					IEnumerable<int> tempList = target as IEnumerable<int>;
					workingTable = new DataTable();
					workingTable.Columns.Add("Int", typeof(int));
					workingTable.AcceptChanges();
					foreach (int item in tempList)
					{
						DataRow newRow = workingTable.NewRow();
						newRow[0] = item;
						workingTable.Rows.Add(newRow);
					}
					workingTable.AcceptChanges();
					tempSet.Tables.Add(workingTable);
				}
				else if (target is IEnumerable<string>)
				{
					IEnumerable<string> tempList = target as IEnumerable<string>;
					workingTable = new DataTable();
					workingTable.Columns.Add("String", typeof(string));
					workingTable.AcceptChanges();
					foreach (string item in tempList)
					{
						DataRow newRow = workingTable.NewRow();
						newRow[0] = item;
						workingTable.Rows.Add(newRow);
					}
					workingTable.AcceptChanges();
					tempSet.Tables.Add(workingTable);
				}
				else if (target is IEnumerable<decimal>)
				{
					IEnumerable<decimal> tempList = target as IEnumerable<decimal>;
					workingTable = new DataTable();
					workingTable.Columns.Add("Decimal", typeof(decimal));
					workingTable.AcceptChanges();
					foreach (decimal item in tempList)
					{
						DataRow newRow = workingTable.NewRow();
						newRow[0] = item;
						workingTable.Rows.Add(newRow);
					}
					workingTable.AcceptChanges();
					tempSet.Tables.Add(workingTable);
				}
				else if (target is IEnumerable<double>)
				{
					IEnumerable<double> tempList = target as IEnumerable<double>;
					workingTable = new DataTable();
					workingTable.Columns.Add("Double", typeof(double));
					workingTable.AcceptChanges();
					foreach (double item in tempList)
					{
						DataRow newRow = workingTable.NewRow();
						newRow[0] = item;
						workingTable.Rows.Add(newRow);
					}
					workingTable.AcceptChanges();
					tempSet.Tables.Add(workingTable);
				}
				else if (target is IEnumerable<char>)
				{
					IEnumerable<char> tempList = target as IEnumerable<char>;
					workingTable = new DataTable();
					workingTable.Columns.Add("Char", typeof(char));
					workingTable.AcceptChanges();
					foreach (char item in tempList)
					{
						DataRow newRow = workingTable.NewRow();
						newRow[0] = item;
						workingTable.Rows.Add(newRow);
					}
					workingTable.AcceptChanges();
					tempSet.Tables.Add(workingTable);
				}
				#region object
				else if (target is IEnumerable)
				{
					List<object> tempList = new List<object>();
					
					foreach (object sourceObject in target as IEnumerable)
					{
						tempList.Add(sourceObject);
					}

					if (tempList.Count > 0)
					{
						foreach (object objectItem in tempList)
						{
							Type targetType = objectItem.GetType();
							FieldInfo[] fields = targetType.GetFields();
							if (tempSet.Tables.Contains(targetType.FullName))
							{
								workingTable = tempSet.Tables[targetType.FullName];
							}
							else
							{
								workingTable = new DataTable(targetType.FullName);
								tempSet.Tables.Add(workingTable);
								for (int i = 0; i < fields.Length; ++i)
								{
									if (!fields[i].IsPublic)
										continue;

									DataColumn column = null;
									if (fields[i].FieldType == typeof(string))
									{
										column = new DataColumn(fields[i].Name, typeof(string));
									}
									else if (fields[i].FieldType == typeof(int) || fields[i].FieldType == typeof(Enum))
									{
										column = new DataColumn(fields[i].Name, typeof(int));
									}
									else if (fields[i].FieldType == typeof(double))
									{
										column = new DataColumn(fields[i].Name, typeof(double));
									}
									else if (fields[i].FieldType == typeof(decimal))
									{
										column = new DataColumn(fields[i].Name, typeof(decimal));
									}
									else
									{
										column = new DataColumn(fields[i].Name, typeof(string));
									}

									workingTable.Columns.Add(column);
								}
								workingTable.AcceptChanges();
							}

							DataRow newRow = workingTable.NewRow();
							for (int i = 0; i < fields.Length; ++i)
							{
								if (!fields[i].IsPublic)
									continue;

								if (fields[i].FieldType == typeof(string))
								{
									newRow[fields[i].Name] = fields[i].GetValue(objectItem).ToString();
								}
								else if (fields[i].FieldType == typeof(int) || fields[i].FieldType == typeof(Enum))
								{
									newRow[fields[i].Name] = (int)fields[i].GetValue(objectItem);
								}
								else if (fields[i].FieldType == typeof(double))
								{
									newRow[fields[i].Name] = (double)fields[i].GetValue(objectItem);
								}
								else if (fields[i].FieldType == typeof(decimal))
								{
									newRow[fields[i].Name] = (decimal)fields[i].GetValue(objectItem);
								}
								else
								{
									newRow[fields[i].Name] = fields[i].GetValue(objectItem).ToString();
								}
							}

							workingTable.Rows.Add(newRow);
							workingTable.AcceptChanges();
						}
					}
				}
				#endregion
				BinaryFormatter formatter = new BinaryFormatter();
				formatter.Serialize(outgoingData, tempSet);
			}
		}
	}
}
