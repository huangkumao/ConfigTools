using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace ConfigTools
{
    public class ExcelHelper
    {
        public static int sCommentRow = 0;//字段注释 0
        public static int sFieldRow = 1;//字段名字 1
        public static int sTypeRow = 2;//字段类型 2
        public static int sExportRow = 3;//导出类型 3

        public static DataTable ImportExcelFile(string filePath)
        {
            IWorkbook hssfworkbook;
            try
            {
                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    hssfworkbook = new XSSFWorkbook(file);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            ISheet sheet = hssfworkbook.GetSheetAt(0);
            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            DataTable dt = new DataTable();
            IRow row0 = sheet.GetRow(0);
            for (int j = row0.FirstCellNum; j < (row0.LastCellNum); j++)
            {
                dt.Columns.Add(row0.GetCell(j).ToString());
            }

            while (rows.MoveNext())
            {
                IRow row = (XSSFRow)rows.Current;
                DataRow dr = dt.NewRow();

                for (int i = 0; i < row.LastCellNum; i++)
                {
                    ICell cell = row.GetCell(i);
                    if (cell == null)
                    {
                        dr[i] = null;
                    }
                    else
                    {
                        dr[i] = cell.ToString();
                    }
                }
                dt.Rows.Add(dr);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Console.Write(@"|" + dt.Rows[i].ItemArray[j]);
                }
                Console.WriteLine();
            }

            return dt;
        }

        public static TableMeta ParseTableMeta(string pFileName, DataTable pDT, ExportCfgType pExpType)
        {
            TableMeta meta = new TableMeta {TableName = pFileName };
            //字段注释 0
            //字段名字 1
            //字段类型 2
            //导出类型 3
            for (int i = 0; i < pDT.Columns.Count; i++)
            {
                TableField field = new TableField
                {
                    mComment = @"//" + pDT.Rows[sCommentRow].ItemArray[i],
                    mFieldName = pDT.Rows[sFieldRow].ItemArray[i].ToString(),
                    mTypeName = pDT.Rows[sTypeRow].ItemArray[i].ToString(),
                    mExportType = pDT.Rows[sExportRow].ItemArray[i].ToString()
                }; 

                meta.Fields.Add(field);
            }
            return meta;
        }
    }
}
