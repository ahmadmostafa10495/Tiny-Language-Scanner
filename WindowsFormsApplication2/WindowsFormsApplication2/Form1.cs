using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        static List<string> tokens = new List<string>();
        static List<string> tokensValue = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.ScrollBars = ScrollBars.Vertical;
            textBox2.ScrollBars = ScrollBars.Vertical;
            textBox1.Visible = false;
            textBox1.TextAlign = HorizontalAlignment.Center;
            button2.Visible = false;
            label3.Visible = false;
            textBox1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            label1.Visible = false;
            button2.Visible = true;
            label3.Visible = true;
            Tokenize(textBox2.Text);
            Scan();
            textBox1.Visible = true;
            textBox1.Font = new Font(textBox1.Font.FontFamily, 16);
            for (int i = 0; i < tokens.Count; i++)
            {
                
                textBox1.Text += tokens[i] + "     " + tokensValue[i] + "\r\n\r\n\r\n";
         

            }
        }
        static void Scan()
        {
            for (int i = 0; i < tokens.Count; i++)
            {
                if ((tokens[i][0] > 47 && tokens[i][0] < 58))
                {
                    tokensValue.Insert(i, "Number");
                }
                else if (((tokens[i][0] == '+')) || ((tokens[i][0] == '-')) || ((tokens[i][0] == '*')) ||
                    ((tokens[i][0] == '/')) || ((tokens[i][0] == '<')) || ((tokens[i][0] == '>')) ||
                    ((tokens[i][0] == '(')) || ((tokens[i][0] == ')')) || ((tokens[i][0] == ';')) ||
                    ((tokens[i][0] == '=')) || ((tokens[i][0] == ':')))
                {
                    if ((tokens[i][0] == '+'))
                        tokensValue.Insert(i, "Plus Sign");
                    else if ((tokens[i][0] == '-'))
                        tokensValue.Insert(i, "Minus Sign");
                    else if ((tokens[i][0] == '*'))
                        tokensValue.Insert(i, "Multiply Sign");
                    else if ((tokens[i][0] == '/'))
                        tokensValue.Insert(i, "Divide Sign");
                    else if ((tokens[i][0] == '<'))
                        tokensValue.Insert(i, "Smaller Than Sign");
                    else if ((tokens[i][0] == '>'))
                        tokensValue.Insert(i, "Greater Than Sign");
                    else if ((tokens[i][0] == '('))
                        tokensValue.Insert(i, "Left Bracket");
                    else if ((tokens[i][0] == ')'))
                        tokensValue.Insert(i, "Right Bracket");
                    else if ((tokens[i][0] == ';'))
                        tokensValue.Insert(i, "Simi Colon");
                    else if ((tokens[i][0] == '='))
                        tokensValue.Insert(i, "Is Eqaul Sign");
                    else if ((tokens[i][0] == ':'))
                        tokensValue.Insert(i, "Assign Sign");
                }
                else if ((tokens[i][0] == '{'))
                {
                    tokensValue.Insert(i, "Comment");
                }
                else if ((tokens[i] == "if") || (tokens[i] == "then") || (tokens[i] == "else") || (tokens[i] == "end") || (tokens[i] == "repeat") || (tokens[i] == "until") ||
                    (tokens[i] == "write") || (tokens[i] == "read"))
                {
                    tokensValue.Insert(i, "Reserved Word");
                }
                else if ((tokens[i][0] > 64 && tokens[i][0] < 91) || (tokens[i][0] > 96 && tokens[i][0] < 123))
                {
                    tokensValue.Insert(i, "Identifier");
                }
            }
        }
        static void Tokenize(string Code)
        {
            string temp = null;

            for (int i = 0; i < Code.Length; i++)
            {
                temp = null;
                if (Code[i] == ' ')
                    continue;
                if ((Code[i] > 47 && Code[i] < 58))
                {
                    while ((Code[i] > 47 && Code[i] < 58))
                    {
                        temp += Code[i];
                        i++;
                        if (i == Code.Length)
                        {
                            break;
                        }
                    }
                    tokens.Add(temp);
                    temp = null;
                    i--;
                    continue;



                }
                if ((Code[i] > 64 && Code[i] < 91) || (Code[i] > 96 && Code[i] < 123))
                {
                    while ((Code[i] > 64 && Code[i] < 91) || (Code[i] > 96 && Code[i] < 123))
                    {
                        temp += Code[i];
                        i++;
                        if (i == Code.Length)
                        {
                            break;
                        }
                    }
                    tokens.Add(temp);
                    temp = null;
                    i--;
                    continue;
                }
                if (Code[i] == ':')
                {
                    if (Code[i + 1] == '=')
                    {
                        i++;
                        temp += ":=";
                        tokens.Add(temp);
                        temp = null;
                        continue;
                    }

                    continue;
                }
                if ((Code[i] == '{'))
                {
                    while (true)
                    {
                        if (Code[i] == ' ')
                        {
                            i++;
                            continue;
                        }

                        temp += Code[i];

                        if ((Code[i] == '}'))
                        {
                            break;
                        }
                        i++;
                    }
                    tokens.Add(temp);
                    temp = null;
                    continue;
                }
                if ((Code[i] == '+') || (Code[i] == '-') || (Code[i] == '*') || (Code[i] == '/') || (Code[i] == '<') || (Code[i] == '>') || (Code[i] == '(') || (Code[i] == ')')
                    || (Code[i] == ';') || (Code[i] == '='))
                {
                    temp += Code[i];
                    tokens.Add(temp);
                    temp = null;
                    continue;
                }


            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Visible = false;
            textBox2.Text = "";
            tokens.Clear();
            tokensValue.Clear();
            button2.Visible = false;
            label3.Visible = false;
            button1.Visible = true;
            label1.Visible = true;


        }
    }
}

//" { Sample program in TINY language – computes factorial     }      read x;   {input an integer }      if  0 < x   then     {  don’t compute if x <= 0 }         fact  := 1;         repeat             fact  := fact *  x;             x  := x  -  1         until  x  =  0;         write  fact   {  output  factorial of x }      end"