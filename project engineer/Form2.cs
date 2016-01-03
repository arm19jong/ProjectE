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

    public partial class Form2 : Form
    {
        int TableAll_CountLine__Thing;
        Int32 TableAll_CountRow_Thing;
        Panel TableAll_Panel_Thing;
        TableLayoutPanel TabAll_Table_Thing;
        public Form2(object sender, EventArgs e)
        {
            InitializeComponent();
            TableAll_update(sender, e);

        }
        public SQLiteConnection com = new SQLiteConnection(@"Data Source=db.db;Version=3;");
        private void TableAll_CreateTable_Thing(object sender, EventArgs e, bool cc)
        {

            TableAll_Panel_Thing = new Panel();
            TableAll_Panel_Thing.AutoScroll = true;
            TableAll_Panel_Thing.Top = 15;
            TableAll_Panel_Thing.Left = 10;
            TableAll_Panel_Thing.Width = groupBox3.Width - 10;
            TableAll_Panel_Thing.Height = groupBox3.Height - 15;
            //com.Close();
            com.Open();

            SQLiteCommand cmd = new SQLiteCommand("SELECT COUNT(*) FROM THING", com);
            TableAll_CountRow_Thing = Convert.ToInt32(cmd.ExecuteScalar());

            TabAll_Table_Thing = new TableLayoutPanel();
            if (!cc) { com.Close(); return; }
            TabAll_Table_Thing.ColumnCount = 5;
            TabAll_Table_Thing.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            TabAll_Table_Thing.RowCount = TableAll_CountRow_Thing + 1;

            TabAll_Table_Thing.Top = 9;
            TabAll_Table_Thing.Left = 20;
            TabAll_Table_Thing.AutoSize = true;


            TabAll_Table_Thing.ColumnStyles.Add(new ColumnStyle());

            TabAll_Table_Thing.Controls.Add(new Label() { Text = "ลำดับ", AutoSize = true }, 0, 0);
            TabAll_Table_Thing.Controls.Add(new Label() { Text = "รหัสพัสดุ", AutoSize = true }, 1, 0);
            TabAll_Table_Thing.Controls.Add(new Label() { Text = "ชื่อพัสดุ", AutoSize = true }, 2, 0);
            TabAll_Table_Thing.Controls.Add(new Label() { Text = "ราคาพัสดุ", AutoSize = true }, 3, 0);
            TabAll_Table_Thing.Controls.Add(new Label() { Text = "หมายเหตุ", AutoSize = true }, 4, 0);


            TabAll_Table_Thing.RowStyles.Add(new RowStyle(SizeType.AutoSize));

            SQLiteCommand cmd2 = new SQLiteCommand("SELECT * FROM THING", com);
            SQLiteDataReader read = cmd2.ExecuteReader();
            TableAll_CountLine__Thing = 1;
            while (read.Read())
            {
                TabAll_Table_Thing.Controls.Add(new Label() { Text = read["ID"] + "", AutoSize = true }, 0, 0 + TableAll_CountLine__Thing);
                TabAll_Table_Thing.Controls.Add(new Label() { Text = read["IDTHING"] + "", AutoSize = true }, 1, 0 + TableAll_CountLine__Thing);
                TabAll_Table_Thing.Controls.Add(new Label() { Text = read["name"] + "", AutoSize = true }, 2, 0 + TableAll_CountLine__Thing);
                TabAll_Table_Thing.Controls.Add(new Label() { Text = read["Price"] + "", AutoSize = true }, 3, 0 + TableAll_CountLine__Thing);
                TabAll_Table_Thing.Controls.Add(new Label() { Text = read["Other"] + "", AutoSize = true }, 4, 0 + TableAll_CountLine__Thing);
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

    }
    
}
