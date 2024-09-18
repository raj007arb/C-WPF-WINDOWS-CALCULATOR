//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;


//namespace Calculator
//{
//    public partial class MainWindow : Window
//    {
//        private double _firstNumber = 0;
//        private double _secondNumber = 0;
//        private string _operator = "";
//        private bool _isOperationPerformed = false;
//        private bool _isDecimalAdded = false;

//        public MainWindow()
//        {
//            InitializeComponent();
//        }

//        // Handles number and decimal point button clicks
//        private void Number_Click(object sender, RoutedEventArgs e)
//        {
//            Button button = sender as Button;

//            // Handle clearing input if an operation was just performed
//            if (_isOperationPerformed)
//            {
//                txtInput.Text = "";
//                _isOperationPerformed = false;
//            }

//            // Handle decimal point separately to prevent multiple decimals in one number
//            if (button.Content.ToString() == ".")
//            {
//                if (!_isDecimalAdded)
//                {
//                    txtInput.Text += button.Content.ToString();
//                    _isDecimalAdded = true;
//                }
//            }
//            else
//            {
//                if (txtInput.Text == "0")
//                    txtInput.Text = button.Content.ToString();
//                else
//                    txtInput.Text += button.Content.ToString();
//            }
//        }

//        // Handles operator button clicks (+, -, *, /)
//        private void Operator_Click(object sender, RoutedEventArgs e)
//        {
//            Button button = sender as Button;

//            if (!string.IsNullOrEmpty(txtInput.Text))
//            {
//                _firstNumber = Convert.ToDouble(txtInput.Text);
//                _operator = button.Content.ToString();
//                txtResult.Text = $"{_firstNumber} {_operator}";
//                txtInput.Text = "0";
//                _isDecimalAdded = false;
//            }
//        }

//        // Handles the "=" button click to perform the calculation
//        private void Equals_Click(object sender, RoutedEventArgs e)
//        {
//            if (!string.IsNullOrEmpty(txtInput.Text))
//            {
//                _secondNumber = Convert.ToDouble(txtInput.Text);
//                double result = 0;

//                try
//                {
//                    switch (_operator)
//                    {
//                        case "+":
//                            result = _firstNumber + _secondNumber;
//                            break;
//                        case "-":
//                            result = _firstNumber - _secondNumber;
//                            break;
//                        case "×":
//                            result = _firstNumber * _secondNumber;
//                            break;
//                        case "÷":
//                            if (_secondNumber == 0)
//                            {
//                                throw new DivideByZeroException("Cannot divide by zero.");
//                            }
//                            result = _firstNumber / _secondNumber;
//                            break;
//                    }

//                    txtResult.Text = $"{_firstNumber} {_operator} {_secondNumber} =";
//                    txtInput.Text = result.ToString();
//                    _firstNumber = result;
//                    _operator = "";
//                    _isOperationPerformed = true;
//                    _isDecimalAdded = false;
//                }
//                catch (DivideByZeroException ex)
//                {
//                    txtInput.Text = ex.Message;
//                }
//                catch (Exception ex)
//                {
//                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
//                }
//            }
//        }

//        // Handles the "C" button click to clear the current input
//        private void Clear_Click(object sender, RoutedEventArgs e)
//        {
//            txtInput.Text = "0";
//            _isDecimalAdded = false;
//        }

//        // Handles the "CE" button click to clear the entire calculation
//        private void ClearEntry_Click(object sender, RoutedEventArgs e)
//        {
//            txtInput.Text = "0";
//            txtResult.Text = "";
//            _firstNumber = 0;
//            _secondNumber = 0;
//            _operator = "";
//            _isDecimalAdded = false;
//        }

//        // Handles the "⌫" button click to delete the last character in the input
//        private void Delete_Click(object sender, RoutedEventArgs e)
//        {
//            if (txtInput.Text.Length > 0)
//            {
//                txtInput.Text = txtInput.Text.Substring(0, txtInput.Text.Length - 1);
//                if (txtInput.Text == "")
//                {
//                    txtInput.Text = "0";
//                }
//            }
//        }

//        // Handles the "+/-" button click to toggle the sign of the input
//        private void Negate_Click(object sender, RoutedEventArgs e)
//        {
//            if (!string.IsNullOrEmpty(txtInput.Text))
//            {
//                double number = Convert.ToDouble(txtInput.Text);
//                number = -number;
//                txtInput.Text = number.ToString();
//            }
//        }

//        // Handles the "1/x" button click to calculate the reciprocal
//        private void Reciprocal_Click(object sender, RoutedEventArgs e)
//        {
//            if (!string.IsNullOrEmpty(txtInput.Text))
//            {
//                try
//                {
//                    double number = Convert.ToDouble(txtInput.Text);
//                    if (number == 0)
//                    {
//                        throw new DivideByZeroException("Cannot divide by zero.");
//                    }
//                    number = 1 / number;
//                    txtInput.Text = number.ToString();
//                }
//                catch (DivideByZeroException ex)
//                {
//                    txtInput.Text = ex.Message;
//                }
//            }
//        }

