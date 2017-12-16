using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConfigTools
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        //初始化
        private void Main_Load(object sender, EventArgs e)
        {
            Console.WriteLine("初始化");
        }

        //选择Excel文件目录
        private void btnExcelPath_Click(object sender, EventArgs e)
        {
            Console.WriteLine("选择Excel文件目录");
        }

        //选择代码目录
        private void btnCodePath_Click(object sender, EventArgs e)
        {
            Console.WriteLine("选择代码目录");
        }

        //选择配置表目录
        private void btnCfgPath_Click(object sender, EventArgs e)
        {
            Console.WriteLine("选择配置表目录");
        }

        //刷新配置表
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Console.WriteLine("刷新配置表");
        }

        //是否生成代码
        private void cbGenCode_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("是否生成代码");
        }

        //是否生成配置
        private void cbGenCfg_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("是否生成配置");
        }

        //代码类型CS
        private void rbCSCode_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("代码类型CS");
        }

        //代码类型TS
        private void rbTSCode_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("代码类型TS");
        }

        //生成客户端配置
        private void rbClient_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("生成客户端配置");
        }

        //生成服务器配置
        private void rbServer_CheckedChanged(object sender, EventArgs e)
        {
            Console.WriteLine("生成服务器配置");
        }

        //生成按钮
        private void btnGen_Click(object sender, EventArgs e)
        {
            Console.WriteLine("生成按钮");
        }

        //全部选择
        private void btnAllCheck_Click(object sender, EventArgs e)
        {
            Console.WriteLine("全部选择");
        }

        //全部取消
        private void btnAllUncheck_Click(object sender, EventArgs e)
        {
            Console.WriteLine("全部取消");
        }
    }
}
