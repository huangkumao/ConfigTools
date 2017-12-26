using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;
using Newtonsoft.Json;

namespace ConfigTools
{
    public class RegistryData
    {
        //Excel路径
        public string mExcelPath = @"c:\ExcelPath\";
        //代码路径
        public string mCodePath = @"c:\CodePath\";
        //配置路径
        public string mCfgPath = @"c:\CfgPath\";
        //导出代码类型
        public ExportCodeType mExportCodeType = ExportCodeType.TypeScript;
        //导出配置类型
        public ExportCfgType mExportCfgType = ExportCfgType.Client;

        public void GetData()
        {
            Main.sExcelPath = mExcelPath;
            Main.sCodePath = mCodePath;
            Main.sCfgPath = mCfgPath;
            Main.sExportCodeType = mExportCodeType;
            Main.sExportCfgType = mExportCfgType;
        }

        public void SetData()
        {
            mExcelPath = Main.sExcelPath;
            mCodePath = Main.sCodePath;
            mCfgPath = Main.sCfgPath;
            mExportCodeType = Main.sExportCodeType;
            mExportCfgType = Main.sExportCfgType;
        }
    }

    public class RegistryHelper
    {
        public static void InitData()
        {
            var R = GetRegistryData("ConfigTools", "Data");
            if (R == null)
            {
                var _D = new RegistryData();
                _D.GetData();
                var _S = JsonConvert.SerializeObject(_D);
                SetRegistryData("ConfigTools", "Data", Encoding.UTF8.GetBytes(_S));
            }
            else
            {
                var _D = JsonConvert.DeserializeObject<RegistryData>(Encoding.UTF8.GetString(R));
                _D.GetData();
            }
        }

        public static void SaveData()
        {
            var _D = new RegistryData();
            _D.SetData();
            var _S = JsonConvert.SerializeObject(_D);
            SetRegistryData("ConfigTools", "Data", Encoding.UTF8.GetBytes(_S));
        }

        //读取指定名称的注册表的值
        public static byte[] GetRegistryData(string pSubkey, string pName)
        {
            byte[] registData = null;
            RegistryKey myKey = Registry.CurrentUser.OpenSubKey(pSubkey, true);
            if (myKey != null)
            {
                registData = (byte[])myKey.GetValue(pName);
            }

            return registData;
        }

        //向注册表中写数据
        public static void SetRegistryData(string pSubkey, string pName, byte[] pValue)
        {
            RegistryKey myKey = Registry.CurrentUser.CreateSubKey(pSubkey);
            myKey?.SetValue(pName, pValue);
        }
    }
}