using App.Data;
using App.Data.Models.QTHT;
using AutoMapper;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using TemplateEngine.Docx;

namespace App.Business.Base
{
    public class CommonUtils
    {
        public static void SetStyleExcel(ref ExcelWorksheet sheet, List<ClsExcel> lstValue)
        {
            List<ExcelRange> lstMerge = new List<ExcelRange>();

            foreach (var item in lstValue)
            {

                sheet.Cells[item.row, item.cell].Value = item.values;
                sheet.Cells[item.row, item.cell].Style.Font.Size = item.fontSize;
                sheet.Cells[item.row, item.cell].Style.Font.Name = item.fontName;
                sheet.Cells[item.row, item.cell].Style.Font.Bold = item.isBold;

                if (item.isBorder)
                {
                    sheet.Cells[item.row, item.cell].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    sheet.Cells[item.row, item.cell].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    sheet.Cells[item.row, item.cell].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    sheet.Cells[item.row, item.cell].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }
                sheet.Cells[item.row, item.cell].AutoFitColumns();

                sheet.Cells[item.row, item.cell].Style.HorizontalAlignment = item.horAlign;
                sheet.Cells[item.row, item.cell].Style.VerticalAlignment = item.verAlign;
                //sheet.Cells[item.row, item.cell].Style.Fill.BackgroundColor.SetColor(item.color);

                if (item.isMersg)
                {
                    sheet.Cells[item.firstRow, item.firstCol, item.lastRow, item.lastCol].Merge = true;

                    if (item.isBorder)
                    {
                        sheet.Cells[item.firstRow, item.firstCol, item.lastRow, item.lastCol].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                        sheet.Cells[item.firstRow, item.firstCol, item.lastRow, item.lastCol].Style.Border.Left.Style = ExcelBorderStyle.Thin;
                        sheet.Cells[item.firstRow, item.firstCol, item.lastRow, item.lastCol].Style.Border.Right.Style = ExcelBorderStyle.Thin;
                        sheet.Cells[item.firstRow, item.firstCol, item.lastRow, item.lastCol].Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                    }
                    sheet.Cells[item.firstRow, item.firstCol, item.lastRow, item.lastCol].AutoFitColumns();
                    if (item.isWrapText)
                    {
                        sheet.Cells[item.firstRow, item.firstCol, item.lastRow, item.lastCol].Style.WrapText = true;
                    }
                }
                if (item.isWrapText)
                {
                    sheet.Cells[item.row, item.cell].Style.WrapText = true;
                }
            }
            for (int col = 1; col <= sheet.Dimension.End.Column; col++)
            {
                if (lstValue.FindIndex(x => x.cell == col && x.width > 0) != -1)
                    sheet.Column(col).Width = (double)lstValue.FirstOrDefault(x => x.cell == col && x.width > 0).width;
                else
                    sheet
                        .Column(col).Width = sheet.Column(col).Width + 1;
            }
        }
    }
    public class ClsExcel
    {
        public bool isHeader { get; set; }
        public bool isBold { get; set; }
        public int row { get; set; }
        public int cell { get; set; }
        public object values { get; set; }
        public bool isBorder { get; set; }
        public bool isMersg { get; set; }
        public int firstRow { get; set; }
        public int lastRow { get; set; }
        public int firstCol { get; set; }
        public int lastCol { get; set; }
        public int fontSize { get; set; }
        public string fontName { get; set; }
        public bool isWrapText { get; set; }
        public ExcelHorizontalAlignment horAlign { get; set; }
        public ExcelVerticalAlignment verAlign { get; set; }
        public double width { get; set; }
        public object color { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="cell"></param>
        /// <param name="values"></param>
        /// <param name="horAlign"></param>
        /// <param name="verAlign"></param>
        /// <param name="isHeader"></param>
        /// <param name="isBold"></param>
        /// <param name="isBorder"></param>
        /// <param name="isWrapText"></param>
        /// <param name="fontSize"></param>
        /// <param name="fontName"></param>
        /// <param name="isMersg"></param>
        /// <param name="firstRow"></param>
        /// <param name="lastRow"></param>
        /// <param name="firstCol"></param>
        /// <param name="lastCol"></param>
        /// <param name="width"></param>
        /// <param name="color"></param>
        public ClsExcel(int row, int cell, object values, ExcelHorizontalAlignment horAlign = ExcelHorizontalAlignment.Left, ExcelVerticalAlignment verAlign = ExcelVerticalAlignment.Center, bool isHeader = false, bool isBold = false, bool isBorder = true, bool isWrapText = false, int fontSize = 12, string fontName = "Times New Roman", bool isMersg = false, int firstRow = 0, int lastRow = 0, int firstCol = 0, int lastCol = 0, double width = 0, object color = null)
        {
            this.row = row;
            this.cell = cell;
            this.values = values;
            this.isMersg = isMersg;
            this.firstRow = firstRow;
            this.lastRow = lastRow;
            this.firstCol = firstCol;
            this.lastCol = lastCol;
            this.fontSize = fontSize;
            this.isBorder = isBorder;
            this.isBold = isBold;
            this.isHeader = isHeader;
            this.isWrapText = isWrapText;
            this.verAlign = verAlign;
            this.horAlign = horAlign;
            this.fontName = fontName;
            this.width = width;
            this.color = color;

        }
    }
    public class objMessage
    {
        public string message { get; set; }
        public bool error { get; set; }
        public objMessage() { }
        public objMessage(bool stt = false, string mes = "")
        {
            message = mes;
            error = stt;
        }
    }
    public class CauHinhExport
    {
        public int index { get; set; }
        public string value { get; set; }
        public string align { get; set; }
        public double width { get; set; }

        public int colSpan { get; set; }
        public int rowSpan { get; set; }

    }
    public class CellValue
    {

        public object value { get; set; }
        public ExcelHorizontalAlignment alignH { get; set; }


    }
}
