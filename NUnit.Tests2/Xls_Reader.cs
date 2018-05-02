using NUnit.Framework;
using System;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Formula.Functions;

namespace Automation_TestScripts
{
    [TestFixture]
    public class Xls_Reader
    {
        //   public static String filename = Environment.SystemDirectory + "RapgodataMVC.xls";
        public String path;
        public FileStream fis = null;
        private HSSFWorkbook Workbook = null;
        private HSSFSheet sheet = null;
        private HSSFRow row = null;
        private HSSFCell cell = null;


        public Xls_Reader(String path)
        {
            this.path = path;
            try
            {
                fis = new FileStream(path, FileMode.Open);
                Workbook = new HSSFWorkbook(fis);
                sheet = (HSSFSheet)Workbook.GetSheetAt(0);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + e.StackTrace);
            }

        }

        public int getRowCount(String sheetName)
        {
            int index = Workbook.GetSheetIndex(sheetName);
            if (index == -1)
                return 0;
            else
            {
                sheet = (HSSFSheet)Workbook.GetSheetAt(index);
                int number = sheet.LastRowNum + 1;
                return number;
            }

        }

        public String getCellData(String sheetName, String colName, int rowNum)
        {
            try
            {
                if (rowNum <= 0)
                    return "";

                int index = Workbook.GetSheetIndex(sheetName);
                int col_Num = -1;
                if (index == -1)
                    return "";

                sheet = (HSSFSheet)Workbook.GetSheetAt(index);
                row = (HSSFRow)sheet.GetRow(0);
                for (int i = 0; i < row.LastCellNum; i++)
                {
                    //System.out.println(row.getCell(i).getStringCellValue().trim());
                    if (row.GetCell(i).StringCellValue.Trim().Equals(colName.Trim()))
                        col_Num = i;
                }
                if (col_Num == -1)
                    return "";

                sheet = (HSSFSheet)Workbook.GetSheetAt(index);
                row = (HSSFRow)sheet.GetRow(rowNum - 1);
                if (row == null)
                    return "";
                cell = (HSSFCell)row.GetCell(col_Num);

                if (cell == null)
                    return "";
                //System.out.println(cell.getCellType());
                if (cell.CellType == CellType.String)
                    return cell.StringCellValue;
                else if (cell.CellType == CellType.Numeric || cell.CellType == CellType.Formula)
                {

                    String cellText = String.Concat(cell.NumericCellValue);
                    if (HSSFDateUtil.IsCellDateFormatted(cell))
                    {
                        // format in form of M/D/YY
                        double d = cell.NumericCellValue;

                    }



                    return cellText;
                }
                //else if (cell.getCellType() == Cell.CELL_TYPE_BLANK)
                //    return "";
                else
                    return string.Concat(cell.BooleanCellValue);

            }
            catch (Exception e)
            {

                //  e.StackTrace();
                return "row " + rowNum + " or column " + colName + " does not exist in xls";
            }
        }
        public String getCellData1(String sheetName, String colName, int rowNum)
        {
            try
            {
                if (rowNum <= 0)
                    return "";

                int index = Workbook.GetSheetIndex(sheetName);
                int col_Num = -1;
                if (index == -1)
                    return "";

                sheet = (HSSFSheet)Workbook.GetSheetAt(index);
                row = (HSSFRow)sheet.GetRow(1);
                for (int i = 0; i < row.LastCellNum; i++)
                {
                    //System.out.println(row.getCell(i).getStringCellValue().trim());
                    if (row.GetCell(i).StringCellValue.Trim().Equals(colName.Trim()))
                        col_Num = i;
                }
                if (col_Num == -1)
                    return "";

                sheet = (HSSFSheet)Workbook.GetSheetAt(index);
                row = (HSSFRow)sheet.GetRow(rowNum - 1);
                if (row == null)
                    return "";
                cell = (HSSFCell)row.GetCell(col_Num);

                if (cell == null)
                    return "";
                //System.out.println(cell.getCellType());
                if (cell.CellType == CellType.String)
                    return cell.StringCellValue;
                else if (cell.CellType == CellType.Numeric || cell.CellType == CellType.Formula)
                {

                    String cellText = String.Concat(cell.NumericCellValue);
                    if (HSSFDateUtil.IsCellDateFormatted(cell))
                    {
                        // format in form of M/D/YY
                        double d = cell.NumericCellValue;

                    }



                    return cellText;
                }
                //else if (cell.getCellType() == Cell.CELL_TYPE_BLANK)
                //    return "";
                else
                    return string.Concat(cell.BooleanCellValue);

            }
            catch (Exception e)
            {

                //  e.StackTrace();
                return "row " + rowNum + " or column " + colName + " does not exist in xls";
            }
        }

