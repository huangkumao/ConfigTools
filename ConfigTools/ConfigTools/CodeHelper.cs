using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigTools
{
    public class CodeHelper
    {
        public static void GenCode(TableMeta pTableMeta, string pPath, ExportCodeType pType, ExportCfgType pCfgType)
        {
            if (pType == ExportCodeType.CSharp)
                GenCSCode(pTableMeta, pPath, pCfgType);
            else if (pType == ExportCodeType.TypeScript)
                GenTSCode(pTableMeta, pPath, pCfgType);
        }

        private static void GenCSCode(TableMeta pTableMeta, string pPath, ExportCfgType pCfgType)
        {
            string _Path = Path.Combine(pPath, pTableMeta.ClassName + ".cs");
            using (FileStream fs = new FileStream(_Path, FileMode.Create, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.WriteLine();
                    sw.WriteLine("public class {0}", pTableMeta.ClassName);
                    sw.WriteLine("{");
                    foreach (var field in pTableMeta.Fields)
                    {
                        if (!field.IsExportField(pCfgType))
                            continue;

                        sw.WriteLine("        " + field.mComment);
                        sw.WriteLine("        public {0} {1};", field.GetFieldTypeName(ExportCodeType.CSharp), field.mFieldName);
                    }
                    sw.WriteLine("}");
                }
            }
        }

        private static void GenTSCode(TableMeta pTableMeta, string pPath, ExportCfgType pCfgType)
        {

        }
    }
}
