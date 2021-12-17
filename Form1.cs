using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;//新增头文件

namespace 登录页面
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            serialPort1.Encoding = Encoding.GetEncoding("GB2312");
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }
        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)//接收函数
        {
            try
            {
                string recive_data;
                recive_data = serialPort1.ReadExisting();
                textBox1.AppendText(recive_data);
                textBox1.AppendText("\r\n");
            }
            catch { }
        }
        private void SearchAnAddSerialToComboBox(SerialPort MyPort, ComboBox MyBox)//搜索串口函数
        {
            string[] NmberOfport = new string[20];//新建一个数组，最多容纳20个
            string MidSting1;//缓存数组
            MyBox.Items.Clear();//清除combobox的内容
            for (int i = 1; i < 20; i++)
            {
                try//核心是靠try和catch完成遍历
                {
                    MidSting1 = "COM" + i.ToString();   //把串口名字赋给缓存数组
                    MyPort.PortName = MidSting1;        //把缓存数组赋给MyPort.PortName
                    MyPort.Open();                      //尝试打开串口（如果没有串口打开，后面就不执行）
                    NmberOfport[i - 1] = MidSting1;     //依次把缓存数组赋给NmberOfport
                    MyBox.Items.Add(MidSting1);         //添加到下拉选项中
                    MyPort.Close();                     //关闭串口
                    MyBox.Text = NmberOfport[i - 1];    //显示最后扫描出来的串口
                }
                catch { };
            }
        }
        //搜索串口部分
        private void button1_Click(object sender, EventArgs e)
        {
            SearchAnAddSerialToComboBox(serialPort1, comboBox2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "打开串口")
            {
                try
                {
                    serialPort1.PortName = comboBox2.Text;                  //设置串口号
                    serialPort1.BaudRate = Convert.ToInt32(comboBox1.Text); //设置波特率
                    serialPort1.Open();
                    button2.Text = "关闭串口";
                }
                catch
                {
                    MessageBox.Show("串口打开错误");
                }
            }
            else
            {
                try
                {
                    serialPort1.Close();
                    button2.Text = "打开串口";
                }
                catch { }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }
    }
    }

