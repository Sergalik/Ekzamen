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

namespace МодульныйЭкзамен
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DB();
        }

        private void DB()
        {
            SqlConnection dbConnection;
            Program.conn(out dbConnection);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand cmd = new SqlCommand("Select * From База", dbConnection);
            Program.DataSave.cmd = cmd;
            Program.DataSave.table = table; 

            da.SelectCommand = cmd;
            da.Fill(table);

            Program.DataSave.tableRow = table.Rows.Count;

            Program.DataSave.table = new DataView(Program.DataSave.table, "", "Название", DataViewRowState.CurrentRows).ToTable();
            da.SelectCommand = Program.DataSave.cmd;
            da.Fill(Program.DataSave.table);

            if(Program.DataSave.nameButton == "btn_Back")
            {
                Program.DataSave.id = Program.DataSave.id - 6;
                TLP1.Visible = true;
                TLP2.Visible = true;
                TLP3.Visible = true;
                btn_Next.Visible = true;
            }
            if(Program.DataSave.id >= 3)
                btn_Back.Visible = true;
            else
                btn_Back.Visible = false;


            if (Program.DataSave.id == Program.DataSave.tableRow)
            {
                TLP1.Visible = false;
                TLP2.Visible = false;
                TLP3.Visible = false;
                btn_Next.Visible = false;
                Program.DataSave.id++;
                Program.DataSave.id++;
                Program.DataSave.id++;
                return;
            }

            string img = table.Rows[Program.DataSave.id]["Обложка"].ToString().Trim();
            pictureBox1.Image = new Bitmap(img);
            name1.Text = "Название: " + table.Rows[Program.DataSave.id]["Название"].ToString() + " | " + "Жанр: " + table.Rows[Program.DataSave.id]["Жанр"] + " | " + "Автор: " + table.Rows[Program.DataSave.id]["Автор"].ToString();
            kol1.Text = "Кол-во в магазине: " + table.Rows[Program.DataSave.id]["Кол_В_Магазине"].ToString() + " | " + "Кол-во на складе: " + table.Rows[Program.DataSave.id]["Кол_На_Складе"].ToString();
            opis1.Text = "Описание: " + table.Rows[Program.DataSave.id]["Описание"].ToString();
            cost1.Text = "Цена: " + table.Rows[Program.DataSave.id]["Цена"].ToString() + " рублей";
            Program.DataSave.id++;

            //--------------

            if (Program.DataSave.id == Program.DataSave.tableRow)
            {
                TLP2.Visible = false;
                TLP3.Visible = false;
                btn_Next.Visible = false;
                Program.DataSave.id++;
                Program.DataSave.id++;
                return;
            }

            img = table.Rows[Program.DataSave.id]["Обложка"].ToString().Trim();
            pictureBox2.Image = new Bitmap(img);
            name2.Text = "Название: " + table.Rows[Program.DataSave.id]["Название"].ToString() + " | " + "Жанр: " + table.Rows[Program.DataSave.id]["Жанр"] + " | " + "Автор: " + table.Rows[Program.DataSave.id]["Автор"].ToString();
            kol2.Text = "Кол-во в магазине: " + table.Rows[Program.DataSave.id]["Кол_В_Магазине"].ToString() + " | " + "Кол-во на складе: " + table.Rows[Program.DataSave.id]["Кол_На_Складе"].ToString();
            opis2.Text = "Описание: " + table.Rows[Program.DataSave.id]["Описание"].ToString();
            cost2.Text = "Цена: " + table.Rows[Program.DataSave.id]["Цена"].ToString() + " рублей";
            Program.DataSave.id++;

            //------------

            if (Program.DataSave.id == Program.DataSave.tableRow)
            {
                TLP3.Visible = false;
                btn_Next.Visible = false;
                Program.DataSave.id++;
                return;
            }

            img = table.Rows[Program.DataSave.id]["Обложка"].ToString().Trim();
            pictureBox3.Image = new Bitmap(img);
            name3.Text = "Название: " + table.Rows[Program.DataSave.id]["Название"].ToString() + " | " + "Жанр: " + table.Rows[Program.DataSave.id]["Жанр"] + " | " + "Автор: " + table.Rows[Program.DataSave.id]["Автор"].ToString();
            kol3.Text = "Кол-во в магазине: " + table.Rows[Program.DataSave.id]["Кол_В_Магазине"].ToString() + " | " + "Кол-во на складе: " + table.Rows[Program.DataSave.id]["Кол_На_Складе"].ToString();
            opis3.Text = "Описание: " + table.Rows[Program.DataSave.id]["Описание"].ToString();
            cost3.Text = "Цена: " + table.Rows[Program.DataSave.id]["Цена"].ToString() + " рублей";
            Program.DataSave.id++;
        }

        private void btnNextAndBack_Click(object sender, EventArgs e)
        {
            Program.DataSave.nameButton = (sender as Button).Name;
            DB();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            
            
        }

        private void btn_Korzina_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Show();
        }
    }

    
}
