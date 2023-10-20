using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
    public partial class Form1 : Form
    {
        private int _Quantity;
        private double _SellPrice;
        private string _ProductName, _Category, _MfgDate, _ExpDate, _Description;
        private BindingSource showProductList;

        public Form1()
        {
            InitializeComponent();
            showProductList = new BindingSource();
        }
      

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                _ProductName = Product_Name(txtProduct.Text);
                _Category = cbCategory.Text;
                _MfgDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                _ExpDate = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                _Description = richtxtDesciption.Text;
                _Quantity = Quantity(txtQty.Text);
                _SellPrice = SellingPrice(txtSellPrice.Text);
                showProductList.Add(new ProductClass(_ProductName, _Category, _MfgDate, _ExpDate, _SellPrice, _Quantity, _Description));
                gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridViewProductList.DataSource = showProductList;
            }
            catch (StringFormatException sfe)
            {
                MessageBox.Show("Message: " + sfe);
            }
            catch (NumberFormatException sfe)
            {
                MessageBox.Show("Message: " + sfe);
            }
            catch (CurrencyFormatException sfe)
            {
                MessageBox.Show("Message: " + sfe);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ListOfProductCategory = new string[]
                {
                    "Beverages",
                    "Break/Bakery",
                    "Canned/jarred goods",
                    "Dairy",
                    "Frozen goods",
                    "Meat",
                    "Personal Care",
                    "Other",
                };

            foreach (string category in ListOfProductCategory)
            {
                cbCategory.Items.Add(category);
            }
        }



        public string Product_Name(string name)
        {
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
            {
                throw new StringFormatException("Product name.");

            }
            else
            {
                return name;
            }


        }
        public int Quantity(string qty)
        {
            if (!Regex.IsMatch(qty, @"^[0-9]"))
            {
                throw new NumberFormatException("Quantity.");
            }
            else
            {
                {

                    return Convert.ToInt32(qty);
                }
            }
        }

        public double SellingPrice(string price)
        {
            if (!Regex.IsMatch(price.ToString(), @"^(\d*\.)?\d+$"))
            {
                throw new CurrencyFormatException("Selling Price.");
            }
            else
            {
                return Convert.ToDouble(price);
            }
        }

    }
}
