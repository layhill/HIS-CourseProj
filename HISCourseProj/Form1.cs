using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HISCourseProj
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
       {
            string username = textBox1.Text;
            string pwd = textBox2.Text;
            if (!String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(pwd)) //非空检验
            {

                if (userVerify(username,pwd))
                    {
                        MessageBox.Show("登录成功！"); //判断合法性（后期用数据库）
                        this.Hide();
                        MainForm mf = new MainForm();
                        mf.Show();
                    }

                else
                {

                    MessageBox.Show("请输入正确的账号或密码！"); //弹窗

                    textBox1.Text = "";

                    textBox2.Text = ""; //密码输入错误后清空两个文本框重新输入

                }

            }

            else MessageBox.Show("账号或密码不能为空！");

        }

        private Boolean userVerify(string username, string pwd)
        {
            Boolean flag = false;

            try
            {
                string sql = string.Format("select count(*) from userInfor where username = '{0}' and pwd = '{1}'", username, pwd);
                SqlCommand conn = new SqlCommand(sql, DBConn.conn);
                DBConn.conn.Open();
                int num = Convert.ToInt32(conn.ExecuteScalar());
                if (num > 0)
                {
                    flag = true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            finally
            {
                DBConn.conn.Close();                
            }
            return flag;

        }



    }
}
