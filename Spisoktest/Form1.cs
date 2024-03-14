using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Spisoktest
{
    public partial class Form1 : Form
    {
        private DataTable productsData; 

        public Form1()
        {
            InitializeComponent();
            textBox1.TextChanged += textBox1_TextChanged;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            {
                DatabaseManager dbManager = new DatabaseManager("Host=localhost;Port=5432;Username=postgres;Password=123;Database=Tovar;");
                productsData = dbManager.GetProductsData();

                foreach (DataRow row in productsData.Rows)
                {
                    string imagePath = row["ImagePath"].ToString();
                    string article = row["Article"].ToString();
                    string name = row["Name"].ToString();
                    string price = row["Price"].ToString();

                    UserControl1 UserControl1 = new UserControl1(imagePath, article, name, price);
                    flowLayoutPanel.Controls.Add(UserControl1);
                }
            }
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchKeyword = textBox1.Text.Trim().ToLower(); 
            flowLayoutPanel.Controls.Clear();

            foreach (DataRow row in productsData.Rows)
            {
                string name = row["Name"].ToString().ToLower();
                if (name.Contains(searchKeyword))
                {
                    string imagePath = row["ImagePath"].ToString();
                    string article = row["Article"].ToString();
                    string price = row["Price"].ToString();
                    UserControl1 productControl = new UserControl1(imagePath, article, row["Name"].ToString(), price);
                    flowLayoutPanel.Controls.Add(productControl);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSorting = comboBox1.SelectedItem.ToString();


            if (selectedSorting == "А-Я")
            {
                productsData.DefaultView.Sort = "Name ASC";
            }
            else if (selectedSorting == "Я-А")
            {
                productsData.DefaultView.Sort = "Name DESC";
            }

            flowLayoutPanel.Controls.Clear();
            foreach (DataRowView rowView in productsData.DefaultView)
            {
                DataRow row = rowView.Row;
                string imagePath = row["ImagePath"].ToString();
                string article = row["Article"].ToString();
                string price = row["Price"].ToString();
                UserControl1 productControl = new UserControl1(imagePath, article, row["Name"].ToString(), price);
                flowLayoutPanel.Controls.Add(productControl);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSorting = comboBox2.SelectedItem.ToString();

          
            if (selectedSorting == "По возрастанию")
            {
                productsData.DefaultView.Sort = "Price ASC"; 
            }
            else if (selectedSorting == "По убыванию")
            {
                productsData.DefaultView.Sort = "Price DESC"; 
            }

            flowLayoutPanel.Controls.Clear();
            foreach (DataRowView rowView in productsData.DefaultView)
            {
                DataRow row = rowView.Row;
                string imagePath = row["ImagePath"].ToString();
                string article = row["Article"].ToString();
                string price = row["Price"].ToString();
                UserControl1 productControl = new UserControl1(imagePath, article, row["Name"].ToString(), price);
                flowLayoutPanel.Controls.Add(productControl);
            }
        }
    }
}
