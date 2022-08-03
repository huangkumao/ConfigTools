using System;
using System.Data;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace ConfigTools
{
    public class ExcelHelper
    {
        public static int sPostilRow = 0;//批注
        public static int sCommentRow = 1; //字段注释 0
        public static int sFieldRow = 2; //字段名字 1
        public static int sTypeRow = 3; //字段类型 2
        public static int sExportRow = 4; //导出类型 3

        public static DataTable ImportExcelFile(string filePath)
        {
            IWorkbook hssfworkbook;
            try
            {
                using (var file = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    hssfworkbook = new XSSFWorkbook(file);
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            var sheet = hssfworkbook.GetSheetAt(0);
            var rows = sheet.GetRowEnumerator();

            var dt = new DataTable();
            var row0 = sheet.GetRow(0);
            for (int j = row0.FirstCellNum; j < row0.LastCellNum; j++)
                dt.Columns.Add(row0.GetCell(j).ToString());

            bool NeedComment = true;
            DataRow comDR = null;
            while (rows.MoveNext())
            {
                IRow row = (XSSFRow) rows.Current;
                var dr = dt.NewRow();
                if (NeedComment)
                    comDR = dt.NewRow();

                for (var i = 0; i < row.LastCellNum; i++)
                {
                    var cell = row.GetCell(i);
                    if (cell == null)
                    {
                        dr[i] = null;
                        if (NeedComment)
                            comDR[i] = "";
                    }
                    else
                    {
                        dr[i] = cell.ToString();
                        if (NeedComment)
                        {
                            if(cell.CellComment != null)
                                comDR[i] = cell.CellComment.String;
                            else
                                comDR[i] = "";
                        }
                    }
                }

                if (NeedComment)
                    dt.Rows.Add(comDR);
                dt.Rows.Add(dr);
                NeedComment = false;
            }

//            for (var i = 0; i < dt.Rows.Count; i++)
//            {
//                for (var j = 0; j < dt.Columns.Count; j++)
//                    Console.Write(@"|" + dt.Rows[i].ItemArray[j]);
//                Console.WriteLine();
//            }

            return dt;
        }

        public static TableMeta ParseTableMeta(string pFileName, DataTable pDT, ExportCfgType pExpType)
        {
            var meta = new TableMeta {TableName = pFileName};

            for (var i = 0; i < pDT.Columns.Count; i++)
            {
                var field = new TableField
                {
                    mSpostil = pDT.Rows[sPostilRow].ItemArray[i] + "",
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