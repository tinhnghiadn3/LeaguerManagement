using ClosedXML.Excel;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LeaguerManagement.Entities.ViewModels;

namespace LeaguerManagement.Entities.Utilities.Helper
{
    public static class ExcelHelper
    {
        public static IXLWorksheet GetWorkSheet(this XLWorkbook workbook, string sheetName)
        {
            // name of Sheet in excel file
            var worksheet = workbook.Worksheet(sheetName);
            // set FontName
            worksheet.Style.Font.FontName = "Times New Roman";
            return worksheet;
        }

        public static void PrintCellsValue<T>(this IXLWorksheet worksheet, T model, int printedRow, int totalColumns, int? indexRow = null, int printedColumn = 2)
        {
            var myType = model.GetType();
            var props = new List<PropertyInfo>(myType.GetProperties());

            worksheet.GenerateRowAndStyling(printedRow, totalColumns);
            if (indexRow != null)
                worksheet.Cell(printedRow, 1).Value = indexRow;

            var j = printedColumn;
            foreach (var propValue in props.Select(prop => prop.GetValue(model, null)))
            {
                // ignore index column
                worksheet.Cell(printedRow, j).Value = propValue;
                j++;
            }
            System.Threading.Thread.Sleep(300);
        }

        public static void GenerateRowAndStyling(this IXLWorksheet worksheet, int currentRow, int totalColumns, bool isFontBold = false)
        {
            worksheet.Row(currentRow).Style.Font.FontName = "Times New Roman";
            worksheet.Row(currentRow).Style.Font.Bold = isFontBold;
            worksheet.Row(currentRow).Style.Font.SetFontSize(13);
            worksheet.Row(currentRow).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Row(currentRow).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

            for (var i = 1; i <= totalColumns; i++)
            {
                worksheet.Cell(currentRow, i).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(currentRow, i).Style.Border.RightBorderColor = XLColor.Black;
                worksheet.Cell(currentRow, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                worksheet.Cell(currentRow, i).Style.Border.BottomBorderColor = XLColor.Black;
            }

            System.Threading.Thread.Sleep(300);
        }

        public static void GenerateFooterAndRestyling(this IXLWorksheet worksheet, int mergedRow, int totalCells, List<MergeCellModel> mergeCells, IList<int> ignoredColumns)
        {
            worksheet.AlignCenter(totalCells, ignoredColumns);
            // add border bottom for last row
            worksheet.BorderLastRow(mergedRow, totalCells);
            // insert cell for footer
            if (!mergeCells.Any()) return;
            mergeCells.ForEach(mergeCell =>
            {
                worksheet.GenerateMergeCell(mergedRow + 3, mergeCell);
            });
            // set font-size
            worksheet.Row(mergedRow + 2).Style.Font.FontSize = 13;
            worksheet.Row(mergedRow + 3).Style.Font.FontSize = 13;
        }

        private static void BorderLastRow(this IXLWorksheet worksheet, int currentRow, int totalCells)
        {
            for (var i = 1; i <= totalCells; i++)
            {
                worksheet.Cell(currentRow, i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            }
        }

        public static void GenerateMergeCell(this IXLWorksheet worksheet, int row, MergeCellModel mergeCell)
        {
            worksheet.Cell(row, mergeCell.From).Value = mergeCell.Text;
            worksheet.Cell(row, mergeCell.From).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(row, mergeCell.From).Style.Font.Bold = mergeCell.IsFontBold;
            // merge cell
            worksheet.Range(worksheet.Cell(row, mergeCell.From), worksheet.Cell(row, mergeCell.To)).Merge();
        }


        public static void GenerateTitleHeader(this IXLWorksheet worksheet, int row, int column, string text)
        {
            worksheet.Cell(row, column).Value = text;
            worksheet.Cell(row, column).Style.Alignment.WrapText = true;
        }

        private static void AlignCenter(this IXLWorksheet worksheet, int totalCells, IList<int> ignoredColumns)
        {
            for (var i = 1; i <= totalCells; i++)
            {
                // align center for all column except 2
                if (ignoredColumns.All(_ => _ != i))
                    worksheet.Column(i).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            }
        }
    }
}