//        // Handles the "x²" button click to calculate the square of the input
//        private void Square_Click(object sender, RoutedEventArgs e)
//        {
//            if (!string.IsNullOrEmpty(txtInput.Text))
//            {
//                double number = Convert.ToDouble(txtInput.Text);
//                number = Math.Pow(number, 2);
//                txtInput.Text = number.ToString();
//            }
//        }

//        // Handles the "√x" button click to calculate the square root of the input
//        private void SquareRoot_Click(object sender, RoutedEventArgs e)
//        {
//            if (!string.IsNullOrEmpty(txtInput.Text))
//            {
//                try
//                {
//                    double number = Convert.ToDouble(txtInput.Text);
//                    if (number < 0)
//                    {
//                        throw new ArithmeticException("Invalid input");
//                    }
//                    number = Math.Sqrt(number);
//                    txtInput.Text = number.ToString();
//                }
//                catch (ArithmeticException ex)
//                {
//                    txtInput.Text = ex.Message;
//                }
//            }
//        }

//        // Handles the History button click (Currently not implemented)
//        private void HistoryButton_Click(object sender, RoutedEventArgs e)
//        {
//            MessageBox.Show("History functionality is not implemented.");
//        }

//        // Handles the Flow Layout button click (Currently not implemented)
//        private void FlowLayoutButton_Click(object sender, RoutedEventArgs e)
//        {
//            MessageBox.Show("Flow Layout functionality is not implemented.");
//        }

//        private void Button_Click(object sender, RoutedEventArgs e)
//        {

//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CalcLogic;


namespace Calculator
{
    public partial class MainWindow : Window
    {
        CalcLogic.Calculator c;
        //AugustCalculatorImp.Calculator c;
        public MainWindow()
        {
            InitializeComponent();
            c = new CalcLogic.Calculator();
            // c = new AugustCalculatorImp.Calculator();
        }

        string cuttentOperator = "";
        string firstNo = "";

        private void NumCheck(string num)
        {

            if (txtInput.Text == firstNo)
            {
                txtInput.Text = "0";
            }
            if (txtInput.Text == num || txtInput.Text == "0")
            {
                txtInput.Text = num;
            }
            else
            {
                txtInput.Text += num;
            }
        }
        //SELECT ALL THE BUTTONS EXAMPLE 0,1,2,3,4,5,6,7,8,9,.
        private void Number_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            NumCheck(c.CheckTxtRcntLogic(button.Content+""));
            //if ((TxtBox.Text == "0") || (isOperationPerform))
            //    TxtBox.Clear();

            //isOperationPerform = false;
            //Button button = (Button)sender;
            //if (button.Text == ".")
            //{
            //    if (!TxtBox.Text.Contains("."))
            //        TxtBox.Text = TxtBox.Text + button.Content;
            //}
            //else
            //{
            //    TxtBox.Text = TxtBox.Text + button.Content;
            //}
        }
        // FOR THE OPERATORS +,-,*,/,%
        private void Operator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            operationStatement.Text = c.OperatorsLogic(Double.Parse(txtInput.Text), button.Content+"");
            firstNo = txtInput.Text;
            operationStatement.Text = txtInput.Text + button.Content;
            cuttentOperator = button.Content+ "";


            //Button button = (Button)sender

