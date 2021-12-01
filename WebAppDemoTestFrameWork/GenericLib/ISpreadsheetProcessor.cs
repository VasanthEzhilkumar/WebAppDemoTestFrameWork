using System.Data;

namespace WebAppDemoTestFrameWork.GenericLib
{
    interface ISpreadsheetProcessor
    {
        DataTable GetDataTable(string filePath, string sheetName);


    }
}
