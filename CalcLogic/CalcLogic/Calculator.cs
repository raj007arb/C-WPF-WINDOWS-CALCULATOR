using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcLogic
{
    
    public class Calculator : ICalculator
    {
        Double result = 0;
        string operationPerformed = "";
        bool isOperationPerformed = false;

        public string getOperationStatement(string s)
        {
            return result + operationPerformed + s + "=";
        }
        /*
        public string updateTxtBox(string txtBox,string btnTxt)
        {
            if ((txtBox == "0") || (isOperationPerformed))
                txtBox="";
 
            isOperationPerformed = false;
            if (btnTxt == ".")
            {
                if (!txtBox.Contains("."))
                    return txtBox + btnTxt;
                else
                    return txtBox;
            }
            else
            {
                return txtBox + btnTxt;
            }
        }
        public string CheckTxtRcntLogic(string txtBox, string btnTxt, string x)
        {
            if ((txtBox == "0") || (isOperationPerformed))
                txtBox = "";
 
            isOperationPerformed = false;
            if (btnTxt == ".")
            {
                return DecimalLogic(txtBox);
            }
            else
            {
                return txtBox + btnTxt;
            }
        }*/
        public string DecimalLogic(string txtBox)
        {
            if (!txtBox.Contains("."))
            {
                txtBox += ".";
            }
            return txtBox;
        }
        public string CheckTxtRcntLogic(string num)
        {
            return num;
        }





        public string BackSpaceLogic(string txtBox)
        {
            if (txtBox.Length > 0)
            {
                return txtBox.Substring(0, txtBox.Length - 1);
            }
            else
                return "0";
        }
        public string OperatorsLogic(double txtBox, string btnTxt)
        {
            try
            {
                if (result != 0 && !isOperationPerformed)
                {
                    result = Double.Parse(ResultLogic(txtBox));
                    operationPerformed = btnTxt;
                    isOperationPerformed = true;
                    return result.ToString();
                }
                else
                {
                    operationPerformed = btnTxt;
                    isOperationPerformed = true;
                    result = txtBox;
                    return txtBox.ToString();
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public string ResultLogic(double secondno)
        {
            isOperationPerformed = true;

            string ans = "";
            switch (operationPerformed)
            {
                case "+":
                    ans = (result + secondno).ToString();
                    break;

                case "-":
                    ans = (result - secondno).ToString();
                    break;

                case "x":
                    ans = (result * secondno).ToString();
                    break;

                case "÷":
                    if (secondno != 0)
                        ans = (result / secondno).ToString();
                    else
                        ans = "Cannot divided by zero";
                    break;

                case "2√x":
                    ans = (Math.Sqrt(result)).ToString();
                    break;

                case "x²":
                    //ans = (Math.Pow(result, 2)).ToString();
                    ans = SquareLogic(result).ToString();
                    break;
                case "1/x":
                    /* if (result != 0)
                         ans = (1 / result).ToString();
                     else
                         ans = "Cannot divided by zero";*/
                    ans = FractionLogic(result).ToString();
                    break;
                case "%":
                    //ans = ((result * secondno) / 100).ToString();
                    ans = PercentLogic(result.ToString(), secondno.ToString()).ToString();
                    break;

                default:
                    break;
            }
            result = Double.Parse(ans);
            return ans;

        }
        public double FractionLogic(double num)
        {
            return (1 / num);
        }
        public double SquareLogic(double num)
        {
            return Math.Pow(num, 2);
        }
        public double SqrtLogic(double num)
        {
            return (Math.Sqrt(result));
        }
        public double PercentLogic(string result, string secondno)
        {
            return ((Double.Parse(result) * Double.Parse(secondno)) / 100);
        }
        public double NegationLogic(double txt)
        {

            txt = txt * -1;
            return txt;
            //if (txt > 0)
            //{
            //    return -txt;
            //}
            //else
            //{
            //    return txt;
            //}
        }
        public string CancelRcntLogic()
        {
            return "";
        }
        public string CancelAllLogic()
        {
            result = 0;
            operationPerformed = "";
            return "";
        }
       
    }
}
