using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace project_engineer
{
    public partial class Form3 : Form
    {
        public Form3(string idna)
        {
            InitializeComponent();
            _ctaa = false;
            id_d = idna;
        }
        String id_d;
        private bool _ctaa;
        public bool ctaa
        { get { return this._ctaa; } set { this._ctaa = false; } }

        private bool _ch;
        public bool ch
        { get { return this._ch; } set { this._ch = false; } }

        //public static bool ctaa;
        public SQLiteConnection com = new SQLiteConnection(@"Data Source=db.db;Version=3;");
        private void button1_Click(object sender, EventArgs e)
        {
            com.Open();
            SQLiteCommand cmd_r = new SQLiteCommand("SELECT COUNT(*) FROM MEMBER", com);
            int Tabrows = Convert.ToInt32(cmd_r.ExecuteScalar());
            com.Close();
            com.Open();
            SQLiteCommand cmdsearch = new SQLiteCommand("SELECT * FROM MEMBER", com);
            SQLiteDataReader readsearch = cmdsearch.ExecuteReader();
            Form1 f = new Form1();
            string idkmitl = id_d;
            
            //MessageBox.Show(idkmitl+"naaaa");
            while (readsearch.Read())
            {
                if (readsearch["StanaM"].ToString().Equals("God") || readsearch["StanaM"].ToString().Equals("Admin"))
                {
                    //MessageBox.Show(readsearch["User"].ToString()+"//"+ readsearch["Pass"].ToString());
                    if (readsearch["User"].ToString().Equals(textBox1.Text) && readsearch["Pass"].ToString().Equals(textBox2.Text))
                    {

                        if (readsearch["IDKMITL"].ToString().Equals(idkmitl))
                        {
                            MessageBox.Show("ขออภัยคุณไม่สามารถอนุญาติตัวเองได้", "unsuccessful",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            com.Close();
                            return;
                        }
                        //com.Close();
                        _ctaa = true;
                        ch = true;
                        MessageBox.Show("login sucessful");
                        //return;

                    }
                    else if (Convert.ToInt32(readsearch["ID"].ToString()) == Tabrows  && ctaa == false)
                    {
                        MessageBox.Show("ขออภัยคุณกรอก Username หรือ Password(God, Admin) ไม่ถูกต้อง1", "unsuccessful",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        com.Close();
                        ch = true;
                        return;
                    }

                }
                else if (Convert.ToInt32(readsearch["ID"].ToString()) == Tabrows  && ctaa == false)
                {
                    MessageBox.Show("ขออภัยคุณกรอก Username หรือ Password(God, Admin) ไม่ถูกต้อง2", "unsuccessful",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    com.Close();
                    ch = true;
                    return;
                }
            }
            ch = true;
            com.Close();
            this.Close();
        }
    }
}
