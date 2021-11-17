using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ConfigTools
{
    public partial class Main : Form
    {
        //Excel路径
        public static string sExcelPath = "";
        //代码路径
        public static string sCodePath = "";
        //配置路径
        public static string sCfgPath = "";
        //导出代码类型
        public static ExportCodeType sExportCodeType = ExportCodeType.CSharp;
        //导出配置类型
        public static ExportCfgType sExportCfgType = ExportCfgType.Server;
        //是否导出代码
        public static bool sCanExportCode = true;
        //是否导出配置
        public static bool sCanExportCfg = true;
        //是否压缩配置
        public static bool sNeedCom = false;

        public static List<ExcelFileInfo> sExcelFileList = new List<ExcelFileInfo>(64);

        public Main()
        {
            InitializeComponent();
        }

        //初始化
        private void Main_Load(object sender, EventArgs e)
        {
            RegistryHelper.InitData();
            mExcelPath.Text = sExcelPath;
            mCodeOutPath.Text = sCodePath;
            mCfgOutPath.Text = sCfgPath;

            if (!sCanExportCode)
            {
                cbGenCode.Checked = false;
                rbCSCode.Enabled = false;
                rbTSCode.Enabled = false;
            }
            else
            {
                cbGenCode.Checked = true;
                rbCSCode.Enabled = true;
                rbTSCode.Enabled = true;
            }

            if (!sCanExportCfg)
            {
                cbGenCfg.Checked = false;
                rbServer.Enabled = false;
                rbClient.Enabled = false;
            }
            else
            {
                cbGenCfg.Checked = true;
                rbServer.Enabled = true;
                rbClient.Enabled = true;
            }

            RefreshExcels();
        }

        //选择Excel文件目录
        private void btnExcelPath_Click(object sender, EventArgs e)
        {
            var _fbd = new FolderBrowserDialog {Description = "选择Excel文件目录"};
            if (_fbd.ShowDialog() == DialogResult.OK)
            {
                sExcelPath = _fbd.SelectedPath;
                mExcelPath.Text = sExcelPath;
                RefreshExcels();
            }
        }

        //选择代码目录
        private void btnCodePath_Click(object sender, EventArgs e)
        {
            var _fbd = new FolderBrowserDialog {Description = "选择代码目录"};
            if (_fbd.ShowDialog() == DialogResult.OK)
            {
                sCodePath = _fbd.SelectedPath;
                mCodeOutPath.Text = sCodePath;
            }
        }

        //选择配置表目录
        private void btnCfgPath_Click(object sender, EventArgs e)
        {
            var _fbd = new FolderBrowserDialog {Description = "选择配置表目录"};
            if (_fbd.ShowDialog() == DialogResult.OK)
            {
                sCfgPath = _fbd.SelectedPath;
                mCfgOutPath.Text = sCfgPath;
            }
        }

        //刷新配置表
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshExcels();
            AddLog("", false);
        }

        //是否生成代码
        private void cbGenCode_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGenCode.Checked)
            {
                sCanExportCode = true;
                rbCSCode.Enabled = true;
                rbTSCode.Enabled = true;
                if (sExportCodeType == ExportCodeType.CSharp)
                    rbCSCode.Checked = true;
                else
                    rbTSCode.Checked = true;
            }
            else
            {
                sCanExportCode = false;
                rbCSCode.Enabled = false;
                rbTSCode.Enabled = false;
            }
        }

        //是否生成配置
        private void cbGenCfg_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGenCfg.Checked)
            {
                sCanExportCfg = true;
                rbServer.Enabled = true;
                rbClient.Enabled = true;
                if (sExportCfgType == ExportCfgType.Client)
                    rbClient.Checked = true;
                else
                    rbServer.Checked = true;
            }
            else
            {
                sCanExportCfg = false;
                rbServer.Enabled = false;
                rbClient.Enabled = false;
            }
        }

        //代码类型CS
        private void rbCSCode_CheckedChanged(object sender, EventArgs e)
        {
            sExportCodeType = ExportCodeType.CSharp;
            RegistryHelper.SaveData();
        }

        //代码类型TS
        private void rbTSCode_CheckedChanged(object sender, EventArgs e)
        {
            sExportCodeType = ExportCodeType.TypeScript;
            RegistryHelper.SaveData();
        }

        //生成客户端配置
        private void rbClient_CheckedChanged(object sender, EventArgs e)
        {
            sExportCfgType = ExportCfgType.Client;
            RegistryHelper.SaveData();
        }

        //生成服务器配置
        private void rbServer_CheckedChanged(object sender, EventArgs e)
        {
            sExportCfgType = ExportCfgType.Server;
            RegistryHelper.SaveData();
        }

        //全部选择
        private void btnAllCheck_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < clbCfgFiles.Items.Count; i++)
                clbCfgFiles.SetItemChecked(i, true);
        }

        //全部取消
        private void btnAllUncheck_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < clbCfgFiles.Items.Count; i++)
                clbCfgFiles.SetItemChecked(i, false);
        }

        //刷新Excel列表
        private void RefreshExcels()
        {
            clbCfgFiles.Items.Clear();
            var _Path = mExcelPath.Text;
            FileHelper.GetExcelFiles(_Path, sExcelFileList);
            foreach (var excelFileInfo in sExcelFileList)
                clbCfgFiles.Items.Add(new ExcelFileInfo
                {
                    Name = excelFileInfo.Name,
                    Path = excelFileInfo.Path
                }, CheckState.Unchecked);

            RefreshAllPaths();
        }

        //刷新目录
        private void RefreshAllPaths()
        {
            sExcelPath = mExcelPath.Text;
            sCfgPath = mCfgOutPath.Text;
            sCodePath = mCodeOutPath.Text;
        }

        //生成按钮
        private void btnGen_Click(object sender, EventArgs e)
        {
            RefreshAllPaths();
            ShowInfo();

            for (var i = 0; i < clbCfgFiles.Items.Count; i++)
            {
                if (clbCfgFiles.GetItemCheckState(i) != CheckState.Checked)
                    continue;

                var excelFileInfo = clbCfgFiles.Items[i] as ExcelFileInfo;

                var dt = ExcelHelper.ImportExcelFile(excelFileInfo.Path);
                var meta = ExcelHelper.ParseTableMeta(excelFileInfo.Name, dt, ExportCfgType.Client);

                //生成代码
                if (sCanExportCode)
                    try
                    {
                        AddLog($"开始生成[ {meta.TableName} ]代码");
                        CodeHelper.GenCode(meta, sCodePath, sExportCodeType, sExportCfgType);
                        AddLog($"生成[ {meta.TableName} ]代码成功");
                    }
                    catch (Exception exp)
                    {
                        AddLog($"生成[{meta.TableName}]代码出现异常 => {exp.Message}");
                    }

                //生成配置
                if (sCanExportCfg)
                    try
                    {
                        AddLog($"开始生成[ {meta.TableName} ]配置");
                        CfgHelper.GenCfg(dt, sCfgPath, meta, sExportCfgType);
                        AddLog($"生成[ {meta.TableName} ]配置成功");
                    }
                    catch (Exception exp)
                    {
                        AddLog($"生成[{meta.TableName}]配置出现异常 => {exp.Message}");
                        return;
                    }

                AddLog("");
            }
            RegistryHelper.SaveData();
        }

        public void ShowInfo()
        {
            AddLog("", false);
            AddLog($"配置输入路径: [{sCfgPath}]");
            AddLog($"代码输出路径: [{sCodePath}]");
            AddLog($"是否导出配置 [{sCanExportCfg}]");
            AddLog($"配置类型 [{sExportCfgType}]");
            AddLog($"是否导出代码 [{sCanExportCode}]");
            AddLog($"代码类型 [{sExportCodeType}]");
            AddLog("");
        }

        public void AddLog(string pLog, bool pAppend = true)
        {
            if (pAppend)
                textLog.AppendText(pLog + "\r\n");
            else
                textLog.Text = pLog;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (NeedCom.Checked)
            {
                sNeedCom = true;
            }
            else
            {
                sNeedCom = false;
            }
        }
    }
}