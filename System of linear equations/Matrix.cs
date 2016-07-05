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
            matrix = mat;

            for (int i = 0; i < Math.Sqrt(mat.Length); i++)
            {
                matrix[i, t] = coe[i];
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

        public void Inc()
        {
            gcount++;
            vcount = 1;
        }

        public void Dic()
        {
            vcount--;
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
    }
}
