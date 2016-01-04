using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Text.RegularExpressions;

namespace project_engineer
{
    public partial class Form1 : Form
    {
        // public static int a=0;
        //-------------------------------------Debug---------------------------------------------//
        //-----------------------------------AddMember-------------------------------------------//
        bool abc2;
        private string _id;
        public string idd
        { get { return this._id; } set { this._id = "66"; } }
        //------------------------------------recoard--------------------------------------------//
        int a;
        string stana;
        string st_all;
        string user_god;
        string pass_god;
        string user_admin;
        string pass_admin;

        string user_ag;

        TextBox[] _value;
        TextBox[] _text;
        Label[] _text2;
        Panel Recoard_Panel;
        Panel Recoard_Panel2;
        ArrayList al_thing;
        ArrayList al_CountThing;
        ArrayList sea;
        bool userpass;
        bool cid;
        //-------------------------------------Thing---------------------------------------------//
        bool abc;
        Dictionary<string, string> dic_i;
        //------------------------------------TableAll-------------------------------------------//
        int TableAll_CountLine__Thing;
        Int32 TableAll_CountRow_Thing;
        Panel TableAll_Panel_Thing;
        TableLayoutPanel TabAll_Table_Thing;

        int TableAll_CountLine_Member;
        Int32 TableAll_CountRow_Member;
        Panel TableAll_Panel_Member;
        TableLayoutPanel TabAll_Table_Member;

        int TableAll_CountLine_MemberRec;
        Int32 TableAll_CountRow_MemberRec;
        Panel TableAll_Panel_MemberRec;
        TableLayoutPanel TabAll_Table_MemberRec;

        int TableAll_CountLine_ALL;
        Int32 TableAll_CountRow_ALL;
        Panel TableAll_Panel_ALL;
        TableLayoutPanel TabAll_Table_ALL;

        bool ctaa;
        bool ctaa2;

        //***************************************************************************************//
        int TableAll_CountLine_Admin;
        Int32 TableAll_CountRow_Admin;
        Panel TableAll_Panel_Admin;
        TableLayoutPanel TabAll_Table_Admin;
        Dictionary<string, string> dic_ip;
        //***************************************************************************************//
        //***************************************************************************************//

        public SQLiteConnection com = new SQLiteConnection(@"Data Source=db.db;Version=3;");
        
       
        public Form1()
        {
            string newPath = Path.GetFullPath(System.IO.Directory.GetCurrentDirectory());
            string[] filePaths = Directory.GetFiles(newPath, "*.db");
            bool findch = false;
            foreach (var i in filePaths)
            {
                if (Path.GetFileName(i).Equals("db.db"))
                {
                    findch = true;
                }
            }
            if (findch == false) {
                button1_Click();
                add_TableThing_Click();
                button7_Click();
                Add_God();
                Add_Card();
                MessageBox.Show("เตรียมDBใหม่เรียบร้อย");
            }
            InitializeComponent();
            comboBox_Room.SelectedIndex = 0;
            comboBox_faculty.SelectedIndex = 0;
            radioButton_Res.Select();
            radioButton5.Select();
            comboBox_DataLend_Hourse.SelectedIndex = 0;
            comboBox_DataLend_min.SelectedIndex = 0;
            comboBox_DataBack_Hourse.SelectedIndex = 0;
            comboBox_DataBack_min.SelectedIndex = 0;
            //comboBox_Card2.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            tabControl2.Hide();
            tabControl3.Hide();
            a = 0;
            Recoard_Panel = new Panel();
            Recoard_Panel.AutoScroll = true;
            Recoard_Panel.Top = 50;
            Recoard_Panel.Left = 90;
            Recoard_Panel.Width = groupBox1.Width - 8/2;
            Recoard_Panel.Height = groupBox1.Height - 100;

            Recoard_Panel2 = new Panel();
            Recoard_Panel2.AutoScroll = true;
            Recoard_Panel2.Top = 50;
            Recoard_Panel2.Left = 15;
            Recoard_Panel2.Width = groupBox1.Width-15;
            Recoard_Panel2.Height = groupBox1.Height-50;

            radioButton1.Select();

            DateTime d = DateTime.Now;

            comboBox_DataLend_Hourse.SelectedItem = d.ToString("HH");
            comboBox_DataLend_min.SelectedItem = d.ToString("mm");
            comboBox_DataBack_Hourse.SelectedItem = d.ToString("HH");
            comboBox_DataBack_min.SelectedItem = d.ToString("mm");
            

        }
        //-------------------------------------Debug---------------------------------------------//
        
        public void button1_Click()
        {
            //string strValue = textBox1.Text;
            //Console.WriteLine(strValue);
            //label1.Text = strValue;
            createTable();
        }
        private void createTable()
        {
            //com.SetPassword("jong");
            com.Open();
            String command = @"CREATE TABLE MEMBER(
                    ID INTEGER PRIMARY KEY AUTOINCREMENT, 
                    IDKMITL TEXT(35),
                    StanaM TEXT(10),
                    Name TEXT(35), 
                    Nic TEXT(35), 
                    Park TEXT(35),
                    Room TEXT(35),
                    Faculty TEXT(35),
                    Phone TEXT(35),
                    Other TEXT(300), 
                    User TEXT(30), 
                    Pass TEXT(30)
                    )";
            SQLiteCommand cmd = new SQLiteCommand(command, com);
            cmd.ExecuteNonQuery();
            com.Close();

        }
        private void add_TableThing_Click()
        {
            com.Open();
            String command = @"CREATE TABLE THING(
                    ID INTEGER PRIMARY KEY AUTOINCREMENT, 
                    IDTHING TEXT(35),
                    Name TEXT(35),
                    Price TEXT(10),
                    Count INTEGER(100), 
                    CountAll INTEGER(100),
                    Other TEXT(100)
                    )";
            SQLiteCommand cmd = new SQLiteCommand(command, com);
            cmd.ExecuteNonQuery();
            com.Close();

            com.Open();

            SQLiteCommand cmdna = new SQLiteCommand(@"insert into 
                            THING (IDTHING, Name, Price, Count, CountAll, Other)
                            values($IDTHING, $Name, $Price, $Count, $CountAll, $Other)", com);
            cmdna.Parameters.AddWithValue("$IDTHING", "");
            cmdna.Parameters.AddWithValue("$Name", "");
            cmdna.Parameters.AddWithValue("$Price", "");
            cmdna.Parameters.AddWithValue("$Count", "");
            cmdna.Parameters.AddWithValue("$CountAll","");
            cmdna.Parameters.AddWithValue("$Other", "");
            cmdna.ExecuteNonQuery();
            com.Close();

        }
        private void button7_Click()
        {
            com.Open();
            String command = @"CREATE TABLE RECALL(
                    ID INTEGER PRIMARY KEY AUTOINCREMENT, 
                    IDKMITL TEXT(100),
                    Stana TEXT(35),
                    BeTo TEXT(35),
                    Project TEXT(35), 
                    DataLend TEXT(35), 
                    DataBack TEXT(35), 
                    Thing TEXT(1000), 
                    Card TEXT(10),
                    StatusAll TEXT(1000), 
                    Accept TEXT(30)
                    )";
            
