
using System.Data;
using System.IO;
using System.Text;

namespace ConfigTools
{
    public class CfgHelper
    {
        public static string JsonHead = "{";
        public static string JsonTail = "}";

        public static string JsonDataBegin = @"  {";
        public static string JsonDataEnd = @"   }";

        public static string JsonDataName_1 = "  \"mDataMap\":{"; //以Map形式保存
        public static string JsonDataName_2 = "  \"mDataList\":["; //以List形式保存

        public static void GenCfg(DataTable pDT, string pPath, TableMeta pTableMeta, ExportCfgType pCfgType)
        {
            var _Path = Path.Combine(pPath, pTableMeta.ClassName + ".json");
            var isMap = pTableMeta.CheckTypeIsMap(); //只有第一个字段是"ID"才会以Map形式保存
            using (var fs = new FileStream(_Path, FileMode.Create, FileAccess.Write))
            {
                using (var sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.WriteLine(JsonHead);
                    sw.WriteLine(isMap ? JsonDataName_1 : JsonDataName_2);

                    for (var iRow = 4; iRow < pDT.Rows.Count; iRow++)
                    {
                        if (isMap)
                            sw.Write("  \"{0}\":", pDT.Rows[iRow].ItemArray[0]);
                        sw.WriteLine(JsonDataBegin);
                        for (var iCol = 0; iCol < pDT.Columns.Count; iCol++)
                        {
                            if (!pTableMeta.Fields[iCol].IsExportField(pCfgType))
                                continue;

                            if (iCol != 0)
                                sw.WriteLine(",");
                            sw.Write("    \"{0}\":", pTableMeta.Fields[iCol].mFieldName);
                            var _D = pDT.Rows[iRow].ItemArray[iCol].ToString();
                            if (pTableMeta.Fields[iCol].mTypeName == "int")
                                sw.Write(ParseInt(_D));
                            else
                            if (pTableMeta.Fields[iCol].mTypeName == "float")
                                sw.Write(ParseFloat(_D));
                            else
                            if (pTableMeta.Fields[iCol].mTypeName == "string")
                                sw.Write(ParseString(_D));
                            else
                            if (pTableMeta.Fields[iCol].mTypeName == "bool")
                                sw.Write(ParseBool(_D));
                            else
                            if (pTableMeta.Fields[iCol].mTypeName == "int+")
                                sw.Write(ParseIntList(_D));
                            else
                            if (pTableMeta.Fields[iCol].mTypeName == "float+")
                                sw.Write(ParseFloatList(_D));
                            else
                            if (pTableMeta.Fields[iCol].mTypeName == "string+")
                                sw.Write(ParseStringList(_D));
                        }
                        sw.WriteLine();
                        sw.Write(JsonDataEnd);
                        if (iRow != pDT.Rows.Count - 1)
                            sw.WriteLine(",");
                        else
                            sw.WriteLine();
                    }

                    sw.WriteLine(isMap ? "  }" : "  ]");
                    sw.WriteLine(JsonTail);
                }
            }
        }

        public static string ParseInt(object pObj)
        {
            return pObj.ToString();
        }

        public static string ParseFloat(object pObj)
        {
            return pObj.ToString();
        }

        public static string ParseString(object pObj)
        {
            return $"\"{pObj}\"";
        }

        public static string ParseBool(object pObj)
        {
            if (pObj.ToString() == "0")
                return "false";
            return "true";
        }

        public static string ParseIntList(object pObj)
        {
            var strTemp = pObj.ToString().Replace("\n", "");
            if (strTemp.Trim().Length <= 0)
                return "null";

            var strData = "[\r\n";
            strData += "            ";
            var endwithsem = false;
            var lastdel = strTemp.LastIndexOf(';');
            if (lastdel == strTemp.Length - 1)
                endwithsem = true;

            for (var i = 0; i < strTemp.Length; ++i)
                if (strTemp[i] == ';')
                    if (endwithsem && (i == lastdel))
                    {
                    }
                    else
                    {
                        strData += ",\r\n";
                        strData += "            ";
                    }
                else
                    strData += strTemp[i];

            strData += "\r\n         ]";
            return strData;
        }

        public static string ParseFloatList(object pObj)
        {
            return ParseIntList(pObj);
        }

        public static string ParseStringList(object pObj)
        {
            string strData = "[\r\n";
            string strTemp = pObj.ToString().Replace("\n", "");
            if (strTemp.Trim().Length <= 0)
            {
                return "null";
            }

            string[] strArray = strTemp.Split(';');
            for (int i = 0; i < strArray.Length; ++i)
            {
                if (strArray[i].Trim().Length > 0)
                {
                    if (i != 0)
                    {
                        strData += ",\r\n";
                    }

                    strData += "            \"" + strArray[i] + "\"";
                }
            }

            strData += "\r\n         ]";
            return strData;
        }
    }
}