            //if (result != 0 && !isOperationPerform)
            //{
            //    try
            //    {
            //        EqualBtn.PerformClick();    //define under Button class which comes under System.Window.Form
            //        operationPerformed = button.Content;
            //        operationStatement.Text = result + " " + operationPerformed;
            //        isOperationPerform = true;
            //    }
            //    catch (FormatException)
            //    {
            //        txtInput.Text = "Enter valid number";
            //    }
            //}
            //else
            //{
            //    operationPerformed = button.Content;
            //    result = Double.Parse(txtInput.Text);
            //    operationStatement.Text = result + " " + operationPerformed;
            //    isOperationPerform = true;
            //}

        }
        //FOR DELETE OPERATION
        private void Delete_Click(object sender, EventArgs e)
        {
            txtInput.Text = c.BackSpaceLogic(txtInput.Text);
            //for text box
            //if (txtInput.Text.Length > 0)
            //{
            //    txtInput.Text = txtInput.Text.Substring(0, txtInput.Text.Length - 1);
            //}
            //if (txtInput.Text == "")
            //{
            //    txtInput.Text = "0";
            //}

        }
        //for clear operation
        private void Clear_Click(object sender, EventArgs e)
        {
            operationStatement.Text = c.CancelAllLogic();
            txtInput.Text = c.CancelAllLogic();
            //txtInput.Text = "0";
            //result = 0;
            //operationStatement.Text = "";

        }
        // when equal button is clicked the operation is performed
        private void Equals_Click(object sender, EventArgs e)
        {
            double secondOperand = Double.Parse(txtInput.Text);
            if (secondOperand == 0 && cuttentOperator == "÷")
            {
                txtInput.Text = "Cant divide by zero";
            }
            else
            {
                //operationPerformed.Text = c.getOperationStatement(txtInput.Text);
                operationStatement.Text = firstNo + cuttentOperator + secondOperand + "=";
                txtInput.Text = c.ResultLogic(secondOperand);
            }
            //try
            //{
            //    double secondOperand = Double.Parse(txtInput.Text);
            //    double a = result;
            //    switch (operationPerformed)
            //    {
            //        case "+":
            //            txtInput.Text = (result + secondOperand).ToString();
            //            break;

            //        case "-":
            //            txtInput.Text = (result - secondOperand).ToString();
            //            break;

            //        case "x":
            //            txtInput.Text = (result * secondOperand).ToString();
            //            break;

            //        case "÷":
            //            if (secondOperand != 0)
            //                txtInput.Text = (result / secondOperand).ToString();
            //            else
            //                txtInput.Text = "Cannot divide by zero";
            //            break;


            //        default:
            //            break;
            //    }
            //    result = Double.Parse(txtInput.Text);
            //    isOperationPerform = false;
            //    operationStatement.Text = a + " " + operationPerformed + " " + secondOperand + "=";
            //    operationPerformed = "";
            //}
            //catch (Exception)
            //{
            //    txtInput.Text = "Cannot divide by zero";
            //}

        }


        //when text box is double clicked then the delete option takes place
        //private void DoubleClick_operation_textbox(object sender, MouseEventArgs e)
        //{
        //    if (operationStatement.Text.Length > 0)
        //    {
        //        operationStatement.Text = operationStatement.Text.Substring(0, operationStatement.Text.Length - 1);
        //    }
        //    if (operationStatement.Text == "")
        //    {
        //        operationStatement.Text = "0";
        //    }

        //}
        double num1;
        //to negate a input number
        private void Negate_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(txtInput.Text);
            txtInput.Text = c.NegationLogic(num1) + "";


            //txtInput.Text = (c.NegationLogic(Double.Parse(txtInput.Text))).ToString();
            //txtInput.Text = double.Parse(txtInput.Text) * -1 + "";

        }
        //for ce
        private void ClearEntry_Click(object sender, EventArgs e)
        {
            txtInput.Text = "0";
        }

        //private void His_Click(object sender, EventArgs e)
        //{
        //    timer1.Start();

        //}
        //Boolean historybarexpand;
        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    if (historybarexpand)
        //    {
        //        HistoryBar.Height -= 50;
        //        if (HistoryBar.Height == HistoryBar.MinimumSize.Height)
        //        {
        //            historybarexpand = false;
        //            timer1.Stop();

        //        }
        //    }
        //    else
        //    {
        //        HistoryBar.Height += 50;
        //        if (HistoryBar.Height == HistoryBar.MaximumSize.Height)
        //        {
        //            historybarexpand = true;
        //            timer1.Stop();
        //        }
        //    }

        //}

        private void SquareRoot_Click(object sender, EventArgs e)
        {
            //double num = double.Parse(txtInput.Text);
            //if (num < 0)
            //{
            //    txtInput.Text = "Invalid Input";

            //}
            //else
            //{
            //    result = Math.Sqrt(num);
            //    txtInput.Text = result + "";
            //    operationStatement.Text = "\u221a(" + num + ")=";
            //}
        }

        private void Square_Click(object sender, EventArgs e)
        {
            //double num = double.Parse(txtInput.Text);
            //result = Math.Pow(num, 2);
            //txtInput.Text = result + "";
            //operationStatement.Text = "sqr(" + num + ")=";
        }

        private void FractionFun(object sender, EventArgs e)
        {
            //double num = double.Parse(txtInput.Text);
            //if (num == 0)
            //{
            //    txtInput.Text = "Cannot Divide By Zero";
            //}
            //else
            //{
            //    result = 1 / num;
            //    txtInput.Text = result + "";
            //    operationStatement.Text = "1/(" + num + ")=";
            //}
        }

        private void PercentFun(object sender, EventArgs e)
        {
            //double num = double.Parse(txtInput.Text);
            //double secondOperand = Double.Parse(txtInput.Text);
            //txtInput.Text = ((result * secondOperand) / 100).ToString();

        }



        //bool sidebarexpand;
        //private void timer2_Tick(object sender, EventArgs e)
        //{
        //    if (sidebarexpand)
        //    {
        //        sidebar.Width -= 50;
        //        if (sidebar.Width == sidebar.MinimumSize.Width)
        //        {
        //            sidebarexpand = false;
        //            timer2.Stop();

        //        }
        //    }
        //    else
        //    {
        //        sidebar.Width += 50;
        //        if (sidebar.Width == sidebar.MaximumSize.Width)
        //        {
        //            sidebarexpand = true;
        //            timer2.Stop();
        //        }
        //    }
        //}

        //private void button25_Click(object sender, EventArgs e)
        //{
        //    timer2.Start();
        //}

        //private void button24_Click(object sender, EventArgs e)
        //{
        //    timer2.Start();
        //}

        private void button17_Click(object sender, EventArgs e)
        {
            txtInput.Text = c.DecimalLogic(txtInput.Text);
        }
    }
}