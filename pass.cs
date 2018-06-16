using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace OCV
{
    public partial class PasswordFrm : Form
    {
        public PasswordFrm()
        {
            InitializeComponent();
        }
        private static int count = 0;//定义个全局静态变量保存次数

        private void PasswordFrm_Load(object sender, EventArgs e)
        {
            textBox_password.Focus();
        }

        private void textBox_password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox_password.Text == "")
                {
                    MessageBoxEx.Show("请输入密码");
                    textBox_password.Focus();
                }
                if (textBox_password.Text == "1212")
                {
                    count = 0;
                    this.DialogResult = DialogResult.Yes;
                    Close();
                }
                else
                {
                    count++;
                    MessageBoxEx.Show("你输入的密码错误");
                    textBox_password.Clear();
                    textBox_password.Focus();
                    if (count == 3)
                    {
                        MessageBoxEx.Show("你输入密码错误次数过多，10秒后再输入！", "警告");
                        textBox_password.Enabled = false;
                        System.Threading.Thread.Sleep(10000);
                        textBox_password.Enabled = true;
                        return;
                    }
                    if (count == 6)
                    {
                        MessageBoxEx.Show("你输入密码错误次超限，60秒后自动退出！", "警告");
                        textBox_password.Enabled = false;
                        System.Threading.Thread.Sleep(60000);
                        textBox_password.Enabled = true;
                        this.Close();
                        
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
