using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR2IvanovAGBBO0118Gammirovanie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int sizeOfChar = 8;
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true) sizeOfChar = 16;
            else { sizeOfChar = 8; }
            string result = "";
            string mainstr = textBox1.Text;
            string key = KeyToRightSize(mainstr.Length, textBox2.Text);
            MessageBox.Show(key);
            MessageBox.Show(mainstr.Length.ToString());
            for(int i=0; i<mainstr.Length; i++)
            {
                    result += FunctionPlus(StringToBinaryHalf(key[i], 0), StringToBinaryHalf(mainstr[i], 0));
                    result += FunctionPlus(StringToBinaryHalf(key[i], ((sizeOfChar / 2))), StringToBinaryHalf(mainstr[i], (sizeOfChar / 2)));
            }
            MessageBox.Show(result);
            textBox3.Text = BinaryToString(result);
        }
        private string FunctionPlus(string inputKey, string input)
        {
            //MessageBox.Show(inputKey + "||" + input);
            string result = "";
            {
                for(int i=0; i < input.Length; i++)
                {
                    if((inputKey[i] == '1' && input[i] == '1') || (inputKey[i] == '0' && input[i] == '0'))
                    {
                        result = result + "0" ;
                    } 
                    else
                    {
                        result = result + "1";
                    }
                }
            }
            //MessageBox.Show(result);
            return result;
        }
        private string StringToBinaryHalf(char input, int q)
        {
            string res_binary = Convert.ToString(input, 2);
            if (input == '_') res_binary = "0";
            while (res_binary.Length < sizeOfChar)
            {
                res_binary = "0" + res_binary; 
            }
            //res_binary = res_binary.Substring(q, (sizeOfChar / 2));
            return StringGetHalf(res_binary, q);
        }
        private string StringGetHalf (string input, int q)
        {
            input = input.Substring(q, (sizeOfChar / 2));
            return input;
        }
        private string BinaryToString (string input)
        {
            string output = "";
            while (input.Length > 0)
            {
                string char_binary = input.Substring(0, sizeOfChar);
                input = input.Remove(0, sizeOfChar);
                int a = 0;
                int degree = char_binary.Length - 1;
                foreach (char c in char_binary)
                    a += Convert.ToInt32(c.ToString()) * (int)Math.Pow(2, degree--);
                //output += ((char)a).ToString();
                MessageBox.Show(a.ToString());
                if(a==0) { a=95; } //???? ОШИБКА ВОЗНИКАЕТ В СЛУЧАЕ ЕСЛИ буква кодирования совпадает с исходной буквой
                output += ((char)a).ToString();
                MessageBox.Show(output);
            }
            return output;
        }
        private string KeyToRightSize(int length, string input)
        {
            int q = 0;
            while (q == 0)
            {
                if (input.Length >= length) 
                { 
                    input = input.Substring(0, length);
                    q = 1;
                }
                if (input.Length < length)
                {
                    input += input;
                }
            }
            return input;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox3.Text;
            textBox3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Realization of XORcipher encryption algorithm by IvanovA (2021)\nATTENTION!\nIt's advised NOT to use a symbol '_' as the password or input text to avoid collisions!\n\n- How to encrypt? \nFirst, you need to enter the text you want to encrypt in the top line. " +
                   "After that, select the key for encryption and press the 'Encrypt' button. You will get the encrypted text in the bottom line. If you need to use more keys, you can Move the encrypted text by pressing the relevant button and encrypt text again." +
                   "\nP.S. You can also choose encoding type (Unicode or ASCII)." +
                   "\n\n- How to Decrypt?" +
                   "\nSimilar to the encryption method. Enter the encrypted text in the top line, necessary key in the middle line and click the 'Encrypt' button. " +
                   "Order of entering keys, if there were several of them, is not important. You will get the decrypted text in the bottom line.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
