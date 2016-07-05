using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_of_linear_equations
{
    class SystemEquations
    {
        private SortedList<String, int> ac = new SortedList<String,int>();
        private List<double> main_coe = new List<double>();
        private Matrix matrix = new Matrix();

        public SystemEquations(String str)
        {
            str = clear(str);
            Parser(str, 0, "");
        }

        private void Parser(String str, int i, String temp)
        {
            if (i < str.Length)
                switch (str[i])
                {
                    case '-':
                        {
                            temp += str[i];
                            Parser(str, ++i, temp);
                        }
                        break;
                    #region 0-9
                    case '1':
                        {
                            temp += str[i];
                            Parser(str, ++i, temp);
                        }
                        break;
                    case '2':
                        {
                            temp += str[i];
                            Parser(str, ++i, temp);
                        }
                        break;
                    case '3':
                        {
                            temp += str[i];
                            Parser(str, ++i, temp);
                        }
                        break;
                    case '4':
                        {
                            temp += str[i];
                            Parser(str, ++i, temp);
                        }
                        break;
                    case '5':
                        {
                            temp += str[i];
                            Parser(str, ++i, temp);
                        }
                        break;
                    case '6':
                        {
                            temp += str[i];
                            Parser(str, ++i, temp);
                        }
                        break;
                    case '7':
                        {
                            temp += str[i];
                            Parser(str, ++i, temp);
                        }
                        break;
                    case '8':
                        {
                            temp += str[i];
                            Parser(str, ++i, temp);
                        }
                        break;
                    case '9':
                        {
                            temp += str[i];
                            Parser(str, ++i, temp);
                        }
                        break;
                    case '0':
                        {
                            temp += str[i];
                            Parser(str, ++i, temp);
                        }
                        break;
                    #endregion
                    case '.':
                        {
                            temp += str[i];
                            Parser(str, ++i, temp);
                        }
                        break;
                    case '+':
                        {
                            if (temp != "")
                            {
                                main_coe.Add(Convert.ToDouble(temp));
                                Parser(str, ++i, "");
                            }
                            else
                                Parser(str, ++i, "");
                        }
                        break;
                    case '*':
                        {
                            Parser(str, ++i, "");
                        }
                        break;
                    case '=':
                        {
                            if (temp != "")
                            {
                                main_coe.Add(Convert.ToDouble(temp));
                                Parser(str, ++i, "");
                            }
                            else
                                Parser(str, ++i, "");
                        }
                        break;
                    case ';':
                        {
                            if (temp != "")
                            {
                                main_coe.Add(Convert.ToDouble(temp));
                                if (i == str.Length - 1)
                                    break;
                                matrix.Inc();
                                Parser(str, ++i, "");
                            }
                            else
                            {
                                if (i == str.Length - 1)
                                    break;
                                matrix.Inc();
                                Parser(str, ++i, "");
                            }
                        }
                        break;
                    default:
                        {
                            matrix.Add(Convert.ToDouble(temp), str[i].ToString());
                            Parser(str, ++i, "");
                        }
                        break;
                }
        }

        private String clear(String str)
        {
            return str;
        }
    }
}
