using Syncfusion.XlsIO;
using System;
using System.Data;

namespace WebAppDemoTestFrameWork.GenericLib
{
    class SpreadsheetLightProcessor : ISpreadsheetProcessor
    {
       
        public DataTable GetDataTable(string filePath, string sheetName)
        {
            IApplication application = new ExcelEngine().Excel;
            Syncfusion.XlsIO.IWorkbook workbook = application.Workbooks.Open(filePath, Syncfusion.XlsIO.ExcelOpenType.Automatic);

            //The first worksheet object in the worksheets collection is accessed.
            Syncfusion.XlsIO.IWorksheet sheet = workbook.Worksheets[sheetName];
            //Get as DataTable
            DataTable dtExcelSheet = sheet.ExportDataTable(sheet.UsedRange, Syncfusion.XlsIO.ExcelExportDataTableOptions.ColumnNames);

            return dtExcelSheet;
        }
        public static DataTable ReadExcelData(string strInputExcel, string strTableName)
        {
            DataTable dataTable;
            try
            {
                dataTable = (new SpreadsheetLightProcessor()).GetDataTable(strInputExcel, strTableName);
            }
            catch (Exception exception1)
            {
                Exception exception = exception1;
                throw exception;
            }
            return dataTable;
        }




    }
}
