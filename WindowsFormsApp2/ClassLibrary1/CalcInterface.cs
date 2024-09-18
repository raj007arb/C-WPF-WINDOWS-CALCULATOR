using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public interface CalcInterface
    {
        string CheckTxtRcntLogic(string num);
        string OperatorsLogic(double num, string ops);
        string ResultLogic(double num2);
        string DecimalLogic(string TxtMain);
        double NegationLogic(double num);
        string BackSpaceLogic(string TxtMain);
        string CancelAllLogic();
        string CancelRcntLogic();
        double FractionLogic(double num);
        double SquareLogic(double num);
        double SqrtLogic(double num);
        double PercentLogic(string TxtMain, string TxtRcnt);
    }
}
