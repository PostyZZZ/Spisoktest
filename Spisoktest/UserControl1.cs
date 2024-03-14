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
    public partial class UserControl1 : UserControl
    {
        public UserControl1(string imagePath, string article, string name, string price)
        {
            InitializeComponent();

            pictureBox.Image = Image.FromFile(imagePath);
            labelArticle.Text =  article;
            labelName.Text = name;
            labelPrice.Text = price;
        }
    }
    }

