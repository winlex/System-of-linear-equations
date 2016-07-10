using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_of_linear_equations
{
    class SystemEquations
    {
        public List<String> var = new List<String>();
        private List<double> main_coe = new List<double>();
        private Matrix matrix = new Matrix();
        List<Matrix> submatrix = new List<Matrix>();

        public SystemEquations(String str)
        {
            str = clear(str);
            Parser(str, 0, "");
            matrix.Dic();
            matrix.TakeMatrix();
            if (matrix.Det() == 0)
                var[0] = "Решений нет/множество";
            else
            {
                for (int i = 0; i < var.Count; i++)
                    submatrix.Add(new Matrix(matrix.GetMatrix, main_coe, matrix.IndexOf(var[i])));
                for (int i = 0; i < var.Count; i++)
                    var[i] += " = " + Math.Round(submatrix[i].Det() / matrix.Det(), 2);
            }
        }

        private void Parser(String str, int i, String temp)
        {
            if (i < str.Length)
                switch (str[i])
                {
                    case ' ':
                        {
                            Parser(str, ++i, temp);
                        }
                        break;
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
                    case ',':
                        {
                            temp += str[i];
                            Parser(str, ++i, temp);
                        }
                        break;
                    case '.':
                        {
                            temp += ',';
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
                            if (temp != "")
                            {
                                if (temp == "-")
                                {
                                    matrix.Add(-1, str[i].ToString());
                                    if (var.IndexOf(str[i].ToString()) == -1)
                                        var.Add(str[i].ToString());
                                    Parser(str, ++i, "");
                                }
                                else
                                {
                                    matrix.Add(Convert.ToDouble(temp), str[i].ToString());
                                    if (var.IndexOf(str[i].ToString()) == -1)
                                        var.Add(str[i].ToString());
                                    Parser(str, ++i, "");
                                }
                            }
                            else
                            {
                                matrix.Add(1, str[i].ToString());
                                if (var.IndexOf(str[i].ToString()) == -1)
                                    var.Add(str[i].ToString());
                                Parser(str, ++i, "");
                            }
                        }
                        break;
                }
        }

        private String clear(String str)
        {
            while (str.IndexOf("\r\n") > -1)
                str = str.Remove(str.IndexOf("\r\n"), 2);
            return str;
        }
    }
}