        // returns the data from a cell
        public String getCellData(String sheetName, int colNum, int rowNum)
        {
            try
            {
                if (rowNum <= 0)
                    return "";

                int index = Workbook.GetSheetIndex(sheetName);

                if (index == -1)
                    return "";


                sheet = (HSSFSheet)Workbook.GetSheetAt(index);
                row = (HSSFRow)sheet.GetRow(rowNum - 1);
                if (row == null)
                    return "";
                cell = (HSSFCell)row.GetCell(colNum);
                if (cell == null)
                    return "";

                if (cell.CellType == CellType.String)
                    return cell.StringCellValue;
                else if (cell.CellType == CellType.Numeric || cell.CellType == CellType.Formula)
                {

                    String cellText = String.Concat(cell.NumericCellValue);
                    if (HSSFDateUtil.IsCellDateFormatted(cell))
                    {
                        // format in form of M/D/YY
                        double d = cell.NumericCellValue;

                        //Calendar cal = Calendar.getInstance();
                        //cal.setTime(HSSFDateUtil.getJavaDate(d));
                        //cellText =
                        // (String.valueOf(cal.get(Calendar.YEAR))).substring(2);
                        //cellText = cal.get(Calendar.MONTH) + 1 + "/" +
                        //           cal.get(Calendar.DAY_OF_MONTH) + "/" +
                        //           cellText;

                        // System.out.println(cellText);

                        // create a new cell style from the workbook otherwise you can end up
                        // modifying the built in style and effecting not only this cell but other cells.


                    }



                    return cellText;
                }
                else if (cell.CellType == CellType.Blank)
                    return "";
                else
                    return String.Concat(cell.BooleanCellValue);
            }
            catch (Exception e)
            {

                //e.StackTrace;
                return "row " + rowNum + " or column " + colNum + " does not exist  in xls";
            }
        }
        // returns number of columns in a sheet	
        public int getColumnCount(String sheetName)
        {
            // check if sheet exists
            // if (!isSheetExist(sheetName))
            //   return -1;

            sheet = (HSSFSheet)Workbook.GetSheet(sheetName);
            row = (HSSFRow)sheet.GetRow(0);

            if (row == null)
                return -1;

            return row.LastCellNum;
        }
        private void writevalue(String value)
        {
            HSSFWorkbook wb1 = null;
            using (var file = new FileStream(@"D:\Anand\writehours.xls", FileMode.Open, FileAccess.ReadWrite))
            {
                wb1 = new HSSFWorkbook(file);
            }
            wb1.GetSheetAt(0).GetRow(0).GetCell(0).SetCellValue(value);

            using (var file2 = new FileStream(@"D:\Anand\writehours.xls", FileMode.Create, FileAccess.ReadWrite))
            {
                wb1.Write(file2);
                file2.Close();
            }
        }
        public int getCellRowNum(String sheetName, String colName, String cellValue)
        {

            for (int i = 2; i <= getRowCount(sheetName); i++)
            {
                if (getCellData(sheetName, colName, i).Equals(cellValue))
                {
                    return i;
                }
            }
            return -1;

        }
        public  void setCellData(String Result, int rowNum, String colName) 
        {
         try{
                
                int index = Workbook.GetSheetIndex("Sheet1");
                int col_Num = -1;
               
                sheet = (HSSFSheet)Workbook.GetSheetAt(index);
                row = (HSSFRow)sheet.GetRow(0);
                for (int i = 0; i <row.LastCellNum; i++)
                {
                    //System.out.println(row.getCell(i).getStringCellValue().trim());
                    if (row.GetCell(i).StringCellValue.Trim().Equals(colName.Trim()))
                        col_Num = i;
                }
           
                sheet = (HSSFSheet)Workbook.GetSheetAt(rowNum);
                row = (HSSFRow)sheet.GetRow(rowNum);
              
                cell = (HSSFCell)row.GetCell(col_Num);
                if (cell == null)
                {
                    cell.SetCellValue(Result);
                }
                else
                {

                    cell = (HSSFCell)row.CreateCell(col_Num);
                    cell.SetCellValue(Result);
                    // Forcing formula recalculation...
                    sheet.ForceFormulaRecalculation = true;

                    MemoryStream ms = new MemoryStream();

                    // Writing the workbook content to the FileStream...
                    Workbook.Write(ms);
                    //FileStream.Flush();

                }
            }
            catch(Exception t)
         {
        	 //
         }
}

    
}
}
