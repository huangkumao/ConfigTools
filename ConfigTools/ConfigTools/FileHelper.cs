using System.Collections.Generic;
using System.IO;

namespace ConfigTools
{
    public class ExcelFileInfo
    {
        public string Name { get; set; }
        public string Path { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }

    public static class FileHelper
    {
        public static void GetExcelFiles(string pPath, List<ExcelFileInfo> pList, string pSuffix = "*.xlsx")
        {
            if (!Directory.Exists(pPath))
                return;

            pList.Clear();
            var files = Directory.GetFiles(pPath, pSuffix, SearchOption.TopDirectoryOnly);
            foreach (var file in files)
            {
                if (File.GetAttributes(file).HasFlag(FileAttributes.Hidden))
                    continue;
                var excelFile = new ExcelFileInfo {Name = Path.GetFileNameWithoutExtension(file), Path = file};
                pList.Add(excelFile);
            }
        }
    }
}