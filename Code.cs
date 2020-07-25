using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Joes_Automotive
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Will tally up oil and lube expenses.
        public double OilLubeCharges()
        {   //Initialized at zero in case oil/lube service is not needed.
            double oilPrice = 0;
            //Series of if else statements to determine the value of oilPrice to be returned.
            if(oilChangecheckBox.Checked == true && lubeJobcheckBox.Checked == false)
            {
                oilPrice = 26.00;
                return oilPrice;
            }
            else if(oilChangecheckBox.Checked == false && lubeJobcheckBox.Checked == true)
            {
                //Price when Lube Job box is checked.
                oilPrice = 18.00;
                return oilPrice;
            }
            //For when both are checked.
            else if(oilChangecheckBox.Checked == true && lubeJobcheckBox.Checked == true)
            {
                oilPrice = 26.00 + 18.00;
                return oilPrice;
            }
            else 
                return oilPrice;
          
        }
        //Will tally up flush expenses.
        public double FlushCharges()
        {   //Initialized at zero in case flush service is not needed.
            double flushPrice = 0;
            //Series of if else statements to determine the value of flushPrice to be returned.
            if (radiatorFlushcheckBox.Checked == true && transmissionFlushcheckBox.Checked == false)
            {
                //Price for radiator flush.
                flushPrice = 30.00;
                return flushPrice;
            }
            else if (radiatorFlushcheckBox.Checked == false && transmissionFlushcheckBox.Checked == true)
            {
                //Price when transmission flush box is checked.
                flushPrice = 80.00;
                return flushPrice;
            }
            //For when both are checked.
            else if (radiatorFlushcheckBox.Checked == true && transmissionFlushcheckBox.Checked == true)
            {
                flushPrice = 30.00 + 80.00;
                return flushPrice;
            }
            else
                //Just returns oilPrice since it is initially set to zero.
                return flushPrice;

        }
        //Method to account for Misc Charges.
        public double MiscCharges()
        {
            //Will hold misc charges price and set it to zero initially.
            double miscPrice = 0;
            //Series of if else statements to determine the value of miscPrice based on box checked.
            //For if just Inspection is checked
            if(inspectioncheckBox.Checked == true && replaceMufflercheckBox.Checked == false && tireRotationcheckBox.Checked == false)
            {
                miscPrice = 15.00;
                return miscPrice;
            }
            //For if just Replace Muffler is checked.
            if (inspectioncheckBox.Checked == false && replaceMufflercheckBox.Checked == true && tireRotationcheckBox.Checked == false)
            {
                miscPrice = 100.00;
                return miscPrice;
            }
            //For if just Tire Rotation is checked.
            if (inspectioncheckBox.Checked == false && replaceMufflercheckBox.Checked == false && tireRotationcheckBox.Checked == true)
            {
                miscPrice = 20.00;
                return miscPrice;
            }
            //For if Inspection and Replace Muffler are checked.
            if (inspectioncheckBox.Checked == true && replaceMufflercheckBox.Checked == true && tireRotationcheckBox.Checked == false)
            {
                miscPrice = 15.00 + 100;
                return miscPrice;
            }
            //For if Replace Muffler and Tire Rotation are checked.
            if (inspectioncheckBox.Checked == false && replaceMufflercheckBox.Checked == true && tireRotationcheckBox.Checked == true)
            {
                miscPrice = 100.00 + 20.00;
                return miscPrice;
            }
            //For if tire rotation and inspection are checked.
            if (inspectioncheckBox.Checked == true && replaceMufflercheckBox.Checked == false && tireRotationcheckBox.Checked == true)
            {
                miscPrice = 15.00 + 20.00;
                return miscPrice;
            }
            //If all misc services are checked.
            if (inspectioncheckBox.Checked == true && replaceMufflercheckBox.Checked == true && tireRotationcheckBox.Checked == true)
            {
                miscPrice = 15.00 + 100.00 + 20.00;
                return miscPrice;
            }
            //If no misc services are checked.
            else 
                return miscPrice;
      
        }
        //Will return the charges for the parts price entered.
        public double PartsCharges()
        {
            //Double to hold the price for user entered parts price.
            double partPrice;
            //Will use TryParse.
            if (double.TryParse(partstextBox.Text, out partPrice))
            {   
               
            }
            else
                MessageBox.Show("Please enter a numbered price for parts.");
            //Returns the value if double data type is able to be parsed from string.
            return partPrice;
        }
        //Will return the charge for hours of labor.
        public double LaborCharges()
        {
            //Double to hours worked.
            double hoursWorked;
            //Charge per labor hour.
            double laborRate = 20.00;
            //Will use TryParse.
            if (double.TryParse(labortextBox.Text, out hoursWorked))
            {
     
            }
            else
                MessageBox.Show("Please enter a numbered value for the hours of labor.");
            //Returns the value of laborRate multiplied by the hours worked.
            return (hoursWorked * laborRate);
        }
        //Method for returning tax charge of 6% also 0.06.
        public double TaxCharges()
        {
            //Will hold tax rate. Will be considered only with PartsCharges()
            double taxRate = 0.06;
            return taxRate;
        }
        //Method to clear and uncheck everything.
        public void ClearAll()
        {
            oilChangecheckBox.Checked = false;
            lubeJobcheckBox.Checked = false;
            radiatorFlushcheckBox.Checked = false;
            transmissionFlushcheckBox.Checked = false;
            inspectioncheckBox.Checked = false;
            replaceMufflercheckBox.Checked = false;
            tireRotationcheckBox.Checked = false;
            partstextBox.Text = "";
            labortextBox.Text = "";
            serviceAndLaborlabel.Text = "";
            finalPartslabel.Text = "";
            taxlabel.Text = "";
            totallabel.Text = "";
        }
        private void calculateButton_Click(object sender, EventArgs e)
        {
            //Will calculate the service and labor and set it to a double.
            double serviceAndLabor = OilLubeCharges() + FlushCharges() + MiscCharges() + LaborCharges();
            //Displays the value.
            serviceAndLaborlabel.Text = serviceAndLabor.ToString("c2");
            //Double to hold PartsCharges() method return value.
            double parts = PartsCharges();
            //Displays the value.
            finalPartslabel.Text = parts.ToString("c2");
            //Will find the cost of tax on our parts.
            double taxHolder = PartsCharges() * TaxCharges();
            //Displays the value.
            taxlabel.Text = taxHolder.ToString("c2");
            //Double to hold the final cost.
            double finalCost = serviceAndLabor + parts + taxHolder;
            //Displays the final cost.
            totallabel.Text = finalCost.ToString("c2");
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            //Calls the ClearAll() method on clicking the clear button.
            ClearAll();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            //Closes the form.
            this.Close();
        }
    }
}
