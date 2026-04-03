using System;
using System.Data;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace ExportTool
{
    public class ExcelExporter
    {
        public void Export(string filePath, DataTable dataTable)
        {
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                throw new ArgumentException("没有数据可以导出");
            }

            try
            {
                using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
                {
                    WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
                    workbookPart.Workbook = new Workbook();

                    WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();

                    Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                    Sheet sheet = new Sheet()
                    {
                        Id = workbookPart.GetIdOfPart(worksheetPart),
                        SheetId = 1,
                        Name = "Sheet1"
                    };
                    sheets.Append(sheet);

                    SharedStringTablePart sstPart = workbookPart.AddNewPart<SharedStringTablePart>();
                    sstPart.SharedStringTable = new SharedStringTable();
                    Dictionary<string, int> sharedStringMap = new Dictionary<string, int>();
                    int sharedStringCount = 0;

                    using (Stream stream = worksheetPart.GetStream(FileMode.Create, FileAccess.Write))
                    using (XmlWriter writer = XmlWriter.Create(stream))
                    {
                        writer.WriteStartDocument();
                        writer.WriteStartElement("worksheet", "http://schemas.openxmlformats.org/spreadsheetml/2006/main");
                        writer.WriteStartElement("sheetData");

                        writer.WriteStartElement("row");
                        for (int colIndex = 0; colIndex < dataTable.Columns.Count; colIndex++)
                        {
                            string columnName = dataTable.Columns[colIndex].ColumnName;
                            int sstIndex = GetSharedStringIndex(sharedStringMap, sstPart.SharedStringTable, columnName, ref sharedStringCount);
                            writer.WriteStartElement("c");
                            writer.WriteAttributeString("t", "s");
                            writer.WriteStartElement("v");
                            writer.WriteString(sstIndex.ToString());
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();

                        int totalRows = dataTable.Rows.Count;

                        for (int rowIndex = 0; rowIndex < totalRows; rowIndex++)
                        {
                            DataRow dataRow = dataTable.Rows[rowIndex];

                            writer.WriteStartElement("row");

                            for (int colIndex = 0; colIndex < dataTable.Columns.Count; colIndex++)
                            {
                                object value = dataRow[colIndex];

                                if (value == null || value == DBNull.Value)
                                {
                                    writer.WriteStartElement("c");
                                    writer.WriteEndElement();
                                }
                                else if (value is DateTime)
                                {
                                    string dateStr = ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
                                    if (dateStr.Length <= 50)
                                    {
                                        int sstIndex = GetSharedStringIndex(sharedStringMap, sstPart.SharedStringTable, dateStr, ref sharedStringCount);
                                        writer.WriteStartElement("c");
                                        writer.WriteAttributeString("t", "s");
                                        writer.WriteStartElement("v");
                                        writer.WriteString(sstIndex.ToString());
                                        writer.WriteEndElement();
                                        writer.WriteEndElement();
                                    }
                                    else
                                    {
                                        writer.WriteStartElement("c");
                                        writer.WriteAttributeString("t", "inlineStr");
                                        writer.WriteStartElement("is");
                                        writer.WriteStartElement("t");
                                        writer.WriteString(dateStr);
                                        writer.WriteEndElement();
                                        writer.WriteEndElement();
                                        writer.WriteEndElement();
                                    }
                                }
                                else if (value is bool)
                                {
                                    writer.WriteStartElement("c");
                                    writer.WriteAttributeString("t", "b");
                                    writer.WriteStartElement("v");
                                    writer.WriteString(((bool)value) ? "1" : "0");
                                    writer.WriteEndElement();
                                    writer.WriteEndElement();
                                }
                                else if (value is int || value is long || value is short || value is byte)
                                {
                                    writer.WriteStartElement("c");
                                    writer.WriteAttributeString("t", "n");
                                    writer.WriteStartElement("v");
                                    writer.WriteString(value.ToString());
                                    writer.WriteEndElement();
                                    writer.WriteEndElement();
                                }
                                else if (value is decimal || value is double || value is float)
                                {
                                    writer.WriteStartElement("c");
                                    writer.WriteAttributeString("t", "n");
                                    writer.WriteStartElement("v");
                                    writer.WriteString(Convert.ToDouble(value).ToString());
                                    writer.WriteEndElement();
                                    writer.WriteEndElement();
                                }
                                else
                                {
                                    string strValue = value.ToString();
                                    if (strValue.Length <= 50)
                                    {
                                        int sstIndex = GetSharedStringIndex(sharedStringMap, sstPart.SharedStringTable, strValue, ref sharedStringCount);
                                        writer.WriteStartElement("c");
                                        writer.WriteAttributeString("t", "s");
                                        writer.WriteStartElement("v");
                                        writer.WriteString(sstIndex.ToString());
                                        writer.WriteEndElement();
                                        writer.WriteEndElement();
                                    }
                                    else
                                    {
                                        writer.WriteStartElement("c");
                                        writer.WriteAttributeString("t", "inlineStr");
                                        writer.WriteStartElement("is");
                                        writer.WriteStartElement("t");
                                        writer.WriteString(strValue);
                                        writer.WriteEndElement();
                                        writer.WriteEndElement();
                                        writer.WriteEndElement();
                                    }
                                }
                            }

                            writer.WriteEndElement();
                        }

                        writer.WriteEndElement();
                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                    }

                    sstPart.SharedStringTable.Save();
                    workbookPart.Workbook.Save();
                }
            }
            catch
            {
                if (File.Exists(filePath))
                {
                    try
                    {
                        File.Delete(filePath);
                    }
                    catch { }
                }
                throw;
            }
        }

        private int GetSharedStringIndex(Dictionary<string, int> map, SharedStringTable sst, string text, ref int count)
        {
            if (map.TryGetValue(text, out int index))
            {
                return index;
            }
            SharedStringItem newItem = new SharedStringItem(new Text(text));
            sst.AppendChild(newItem);
            map[text] = count;
            return count++;
        }
    }
}
