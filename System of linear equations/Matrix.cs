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

        public Matrix()
        {
            mat_var = new String[26,26];
            mat_coe = new double[26,26];
        }

        public void Add(double t, String var)
        {
            if (IndexOf(var) > -1)
                mat_coe[gcount - 1, IndexOf(var)] += mat_coe[gcount - 1, IndexOf(var)] + t;
            else
            {
                vcount++;
                mat_var[gcount - 1, vcount - 1] = var;
                mat_coe[gcount - 1, vcount - 1] = t;
            }

        }

        public void Inc()
        {
            gcount++;
        }

        private int IndexOf(String str)
        {
            for (int j = 0; j < 26; j++)
            {
                if (mat_var[gcount-1,j] == str)
                    return j;
            }
            return -1;
        }
    }
}
