using System;
using System.Data;
using System.IO;
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

            using (SpreadsheetDocument spreadsheetDocument = SpreadsheetDocument.Create(filePath, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = spreadsheetDocument.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet(new SheetData());

                Sheets sheets = spreadsheetDocument.WorkbookPart.Workbook.AppendChild(new Sheets());

                Sheet sheet = new Sheet()
                {
                    Id = spreadsheetDocument.WorkbookPart.GetIdOfPart(worksheetPart),
                    SheetId = 1,
                    Name = "Sheet1"
                };
                sheets.Append(sheet);

                SheetData sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();

                Stylesheet stylesheet = CreateStylesheet();
                WorkbookStylesPart stylesPart = workbookPart.AddNewPart<WorkbookStylesPart>();
                stylesPart.Stylesheet = stylesheet;
                stylesPart.Stylesheet.Save();

                Row headerRow = new Row();
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    Cell cell = new Cell();
                    cell.DataType = CellValues.String;
                    cell.CellValue = new CellValue(dataTable.Columns[i].ColumnName);
                    cell.StyleIndex = 1;
                    headerRow.AppendChild(cell);
                }
                sheetData.AppendChild(headerRow);

                for (int rowIndex = 0; rowIndex < dataTable.Rows.Count; rowIndex++)
                {
                    Row row = new Row();
                    DataRow dataRow = dataTable.Rows[rowIndex];

                    for (int colIndex = 0; colIndex < dataTable.Columns.Count; colIndex++)
                    {
                        Cell cell = new Cell();
                        object value = dataRow[colIndex];

                        if (value == null || value == DBNull.Value)
                        {
                            cell.DataType = CellValues.String;
                            cell.CellValue = new CellValue(string.Empty);
                        }
                        else if (value is DateTime)
                        {
                            DateTime dateTime = (DateTime)value;
                            cell.DataType = CellValues.String;
                            cell.CellValue = new CellValue(dateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        }
                        else if (value is bool)
                        {
                            cell.DataType = CellValues.Boolean;
                            cell.CellValue = new CellValue((bool)value);
                        }
                        else
                        {
                            cell.DataType = CellValues.String;
                            cell.CellValue = new CellValue(value.ToString());
                        }

                        row.AppendChild(cell);
                    }

                    sheetData.AppendChild(row);
                }

                worksheetPart.Worksheet.Save();
                workbookPart.Workbook.Save();
            }
        }

        private Stylesheet CreateStylesheet()
        {
            Stylesheet stylesheet = new Stylesheet();

            Fonts fonts = new Fonts();
            fonts.Count = 2;

            Font defaultFont = new Font(
                new FontSize() { Val = 11 },
                new FontName() { Val = "Calibri" }
            );
            fonts.AppendChild(defaultFont);

            Font boldFont = new Font(
                new Bold(),
                new FontSize() { Val = 11 },
                new FontName() { Val = "Calibri" }
            );
            fonts.AppendChild(boldFont);

            Fills fills = new Fills();
            fills.Count = 2;

            Fill defaultFill = new Fill(new PatternFill() { PatternType = PatternValues.None });
            fills.AppendChild(defaultFill);

            Fill grayFill = new Fill(new PatternFill() { PatternType = PatternValues.Gray125 });
            fills.AppendChild(grayFill);

            Borders borders = new Borders();
            borders.Count = 1;

            Border defaultBorder = new Border();
            borders.AppendChild(defaultBorder);

            CellStyleFormats cellStyleFormats = new CellStyleFormats();
            cellStyleFormats.Count = 1;

            CellFormat defaultCellFormat = new CellFormat() { FontId = 0, FillId = 0, BorderId = 0 };
            cellStyleFormats.AppendChild(defaultCellFormat);

            CellFormats cellFormats = new CellFormats();
            cellFormats.Count = 2;

            CellFormat normalFormat = new CellFormat() { FontId = 0, FillId = 0, BorderId = 0, FormatId = 0 };
            cellFormats.AppendChild(normalFormat);

            CellFormat headerFormat = new CellFormat() { FontId = 1, FillId = 0, BorderId = 0, FormatId = 0 };
            cellFormats.AppendChild(headerFormat);

            stylesheet.AppendChild(fonts);
            stylesheet.AppendChild(fills);
            stylesheet.AppendChild(borders);
            stylesheet.AppendChild(cellStyleFormats);
            stylesheet.AppendChild(cellFormats);

            return stylesheet;
        }
    }
}
