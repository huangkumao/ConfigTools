using System.IO;
using System.Text;

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
            var _Path = Path.Combine(pPath, pTableMeta.ClassName + ".cs");
            using (var fs = new FileStream(_Path, FileMode.Create, FileAccess.Write))
            {
                using (var sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.WriteLine("/*");
                    sw.WriteLine("* 此类由ConfigTools自动生成. https://github.com/huangkumao/ConfigTools");
                    sw.WriteLine("*/");
                    sw.WriteLine("using System.Collections.Generic;");
                    sw.WriteLine("");
                    sw.WriteLine("namespace Configs");
                    sw.WriteLine("{");
                    sw.WriteLine("    public class {0}", pTableMeta.ClassName);
                    sw.WriteLine("    {");
                    if (pTableMeta.CheckTypeIsMap())
                        sw.WriteLine("        public Dictionary<string, {0}> mDataMap;", pTableMeta.DataName);
                    else
                        sw.WriteLine("        public List<{0}> mDataList;", pTableMeta.DataName);
                    sw.WriteLine("    }");
                    sw.WriteLine();
                    sw.WriteLine("    public class {0}", pTableMeta.DataName);
                    sw.WriteLine("    {");
                    foreach (var field in pTableMeta.Fields)
                    {
                        if (!field.IsExportField(pCfgType))
                            continue;

                        sw.WriteLine("        " + field.mComment);
                        sw.WriteLine("        public {0} {1};", field.GetFieldTypeName(ExportCodeType.CSharp),
                            field.mFieldName);
                    }
                    sw.WriteLine("    }");
                    sw.WriteLine("}");
                }
            }
        }

        private static void GenTSCode(TableMeta pTableMeta, string pPath, ExportCfgType pCfgType)
        {
            var _Path = Path.Combine(pPath, pTableMeta.ClassName + ".ts");
            using (var fs = new FileStream(_Path, FileMode.Create, FileAccess.Write))
            {
                using (var sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.WriteLine("/*");
                    sw.WriteLine("* 此类由ConfigTools自动生成. https://github.com/huangkumao/ConfigTools");
                    sw.WriteLine("*/");
                    sw.WriteLine("namespace Configs");
                    sw.WriteLine("{");
                    sw.WriteLine("    export class {0}", pTableMeta.ClassName);
                    sw.WriteLine("    {");
                    if (pTableMeta.CheckTypeIsMap())
                        sw.WriteLine("        public mDataMap:{{ [key:string] :{0} }};", pTableMeta.DataName);
                    else
                        sw.WriteLine("        public mDataList:{0}[];", pTableMeta.DataName);
                    sw.WriteLine("    }");
                    sw.WriteLine();
                    sw.WriteLine("    export class {0}", pTableMeta.DataName);
                    sw.WriteLine("    {");
                    foreach (var field in pTableMeta.Fields)
                    {
                        if (!field.IsExportField(pCfgType))
                            continue;

                        sw.WriteLine("        " + field.mComment);
                        sw.WriteLine("        public {0}:{1};", field.mFieldName,
                            field.GetFieldTypeName(ExportCodeType.TypeScript));
                    }
                    sw.WriteLine("    }");
                    sw.WriteLine("}");
                }
            }
        }
    }
}