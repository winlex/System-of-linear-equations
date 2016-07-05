using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_of_linear_equations
{
    class Matrix
    {
        private String[,] mat_var;
        private double[,] mat_coe;
        private int gcount = 1;
        private int vcount = 1;
        private double[,] matrix;

        private int x = 0 , y = 0;

        public int count
        {
            get
            {
                return vcount;
            }
        }
        public double[,] GetMatrix
        {
            get
            {
                return matrix;
            }
        }

        public Matrix()
        {
            mat_var = new String[26,26];
            mat_coe = new double[26,26];
        }

        public Matrix(double[,] mat, List<double> coe, int t)
        {
            vcount = Convert.ToInt32(Math.Sqrt(mat.Length));
            matrix = new double[vcount, vcount];

            for (int i = 0; i < vcount; i++)
                for (int j = 0; j < vcount; j++)
                {
                    matrix[i, j] = mat[i, j];
                }

            for (int i = 0; i < Math.Sqrt(mat.Length); i++)
            {
                matrix[i, t] = coe[i];
            }
        }

        public Matrix(double[,] mat, int t)
        {
            int c = Convert.ToInt32(Math.Sqrt(mat.Length));
            vcount = c - 1;
            matrix = new double[vcount, vcount];
            
            for (int i = 1; i < c; i++)
                for (int j = 0; j < c; j++)
                {
                    if (j != t)
                        Add(mat[i, j]);
                }
        }

        public void Add(double t, String var)
        {
            if (IndexOf(var) > -1)
                mat_coe[gcount - 1, IndexOf(var)] += mat_coe[gcount - 1, IndexOf(var)] + t;
            else
            {
                mat_var[gcount - 1, vcount - 1] = var;
                mat_coe[gcount - 1, vcount - 1] = t;
                vcount++;
            }

        }

        public void Add(double t)
        {
            matrix[y, x] = t;

            x++;
            if (x >= Math.Sqrt(matrix.Length))
            {
                x = 0;
                y++;
            }
        }

        public void Inc()
        {
            gcount++;
            vcount = 1;
        }

        public void Dic()
        {
            vcount--;
        }

        public double Det()
        {
            return Determinant();
        }

        public int IndexOf(String str)
        {
            for (int j = 0; j < 26; j++)
            {
                if (mat_var[gcount-1,j] == str)
                    return j;
            }
            return -1;
        }

        public void TakeMatrix()
        {
            matrix = new double[gcount, vcount];
            for (int i = 0; i < gcount; i++) 
                for (int j = 0; j < vcount; j++)
                {
                    matrix[i,j] = mat_coe[i, j];
                }
        }

        public double Determinant()
        {
            if (vcount == 2)
            {
                double c = matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }
            else
            {
                double result = 0;
                for (int i = 0; i < Convert.ToInt32(Math.Sqrt(matrix.Length)); i++)
                {
                    result += Math.Pow(-1,i) * matrix[0, i] * (new Matrix(matrix, i)).Det();
                }
                return result;
            }
        }
    }
}
