using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        bool isOperationPerform = false;
        Double result = 0;
        string operationPerformed = "";

        public Form1()
        {
            InitializeComponent();
        }
        //SELECT ALL THE BUTTONS EXAMPLE 0,1,2,3,4,5,6,7,8,9,.
        private void numbttnclk(object sender, EventArgs e)
        {
            if ((TxtBox.Text == "0") || (isOperationPerform))
                TxtBox.Clear();

            isOperationPerform = false;
            Button button = (Button)sender;
            if (button.Text == ".")
            {
                if (!TxtBox.Text.Contains("."))
                    TxtBox.Text = TxtBox.Text + button.Text;
            }
            else
            {
                TxtBox.Text = TxtBox.Text + button.Text;
            }
        }
        // FOR THE OPERATORS +,-,*,/,%
        private void OperatorClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (result != 0 && !isOperationPerform)
            {
                try
                {
                    EqualBtn.PerformClick();    //define under Button class which comes under System.Window.Form
                    operationPerformed = button.Text;
                    operationStatement.Text = result + " " + operationPerformed;
                    isOperationPerform = true;
                }
                catch (FormatException)
                {
                    TxtBox.Text = "Enter valid number";
                }
            }
            else
            {
                operationPerformed = button.Text;
                result = Double.Parse(TxtBox.Text);
                operationStatement.Text = result + " " + operationPerformed;
                isOperationPerform = true;
            }

        }
        //FOR DELETE OPERATION
        private void button7_Click(object sender, EventArgs e)
        {
            //for text box
            if (TxtBox.Text.Length > 0)
            {
                TxtBox.Text = TxtBox.Text.Substring(0, TxtBox.Text.Length - 1);
            }
            if (TxtBox.Text == "")
            {
                TxtBox.Text = "0";
            }
            //operationStatement
                      /* if (operationStatement.Text.Length > 0)
                        {
                            operationStatement.Text = operationStatement.Text.Substring(0, operationStatement.Text.Length - 1);
                        }
                        if (operationStatement.Text == "")
                        {
                            operationStatement.Text = "0";
                        }*/
        }
        //for clear operation
        private void button5_Click(object sender, EventArgs e)
        {
            TxtBox.Text = "0";
            result = 0;
            operationStatement.Text="";

        }
        // when equal button is clicked the operation is performed
        private void EqualBtn_Click(object sender, EventArgs e)
        {
            try
            {
                double secondOperand = Double.Parse(TxtBox.Text);
                double a = result;
                switch (operationPerformed)
                {
                    case "+":
                        TxtBox.Text = (result + secondOperand).ToString();
                        break;

                    case "-":
                        TxtBox.Text = (result - secondOperand).ToString();
                        break;

                    case "x":
                        TxtBox.Text = (result * secondOperand).ToString();
                        break;

                    case "÷":
                        if (secondOperand != 0)
                            TxtBox.Text = (result / secondOperand).ToString();
                        else
                            TxtBox.Text = "Cannot divide by zero";
                        break;


                    default:
                        break;
                }
                result = Double.Parse(TxtBox.Text);
                isOperationPerform = false;
                operationStatement.Text = a + " " + operationPerformed + " " + secondOperand + "=";
                operationPerformed = "";
            }
            catch (Exception)
            {
                TxtBox.Text = "Cannot divide by zero";
            }

        }

    
        //when text box is double clicked then the delete option takes place
        private void DoubleClick_operation_textbox(object sender, MouseEventArgs e)
        {
            if (operationStatement.Text.Length > 0)
            {
                operationStatement.Text = operationStatement.Text.Substring(0, operationStatement.Text.Length - 1);
            }
            if (operationStatement.Text == "")
            {
                operationStatement.Text = "0";
            }

        }
        //to negate a input number
        private void button3_Click(object sender, EventArgs e)
        {
            TxtBox.Text = double.Parse(TxtBox.Text) * -1+"";

        }

        private void button22_Click(object sender, EventArgs e)
        {
            TxtBox.Text = "0";
        }

        private void His_Click(object sender, EventArgs e)
        {
            timer1.Start();

        }
        Boolean historybarexpand;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(historybarexpand)
            {
                HistoryBar.Height -= 50;
                if(HistoryBar.Height==HistoryBar.MinimumSize.Height)
                {
                    historybarexpand = false;
                    timer1.Stop();

                }
            }
            else
            {
                HistoryBar.Height += 50;
                if(HistoryBar.Height==HistoryBar.MaximumSize.Height)
                {
                    historybarexpand = true;
                    timer1.Stop();
                }
            }
            
        }

        private void RootFun(object sender, EventArgs e)
        {
            double num = double.Parse(TxtBox.Text);
            if (num < 0)
            {
                TxtBox.Text = "Invalid Input";
               
            }
            else
            {
                result = Math.Sqrt(num);
                TxtBox.Text = result + "";
                operationStatement.Text = "\u221a(" + num + ")=";
            }
        }

        private void SquareFun(object sender, EventArgs e)
        {
            double num = double.Parse(TxtBox.Text);
            result = Math.Pow(num, 2);
            TxtBox.Text = result + "";
            operationStatement.Text = "sqr(" + num + ")=";
        }

        private void FractionFun(object sender, EventArgs e)
        {
            double num = double.Parse(TxtBox.Text);
            if (num == 0)
            {
                TxtBox.Text = "Cannot Divide By Zero";
            }
            else
            {
                result = 1 / num;
                TxtBox.Text = result + "";
                operationStatement.Text = "1/(" + num + ")=";
            }
        }

        private void PercentFun(object sender, EventArgs e)
        {
            double num = double.Parse(TxtBox.Text);
            double secondOperand = Double.Parse(TxtBox.Text);
            TxtBox.Text = ((result * secondOperand) / 100).ToString();

        }

      

        bool sidebarexpand;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (sidebarexpand)
            {
                sidebar.Width -= 50;
                if (sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarexpand = false;
                    timer2.Stop();

                }
            }
            else
            {
                sidebar.Width += 50;
                if (sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarexpand = true;
                    timer2.Stop();
                }
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void operationStatement_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
