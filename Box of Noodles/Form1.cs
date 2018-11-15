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

        public double TotalPrice() {
            double totalPrice = 0.0;
            int meatPrice = 0;
            int vegetableNumber = 0;

            meatPrice = MeatPrice();
            vegetableNumber = VegetableNumber();

            if (vegetableNumber <= 4) {
                totalPrice = meatPrice + 5.5;
            } else {
                totalPrice = meatPrice + 5.5 + (vegetableNumber - 4) * 0.5;
            }

            if (bigSizeCheckBox.Checked) {
                totalPrice *= 1.5;
            }

            return totalPrice;
        }

        private void calculateButton_Click(object sender, EventArgs e) {
            bool judge;
            double totalPrice;

            if (judge = Judgement()) {
                orderPriceLabel.Visible = true;
                priceTextBox.Visible = true;
                groupBox.Visible = true;
            }

            totalPrice = TotalPrice();

            priceTextBox.Text = "$" + totalPrice.ToString("0.00");
        }

        private void capscicumCheckBox_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }

        private void cabbageCheckBox_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }

        private void broccoilCheckBox_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }

        private void shallotsCheckBox_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }

        private void carrotCheckBox_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }

        private void bokChoyheckBox_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }

        private void onionCheckBox_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }

        private void snowPeasCheckBox1_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }

        private void greenBeansCheckBox_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }

        private void sproutsCheckBox_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }

        private void usdRadioButton_CheckedChanged(object sender, EventArgs e) {
            double totalPrice = TotalPrice();
            totalPrice *= 0.77;
            priceTextBox.Text = "$" + totalPrice.ToString("0.00");
        }

        private void bigSizeCheckBox_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }

        private void chickenRadioButton_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }

        private void porkRadioButton_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }

        private void beefRadioButton_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }

        private void seafoodRadioButton_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }

        private void noneRadioButton_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }

        private void audRadioButton_CheckedChanged(object sender, EventArgs e) {
            double totalPrice = TotalPrice();
            priceTextBox.Text = "$" + totalPrice.ToString("0.00");
        }
    }
}
