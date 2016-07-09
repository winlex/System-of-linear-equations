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

namespace System_of_linear_equations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SystemEquations SystemEquations;

        List<string> abc = new List<string> { "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z" };
        List<string> zn = new List<string> { "-","+" };
        List<string> history = new List<string>();
        List<ListBox> ans = new List<ListBox>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Generate()
        {
            Random rand = new Random();
            if (textBox1.Text != "")
            {
                int c = Convert.ToInt32(textBox1.Text);
                for (int i = 0; i < c; i++)
                {
                    for (int j = 0; j < c; j++)
                    {
                        textBox.Text += rand.Next(50);
                        textBox.Text += abc[j];
                        if (j != c - 1)
                            textBox.Text += zn[(i + j) % 2];
                    }
                    textBox.Text += "=" + rand.Next(50) + ";";
                    if (i != c - 1)
                        textBox.Text += "\r\n";
                }
            }
            else
                MessageBox.Show("Введите колчиество переменных!");
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            textBox.Text = "";
            if (Convert.ToInt32(textBox1.Text) <= 26 && Convert.ToInt32(textBox1.Text) > 0)
                Generate();
            else
                MessageBox.Show("Введите количество переменных от 1 до 26.");
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            if (listBox1.Items.IndexOf(textBox.Text) == -1)
                listBox1.Items.Add(textBox.Text);
            history.Add(textBox.Text);
            ans.Add(listBox);
            listBox.Items.Clear();
            SystemEquations = new SystemEquations(textBox.Text);
            foreach (string s in SystemEquations.var)
                listBox.Items.Add(s);
        }

        private void textBox1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            textBox.Text = "";
            textBox1.Text = "";
        }

        private void listBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            textBox.Text = history[listBox1.SelectedIndex];
            listBox = ans[listBox1.SelectedIndex];
        }
    }
}
