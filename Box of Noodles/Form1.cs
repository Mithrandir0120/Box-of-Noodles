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
    /// <summary>
    /// Class Name:     MainForm
    /// Description:    This is a a simple online ordering form for a fictitious 
    ///                 noodle restaurant called "Box of Noodles".
    /// Author:         Mithrandir He
    /// Stu No:         1622441019
    /// Date:           October 20, 2018
    /// </summary>
    public partial class MainForm : Form {
        /// <summary>
        /// Method Name:    MainForm
        /// Description:    Initialize the form
        /// </summary>
        public MainForm() {
            InitializeComponent();
        }// end MainForm

        /// <summary>
        /// Method Name:    Judgement
        /// Description:    Judge whether the user input the name, select noodle type, 
        ///                 select a flavour or not. If not, send a messagebox and return false.
        ///                 If so, return true.
        /// </summary>
        /// <returns>The value of judge result</returns>
        public bool Judgement() {
            bool noNoodle = true;

            // Read user's name, and send a message if no name
            if (nameTextBox.Text == "") {
                MessageBox.Show("Please input your name!");
            }// end if

            // Traverse all radiobutton in noodle groupbox to check if noodle is chosen
            foreach (Control radio in noodleTypeGroupBox.Controls) {
                if (radio is RadioButton) {
                    RadioButton radioButton = radio as RadioButton;
                    if (radioButton.Checked) {
                        noNoodle = false;
                        break;
                    }// end if
                }// end if
            }// end foreach
            // If not chosen, send a message
            if (noNoodle) {
                MessageBox.Show("Please select a type of noodle!");
            }// end if

            // Check if flavour is chosen. If not, send a message
            if (flavoursBox.SelectedIndex == -1) {
                MessageBox.Show("Please select a type of flavour!");
            }// end if

            // If all checks are right, return true. Otherwise, return false
            if (nameTextBox.Text != "" && !noNoodle && flavoursBox.SelectedIndex != -1) {
                return true;
            } else {
                return false;
            }// end if
        }// end Judgement

        /// <summary>
        /// Method Name:    MeatPrice
        /// Description:    Calculate meat price by meat's name
        /// </summary>
        /// <returns>The price of meat</returns>
        public int MeatPrice() {
            string meatName = "";
            int meatPrice;

            // Read meat name
            foreach (Control radio in addMeatGroupBox.Controls) {
                if (radio is RadioButton) {
                    RadioButton radioButton = radio as RadioButton;
                    if (radioButton.Checked) {
                        meatName = radioButton.Text;
                        break;
                    }// end if
                }
            }// end if

            // Calculate meat price by name
            if (meatName == "None") {
                meatPrice = 0;
            } else if (meatName == "Seafood") {
                meatPrice = 7;
            } else {
                meatPrice = 5;
            }// end if

            return meatPrice;
        }// end MeatPrice

        /// <summary>
        /// Method Name:    VegetableNumber
        /// Description:    Count vegetable number
        /// </summary>
        /// <returns>The number of vegetable</returns>
        public int VegetableNumber() {
            int vegetableNum = 0;

            // Traverse all checkbox to count vegetable number
            foreach (Control check in addVegetablesGroupBox.Controls) {
                if (check is CheckBox) {
                    CheckBox checkBox = check as CheckBox;
                    if (checkBox.Checked) {
                        vegetableNum++;
                    }// end if
                }// end if
            }// end foreach

            return vegetableNum;
        }// end VegtableNumber

        /// <summary>
        /// Method Name:    TotalPrice
        /// Description:    Calculate the total price in AUD
        /// </summary>
        /// <returns></returns>
        public double TotalPrice() {
            double totalPrice = 0.0;
            int meatPrice = 0;
            int vegetableNumber = 0;

            // invoke the method
            meatPrice = MeatPrice();
            vegetableNumber = VegetableNumber();

            // calculate the price of vegetable
            if (vegetableNumber <= 4) {
                totalPrice = meatPrice + 5.5;
            } else {
                totalPrice = meatPrice + 5.5 + (vegetableNumber - 4) * 0.5;
            }// end if

            // if bigsize, price * 1.5
            if (bigSizeCheckBox.Checked) {
                totalPrice *= 1.5;
            }

            return totalPrice;
        }// end TotalPrice

        /// <summary>
        /// Method Name:    calculateButton_Click
        /// Description:    Display the result when clicks button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void calculateButton_Click(object sender, EventArgs e) {
            bool judge;
            double totalPrice;

            // set result visible
            if (judge = Judgement()) {
                orderPriceLabel.Visible = true;
                priceTextBox.Visible = true;
                groupBox.Visible = true;
            }

            totalPrice = TotalPrice();

            priceTextBox.Text = "$" + totalPrice.ToString("0.00");
        }// end calculateButton_Click

        /// <summary>
        /// Method Name:    capscicumCheckBox_CheckedChanged
        /// Description:    Set result invisible, when clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void capscicumCheckBox_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }// end capscicumCheckBox_CheckedChanged

        /// <summary>
        /// Method Name:    cabbageCheckBox_CheckedChanged
        /// Description:    Set result invisible, when clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cabbageCheckBox_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }// end cabbageCheckBox_CheckedChanged

        /// <summary>
        /// Method Name:     broccoilCheckBox_CheckedChanged
        /// Description:    Set result invisible, when clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void broccoilCheckBox_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }// end broccoilCheckBox_CheckedChanged

        /// <summary>
        /// Method Name:    shallotsCheckBox_CheckedChanged
        /// Description:    Set result invisible, when clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shallotsCheckBox_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }// end shallotsCheckBox_CheckedChanged

        /// <summary>
        /// Method Name:    carrotCheckBox_CheckedChanged
        /// Description:    Set result invisible, when clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void carrotCheckBox_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }// end carrotCheckBox_CheckedChanged

        /// <summary>
        /// Method Name:    bokChoyheckBox_CheckedChanged
        /// Description:    Set result invisible, when clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bokChoyheckBox_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }//end bokChoyheckBox_CheckedChanged

        /// <summary>
        /// Method Name:    onionCheckBox_CheckedChanged
        /// Description:    Set result invisible, when clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void onionCheckBox_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }//end onionCheckBox_CheckedChanged

        /// <summary>
        /// Method Name:    snowPeasCheckBox1_CheckedChanged
        /// Description:    Set result invisible, when clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void snowPeasCheckBox1_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }// end snowPeasCheckBox1_CheckedChanged

        /// <summary>
        /// Method Name:    greenBeansCheckBox_CheckedChanged
        /// Description:    Set result invisible, when clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void greenBeansCheckBox_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }// end greenBeansCheckBox_CheckedChanged

        /// <summary>
        /// Method Name:    sproutsCheckBox_CheckedChanged
        /// Description:    Set result invisible, when clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sproutsCheckBox_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }// end sproutsCheckBox_CheckedChanged

        /// <summary>
        /// Method Name:    usdRadioButton_CheckedChanged
        /// Description:    Transform the price into USD, when click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void usdRadioButton_CheckedChanged(object sender, EventArgs e) {
            double totalPrice = TotalPrice();
            totalPrice *= 0.77;
            priceTextBox.Text = "$" + totalPrice.ToString("0.00");
        }// end usdRadioButton_CheckedChanged

        /// <summary>
        /// Method Name:    bigSizeCheckBox_CheckedChanged
        /// Description:    Set result invisible, when clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bigSizeCheckBox_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }// end bigSizeCheckBox_CheckedChanged

        /// <summary>
        /// Method Name:    chickenRadioButton_CheckedChanged
        /// Description:    Set result invisible, when clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chickenRadioButton_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }// end chickenRadioButton_CheckedChanged

        /// <summary>
        /// Method Name:    porkRadioButton_CheckedChanged
        /// Description:    Set result invisible, when clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void porkRadioButton_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }// end porkRadioButton_CheckedChanged

        /// <summary>
        /// Method Name:    beefRadioButton_CheckedChanged
        /// Description:    Set result invisible, when clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void beefRadioButton_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }// end beefRadioButton_CheckedChanged

        /// <summary>
        /// Method Name:    seafoodRadioButton_CheckedChanged
        /// Description:    Set result invisible, when clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void seafoodRadioButton_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }// end seafoodRadioButton_CheckedChanged

        /// <summary>
        /// Method Name:    noneRadioButton_CheckedChanged
        /// Description:    Set result invisible, when clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void noneRadioButton_CheckedChanged(object sender, EventArgs e) {
            orderPriceLabel.Visible = false;
            priceTextBox.Visible = false;
            groupBox.Visible = false;
        }// end noneRadioButton_CheckedChanged

        /// <summary>
        /// Method Name:    audRadioButton_CheckedChanged
        /// Description:    Transform the price into AUD, when clicks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void audRadioButton_CheckedChanged(object sender, EventArgs e) {
            double totalPrice = TotalPrice();
            priceTextBox.Text = "$" + totalPrice.ToString("0.00");
        }// end audRadioButton_CheckedChanged
    }
}
