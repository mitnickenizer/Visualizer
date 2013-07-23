using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using Microsoft.VisualStudio.DebuggerVisualizers;
using System.Windows.Forms;
using System.Data;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.IO;
using System.Reflection;
using System.ComponentModel.Design;
using DataSetVisualizer;
using DataSetVisualizer.ObjectSource;
using DataSetVisualizer.Forms;


[assembly: System.Diagnostics.DebuggerVisualizer(
			typeof(ListVisualizer),
			typeof(ListVisualizerObjectSource),
			Target = typeof(List<>),
			Description = "My List Visualizer")]

namespace DataSetVisualizer 
{
	public class ListVisualizer : DialogDebuggerVisualizer
	{
		protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
		{
			DSVisualizer myVisualizer = new DSVisualizer();
			Thread loadDataThread = new Thread(() =>
				{
					try
					{
						Stream myObjectStream = objectProvider.GetData();
						BinaryFormatter formatter = new BinaryFormatter();
						DataSet tempSet = (System.Data.DataSet)formatter.Deserialize(myObjectStream);
						//Visualizer myVisualizer = new Visualizer(tempTable);
						myVisualizer.NewDataSetPosted(tempSet);
					}
					catch (Exception)
					{
						try
						{
							Stream myObjectStream = objectProvider.GetData();
							BinaryFormatter formatter = new BinaryFormatter();
							object target = formatter.Deserialize(myObjectStream);
							if (target != null)
							{
								DataSet tempSet = new DataSet();
								DataTable workingTable = null;
								if (target is IEnumerable<int>)
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

								myVisualizer.NewDataSetPosted(tempSet);
							}

						}
						catch (Exception)
						{
							MessageBox.Show("Could not load please try using the standard debugger visualizer");
						}
						
					}
				});
			loadDataThread.Start();
			windowService.ShowDialog((Form)myVisualizer);
		}
	}
}