            SQLiteCommand cmd = new SQLiteCommand(command, com);
            cmd.ExecuteNonQuery();
            com.Close();

        }
        private void Add_God() {
            com.Open();
            SQLiteCommand cmd2 = new SQLiteCommand(@"insert into 
                            MEMBER (IDKMITL,StanaM, Name, Nic, Park, Room, Faculty, Phone, Other, User, Pass)
                            values($ID_KMITL,$StanaM, $name_S, $nic, $park, $room, $faculty, $phone, $other, $user, $pass)", com);

            cmd2.Parameters.AddWithValue("$ID_KMITL", "xxxx");
            cmd2.Parameters.AddWithValue("$StanaM", "God");
            cmd2.Parameters.AddWithValue("$name_S", "xxxx");
            cmd2.Parameters.AddWithValue("$nic", "xxxx");
            cmd2.Parameters.AddWithValue("$park", "xxxx");
            cmd2.Parameters.AddWithValue("$room", "1");
            cmd2.Parameters.AddWithValue("$faculty", "วิศวกรรมศาสตร์");
            cmd2.Parameters.AddWithValue("$phone", "xxxx");
            cmd2.Parameters.AddWithValue("$other", "xxxx");
            cmd2.Parameters.AddWithValue("$user", "god");
            cmd2.Parameters.AddWithValue("$pass", "god");

            cmd2.ExecuteNonQuery();
            com.Close();
            
        }
        private void Add_Card() {
            com.Open();
            String command = @"CREATE TABLE CARD(
                    ID INTEGER PRIMARY KEY AUTOINCREMENT, 
                    IDCARD TEXT(3),
                    Stana TEXT(10)  
                    )";
            SQLiteCommand cmd = new SQLiteCommand(command, com);
            cmd.ExecuteNonQuery();
            com.Close();

            com.Open();
            for (int i = 1; i <= 99; i++)
            {
                SQLiteCommand cmd2 = new SQLiteCommand(@"insert into 
                            CARD (IDCARD,Stana)
                            values($IDCARD,$Stana)", com);
                string a = "";
                if (i.ToString().Length == 1) { a = "0" + i.ToString(); }
                else { a = i.ToString();}
                cmd2.Parameters.AddWithValue("$IDCARD", a);
                cmd2.Parameters.AddWithValue("$Stana", "True");
                cmd2.ExecuteNonQuery();
            }
            com.Close();
        }
        //-----------------------------------AddMember-------------------------------------------//
        private void button_Addmember_Click(object sender, EventArgs e)
        {
            if (textBox_IDKMITL.Text.Equals("")||
                textBox_Name.Text.Equals("")||
                textBox_Nic.Text.Equals("")||
                textBox_Park.Text.Equals("") ||
                textBox_Phone.Text.Equals("")
                ) {
                MessageBox.Show("ขออภัยคุณกรอกข้อมูลไม่ครบ", "unsuccessful",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox_IDKMITL.Text.Length != 8)
            {
                MessageBox.Show("กรุณาใส่ตัวเลขรหัสนักศึกษา 8 ตัว", "unsuccessful",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox_Phone.Text.Length != 10)
            {
                MessageBox.Show("กรุณาใส่เบอร์โทร 10 ตัว", "unsuccessful",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            com.Open();
            SQLiteCommand cmdsearch = new SQLiteCommand("SELECT * FROM MEMBER", com);
            SQLiteDataReader readsearch = cmdsearch.ExecuteReader();
            user_god="";
            pass_god="";
            while (readsearch.Read())
            {
                if (readsearch["StanaM"].ToString().Equals("God"))
                {
                    user_god = readsearch["User"].ToString();
                    pass_god = readsearch["Pass"].ToString();
                }
            }
            com.Close();

            if (abc2 == true) {

                _id = textBox_IDKMITL.Text;
                //MessageBox.Show(_id);
                Form3 f = new Form3(_id);

                f.ShowDialog();
                
                if (f.ctaa == false) { return; }

                com.Close();
                dic_ip = new Dictionary<string, string> { };
                dic_ip.Add("Name", textBox_Name.Text);
                dic_ip.Add("Nic", textBox_Nic.Text);
                dic_ip.Add("Park", textBox_Park.Text);
                dic_ip.Add("Room", comboBox_Room.SelectedItem.ToString());
                dic_ip.Add("Faculty", comboBox_faculty.SelectedItem.ToString());
                dic_ip.Add("Phone", textBox_Phone.Text);
                dic_ip.Add("Other", richTextBox_Other.Text);
                string readid = "";
                com.Open();
                SQLiteCommand cmd2 = new SQLiteCommand("SELECT * FROM MEMBER", com);   
                SQLiteDataReader read = cmd2.ExecuteReader();
                        
                while (read.Read())
                {
                    if (read["IDKMITL"].ToString().Equals(textBox_IDKMITL.Text))
                    {
                        readid = read["ID"].ToString();
                        
                    }
                }   
                com.Close();
                com.Open();
                com.Close();
                foreach (var ii in dic_ip)
                {
                    com.Open();

                    String str_update = "UPDATE MEMBER SET " + ii.Key + " = '" + ii.Value + "' WHERE ID = " + readid+";";
                    //MessageBox.Show(str_update);
                    SQLiteCommand cmdUpDate = new SQLiteCommand(str_update, com);
                    cmdUpDate.ExecuteNonQuery();
                    //MessageBox.Show("ll");
                    com.Close();
                }
                
                MessageBox.Show("บันทึกการเปลี่ยนแปลงข้อมูลเรียบร้อย", "successful",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            com.Open();
            SQLiteCommand cmdsearcha = new SQLiteCommand("SELECT * FROM MEMBER", com);
            SQLiteDataReader readsearcha = cmdsearcha.ExecuteReader();
            while (readsearcha.Read())
            {
                if (readsearcha["StanaM"].ToString().Equals("Admin")&&readsearcha["User"].ToString().Equals(textBox_AddAdmin_User_Admin.Text))
                {
                    MessageBox.Show("ขออภัยUsernameนี้มีคนใช้แล้ว", "unsuccessful",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    com.Close();
                    return;
                }
                if (readsearcha["StanaM"].ToString().Equals("God") && readsearcha["User"].ToString().Equals(textBox_AddAdmin_User_Admin.Text))
                {
                    MessageBox.Show("ขออภัยUsernameนี้มีคนใช้แล้ว", "unsuccessful",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    com.Close();
                    return;
                }
            }
            com.Close();


            if (radioButton6.Checked) {
                if (textBox_AddAdmin_Pass_Admin.Text.Equals(textBox_AddAdmin_con_Admin.Text)) {
                    if (user_god.Equals(textBox_AddAdmin_User.Text) && pass_god.Equals(textBox_AddAdmin_Pass.Text)) { }
                    else {
                        MessageBox.Show("ขออภัยคุณกรอก Username หรือ Password(God) ไม่ถูกต้อง", "unsuccessful",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else {
                    MessageBox.Show("ขออภัยคุณกรอก Password ไม่ตรงกัน(Admin)", "unsuccessful",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            user_admin="";
            pass_admin="";

            string check_stana2;
            if (radioButton5.Checked)
            {
                check_stana2 = "Member";
            }
            else {
                check_stana2 = "Admin";
                user_admin = textBox_AddAdmin_User_Admin.Text;
                pass_admin = textBox_AddAdmin_Pass_Admin.Text;

            }

            com.Open();

            SQLiteCommand cmd = new SQLiteCommand(@"insert into 
                            MEMBER (IDKMITL,StanaM, Name, Nic, Park, Room, Faculty, Phone, Other, User, Pass)
                            values($ID_KMITL,$StanaM, $name_S, $nic, $park, $room, $faculty, $phone, $other, $user, $pass)", com);

            cmd.Parameters.AddWithValue("$ID_KMITL", textBox_IDKMITL.Text);
            cmd.Parameters.AddWithValue("$StanaM", check_stana2);
            cmd.Parameters.AddWithValue("$name_S", textBox_Name.Text);
            cmd.Parameters.AddWithValue("$nic", textBox_Nic.Text);
            cmd.Parameters.AddWithValue("$park", textBox_Park.Text);
            cmd.Parameters.AddWithValue("$room", comboBox_Room.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("$faculty", comboBox_faculty.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("$phone", textBox_Phone.Text);
            cmd.Parameters.AddWithValue("$other", richTextBox_Other.Text);
            cmd.Parameters.AddWithValue("$user", user_admin);
            cmd.Parameters.AddWithValue("$pass", pass_admin);
            cmd.ExecuteNonQuery();
            com.Close();
            //----------------------------------------------------------
           
            //----------------------------------------------------------
            MessageBox.Show("เพิ่มข้อมูลสมาชิกเรียบร้อยแล้ว", "successful",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
            TableAll_update_Member(sender, e);
            TableAll_update_Admin(sender, e);
            textBox_IDKMITL_TextChanged(sender, e);



        }
        //------------------------------------recoard--------------------------------------------//

        private void button2_Click(object sender, EventArgs e)
        {
            int authors = 100;
            _text = new TextBox[authors];
            _text[a] = new TextBox();
            _text[a].Name = "Thing";
            _text[a].Top = (a * 33);
            _text[a].Left = 70;
            _text[a].Width = 300;
            _text[a].Height = 30;
            Recoard_Panel2.Controls.Add(_text[a]);

            _text2 = new Label[authors];
            _text2[a] = new Label();
            _text2[a].Name = "Text" + a;
            _text2[a].Text = "" + (a+1);
            _text2[a].Top = (a * 33);
            _text2[a].Left = 10;
            _text2[a].Width = 50;
            _text2[a].Height = 30;
            Recoard_Panel2.Controls.Add(_text2[a]);
          
            _value = new TextBox[authors];
            _value[a] = new TextBox();
            _value[a].Name = "value";
            _value[a].Top = (a * 33);
            _value[a].Left = 390;
            _value[a].Width = 100;
            _value[a].Height = 30;
            Recoard_Panel2.Controls.Add(_value[a]);
            
            groupBox1.Controls.Add(Recoard_Panel2);
            a += 1;
 
        }
        private void radioButton_Res_CheckedChanged(object sender, EventArgs e)
        {
            Label_Card2.Hide();
            comboBox_Card2.Hide();

            comboBox_DataBack_min.Enabled = true;
            comboBox_DataBack_Hourse.Enabled = true;


            dateTimePicker1.Enabled = true;
            dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            comboBox_DataLend_Hourse.SelectedItem = DateTime.Now.Hour.ToString();
            comboBox_DataLend_min.SelectedItem = DateTime.Now.Minute.ToString();

            dateTimePicker2.Enabled = true;
            dateTimePicker2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            comboBox_DataBack_Hourse.SelectedItem = DateTime.Now.Hour.ToString();
            comboBox_DataBack_min.SelectedItem = DateTime.Now.Minute.ToString();

            comboBox_DataLend_Hourse.Enabled = true;
            comboBox_DataLend_min.Enabled = true;
        }
        private void radioButton_lend_CheckedChanged(object sender, EventArgs e)
        {
            Label_Card2.Show();
            comboBox_Card2.Show();
            comboBox_DataBack_min.Enabled = true;
            comboBox_DataBack_Hourse.Enabled = true;

            comboBox_DataLend_Hourse.Enabled = false;
            comboBox_DataLend_min.Enabled = false;

            dateTimePicker1.Enabled = false;
            dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            comboBox_DataLend_Hourse.SelectedItem = DateTime.Now.Hour.ToString();
            comboBox_DataLend_min.SelectedItem = DateTime.Now.Minute.ToString();

            dateTimePicker2.Enabled = true;
            dateTimePicker2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            comboBox_DataBack_Hourse.SelectedItem = DateTime.Now.Hour.ToString();
            comboBox_DataBack_min.SelectedItem = DateTime.Now.Minute.ToString();
            update_card_check(sender, e);
            textBox_ITKMITL2_TextChanged(sender, e);
        }
        private void radioButton_back_CheckedChanged(object sender, EventArgs e)
        {
            Label_Card2.Show();
            comboBox_Card2.Show();
            comboBox_DataBack_min.Enabled = false;
            comboBox_DataBack_Hourse.Enabled = false;

            dateTimePicker2.Enabled = false;
            dateTimePicker2.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            comboBox_DataBack_Hourse.SelectedItem = DateTime.Now.Hour.ToString();
            comboBox_DataBack_min.SelectedItem = DateTime.Now.Minute.ToString();

            dateTimePicker1.Enabled = false;
            comboBox_DataLend_Hourse.Enabled = false;
            comboBox_DataLend_min.Enabled = false;
            comboBox_Card2.Enabled = false;

            update_card_check(sender, e);
            textBox_ITKMITL2_TextChanged(sender, e);
        }

        private void textBox_ITKMITL2_TextChanged(object sender, EventArgs e)
        {
            
            com.Open();
            sea = new ArrayList();
            cid = false;
            SQLiteCommand cmdsearch = new SQLiteCommand("SELECT * FROM MEMBER", com);
            SQLiteDataReader readsearch = cmdsearch.ExecuteReader();
            while (readsearch.Read())
            {
                sea.Add(readsearch["IDKMITL"]);
            }

            foreach (String ii in sea)
            {
                if (textBox_ITKMITL2.Text.Equals(ii))
                {
                    label7.Text = "มีข้อมูล";
                    label7.ForeColor = Color.Green;
                    cid = true;
                    com.Close();
                    Show_Data_Member(sender, e);
                    update_card_check(sender, e);
                    Show_Data_lend(sender, e);
                    break;
                }
                else
                {
                    com.Close();
                    update_card_check(sender, e);
                    label44.Text = "ไม่มีข้อมูล";
                    label45.Text = "ไม่มีข้อมูล";
                    label46.Text = "ไม่มีข้อมูล";
                    label47.Text = "ไม่มีข้อมูล";
                    label48.Text = "ไม่มีข้อมูล";
                    label49.Text = "ไม่มีข้อมูล";
                    label7.Text = "ไม่มีข้อมูล";
                    label7.ForeColor = Color.Red;
                    comboBox_Card2.Enabled = true;
                    cid = false;
                }
            }
            com.Close();
        }
        private void update_card_check(object sender, EventArgs e)
        {
            com.Open();
            comboBox_Card2.Items.Clear();
            SQLiteCommand cmdsearch2 = new SQLiteCommand("SELECT * FROM CARD", com);
            SQLiteDataReader readsearch2 = cmdsearch2.ExecuteReader();
            while (readsearch2.Read())
            {
                if (readsearch2["Stana"].ToString().Equals("True"))
                {
                    comboBox_Card2.Items.Add(readsearch2["IDCARD"].ToString());
                    comboBox_Card2.SelectedIndex = 0;
                }
            }
            com.Close();
        }
        private void Show_Data_Member(object sender, EventArgs e)
        {
            com.Open();
            SQLiteCommand cmdsearch = new SQLiteCommand("SELECT * FROM MEMBER", com);
            SQLiteDataReader readsearch = cmdsearch.ExecuteReader();
            while (readsearch.Read())
            {
                if (textBox_ITKMITL2.Text.Equals(readsearch["IDKMITL"]))
                {
                    label44.Text = readsearch["Name"].ToString();
                    label45.Text = readsearch["Nic"].ToString();
                    label46.Text = readsearch["Faculty"].ToString();
                    label47.Text = readsearch["Park"].ToString();
                    label48.Text = readsearch["Phone"].ToString();
                    label49.Text = readsearch["Room"].ToString();
                }

            }
            com.Close();
        }
        private void Show_Data_lend(object sender, EventArgs e)
        {
            com.Open();
            bool check = false;
            SQLiteCommand cmdsearch = new SQLiteCommand("SELECT * FROM RECALL ORDER BY ID DESC", com);
            SQLiteDataReader readsearch = cmdsearch.ExecuteReader();
            while (readsearch.Read())
            {
                if (textBox_ITKMITL2.Text.Equals(readsearch["IDKMITL"].ToString()) && check == false && !readsearch["Stana"].ToString().Equals("จอง"))
                {
                    if (readsearch["StatusAll"].ToString().Equals("")) { }
                    else
                    {
                        textBox_BeTo2.Text = readsearch["BeTo"].ToString();
                        textBox_Project2.Text = readsearch["Project"].ToString();
                        //update_card_check(sender, e);
                        comboBox_Card2.Items.Add(readsearch["Card"].ToString());
                        comboBox_Card2.SelectedItem = readsearch["Card"].ToString();
                        comboBox_Card2.Enabled = false;
                        if (!radioButton_Res.Checked)
                        {
                            string a = readsearch["DataLend"].ToString();
                            string[] lines = Regex.Split(a, "Time:");
                            string[] lines2 = Regex.Split(lines[0], "-");
                            comboBox_DataLend_Hourse.SelectedItem = lines[1].Substring(0, 2);
                            comboBox_DataLend_min.SelectedItem = lines[1].Substring(2, 2);
                            dateTimePicker1.Value = new DateTime(Convert.ToInt32(lines2[2]) - 543, Convert.ToInt32(lines2[1]), Convert.ToInt32(lines2[0]));
                        }
                    }
                    check = true;
                }
                else { }
            }
            com.Close();
        }
        private void SubmitRecord_Click(object sender, EventArgs e)
        {
            if (textBox_ITKMITL2.Text.Equals("") ||
                textBox_BeTo2.Text.Equals("") ||
                textBox_Project2.Text.Equals("")
                )
            {
                MessageBox.Show("ขออภัยคุณกรอกข้อมูลไม่ครบ", "unsuccessful",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox_Rec_User.Text.Equals("") || textBox_Rec_Pass.Text.Equals("")) {
                MessageBox.Show("กรุณาใส่ User, Password(God, Admin)", "unsuccessful",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cid == false) {
                MessageBox.Show("ไม่มีรหัสนักศึกษานี้ กรุณาลงทะเบียนสมาชิก", "unsuccessful",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            com.Open();
            SQLiteCommand cmd_r = new SQLiteCommand("SELECT COUNT(*) FROM MEMBER", com);
            int Tabrows = Convert.ToInt32(cmd_r.ExecuteScalar());
            com.Close();
            com.Open();
            SQLiteCommand cmdsearch = new SQLiteCommand("SELECT * FROM MEMBER", com);
            SQLiteDataReader readsearch = cmdsearch.ExecuteReader();
            userpass = false;
            user_ag = "";
            while (readsearch.Read())
            {
                if (readsearch["StanaM"].ToString().Equals("God") || readsearch["StanaM"].ToString().Equals("Admin"))
                {
                    //userpass.Add(readsearch["User"].ToString(), readsearch["Pass"].ToString());
                    if (readsearch["User"].ToString().Equals(textBox_Rec_User.Text) && readsearch["Pass"].ToString().Equals(textBox_Rec_Pass.Text)) {
                        if (readsearch["IDKMITL"].ToString().Equals(textBox_ITKMITL2.Text)) {
                            MessageBox.Show("ขออภัยคุณไม่สามารถอนุญาติตัวเองได้", "unsuccessful",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                            com.Close();
                            return;
                        }
                        userpass = true;
                        user_ag = readsearch["Name"].ToString();

                    }
                    else if (Convert.ToInt32(readsearch["ID"].ToString()) == Tabrows && userpass == false)
                    {
                        MessageBox.Show("ขออภัยคุณกรอก Username หรือ Password(God, Admin) ไม่ถูกต้อง", "unsuccessful",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        com.Close();
                        return;
                    }

                }
                else if (Convert.ToInt32(readsearch["ID"].ToString()) == Tabrows && userpass==false)
                {
                    MessageBox.Show("ขออภัยคุณกรอก Username หรือ Password(God, Admin) ไม่ถูกต้อง", "unsuccessful",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    com.Close();
                    return;
                }
            }
            com.Close();
           
            al_thing = new ArrayList();
            al_CountThing = new ArrayList();

            string theDate = dateTimePicker1.Value.ToString("dd-MM-yyyy");
            string theDate2 = dateTimePicker2.Value.ToString("dd-MM-yyyy");

            theDate += "Time:"+comboBox_DataLend_Hourse.SelectedItem+""+ comboBox_DataLend_min.SelectedItem;
            theDate2 += "Time:" + comboBox_DataBack_Hourse.SelectedItem + "" + comboBox_DataBack_min.SelectedItem;

            foreach (Control item in Recoard_Panel2.Controls.OfType<Control>())
            {
                if (item.Name == "Thing" && item.Text != "") { 
                    al_thing.Add(item.Text);
                }
                else if (item.Name == "value" && item.Text != "")
                {
                    al_CountThing.Add(Convert.ToInt32(item.Text));
                }
            }
           
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            com.Open();
            SQLiteCommand cmdcountall2 = new SQLiteCommand("SELECT * FROM RECALL ORDER BY ID DESC", com);
            SQLiteDataReader readline2 = cmdcountall2.ExecuteReader();
            Dictionary<string, int> dictt_all_ = new Dictionary<string, int>();
            Dictionary<string, int> dictt_all2_ = new Dictionary<string, int>();
            string les = "";
            //get Status All
            bool ch = false;
            while (readline2.Read())
            {
                if (textBox_ITKMITL2.Text.Equals(readline2["IDKMITL"].ToString()) && ch==false)
                {
                    dictt_all_ = readline2["StatusAll"].ToString().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                      .Select(part => part.Split('='))
                      .ToDictionary(split => split[0], split => Convert.ToInt32(split[1]));
                    dictt_all2_ = readline2["StatusAll"].ToString().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                       .Select(part => part.Split('='))
                       .ToDictionary(split => split[0], split => Convert.ToInt32(split[1]));
                    les = readline2["StatusAll"].ToString();
                    ch = true;
                }
            }

            com.Close();
            //--------------------------------------------------------------
            for (int j = 0; j < al_thing.Count; j++) {
                
                

                try
                {               
                    dictionary.Add(al_thing[j] + "", Convert.ToInt32(al_CountThing[j]));
                }
                catch
                {      
                    dictionary[al_thing[j] + ""] += Convert.ToInt32(al_CountThing[j]);
                }
            }

            //---------------------------------------------------------
            bool che = true;
            com.Open();
            Dictionary<string, int> dicttcon = new Dictionary<string, int>();
            for (int j = 0; j < al_thing.Count; j++)
            {
               
                SQLiteCommand cmdcheck = new SQLiteCommand("SELECT * FROM THING", com);
                SQLiteDataReader readd = cmdcheck.ExecuteReader();
                while (readd.Read())
                {
                   
                    if (readd["IDTHING"].Equals(al_thing[j] + ""))
                    {
                        try
                        {
                            dicttcon.Add(readd["Name"] +"", Convert.ToInt32(al_CountThing[j]));
                        }
                        catch
                        {
                            dicttcon[readd["Name"] + ""] += Convert.ToInt32(al_CountThing[j]);
                        }
                        if (Convert.ToInt32(readd["Count"]) < Convert.ToInt32(al_CountThing[j])) {
                            che = false;
                        }
                    }
                }

            }
            com.Close();
            
            string s = string.Join(";", dictionary.Select(x => x.Key + "=" + x.Value).ToArray());
            string s_q = string.Join("\n", dicttcon.Select(x => x.Key + "=" + x.Value).ToArray());

            if (radioButton_Res.Checked) {
                DialogResult dialogResult = MessageBox.Show(s_q+"\n ทั้งหมด "+dicttcon.Count +" รายการ", "Some Title", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
                string s_all = string.Join(";", dictt_all_.Select(x => x.Key + "=" + x.Value).ToArray());
                
                MessageBox.Show("บันทึกการจองเสร็จเรียบร้อย ถ้ามีการเปลี่ยนแปลง ทางสโมฯจะติดต่อกลับครับ", "successful",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                stana = "จอง";
                st_all = les;

            }

            else if (radioButton_lend.Checked)
            {
                if (che == false) {
                    DialogResult dialogResult_false = MessageBox.Show(s_q + "\n ทั้งหมด " + dicttcon.Count + " รายการ", "Some Title", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DialogResult dialogResult = MessageBox.Show(s_q + "\n ทั้งหมด " + dicttcon.Count + " รายการ", "Some Title", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
                //---------------------------------------------------------------
                for (int j = 0; j < al_thing.Count; j++) {
                    try
                    {
                        dictt_all_.Add(al_thing[j] + "", Convert.ToInt32(al_CountThing[j]));
                    }
                    catch
                    {
                        dictt_all_[al_thing[j] + ""] += Convert.ToInt32(al_CountThing[j]);
                    }
                }
                //---------------------------------------------------------------
                string s_all = string.Join(";", dictt_all_.Select(x => x.Key + "=" + x.Value).ToArray());
                com.Open();

                //change Value
                foreach (var k in dictionary) {
                    SQLiteCommand cmd2 = new SQLiteCommand("SELECT * FROM THING", com);
                    SQLiteDataReader read = cmd2.ExecuteReader();
                    while (read.Read())
                    {
                        if (read["IDTHING"].Equals(k.Key)) {
                            //UPDATE COMPANY SET ADDRESS = 'Texas' WHERE ID = 6;
                            String str_updatee ="UPDATE THING SET Count = "+ (Convert.ToInt32(read["Count"]) - Convert.ToInt32(k.Value))+" WHERE ID = "+read["ID"];
                            SQLiteCommand cmdUpDatee = new SQLiteCommand(str_updatee, com);
                            cmdUpDatee.ExecuteNonQuery();
                        }
                    }
                }
                SQLiteCommand cmdL = new SQLiteCommand("SELECT * FROM CARD", com);
                SQLiteDataReader readL = cmdL.ExecuteReader();
                while (readL.Read()) {
                    if (readL["IDCARD"].ToString().Equals(comboBox_Card2.SelectedItem.ToString())) {
                        String str_update = "UPDATE CARD SET Stana = 'False' WHERE ID = " + readL["ID"];
                        SQLiteCommand cmdUpDate = new SQLiteCommand(str_update, com);
                        cmdUpDate.ExecuteNonQuery();
                    }
                }

                
                com.Close();
                //---------------------------------------------------------------
               
                stana = "ยืม";
                st_all = s_all;
                MessageBox.Show("บันทึกการยืมเสร็จเรียบร้อย กรุณาคืนพัสดุตามกำหนด และทางสโมฯขออนุญาติทำการปรับในกรณีคืนพัสดุล่าช้าครับ", "successful",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (radioButton_back.Checked)
            {
                DialogResult dialogResult = MessageBox.Show(s_q + "\n ทั้งหมด " + dicttcon.Count + " รายการ", "Some Title", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
                //---------------------------------------------------------------
                for (int j = 0; j < al_thing.Count; j++)
                {
                    try
                    {
                        dictt_all2_.Add(al_thing[j] + "", Convert.ToInt32(al_CountThing[j]));
                    }
                    catch
                    {
                        dictt_all2_[al_thing[j] + ""] -= Convert.ToInt32(al_CountThing[j]);
                        if (dictt_all2_[al_thing[j] + ""]==0) {
                            dictt_all2_.Remove(al_thing[j] + "");
                        }
                    }
                }
                //---------------------------------------------------------------
                com.Open();
                string s_all2 = string.Join(";", dictt_all2_.Select(x => x.Key + "=" + x.Value).ToArray());

                //change Value
                foreach (var k in dictionary)
                {
                    SQLiteCommand cmd2 = new SQLiteCommand("SELECT * FROM THING", com);
                    SQLiteDataReader read = cmd2.ExecuteReader();
                    while (read.Read())
                    {
                        //Console.WriteLine(k.Key + "/" + read["IDTHING"]);
                        if (read["IDTHING"].Equals(k.Key))
                        {
                            //UPDATE COMPANY SET ADDRESS = 'Texas' WHERE ID = 6;
                            String str_update = "UPDATE THING SET Count = " + (Convert.ToInt32(read["Count"]) + Convert.ToInt32(k.Value)) + " WHERE ID = " + read["ID"];
                            //Console.WriteLine(str_update);
                            SQLiteCommand cmdUpDate = new SQLiteCommand(str_update, com);
                            cmdUpDate.ExecuteNonQuery();
                            //break;
                        }
                    }
                }
                SQLiteCommand cmdL = new SQLiteCommand("SELECT * FROM CARD", com);
                SQLiteDataReader readL = cmdL.ExecuteReader();
                while (readL.Read())
                {
                    if (readL["IDCARD"].ToString().Equals(comboBox_Card2.SelectedItem.ToString()))
                    {
                        String str_update = "UPDATE CARD SET Stana = 'True' WHERE ID = " + readL["ID"];
                        SQLiteCommand cmdUpDate = new SQLiteCommand(str_update, com);
                        cmdUpDate.ExecuteNonQuery();
                    }
                }

                com.Close();
                //---------------------------------------------------------------
               
                stana = "คืน";
                st_all = s_all2;
                MessageBox.Show("บันทึกการคืนเสร็จเรียบร้อย", "successful",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            

            com.Open();
            SQLiteCommand cmd_all = new SQLiteCommand(@"insert into 
                            RECALL (IDKMITL, Stana, BeTo, Project, DataLend, DataBack, Thing, Card, StatusAll, Accept)
                            values($IDKMITL, $Stana, $Beto, $Project, $DataLend, $DataBack, $Thing, $Card, $StatusAll, $Accept)", com);
            cmd_all.Parameters.AddWithValue("$IDKMITL", textBox_ITKMITL2.Text);
            cmd_all.Parameters.AddWithValue("$Stana", stana);
            cmd_all.Parameters.AddWithValue("$Beto", textBox_BeTo2.Text);
            cmd_all.Parameters.AddWithValue("$Project", textBox_Project2.Text);
            if (radioButton_back.Checked) { theDate = ""; }
            cmd_all.Parameters.AddWithValue("$DataLend", theDate);
            //if (radioButton_back.Checked) { dateTimePicker1.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day); }
            cmd_all.Parameters.AddWithValue("$DataBack", theDate2);
            cmd_all.Parameters.AddWithValue("$Thing", s);
            string card_naja="";
            if (!radioButton_Res.Checked) { card_naja = comboBox_Card2.SelectedItem.ToString(); }
                
            if (radioButton_Res.Checked) { card_naja = "xx"; }
            cmd_all.Parameters.AddWithValue("$Card", card_naja);
            cmd_all.Parameters.AddWithValue("$StatusAll", st_all);
            cmd_all.Parameters.AddWithValue("$Accept", user_ag);
            cmd_all.ExecuteNonQuery();
            com.Close();
            TableAll_update(sender, e);
            textBox_SearchMember_TextChanged(sender, e);
            comboBox2_SelectedIndexChanged(sender, e);
            TableAll_update_Admin(sender, e);
            //---------
            Recoard_Panel2.Controls.Clear();
            groupBox1.Controls.Clear();
            a = 0;
            //---------


        }

        //-------------------------------------Thing---------------------------------------------//
        private void textBox_IDThing_TextChanged(object sender, EventArgs e)
        {
            com.Open();
            sea = new ArrayList();
            SQLiteCommand cmd = new SQLiteCommand("SELECT COUNT(*) FROM THING", com);
            int Tabrows = Convert.ToInt32(cmd.ExecuteScalar());
            com.Close();
            abc = false;
            com.Open();
            SQLiteCommand cmdsearch = new SQLiteCommand("SELECT * FROM THING", com);
            SQLiteDataReader readsearch = cmdsearch.ExecuteReader();
            while (readsearch.Read())
            {

                if (textBox_IDThing.Text.Equals(readsearch["IDTHING"]))
                {
                    textBox_NameThing.Text = readsearch["Name"].ToString();
                    textBox_CountAll.Text = readsearch["CountAll"].ToString();
                    textBox_PriceThing.Text = readsearch["Price"].ToString();
                    richTextBox_Otherr.Text = readsearch["Other"].ToString();
                    label6.Text = "มีข้อมูล";
                    label6.ForeColor = Color.Green;
                    abc = true;
                }
                else if (Convert.ToInt32(readsearch["ID"]) == Tabrows && abc == false)
                {
                    textBox_NameThing.Text = "";
                    textBox_CountAll.Text = "";
                    textBox_PriceThing.Text = "";
                    richTextBox_Otherr.Text = "";
                    label6.Text = "ไม่มีข้อมูล";
                    label6.ForeColor = Color.Red;
                }
            }
            com.Close();
        }
        private void button_AddThing_Click(object sender, EventArgs e)
        {
            if (textBox_IDThing.Text.Equals("") ||
                textBox_NameThing.Text.Equals("") ||
                //richTextBox_Otherr.Text.Equals("") ||
                textBox_CountAll.Text.Equals("") ||
                textBox_PriceThing.Text.Equals("")
                )
            {
                MessageBox.Show("ขออภัยคุณกรอกข้อมูลไม่ครบ", "unsuccessful",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //++++++++++++++++++++++++++++
            if (abc == true)
            {
                com.Open();

                int countss = 0;
                int countssAll = 0;
                SQLiteCommand cmds = new SQLiteCommand("SELECT * FROM THING", com);
                SQLiteDataReader reads = cmds.ExecuteReader();
                while (reads.Read()) {
                    if (reads["IDTHING"].Equals(textBox_IDThing.Text)) {
                        countss = Convert.ToInt32(reads["Count"].ToString());
                        countssAll = Convert.ToInt32(reads["CountAll"].ToString());
                    }

                }
                int countcount = 0;
                countcount = (Convert.ToInt32(textBox_CountAll.Text))-(countssAll-countss);
                dic_i = new Dictionary<string, string> {
                    { "Name", textBox_NameThing.Text },
                    { "Count", countcount.ToString() },
                    { "CountAll", textBox_CountAll.Text},
                    { "Price", textBox_PriceThing.Text },
                    { "Other", richTextBox_Otherr.Text}
                    };
                com.Close();
                com.Open();
                SQLiteCommand cmd2 = new SQLiteCommand("SELECT * FROM THING", com);
                SQLiteDataReader read = cmd2.ExecuteReader();
                while (read.Read())
                {
                    if (read["IDTHING"].Equals(textBox_IDThing.Text))
                    {
                        foreach (var ii in dic_i)
                        {
                            String str_update = "UPDATE THING SET " + ii.Key + " = '" + ii.Value + "' WHERE ID = " + read["ID"]; ;
                            SQLiteCommand cmdUpDate = new SQLiteCommand(str_update, com);
                            cmdUpDate.ExecuteNonQuery();
                        }
                    }
                }
                com.Close();
                MessageBox.Show("บันทึกการเปลี่ยนแปลงข้อมูลสิ่งของเรียบร้อย");
                textBox_IDThing_TextChanged(sender, e);
                return;
            }
            //++++++++++++++++++++++++++++




            com.Open();

            SQLiteCommand cmdna = new SQLiteCommand(@"insert into 
                            THING (IDTHING, Name, Price, Count, CountAll, Other)
                            values($IDTHING, $Name, $Price, $Count, $CountAll, $Other)", com);

            cmdna.Parameters.AddWithValue("$IDTHING", textBox_IDThing.Text);
            cmdna.Parameters.AddWithValue("$Name", textBox_NameThing.Text);
            cmdna.Parameters.AddWithValue("$Price", textBox_PriceThing.Text);
            cmdna.Parameters.AddWithValue("$Count", int.Parse(textBox_CountAll.Text));
            cmdna.Parameters.AddWithValue("$CountAll", int.Parse(textBox_CountAll.Text));
            cmdna.Parameters.AddWithValue("$Other", richTextBox_Otherr.Text);
            cmdna.ExecuteNonQuery();
            com.Close();
            MessageBox.Show("บันทึกการเพิ่มเติมสิ่งของเสร็จเรียบร้อย", "successful",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //------------------------------------TableAll-------------------------------------------//
        private void TableAll_CreateTable_Thing(object sender, EventArgs e, bool cc)
        {
            TableAll_Panel_Thing = new Panel();
            TableAll_Panel_Thing.AutoScroll = true;
            TableAll_Panel_Thing.Top = 15;
            TableAll_Panel_Thing.Left = 10;
            TableAll_Panel_Thing.Width = groupBox3.Width - 10;
            TableAll_Panel_Thing.Height = groupBox3.Height - 15;
            com.Open();
            SQLiteCommand cmd = new SQLiteCommand("SELECT COUNT(*) FROM THING", com);
            TableAll_CountRow_Thing = Convert.ToInt32(cmd.ExecuteScalar());

            TabAll_Table_Thing = new TableLayoutPanel();
            if (!cc) { com.Close(); return; }
            TabAll_Table_Thing.ColumnCount = 7;
            TabAll_Table_Thing.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            TabAll_Table_Thing.RowCount = TableAll_CountRow_Thing + 1;

            TabAll_Table_Thing.Top = 9;
            TabAll_Table_Thing.Left = 20;
            TabAll_Table_Thing.AutoSize = true;


            TabAll_Table_Thing.ColumnStyles.Add(new ColumnStyle());

            TabAll_Table_Thing.Controls.Add(new Label() { Text = "ลำดับ", AutoSize = true }, 0, 0);
            TabAll_Table_Thing.Controls.Add(new Label() { Text = "รหัสพัสดุ", AutoSize = true }, 1, 0);
            TabAll_Table_Thing.Controls.Add(new Label() { Text = "ชื่อพัสดุ", AutoSize = true }, 2, 0);
            TabAll_Table_Thing.Controls.Add(new Label() { Text = "จำนวนที่มี", AutoSize = true }, 3, 0);
            TabAll_Table_Thing.Controls.Add(new Label() { Text = "จำนวณทั้งหมด", AutoSize = true }, 4, 0);
            TabAll_Table_Thing.Controls.Add(new Label() { Text = "ราคาพัสดุ", AutoSize = true }, 5, 0);
            TabAll_Table_Thing.Controls.Add(new Label() { Text = "หมายเหตุ", AutoSize = true }, 6, 0);

            TabAll_Table_Thing.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            SQLiteCommand cmd2 = new SQLiteCommand("SELECT * FROM THING", com);
            SQLiteDataReader read = cmd2.ExecuteReader();
            TableAll_CountLine__Thing = 1;
            while (read.Read())
            {
                TabAll_Table_Thing.Controls.Add(new Label() { Text = read["ID"] + "", AutoSize = true }, 0, 0 + TableAll_CountLine__Thing);
                TabAll_Table_Thing.Controls.Add(new Label() { Text = read["IDTHING"] + "", AutoSize = true }, 1, 0 + TableAll_CountLine__Thing);
                TabAll_Table_Thing.Controls.Add(new Label() { Text = read["name"] + "", AutoSize = true }, 2, 0 + TableAll_CountLine__Thing);
                TabAll_Table_Thing.Controls.Add(new Label() { Text = read["Count"] + "", AutoSize = true }, 3, 0 + TableAll_CountLine__Thing);
                TabAll_Table_Thing.Controls.Add(new Label() { Text = read["CountAll"] + "", AutoSize = true }, 4, 0 + TableAll_CountLine__Thing);
                TabAll_Table_Thing.Controls.Add(new Label() { Text = read["Price"] + "", AutoSize = true }, 5, 0 + TableAll_CountLine__Thing);
                TabAll_Table_Thing.Controls.Add(new Label() { Text = read["Other"] + "", AutoSize = true }, 6, 0 + TableAll_CountLine__Thing);
                TableAll_CountLine__Thing += 1;
            }
            com.Close();
            TableAll_Panel_Thing.Controls.Add(TabAll_Table_Thing);
            groupBox3.Controls.Add(TableAll_Panel_Thing);
            com.Close();
        }
        private void TableAll_ClearTable_Thing(object sender, EventArgs e)
        {
            TabAll_Table_Thing.Controls.Clear();
            TableAll_Panel_Thing.Controls.Clear();
            groupBox3.Controls.Clear();
        }
        private void TableAll_update(object sender, EventArgs e)
        {
            TableAll_CreateTable_Thing(sender, e, false);
            TableAll_ClearTable_Thing(sender, e);
            TableAll_CreateTable_Thing(sender, e, true);

        }

        private void TableAll_CreateTable_Member(object sender, EventArgs e, bool cc)
        {
            TableAll_Panel_Member = new Panel();
            TableAll_Panel_Member.AutoScroll = true;
            TableAll_Panel_Member.Top = 15;
            TableAll_Panel_Member.Left = 10;
            TableAll_Panel_Member.Width = groupBox4.Width - 10;
            TableAll_Panel_Member.Height = groupBox4.Height - 15;
            com.Open();

            SQLiteCommand cmd = new SQLiteCommand("SELECT COUNT(*) FROM MEMBER", com);
            TableAll_CountRow_Member = Convert.ToInt32(cmd.ExecuteScalar());

            TabAll_Table_Member = new TableLayoutPanel();
            if (!cc) { com.Close(); return; }
            TabAll_Table_Member.ColumnCount = 10;
            TabAll_Table_Member.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            TabAll_Table_Member.RowCount = TableAll_CountRow_Member + 1;

            TabAll_Table_Member.Top = 9;
            TabAll_Table_Member.Left = 20;
            TabAll_Table_Member.AutoSize = true;

            TabAll_Table_Member.ColumnStyles.Add(new ColumnStyle());

            TabAll_Table_Member.Controls.Add(new Label() { Text = "ลำดับ", AutoSize = true }, 0, 0);
            TabAll_Table_Member.Controls.Add(new Label() { Text = "รหัสนักศึกษา", AutoSize = true }, 1, 0);
            TabAll_Table_Member.Controls.Add(new Label() { Text = "ประเภท", AutoSize = true }, 2, 0);
            TabAll_Table_Member.Controls.Add(new Label() { Text = "ชื่อ-นามสกุล", AutoSize = true }, 3, 0);
            TabAll_Table_Member.Controls.Add(new Label() { Text = "ชื่อเล่น", AutoSize = true }, 4, 0);
            TabAll_Table_Member.Controls.Add(new Label() { Text = "ภาควิชา", AutoSize = true }, 5, 0);
            TabAll_Table_Member.Controls.Add(new Label() { Text = "ห้อง", AutoSize = true }, 6, 0);
            TabAll_Table_Member.Controls.Add(new Label() { Text = "คณะ", AutoSize = true }, 7, 0);
            TabAll_Table_Member.Controls.Add(new Label() { Text = "โทรศัพท์", AutoSize = true }, 8, 0);
            TabAll_Table_Member.Controls.Add(new Label() { Text = "หมายเหตุ", AutoSize = true }, 9, 0);

            TabAll_Table_Member.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            SQLiteCommand cmd2 = new SQLiteCommand("SELECT * FROM Member", com);
            SQLiteDataReader read = cmd2.ExecuteReader();
            TableAll_CountLine_Member = 1;
            while (read.Read())
            {
                TabAll_Table_Member.Controls.Add(new Label() { Text = read["ID"] + "", AutoSize = true }, 0, 0 + TableAll_CountLine_Member);
                TabAll_Table_Member.Controls.Add(new Label() { Text = read["IDKMITL"] + "", AutoSize = true }, 1, 0 + TableAll_CountLine_Member);
                TabAll_Table_Member.Controls.Add(new Label() { Text = read["StanaM"] + "", AutoSize = true }, 2, 0 + TableAll_CountLine_Member);
                TabAll_Table_Member.Controls.Add(new Label() { Text = read["Name"] + "", AutoSize = true }, 3, 0 + TableAll_CountLine_Member);
                TabAll_Table_Member.Controls.Add(new Label() { Text = read["Nic"] + "", AutoSize = true }, 4, 0 + TableAll_CountLine_Member);
                TabAll_Table_Member.Controls.Add(new Label() { Text = read["Park"] + "", AutoSize = true }, 5, 0 + TableAll_CountLine_Member);
                TabAll_Table_Member.Controls.Add(new Label() { Text = read["Room"] + "", AutoSize = true }, 6, 0 + TableAll_CountLine_Member);
                TabAll_Table_Member.Controls.Add(new Label() { Text = read["Faculty"] + "", AutoSize = true }, 7, 0 + TableAll_CountLine_Member);
                TabAll_Table_Member.Controls.Add(new Label() { Text = read["Phone"] + "", AutoSize = true }, 8, 0 + TableAll_CountLine_Member);
                TabAll_Table_Member.Controls.Add(new Label() { Text = read["Other"] + "", AutoSize = true }, 9, 0 + TableAll_CountLine_Member);
                TableAll_CountLine_Member += 1;
            }
            com.Close();
            TableAll_Panel_Member.Controls.Add(TabAll_Table_Member);
            groupBox4.Controls.Add(TableAll_Panel_Member);
            com.Close();
        }
        private void TableAll_ClearTable_Member(object sender, EventArgs e)
        {
            TabAll_Table_Member.Controls.Clear();
            TableAll_Panel_Member.Controls.Clear();
            groupBox4.Controls.Clear();
        }
        private void TableAll_update_Member(object sender, EventArgs e)
        {
            TableAll_CreateTable_Member(sender, e, false);
            TableAll_ClearTable_Member(sender, e);
            TableAll_CreateTable_Member(sender, e, true);
        }

        private void TableAll_CreateTable_MemberRec(object sender, EventArgs e, bool cc)
        {
            TableAll_Panel_MemberRec = new Panel();
            TableAll_Panel_MemberRec.AutoScroll = true;
            TableAll_Panel_MemberRec.Top = 15;
            TableAll_Panel_MemberRec.Left = 10;
            TableAll_Panel_MemberRec.Width = groupBox5.Width - 10;
            TableAll_Panel_MemberRec.Height = groupBox5.Height - 15;
            
            com.Open();
            
            SQLiteCommand cmd = new SQLiteCommand("SELECT COUNT(*) FROM RECALL", com);
            TableAll_CountRow_MemberRec = Convert.ToInt32(cmd.ExecuteScalar());

            TabAll_Table_MemberRec = new TableLayoutPanel();
            if (!cc) { com.Close(); return; }
            TabAll_Table_MemberRec.ColumnCount = 10;
            TabAll_Table_MemberRec.RowCount = TableAll_CountRow_MemberRec + 1;
            TabAll_Table_MemberRec.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            TabAll_Table_MemberRec.Top = 9;
            TabAll_Table_MemberRec.Left = 20;
            TabAll_Table_MemberRec.AutoSize = true;

            TabAll_Table_MemberRec.ColumnStyles.Add(new ColumnStyle());

            TabAll_Table_MemberRec.Controls.Add(new Label() { Text = "ลำดับ", AutoSize = true }, 0, 0);
            TabAll_Table_MemberRec.Controls.Add(new Label() { Text = "สถานะ", AutoSize = true }, 1, 0);
            TabAll_Table_MemberRec.Controls.Add(new Label() { Text = "สังกัด", AutoSize = true }, 2, 0);
            TabAll_Table_MemberRec.Controls.Add(new Label() { Text = "โครงงาน", AutoSize = true }, 3, 0);
            TabAll_Table_MemberRec.Controls.Add(new Label() { Text = "วันที่ยืม", AutoSize = true }, 4, 0);
            TabAll_Table_MemberRec.Controls.Add(new Label() { Text = "วันที่คืน", AutoSize = true }, 5, 0);
            TabAll_Table_MemberRec.Controls.Add(new Label() { Text = "ช่องใส่การ์ด", AutoSize = true }, 6, 0);
            TabAll_Table_MemberRec.Controls.Add(new Label() { Text = "พัสดุ", AutoSize = true }, 7, 0);
            TabAll_Table_MemberRec.Controls.Add(new Label() { Text = "ยังไม่ได้คืน", AutoSize = true }, 8, 0);
            TabAll_Table_MemberRec.Controls.Add(new Label() { Text = "ผู้อนุญาติ", AutoSize = true }, 9, 0);

            TabAll_Table_MemberRec.RowStyles.Add(new RowStyle(SizeType.AutoSize));


            string se = "";
            if (comboBox1.SelectedIndex==0) { se = "SELECT * FROM RECALL ORDER BY ID ASC"; }
            else if (comboBox1.SelectedIndex == 1) { se = "SELECT * FROM RECALL ORDER BY ID DESC"; }
            SQLiteCommand cmd2 = new SQLiteCommand(se, com);

            SQLiteDataReader read = cmd2.ExecuteReader();
            TableAll_CountLine_MemberRec = 1;
            
            while (read.Read())
            {
                if (read["IDKMITL"].ToString().Equals(textBox_SearchMember.Text)) {
                    Dictionary<string, int> dictt_all = new Dictionary<string, int>();
                    Dictionary<string, int> dictt_all2 = new Dictionary<string, int>();
                    Dictionary<string, int> dictt_thing = new Dictionary<string, int>();
                    Dictionary<string, int> dictt_thing2 = new Dictionary<string, int>();
                    dictt_all = read["StatusAll"].ToString().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                       .Select(part => part.Split('='))
                       .ToDictionary(split => split[0], split => Convert.ToInt32(split[1]));
                    dictt_thing = read["Thing"].ToString().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                       .Select(part => part.Split('='))
                       .ToDictionary(split => split[0], split => Convert.ToInt32(split[1]));

                    foreach (var i in dictt_all) {
                        SQLiteCommand cmd_con = new SQLiteCommand("SELECT * FROM THING", com);
                        SQLiteDataReader read_con = cmd_con.ExecuteReader();
                        while (read_con.Read()) {
                            if (i.Key.Equals(read_con["IDTHING"].ToString())) {
                                dictt_all2.Add(read_con["Name"].ToString(), i.Value);
                            }
                        }
                    }
                    foreach (var i in dictt_thing)
                    {
                        SQLiteCommand cmd_con = new SQLiteCommand("SELECT * FROM THING", com);
                        SQLiteDataReader read_con = cmd_con.ExecuteReader();
                        while (read_con.Read())
                        {
                            if (i.Key.Equals(read_con["IDTHING"].ToString()))
                            {
                                dictt_thing2.Add(read_con["Name"].ToString(), i.Value);
                            }
                        }
                    }
                    string s_all2 = string.Join("\n", dictt_all2.Select(x => x.Key + "=" + x.Value).ToArray());
                    string s_thing = string.Join("\n", dictt_thing2.Select(x => x.Key + "=" + x.Value).ToArray());

                    string s1 = read["Thing"].ToString().Replace(";", "\n");
                    string s = read["StatusAll"].ToString().Replace(";", "\n");
                    TabAll_Table_MemberRec.Controls.Add(new Label() { Text = read["ID"] + "", AutoSize = true }, 0, 0 + TableAll_CountLine_MemberRec);
                    TabAll_Table_MemberRec.Controls.Add(new Label() { Text = read["Stana"] + "", AutoSize = true }, 1, 0 + TableAll_CountLine_MemberRec);
                    TabAll_Table_MemberRec.Controls.Add(new Label() { Text = read["Beto"] + "", AutoSize = true }, 2, 0 + TableAll_CountLine_MemberRec);
                    TabAll_Table_MemberRec.Controls.Add(new Label() { Text = read["Project"] + "", AutoSize = true }, 3, 0 + TableAll_CountLine_MemberRec);
                    TabAll_Table_MemberRec.Controls.Add(new Label() { Text = read["DataLend"] + "", AutoSize = true }, 4, 0 + TableAll_CountLine_MemberRec);
                    TabAll_Table_MemberRec.Controls.Add(new Label() { Text = read["DataBack"] + "", AutoSize = true }, 5, 0 + TableAll_CountLine_MemberRec);
                    TabAll_Table_MemberRec.Controls.Add(new Label() { Text = read["Card"] + "", AutoSize = true }, 6, 0 + TableAll_CountLine_MemberRec);
                    TabAll_Table_MemberRec.Controls.Add(new Label() { Text = s_thing + "", AutoSize = true }, 7, 0 + TableAll_CountLine_MemberRec);
                    TabAll_Table_MemberRec.Controls.Add(new Label() { Text = s_all2 + "", AutoSize = true }, 8, 0 + TableAll_CountLine_MemberRec);
                    TabAll_Table_MemberRec.Controls.Add(new Label() { Text = read["Accept"] + "", AutoSize = true }, 9, 0 + TableAll_CountLine_MemberRec);

                    TableAll_CountLine_MemberRec += 1;
                }
            }
            TableAll_Panel_MemberRec.Controls.Add(TabAll_Table_MemberRec);
            groupBox5.Controls.Add(TableAll_Panel_MemberRec);
            com.Close();
        }
        private void TableAll_ClearTable_MemberRec(object sender, EventArgs e)
        {
            TabAll_Table_MemberRec.Controls.Clear();
            TableAll_Panel_MemberRec.Controls.Clear();
            groupBox5.Controls.Clear();
        }
        private void TableAll_update_MemberRec(object sender, EventArgs e)
        {
            TableAll_CreateTable_MemberRec(sender, e, false);
            TableAll_ClearTable_MemberRec(sender, e);
            TableAll_CreateTable_MemberRec(sender, e, true);
        }

        private void TableAll_CreateTable_ALL(object sender, EventArgs e, bool cc)
        {
            TableAll_Panel_ALL = new Panel();
            TableAll_Panel_ALL.AutoScroll = true;
            TableAll_Panel_ALL.Top = 15;
            TableAll_Panel_ALL.Left = 10;
            TableAll_Panel_ALL.Width = groupBox6.Width - 10;
            TableAll_Panel_ALL.Height = groupBox6.Height - 15;
            com.Open();

            SQLiteCommand cmd = new SQLiteCommand("SELECT COUNT(*) FROM RECALL", com);
            TableAll_CountRow_ALL = Convert.ToInt32(cmd.ExecuteScalar());

            TabAll_Table_ALL = new TableLayoutPanel();
            if (!cc) { com.Close(); return; }
            TabAll_Table_ALL.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            TabAll_Table_ALL.ColumnCount = 13;
            TabAll_Table_ALL.RowCount = TableAll_CountRow_ALL + 1;

            TabAll_Table_ALL.Top = 9;
            TabAll_Table_ALL.Left = 20;
            TabAll_Table_ALL.AutoSize = true;

            TabAll_Table_ALL.ColumnStyles.Add(new ColumnStyle());
            //TabAll_Table_ALL.Col

            TabAll_Table_ALL.Controls.Add(new Label() { Text = "ลำดับ", AutoSize = true }, 0, 0);
            TabAll_Table_ALL.Controls.Add(new Label() { Text = "รหัสนักศึกษา", AutoSize = true }, 1, 0);
            TabAll_Table_ALL.Controls.Add(new Label() { Text = "สถานะ", AutoSize = true }, 2, 0);
            TabAll_Table_ALL.Controls.Add(new Label() { Text = "สังกัด", AutoSize = true }, 3, 0);
            TabAll_Table_ALL.Controls.Add(new Label() { Text = "โครงงาน", AutoSize = true }, 4, 0);
            TabAll_Table_ALL.Controls.Add(new Label() { Text = "วันที่ยืม", AutoSize = true }, 5, 0);
            TabAll_Table_ALL.Controls.Add(new Label() { Text = "วันที่คืน", AutoSize = true }, 6, 0);
            TabAll_Table_ALL.Controls.Add(new Label() { Text = "ช่องใส่การ์ด", AutoSize = true }, 7, 0);
            TabAll_Table_ALL.Controls.Add(new Label() { Text = "รหัสพัสดุ", AutoSize = true }, 8, 0);
            TabAll_Table_ALL.Controls.Add(new Label() { Text = "พัสดุ", AutoSize = true }, 9, 0);
            TabAll_Table_ALL.Controls.Add(new Label() { Text = "ยังไม่ได้คืน", AutoSize = true }, 10, 0);
            TabAll_Table_ALL.Controls.Add(new Label() { Text = "ยังไม่ได้คืน", AutoSize = true }, 11, 0);
            TabAll_Table_ALL.Controls.Add(new Label() { Text = "ผู้อนุญาติ", AutoSize = true }, 12, 0);

            TabAll_Table_ALL.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            string se = "";
            if (comboBox2.SelectedIndex == 0) { se = "SELECT * FROM RECALL ORDER BY ID ASC"; }
            else if (comboBox2.SelectedIndex == 1) { se = "SELECT * FROM RECALL ORDER BY ID DESC"; }
            SQLiteCommand cmd2 = new SQLiteCommand(se, com);

            SQLiteDataReader read = cmd2.ExecuteReader();

            TableAll_CountLine_ALL = 1;
            string stana_all = "All";
            bool all = false; ;
            if (radioButton1.Checked) {
                stana_all = "ALL";
                all = true;
            }
            else if (radioButton2.Checked)
            {
                stana_all = "จอง";
            }
            else if (radioButton3.Checked)
            {
                stana_all = "ยืม";
            }
            else if (radioButton4.Checked)
            {
                stana_all = "คืน";
            }


            while (read.Read())
            {
                
                if (read["Stana"].ToString().Equals(stana_all)||all)
                {
                    Dictionary<string, int> dictt_all = new Dictionary<string, int>();
                    Dictionary<string, int> dictt_all2 = new Dictionary<string, int>();
                    Dictionary<string, int> dictt_thing = new Dictionary<string, int>();
                    Dictionary<string, int> dictt_thing2 = new Dictionary<string, int>();
                    dictt_all = read["StatusAll"].ToString().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                       .Select(part => part.Split('='))
                       .ToDictionary(split => split[0], split => Convert.ToInt32(split[1]));
                    dictt_thing = read["Thing"].ToString().Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
                       .Select(part => part.Split('='))
                       .ToDictionary(split => split[0], split => Convert.ToInt32(split[1]));

                    foreach (var i in dictt_all)
                    {
                        SQLiteCommand cmd_con = new SQLiteCommand("SELECT * FROM THING", com);
                        SQLiteDataReader read_con = cmd_con.ExecuteReader();
                        while (read_con.Read())
                        {
                            if (i.Key.Equals(read_con["IDTHING"].ToString()))
                            {
                                dictt_all2.Add(read_con["Name"].ToString(), i.Value);
                            }
                        }
                    }
                    foreach (var i in dictt_thing)
                    {
                        SQLiteCommand cmd_con = new SQLiteCommand("SELECT * FROM THING", com);
                        SQLiteDataReader read_con = cmd_con.ExecuteReader();
                        while (read_con.Read())
                        {
                            if (i.Key.Equals(read_con["IDTHING"].ToString()))
                            {
                                dictt_thing2.Add(read_con["Name"].ToString(), i.Value);
                            }
                        }
                    }
                    string s_all2 = string.Join("\n", dictt_all2.Select(x => x.Key + "=" + x.Value).ToArray());
                    string s_thing = string.Join("\n", dictt_thing2.Select(x => x.Key + "=" + x.Value).ToArray());

                    string ss_all2 = string.Join("\n", dictt_all.Select(x => x.Key + "=" + x.Value).ToArray());
                    string ss_thing = string.Join("\n", dictt_thing.Select(x => x.Key + "=" + x.Value).ToArray());
                    TabAll_Table_ALL.Controls.Add(new Label() { Text = read["ID"] + "", AutoSize = true }, 0, 0 + TableAll_CountLine_ALL);
                    TabAll_Table_ALL.Controls.Add(new Label() { Text = read["IDKMITL"] + "", AutoSize = true }, 1, 0 + TableAll_CountLine_ALL);
                    TabAll_Table_ALL.Controls.Add(new Label() { Text = read["Stana"] + "", AutoSize = true }, 2, 0 + TableAll_CountLine_ALL);
                    TabAll_Table_ALL.Controls.Add(new Label() { Text = read["Beto"] + "", AutoSize = true }, 3, 0 + TableAll_CountLine_ALL);
                    TabAll_Table_ALL.Controls.Add(new Label() { Text = read["Project"] + "", AutoSize = true }, 4, 0 + TableAll_CountLine_ALL);
                    TabAll_Table_ALL.Controls.Add(new Label() { Text = read["DataLend"] + "", AutoSize = true }, 5, 0 + TableAll_CountLine_ALL);
                    TabAll_Table_ALL.Controls.Add(new Label() { Text = read["DataBack"] + "", AutoSize = true }, 6, 0 + TableAll_CountLine_ALL);
                    TabAll_Table_ALL.Controls.Add(new Label() { Text = read["Card"] + "", AutoSize = true }, 7, 0 + TableAll_CountLine_ALL);
                    TabAll_Table_ALL.Controls.Add(new Label() { Text = ss_thing + "", AutoSize = true }, 8, 0 + TableAll_CountLine_ALL);
                    TabAll_Table_ALL.Controls.Add(new Label() { Text = s_thing + "", AutoSize = true }, 9, 0 + TableAll_CountLine_ALL);
                    TabAll_Table_ALL.Controls.Add(new Label() { Text = ss_all2, AutoSize = true }, 10, 0 + TableAll_CountLine_ALL);
                    TabAll_Table_ALL.Controls.Add(new Label() { Text = s_all2, AutoSize = true }, 11, 0 + TableAll_CountLine_ALL);
                    TabAll_Table_ALL.Controls.Add(new Label() { Text = read["Accept"] + "", AutoSize = true }, 12, 0 + TableAll_CountLine_ALL);
                    TableAll_CountLine_ALL += 1;
                }
            }
            com.Close();
            //TableAll_Panel_ALL.Height += 100;
            TableAll_Panel_ALL.Controls.Add(TabAll_Table_ALL);
            groupBox6.Controls.Add(TableAll_Panel_ALL);
            com.Close();
        }
        private void TableAll_ClearTable_ALL(object sender, EventArgs e)
        {
            TabAll_Table_ALL.Controls.Clear();
            TableAll_Panel_ALL.Controls.Clear();
            groupBox6.Controls.Clear();
        }
        private void TableAll_update_ALL(object sender, EventArgs e)
        {
            
            TableAll_CreateTable_ALL(sender, e, false);           
            TableAll_ClearTable_ALL(sender, e);
            TableAll_CreateTable_ALL(sender, e, true);
        }

        //--------------------------------------END----------------------------------------------//
       
        
        private void textBox_SearchMember_TextChanged(object sender, EventArgs e)
        {
            try {
                com.Open();
                sea = new ArrayList();

                SQLiteCommand cmdsearch = new SQLiteCommand("SELECT * FROM MEMBER", com);
                SQLiteDataReader readsearch = cmdsearch.ExecuteReader();
                while (readsearch.Read())
                {
                    sea.Add(readsearch["IDKMITL"]);
                }
                foreach (String ii in sea)
                {
                    if (textBox_SearchMember.Text.Equals(ii))
                    {
                        com.Close();
                        TableAll_update_MemberRec(sender, e);
                        break;
                    }
                    else{}
                }
                com.Close();
            }
            catch { com.Close(); }
            
            
        }
        
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            TableAll_update_ALL(sender, e);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            TableAll_update_ALL(sender, e);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            TableAll_update_ALL(sender, e);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            TableAll_update_ALL(sender, e);
        }

        

        private void textBox_IDKMITL_TextChanged(object sender, EventArgs e)
        {
            com.Open();
            sea = new ArrayList();

            SQLiteCommand cmd_r = new SQLiteCommand("SELECT COUNT(*) FROM MEMBER", com);
            int Tabrows = Convert.ToInt32(cmd_r.ExecuteScalar());
            com.Close();
            abc2 = false;
            com.Open();
            SQLiteCommand cmdsearch = new SQLiteCommand("SELECT * FROM MEMBER", com);
            SQLiteDataReader readsearch = cmdsearch.ExecuteReader();
            while (readsearch.Read())
            {
                if (textBox_IDKMITL.Text.Equals(readsearch["IDKMITL"].ToString()))
                {
                    textBox_Name.Text = readsearch["name"].ToString();
                    textBox_Nic.Text = readsearch["nic"].ToString();
                    textBox_Park.Text = readsearch["park"].ToString();
                    textBox_Phone.Text = readsearch["phone"].ToString();
                    comboBox_faculty.SelectedItem = readsearch["faculty"].ToString();
                    comboBox_Room.SelectedItem = readsearch["room"].ToString();
                    richTextBox_Other.Text = readsearch["other"].ToString();
                    label9.Text = "มีข้อมูล";
                    label9.ForeColor = Color.Green;
                    abc2 = true;
                }
                else if (Convert.ToInt32(readsearch["ID"].ToString()) == Tabrows && abc2 == false)
                {
                    textBox_Name.Text = "";
                    textBox_Nic.Text = "";
                    textBox_Park.Text = "";
                    textBox_Phone.Text = "";
                    comboBox_faculty.SelectedItem = "วิศวกรรมศาสตร์";
                    comboBox_Room.SelectedItem = "-";
                    richTextBox_Other.Text = "";
                    label9.Text = "ไม่มีข้อมูล";
                    label9.ForeColor = Color.Red;
                }
            }

            com.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            com.Open();
            SQLiteCommand cmd_r = new SQLiteCommand("SELECT COUNT(*) FROM MEMBER", com);
            int Tabrows = Convert.ToInt32(cmd_r.ExecuteScalar());

            SQLiteCommand cmdsearch = new SQLiteCommand("SELECT * FROM MEMBER", com);
            SQLiteDataReader readsearch = cmdsearch.ExecuteReader();
            ctaa = false;
            while (readsearch.Read())
            {
                if (readsearch["StanaM"].ToString().Equals("God") || readsearch["StanaM"].ToString().Equals("Admin"))
                {
                    if (readsearch["User"].ToString().Equals(textBox2.Text) && readsearch["Pass"].ToString().Equals(textBox3.Text))
                    {
                        com.Close();
                        TableAll_update(sender, e);

                        TableAll_update_Member(sender, e);
                        tabControl2.Show();
                        ctaa = true;
                        return;

                    }
                    else if (Convert.ToInt32(readsearch["ID"].ToString()) == Tabrows-1 && ctaa == false)
                    {
                        MessageBox.Show("ขออภัยคุณกรอก Username หรือ Password(God, Admin) ไม่ถูกต้อง", "unsuccessful",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        com.Close();
                        return;
                    }

                }
                else if (Convert.ToInt32(readsearch["ID"].ToString()) == Tabrows-1 && ctaa == false)
                {
                    MessageBox.Show("ขออภัยคุณกรอก Username หรือ Password(God, Admin) ไม่ถูกต้อง", "unsuccessful",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    com.Close();
                    return;
                }
            }
            com.Close();


        }

        private void Add_Member_Click(object sender, EventArgs e)
        {
            
        }

        private void radioButton5_Click(object sender, EventArgs e)
        {
            label11.Hide();
            label12.Hide();
            textBox_AddAdmin_User.Hide();
            textBox_AddAdmin_Pass.Hide();
            label13.Hide();
            label14.Hide();
            label15.Hide();
            textBox_AddAdmin_User_Admin.Hide();
            textBox_AddAdmin_Pass_Admin.Hide();
            textBox_AddAdmin_con_Admin.Hide();

        }

        private void radioButton6_Click(object sender, EventArgs e)
        {
            label11.Show();
            label12.Show();
            textBox_AddAdmin_User.Show();
            textBox_AddAdmin_Pass.Show();
            label13.Show();
            label14.Show();
            label15.Show();
            textBox_AddAdmin_User_Admin.Show();
            textBox_AddAdmin_Pass_Admin.Show();
            textBox_AddAdmin_con_Admin.Show();
        }
        //-----------------------------------------------------------------------------------
        private void TableAll_CreateTable_Admin(object sender, EventArgs e, bool cc)
        {
            TableAll_Panel_Admin = new Panel();
            TableAll_Panel_Admin.AutoScroll = true;
            TableAll_Panel_Admin.Top = 15;
            TableAll_Panel_Admin.Left = 10;
            TableAll_Panel_Admin.Width = groupBox2.Width - 10;
            TableAll_Panel_Admin.Height = groupBox2.Height - 15;
            com.Open();

            SQLiteCommand cmd = new SQLiteCommand("SELECT COUNT(*) FROM MEMBER", com);
            TableAll_CountRow_Admin = Convert.ToInt32(cmd.ExecuteScalar());

            TabAll_Table_Admin = new TableLayoutPanel();
            if (!cc) { com.Close(); return; }
            TabAll_Table_Admin.ColumnCount = 10;
            TabAll_Table_Admin.RowCount = TableAll_CountRow_Admin + 1;
            TabAll_Table_Admin.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            TabAll_Table_Admin.Top = 9;
            TabAll_Table_Admin.Left = 20;
            TabAll_Table_Admin.AutoSize = true;
            TabAll_Table_Admin.ColumnStyles.Add(new ColumnStyle());

            TabAll_Table_Admin.Controls.Add(new Label() { Text = "ลำดีบ", AutoSize = true }, 0, 0);
            TabAll_Table_Admin.Controls.Add(new Label() { Text = "รหัสนักศึกษา", AutoSize = true }, 1, 0);
            TabAll_Table_Admin.Controls.Add(new Label() { Text = "ประเภท", AutoSize = true }, 2, 0);
            TabAll_Table_Admin.Controls.Add(new Label() { Text = "ชื่อ-นามสกุล", AutoSize = true }, 3, 0);
            TabAll_Table_Admin.Controls.Add(new Label() { Text = "ชื่อเล่น", AutoSize = true }, 4, 0);
            TabAll_Table_Admin.Controls.Add(new Label() { Text = "ภาควิชา", AutoSize = true }, 5, 0);
            TabAll_Table_Admin.Controls.Add(new Label() { Text = "ห้อง", AutoSize = true }, 6, 0);
            TabAll_Table_Admin.Controls.Add(new Label() { Text = "คณะ", AutoSize = true }, 7, 0);
            TabAll_Table_Admin.Controls.Add(new Label() { Text = "โทรศัพท์", AutoSize = true }, 8, 0);
            TabAll_Table_Admin.Controls.Add(new Label() { Text = "หมายเหตุ", AutoSize = true }, 9, 0);
            //TabAll_Table_Admin.Controls.Add(new Label() { Text = "Username", AutoSize = true }, 10, 0);
            //TabAll_Table_Admin.Controls.Add(new Label() { Text = "Password", AutoSize = true }, 11, 0);

            TabAll_Table_Admin.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            SQLiteCommand cmd2 = new SQLiteCommand("SELECT * FROM MEMBER", com);
            SQLiteDataReader read = cmd2.ExecuteReader();
            TableAll_CountLine_Admin = 1;
            while (read.Read())
            {
                if (read["StanaM"].ToString().Equals("Admin") || read["StanaM"].ToString().Equals("God"))
                {

                    TabAll_Table_Admin.Controls.Add(new Label() { Text = read["ID"] + "", AutoSize = true }, 0, 0 + TableAll_CountLine_Admin);
                    TabAll_Table_Admin.Controls.Add(new Label() { Text = read["IDKMITL"] + "", AutoSize = true }, 1, 0 + TableAll_CountLine_Admin);
                    TabAll_Table_Admin.Controls.Add(new Label() { Text = read["StanaM"] + "", AutoSize = true }, 2, 0 + TableAll_CountLine_Admin);
                    TabAll_Table_Admin.Controls.Add(new Label() { Text = read["Name"] + "", AutoSize = true }, 3, 0 + TableAll_CountLine_Admin);
                    TabAll_Table_Admin.Controls.Add(new Label() { Text = read["Nic"] + "", AutoSize = true }, 4, 0 + TableAll_CountLine_Admin);
                    TabAll_Table_Admin.Controls.Add(new Label() { Text = read["Park"] + "", AutoSize = true }, 5, 0 + TableAll_CountLine_Admin);
                    TabAll_Table_Admin.Controls.Add(new Label() { Text = read["Room"] + "", AutoSize = true }, 6, 0 + TableAll_CountLine_Admin);
                    TabAll_Table_Admin.Controls.Add(new Label() { Text = read["Faculty"]+"", AutoSize = true }, 7, 0 + TableAll_CountLine_Admin);
                    TabAll_Table_Admin.Controls.Add(new Label() { Text = read["Phone"] + "", AutoSize = true }, 8, 0 + TableAll_CountLine_Admin);
                    TabAll_Table_Admin.Controls.Add(new Label() { Text = read["Other"]+"", AutoSize = true }, 9, 0 + TableAll_CountLine_Admin);
                    //TabAll_Table_Admin.Controls.Add(new Label() { Text = read["User"] + "", AutoSize = true }, 10, 0 + TableAll_CountLine_Admin);
                    //TabAll_Table_Admin.Controls.Add(new Label() { Text = read["Pass"] + "", AutoSize = true }, 11, 0 + TableAll_CountLine_Admin);
                    TableAll_CountLine_Admin += 1;

                }
            }
            com.Close();
            TableAll_Panel_Admin.Controls.Add(TabAll_Table_Admin);
            groupBox2.Controls.Add(TableAll_Panel_Admin);
            com.Close();
        }
        private void TableAll_ClearTable_Admin(object sender, EventArgs e)
        {
            TabAll_Table_Admin.Controls.Clear();
            TableAll_Panel_Admin.Controls.Clear();
            groupBox2.Controls.Clear();
        }
        private void TableAll_update_Admin(object sender, EventArgs e)
        {
            TableAll_CreateTable_Admin(sender, e, false);
            TableAll_ClearTable_Admin(sender, e);
            TableAll_CreateTable_Admin(sender, e, true);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TableAll_update_Admin(sender, e);
        }

        private void button_Submit_God_Click(object sender, EventArgs e)
        {
            if (!textBox_Pass_god.Text.Equals(textBox_Con_God.Text)){
                MessageBox.Show("กรุณาใส่ Password ให้ตรงกัน", "successful",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (textBox_Phond_God.Text.Length != 10)
            {
                MessageBox.Show("กรุณาใส่เบอร์โทร 10 ตัว", "unsuccessful",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            com.Open();
            SQLiteCommand cmdsearcha = new SQLiteCommand("SELECT * FROM MEMBER", com);
            SQLiteDataReader readsearcha = cmdsearcha.ExecuteReader();
            while (readsearcha.Read())
            {
                if (readsearcha["StanaM"].ToString().Equals("Admin") && readsearcha["User"].ToString().Equals(textBox_User_god.Text))
                {
                    MessageBox.Show("ขออภัยUsernameนี้มีคนใช้แล้ว", "unsuccessful",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    com.Close();
                    return;
                }
            }
            com.Close();
            com.Open();
            SQLiteCommand cmd2 = new SQLiteCommand("SELECT * FROM MEMBER", com);
            SQLiteDataReader read = cmd2.ExecuteReader();
            //dic_ip.Clear();
            dic_ip = new Dictionary<string, string> { };
            dic_ip.Add("IDKMITL", textBox_IDKMITL_God.Text);
            dic_ip.Add("Name", textBox_Name_God.Text);
            dic_ip.Add("Nic", textBox_Nic_God.Text);
            dic_ip.Add("Park", textBox_Park_God.Text);
            dic_ip.Add("Room", comboBox_Room_God.SelectedItem.ToString());
            dic_ip.Add("Faculty", comboBox_Faculty_God.SelectedItem.ToString());
            dic_ip.Add("Phone", textBox_Phond_God.Text);
            dic_ip.Add("User", textBox_User_god.Text);
            dic_ip.Add("Pass", textBox_Pass_god.Text);
            dic_ip.Add("Other", richTextBox_Other_God.Text);              
            while (read.Read())
            {
                if (read["StanaM"].Equals("God"))
                {
                    foreach (var ii in dic_ip)
                    {
                        String str_update = "UPDATE MEMBER SET " + ii.Key + " = '" + ii.Value + "' WHERE ID = 1";
                        SQLiteCommand cmdUpDate = new SQLiteCommand(str_update, com);
                        cmdUpDate.ExecuteNonQuery();

                    }
                }
            }
            com.Close();

            MessageBox.Show("บันทึกการเปลี่ยนแปลงข้อมูลสิ่งของเรียบร้อย");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            com.Open();
            SQLiteCommand cmd2 = new SQLiteCommand("SELECT * FROM MEMBER", com);
            SQLiteDataReader read = cmd2.ExecuteReader();
            while (read.Read())
            {
                if (read["StanaM"].Equals("God"))
                {
                    textBox_IDKMITL_God.Text = read["IDKMITL"].ToString();
                    textBox_Name_God.Text = read["Name"].ToString();
                    textBox_Nic_God.Text = read["Nic"].ToString();
                    textBox_Park_God.Text = read["Park"].ToString();
                    textBox_Phond_God.Text = read["Phone"].ToString();
                    richTextBox_Other_God.Text = read["Other"].ToString();
                    comboBox_Room_God.SelectedItem = read["room"].ToString();
                    comboBox_Faculty_God.SelectedItem = read["Faculty"].ToString();
                    textBox_User_god.Text = read["User"].ToString();


                }
            }
            com.Close();
            TableAll_update_Admin(sender, e);
        }

        private void textBox_IDKMITL_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox_ITKMITL2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            tabControl2.Show();
            TableAll_update(sender, e);
            TableAll_update_Member(sender, e);

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            TableAll_update_ALL(sender, e);
        }

        private void comboBox_faculty_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }

        private void comboBox_Room_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }

        private void comboBox_Card2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }

        private void comboBox_DataLend_Hourse_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }

        private void comboBox_DataLend_min_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }

        private void comboBox_DataBack_Hourse_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }

        private void comboBox_DataBack_min_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }

        private void dateTimePicker1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }

        private void dateTimePicker2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }

        private void comboBox_Faculty_God_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }

        private void comboBox_Room_God_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = (char)Keys.None;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            com.Open();
            SQLiteCommand cmdsearch2 = new SQLiteCommand("SELECT * FROM MEMBER", com);
            SQLiteDataReader readsearch2 = cmdsearch2.ExecuteReader();
            string namee="";
            while (readsearch2.Read())
            {
                if (readsearch2["IDKMITL"].ToString().Equals(textBox4.Text)) {
                    namee = readsearch2["Name"].ToString();
                }
            }
            com.Close();

            DialogResult dialogResult = MessageBox.Show("คุณต้องการจะลบ "+namee , "ลบข้อมูลสมาชิก", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }


            com.Open();
            SQLiteCommand cmdsearch = new SQLiteCommand("SELECT * FROM MEMBER", com);
            SQLiteDataReader readsearch = cmdsearch.ExecuteReader();
            string idgod="";
            while (readsearch.Read()) {
                if (readsearch["StanaM"].ToString().Equals("God")) {
                    idgod = readsearch["IDKMITL"].ToString();
                }
            }
            com.Close();
            

            if (textBox4.Text.Equals(idgod)) {
                MessageBox.Show("ขออภัยคุณไม่สามารถลบ God ได้", "unsuccessful",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                com.Close();
                return;
            }
            com.Open();
            SQLiteCommand cmd_del = new SQLiteCommand("DELETE FROM MEMBER WHERE IDKMITL = "+textBox4.Text, com);
            cmd_del.ExecuteNonQuery();
            SQLiteCommand cmd_del2 = new SQLiteCommand("DELETE FROM RECALL WHERE IDKMITL = " + textBox4.Text, com);
            cmd_del2.ExecuteNonQuery();
            MessageBox.Show("ลบข้อมูลเสร็จสิ้น", "Sucessfull");
            com.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            com.Open();
            sea = new ArrayList();
            SQLiteCommand cmdsearch = new SQLiteCommand("SELECT * FROM MEMBER", com);
            SQLiteDataReader readsearch = cmdsearch.ExecuteReader();
            while (readsearch.Read())
            {
                sea.Add(readsearch["IDKMITL"]);
            }
            com.Close();
            foreach (String ii in sea)
            {
                if (textBox4.Text.Equals(ii))
                {
                    label28.Text = "มีข้อมูล";
                    label28.ForeColor = Color.Green;
                    break;
                }
                else
                {
                    label28.Text = "ไม่มีข้อมูล";
                    label28.ForeColor = Color.Red;
                }
            }
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("คุณต้องการจะลบ", "ลบข้อมูลสมาชิก", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
            com.Open();
            progressBar1.Minimum = Convert.ToInt32(textBox7.Text);
            progressBar1.Maximum = Convert.ToInt32(textBox8.Text);
            for (int i = progressBar1.Minimum; i<= progressBar1.Maximum; i++) {
                progressBar1.Value = i;
                SQLiteCommand cmd_del = new SQLiteCommand("DELETE FROM MEMBER WHERE IDKMITL = " +i, com);
                cmd_del.ExecuteNonQuery();
                SQLiteCommand cmd_del2 = new SQLiteCommand("DELETE FROM RECALL WHERE IDKMITL = " + i, com);
                cmd_del2.ExecuteNonQuery();
            }
            com.Close();
            MessageBox.Show("ลบข้อมูลเสร็จสิ้น");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;   
            comboBox_DataLend_Hourse.SelectedItem = d.ToString("HH");
            comboBox_DataLend_min.SelectedItem = d.ToString("mm");
            comboBox_DataBack_Hourse.SelectedItem = d.ToString("HH");
            comboBox_DataBack_min.SelectedItem = d.ToString("mm");
        }

        private void clearscreen(object sender, EventArgs e) {
            textBox_IDKMITL.Text = "";
            textBox_Nic.Text = "";
            textBox_Park.Text = "";
            textBox_Phone.Text = "";
            richTextBox_Other.Text = "";
            textBox_AddAdmin_User_Admin.Text = "";
            textBox_AddAdmin_Pass_Admin.Text = "";
            textBox_AddAdmin_con_Admin.Text = "";
            textBox_AddAdmin_User.Text = "";
            textBox_AddAdmin_Pass.Text = "";
            comboBox_Room.SelectedItem = "-";
            comboBox_faculty.SelectedItem = "วิศวกรรมศาสตร์";

            textBox_ITKMITL2.Text = "";
            textBox_BeTo2.Text = "";
            textBox_Project2.Text = "";
            comboBox_Card2.SelectedItem = "-";
            textBox_Rec_User.Text = "";
            textBox_Rec_Pass.Text = "";

            textBox_IDThing.Text = "";
            textBox_NameThing.Text = "";
            textBox_CountAll.Text = "";
            textBox_PriceThing.Text = "";
            richTextBox_Otherr.Text = "";

            DateTime d = DateTime.Now;

            comboBox_DataLend_Hourse.SelectedItem = d.ToString("HH");
            comboBox_DataLend_min.SelectedItem = d.ToString("mm");
            comboBox_DataBack_Hourse.SelectedItem = d.ToString("HH");
            comboBox_DataBack_min.SelectedItem = d.ToString("mm");

            tabControl2.Hide();
            textBox2.Text = "";
            textBox3.Text = "";
            tabControl3.Hide();
            textBox5.Text = "";
            textBox6.Text = "";

            Recoard_Panel2.Controls.Clear();
            groupBox1.Controls.Clear();
            a = 0;

        }

        private void button12_Click(object sender, EventArgs e)
        {
            com.Open();
            SQLiteCommand cmd_r = new SQLiteCommand("SELECT COUNT(*) FROM MEMBER", com);
            int Tabrows = Convert.ToInt32(cmd_r.ExecuteScalar());
            com.Close();
            com.Open();
            SQLiteCommand cmdsearch = new SQLiteCommand("SELECT * FROM MEMBER", com);
            SQLiteDataReader readsearch = cmdsearch.ExecuteReader();
            ctaa2 = false;
            while (readsearch.Read())
            {
                if (readsearch["StanaM"].ToString().Equals("God"))
                {
                    if (readsearch["User"].ToString().Equals(textBox5.Text) && readsearch["Pass"].ToString().Equals(textBox6.Text))
                    {
                        com.Close();
                        //TableAll_update(sender, e);
                        //TableAll_update_Member(sender, e);
                        tabControl3.Show();
                        ctaa2 = true;
                        //break;
                        return;

                    }
                    else if (Convert.ToInt32(readsearch["ID"].ToString()) == Tabrows-1 && ctaa2 == false)
                    {
                        MessageBox.Show("ขออภัยคุณกรอก Username หรือ Password(God, Admin) ไม่ถูกต้อง", "unsuccessful",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        com.Close();
                        return;
                    }

                }
                else if (Convert.ToInt32(readsearch["ID"].ToString()) == Tabrows-1 && ctaa2 == false)
                {
                    MessageBox.Show("ขออภัยคุณกรอก Username หรือ Password(God, Admin) ไม่ถูกต้อง", "unsuccessful",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    com.Close();
                    return;
                }
            }
            com.Close();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            tabControl3.Show();
        }
       

        private void button15_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(sender, e);
            form2.Show();
        }
        

        private void textBox_CountAll_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox_Phond_God_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click_1(sender, e);
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button12_Click(sender, e);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Recoard_Panel2.Controls.Clear();
            groupBox1.Controls.Clear();
            a = 0;
        }

        //-----------------------------------------------------------------------------------
    }
}
