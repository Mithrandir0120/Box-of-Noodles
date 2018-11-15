using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Box_of_Noodles {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        public bool Judgement() {
            bool noNoodle = true;
            if (nameTextBox.Text == "") {
                MessageBox.Show("Please input your name!");
            }
            foreach (Control radio in noodleTypeGroupBox.Controls) {
                if (radio is RadioButton) {
                    RadioButton radioButton = radio as RadioButton;
                    if (radioButton.Checked) {
                        noNoodle = false;
                        break;
                    }
                }
            }
            if (noNoodle) {
                MessageBox.Show("Please select a type of noodle!");
            }
            if (flavoursBox.SelectedIndex == -1) {
                MessageBox.Show("Please select a type of flavour!");
            }
            if (nameTextBox.Text != "" && !noNoodle && flavoursBox.SelectedIndex != -1) {
                return true;
            } else {
                return false;
            }
        }


        public int MeatPrice() {
            string meatName = "";
            int meatPrice;
            foreach (Control radio in addMeatGroupBox.Controls) {
                if (radio is RadioButton) {
                    RadioButton radioButton = radio as RadioButton;
                    if (radioButton.Checked) {
                        meatName = radioButton.Text;
                        break;
                    }
                }
            }
            if (meatName == "None") {
                meatPrice = 0;
            } else if (meatName == "Seafood") {
                meatPrice = 7;
            } else {
                meatPrice = 5;
            }
            return meatPrice;
        }

        public int VegetableNumber() {
            int vegetableNum = 0;
            foreach (Control check in addVegetablesGroupBox.Controls) {
                if (check is CheckBox) {
                    CheckBox checkBox = check as CheckBox;
                    if (checkBox.Checked) {
                        vegetableNum++;
                    }
                }
            }
            return vegetableNum;
        }

        public double CalculateTotalPrice(int meatPrice, int vegetableNum) {
            double totalPrice = 0.0;
            if (vegetableNum <= 4) {
                totalPrice = meatPrice + 5.5;
            } else {
                totalPrice = meatPrice + 5.5 + (vegetableNum - 4) * 0.5;
            }
            return totalPrice;
        }

        private void calculateButton_Click(object sender, EventArgs e) {            
            int meatPrice = 0;
            int vegetableNumber = 0;
            double totalPrice = 0.0;
            bool judge;

            if (judge = Judgement()) {
                orderPriceLabel.Visible = true;
                priceTextBox.Visible = true;
                groupBox.Visible = true;
            }

            meatPrice = MeatPrice();
            vegetableNumber = VegetableNumber();
            totalPrice = CalculateTotalPrice(meatPrice, vegetableNumber);

            if (bigSizeCheckBox.Checked) {
                totalPrice *= 1.5;
            }

            if (usdRadioButton.Checked) {
                totalPrice *= 0.77;
            }
            priceTextBox.Text = "$" + totalPrice.ToString("0.00");
        }
    }
}
