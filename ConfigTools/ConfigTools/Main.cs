using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
        public static ExportCodeType sExportCodeType = ExportCodeType.NULL;
        //导出配置类型
        public static ExportCfgType sExportCfgType = ExportCfgType.NULL;

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

            if (sExportCodeType == ExportCodeType.NULL)
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

            if (sExportCfgType == ExportCfgType.NULL)
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
            FolderBrowserDialog _fbd = new FolderBrowserDialog {Description = "选择Excel文件目录"};
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
            FolderBrowserDialog _fbd = new FolderBrowserDialog { Description = "选择代码目录" };
            if (_fbd.ShowDialog() == DialogResult.OK)
            {
                sCodePath = _fbd.SelectedPath;
                mCodeOutPath.Text = sCodePath;
            }
        }

        //选择配置表目录
        private void btnCfgPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog _fbd = new FolderBrowserDialog { Description = "选择配置表目录" };
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
        }

        //是否生成代码
        private void cbGenCode_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("是否生成代码");
            if (cbGenCode.Checked)
            {
                rbCSCode.Enabled = true;
                rbTSCode.Enabled = true;
                if (sExportCodeType == ExportCodeType.CSharp)
                    rbCSCode.Checked = true;
                else
                    rbTSCode.Checked = true;
            }
            else
            {
                rbCSCode.Enabled = false;
                rbTSCode.Enabled = false;
            }
        }

        //是否生成配置
        private void cbGenCfg_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("是否生成配置");
            if (cbGenCfg.Checked)
            {
                rbServer.Enabled = true;
                rbClient.Enabled = true;
                if (sExportCfgType == ExportCfgType.Client)
                    rbClient.Checked = true;
                else
                    rbServer.Checked = true;

            }
            else
            {
                rbServer.Enabled = false;                                  
                rbClient.Enabled = false;
            }
        }

        //代码类型CS
        private void rbCSCode_CheckedChanged(object sender, EventArgs e)
        {
            sExportCodeType = ExportCodeType.CSharp;
        }

        //代码类型TS
        private void rbTSCode_CheckedChanged(object sender, EventArgs e)
        {
            sExportCodeType = ExportCodeType.TypeScript;
        }

        //生成客户端配置
        private void rbClient_CheckedChanged(object sender, EventArgs e)
        {
            sExportCfgType = ExportCfgType.Client;
        }

        //生成服务器配置
        private void rbServer_CheckedChanged(object sender, EventArgs e)
        {
            sExportCfgType = ExportCfgType.Server;
        }

        //全部选择
        private void btnAllCheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbCfgFiles.Items.Count; i++)
            {
                clbCfgFiles.SetItemChecked(i, true);
            }
        }

        //全部取消
        private void btnAllUncheck_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbCfgFiles.Items.Count; i++)
            {
                clbCfgFiles.SetItemChecked(i, false);
            }
        }

        //刷新Excel列表
        private void RefreshExcels()
        {
            clbCfgFiles.Items.Clear();
            string _Path = mExcelPath.Text;
            FileHelper.GetExcelFiles(_Path, sExcelFileList);
            foreach (var excelFileInfo in sExcelFileList)
            {
                clbCfgFiles.Items.Add(new ExcelFileInfo
                {
                    Name = excelFileInfo.Name,
                    Path = excelFileInfo.Path
                }, CheckState.Unchecked);
            }

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
            for (int i = 0; i < clbCfgFiles.Items.Count; i++)
            {
                if (clbCfgFiles.GetItemCheckState(i) != CheckState.Checked)
                    continue;

                var excelFileInfo = clbCfgFiles.Items[i] as ExcelFileInfo;

                var dt = ExcelHelper.ImportExcelFile(excelFileInfo.Path);
                var meta = ExcelHelper.ParseTableMeta(excelFileInfo.Name, dt, ExportCfgType.Client);

                //生成代码
                CodeHelper.GenCode(meta, sCodePath, sExportCodeType, sExportCfgType);

                //生成配置
                CfgHelper.GenCfg(dt, sCfgPath, meta, sExportCfgType);
            }
            RegistryHelper.SaveData();
        }
    }
}
