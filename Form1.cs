using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;

namespace PrintApp
{
    public partial class Form1 : Form
    {
        PrintDocument objDocument = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            objDocument = new PrintDocument();
            PaperSize RequiredPaperSize = new PaperSize("Custom", 185, 138);//宽度80mm
            objDocument.DefaultPageSettings.PaperSize = RequiredPaperSize;
            objDocument.PrintPage += new PrintPageEventHandler(MyPrintDocument_PrintPage);

            PrintDialog pd = new PrintDialog();
            pd.Document = objDocument;
            if (pd.ShowDialog() == DialogResult.OK) //如果确认，将会覆盖所有的打印参数设置
            {
                objDocument.Print(); //打印
                ////页面设置对话框（可以不使用，其实PrintDialog对话框已提供页面设置）
                //PageSetupDialog psd = new PageSetupDialog();
                //psd.Document = objDocument;
                //if (DialogResult.OK == psd.ShowDialog())
                //{
                //    //打印预览
                //    PrintPreviewDialog ppd = new PrintPreviewDialog();
                //    ppd.Document = objDocument;
                //    if (DialogResult.OK == ppd.ShowDialog())
                //    {
                //        objDocument.Print(); //打印
                //    }

                //}
            }
        }

        private void MyPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int left = 32;
            int right = 999;

            try
            {
                Font _Font = new Font(new FontFamily("黑体"), 6);
                int Y = 0;
                //e.Graphics.DrawLine(Pens.Black, left, 0,right,0);
                string pageinfo = "扫一扫有惊喜哦！！！";
                
                e.Graphics.DrawString(pageinfo, new Font(new FontFamily("黑体"), 6), System.Drawing.Brushes.Black, left, 8);
                e.Graphics.DrawLine(Pens.Black, left, 19, right, 19);
                Y = Y + 20;
                string prtstr = "";
                Image image = Image.FromFile(Path.Combine(Application.StartupPath, "p.png"));
                e.Graphics.DrawImage(image, left+9, 20, 100, 100);
            }
            catch (Exception ex)
            {

                WriteLog("打印叫号异常：" + ex.Message);
            }
        }

        private void WriteLog(string s)
        {
            MessageBox.Show(s);
        }

    }
}
