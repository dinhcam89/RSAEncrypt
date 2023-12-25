using System;
using System.CodeDom.Compiler;
using System.Numerics;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using BigInt;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace RSAEncrypt
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        Random random = new Random();
        public List<int> cipherTextList = new List<int>();

        static bool IsPrime(int number)
        {
            if (number <= 1)
                return false;
            if (number <= 3)
                return true;

            if (number % 2 == 0 || number % 3 == 0)
                return false;

            for (int i = 5; i * i <= number; i += 6)
            {
                if (number % i == 0 || number % (i + 2) == 0)
                    return false;
            }

            return true;
        }

        static int GetRandomPrimeNumber(Random random)
        {
            int randomNum;

            do
            {
                // Tạo một số ngẫu nhiên
                randomNum = random.Next(20, 200); // Thay đổi khoảng số ngẫu nhiên tùy ý

            } while (!IsPrime(randomNum)); // Lặp lại cho đến khi số ngẫu nhiên là số nguyên tố

            return randomNum;
        }

        //
        //  VALID CHECK FOR P, Q VALUE
        //
        private void tb_PrimeP_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(tb_PrimeP.Text, out int bigInt))
            {
                //Check prime for "int" value
                if (bigInt < Int32.MaxValue)
                {
                    int smallInt = (int)bigInt;
                    if (IsPrime(smallInt))
                    {
                        lb_WarningP.ForeColor = System.Drawing.Color.Green;
                        lb_WarningP.Text = "Valid Input!";
                    }
                    else
                    {
                        lb_WarningP.ForeColor = System.Drawing.Color.Red;
                        lb_WarningP.Text = "Invalid input. Please enter a valid integer.";
                    }
                }
                //Check prime for "BigInt" value
                else
                {
                    if (BigInt.Program.isPrime(bigInt))
                    {
                        lb_WarningP.ForeColor = System.Drawing.Color.Green;
                        lb_WarningP.Text = "Valid Input!";
                    }
                    else
                    {
                        lb_WarningP.ForeColor = System.Drawing.Color.Red;
                        lb_WarningP.Text = "Invalid input. Please enter a valid integer.";
                    }
                }
            }
            else
            {
                lb_WarningP.ForeColor = System.Drawing.Color.Red;
                lb_WarningP.Text = "Invalid input. Please enter a valid integer.";
            }
        }

        private void tb_PrimeQ_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(tb_PrimeQ.Text, out int bigInt))
            {
                //Check prime for "int" value
                if (bigInt < Int32.MaxValue)
                {
                    int smallInt = (int)bigInt;
                    if (IsPrime(smallInt))
                    {
                        lb_WarningQ.ForeColor = System.Drawing.Color.Green;
                        lb_WarningQ.Text = "Valid Input!";
                    }
                    else
                    {
                        lb_WarningQ.ForeColor = System.Drawing.Color.Red;
                        lb_WarningQ.Text = "Invalid input. Please enter a valid integer.";
                    }
                }
            }
            else
            {
                lb_WarningQ.ForeColor = System.Drawing.Color.Red;
                lb_WarningQ.Text = "Invalid input. Please enter a valid integer.";
            }
        }

        //
        //MAPPING STRING PARTS WITH CORRESPONDING INTERGER POSITION
        //
        static int ConvertToAlphabetIndex(string input)
        {
            char[] nonAlphabetCharacters = {
                ' ', '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',',
                '-', '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^',
                '_', '`', '{', '|', '}', '~'
            };

            char[] numberCharacters = {
                '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'
            };


            Dictionary<char, int> characterIndexMap = new Dictionary<char, int>();
            Dictionary<char, int> characterIndexMap2 = new Dictionary<char, int>();

            int currentIndex2 = 85;
            foreach (char c in numberCharacters)
            {
                characterIndexMap2[c] = currentIndex2;
                currentIndex2++;
            }


            int currentIndex = 52; // Start the index from 52 for non alphabet index

            foreach (char c in nonAlphabetCharacters)
            {
                characterIndexMap[c] = currentIndex;
                currentIndex++;
            }


            List<int> indicesList = new List<int>();
            for (int i = 0; i < input.Length; i++)
            {
                char c = input[i];

                if (char.IsLetter(c))
                {
                    if (char.IsLower(c))
                    {
                        int index = c - 'a';
                        indicesList.Add(index);
                    }
                    else
                    {
                        int index = c - 'A' + 26;
                        indicesList.Add(index);
                    }
                }
                else if (characterIndexMap.ContainsKey(c))
                {
                    int index = characterIndexMap[c];
                    indicesList.Add(index);
                }
                else if (characterIndexMap2.ContainsKey(c))
                {
                    int index = characterIndexMap2[c];
                    indicesList.Add(index);
                }
                else
                {
                    // For characters not in the mapping, you can skip or store a suitable value
                    indicesList.Add(c);

                }
            }

            int result = 0;

            foreach (int value in indicesList)
            {
                // Adjust the combination logic as needed
                result = result * 100 + value; // Assumes each integer is a two-digit number
            }

            return result;
        }

        static string ConvertIndicesToOriginalString(List<int> indices)
        {
            char[] nonAlphabetCharacters = {
                ' ', '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',',
                '-', '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^',
                '_', '`', '{', '|', '}', '~'
            };
            char[] numberCharacters = {
                '1', '2', '3', '4', '5', '6', '7', '8', '9', '0'
            };
            Dictionary<int, char> indexCharacterMap = new Dictionary<int, char>();
            Dictionary<int, char> indexCharacterMap2 = new Dictionary<int, char>();

            int currentIndex = 52; // Start the index from 52
            int currentIndex2 = 85;
            foreach (char c in numberCharacters)
            {
                indexCharacterMap2[currentIndex2] = c;
                currentIndex2++;
            }
            foreach (char c in nonAlphabetCharacters)
            {
                indexCharacterMap[currentIndex] = c;
                currentIndex++;
            }

            string result = "";

            foreach (int index in indices)
            {
                string indexString = index.ToString();

                if (index < 1000)
                {
                    indexString = indexString.PadLeft(4, '0');
                }

                string part1 = indexString.Substring(0, 2);
                string part2 = indexString.Substring(2, 2);

                if (Int32.TryParse(part1, out int partIndex1) && Int32.TryParse(part2, out int partIndex2))
                {
                    char character1 = ' ';
                    char character2 = ' ';

                    if (indexCharacterMap.ContainsKey(partIndex1))
                    {
                        character1 = indexCharacterMap[partIndex1];
                    }
                    else if (indexCharacterMap2.ContainsKey(partIndex1))
                    {
                        character1 = indexCharacterMap2[partIndex1];
                    }
                    else if (partIndex1 >= 0 && partIndex1 < 26)
                    {
                        character1 = (char)('a' + partIndex1);
                    }
                    else if (partIndex1 >= 26 && partIndex1 < 52)
                    {
                        character1 = (char)('A' + partIndex1 - 26);
                    }
                    else
                    {

                    }

                    if (indexCharacterMap.ContainsKey(partIndex2))
                    {
                        character2 = indexCharacterMap[partIndex2];
                    }
                    else if (indexCharacterMap2.ContainsKey(partIndex2))
                    {
                        character2 = indexCharacterMap2[partIndex2];
                    }
                    else if (partIndex2 >= 0 && partIndex2 < 26)
                    {
                        character2 = (char)('a' + partIndex2);
                    }
                    else if (partIndex2 >= 26 && partIndex2 < 52)
                    {
                        character2 = (char)('A' + partIndex2 - 26);
                    }
                    else
                    {
                        // EXCEPTION
                    }

                    result += character1.ToString() + character2.ToString();
                }
            }

            return result;
        }


        //
        //SPLIT PLAIN TEXT STRING INTO PART CONTAINS 2 CHARS
        //
        static IEnumerable<string> SplitStringIntoParts(string input, int partLength)
        {
            for (int i = 0; i < input.Length; i += partLength)
            {
                if (i + partLength <= input.Length)
                {
                    yield return input.Substring(i, partLength);
                }
                else
                {
                    yield return input.Substring(i);
                }
            }
        }

        //
        //CONVERT STRING AND STORE MAPPING VALUE TO LIST
        //
        static List<int> ConvertAndStoreIndexParts(string input, int partLength)
        {
            List<int> integerList = new List<int>();

            foreach (string part in SplitStringIntoParts(input, partLength))
            {
                integerList.Add(ConvertToAlphabetIndex(part));
            }
            return integerList;
        }
        //
        // MOD POW FUNCTION FOR ENCRYPT
        //
        static int ModPow(int baseNumber, int exponent, int modulus)
        {
            if (modulus == 1)
                return 0;

            int result = 1;
            baseNumber = baseNumber % modulus;

            while (exponent > 0)
            {
                // Nếu exponent là số lẻ, nhân kết quả với baseNumber
                if (exponent % 2 == 1)
                    result = (result * baseNumber) % modulus;

                // exponent chia đôi, baseNumber bình phương
                exponent >>= 1;
                baseNumber = (baseNumber * baseNumber) % modulus;
            }

            return result;
        }

        private List<int> rsaEncrypt(List<int> intList)
        {
            List<int> encryptedInt = new List<int>();

            int eValue = Int32.Parse(tb_eValue.Text);
            int nValue = Int32.Parse(tb_nValue.Text);

            foreach (int intValue in intList)
            {
                int temp = ModPow(intValue, eValue, nValue);
                encryptedInt.Add(temp);
                cipherTextList.Add(temp);
            }

            return encryptedInt;
        }

        private void bt_Encrypt_Click(object sender, EventArgs e)
        {
            if (tb_PlainText.Text.Length % 2 == 1)
                tb_PlainText.Text += ' ';

            if (lb_WarningD.Text == "Invalid input. Please enter a valid integer." ||
                lb_WarningE.Text == "Invalid input. Please enter a valid integer." ||
                lb_WarningP.Text == "Invalid input. Please enter a valid integer." ||
                lb_WarningQ.Text == "Invalid input. Please enter a valid integer." ||
                lb_WarningD.Text == "" || lb_WarningE.Text == "" || lb_WarningP.Text == "" ||
                lb_WarningQ.Text == "" || tb_PlainText.Text == "")
            {
                MessageBox.Show("Invalid input. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string input = tb_PlainText.Text;
                List<int> indices;
                indices = ConvertAndStoreIndexParts(input, 2);

                List<int> encryptedCipherText = new List<int>();

                //int eValue = Int32.Parse(tb_eValue.Text.ToString());
                //int dValue = Int32.Parse(tb_dValue.Text.ToString());

                encryptedCipherText = rsaEncrypt(indices);

                foreach (int indice in encryptedCipherText)
                {
                    tb_CipherText.AppendText(indice.ToString());
                }
            }
        }

        private List<int> rsaDecrypt(List<int> intList)
        {
            List<int> decryptedInt = new List<int>();

            int dValue = Int32.Parse(tb_dValue.Text);
            int nValue = Int32.Parse(tb_nValue.Text);

            foreach (int intValue in intList)
            {
                int temp = ModPow(intValue, dValue, nValue);
                decryptedInt.Add(temp);
            }

            return decryptedInt;
        }

        private void bt_Decrypt_Click(object sender, EventArgs e)
        {
            List<int> decryptedCipherText = new List<int>();

            //int eValue = Int32.Parse(tb_eValue.Text.ToString());
            //int dValue = Int32.Parse(tb_dValue.Text.ToString());
            string cipherText = tb_CipherText.Text;
            //decryptedCipherText = rsaDecrypt(cipherText);
            //int eValue = Int32.Parse(tb_eValue.Text.ToString());
            //int dValue = Int32.Parse(tb_dValue.Text.ToString());

            string decryptedText = ConvertIndicesToOriginalString(rsaDecrypt(cipherTextList));
            tb_DecryptedText.AppendText(decryptedText);
            cipherTextList.Clear();
        }

        private void bt_CalcN_Click(object sender, EventArgs e)
        {
            int pValue = Int32.Parse(tb_PrimeP.Text);
            int qValue = Int32.Parse(tb_PrimeQ.Text);

            int nValue = pValue * qValue;
            tb_nValue.Text = nValue.ToString();
        }

        private void bt_CalcU_Click(object sender, EventArgs e)
        {
            int pValue = Int32.Parse(tb_PrimeP.Text);
            int qValue = Int32.Parse(tb_PrimeQ.Text);

            //
            int uValue = (pValue - 1) * (qValue - 1);
            tb_uValue.Text = uValue.ToString();
        }

        //
        // GENERATE RANDOM P AND Q PRIME VALUE
        //
        private void bt_GenerateP_Click(object sender, EventArgs e)
        {
            int pValue = GetRandomPrimeNumber(random);
            tb_PrimeP.Text = pValue.ToString();
        }

        private void bt_GenerateQ_Click(object sender, EventArgs e)
        {
            int qValue = GetRandomPrimeNumber(random);
            tb_PrimeQ.Text = qValue.ToString();
        }

        //
        // GENERATE RANDOM PRIME E VALUE THAT E COPRIME WITH U(N) AND E SMALLER THAN U(N)
        //
        private void bt_GenerateE_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(tb_uValue.Text, out int uValue))
            {
                int eValue;
                do
                {
                    eValue = GetRandomPrimeNumber(random);

                } while (eValue >= uValue);

                tb_eValue.Text = eValue.ToString();
            }
            else
            {
                MessageBox.Show("Missing input value. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tb_eValue_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(tb_eValue.Text, out int bigE)
                && Int32.TryParse(tb_uValue.Text, out int bigU))
            {
                int eValue = Int32.Parse(tb_eValue.Text);
                int uValue = Int32.Parse(tb_uValue.Text);

                if (BigInt.Program.GCD(eValue, uValue) == 1)
                {

                    lb_WarningE.ForeColor = System.Drawing.Color.Green;
                    lb_WarningE.Text = "Valid e Value!";
                }
                else if (eValue < uValue)
                {
                    lb_WarningE.ForeColor = System.Drawing.Color.Red;
                    lb_WarningE.Text = "Invalid e Value!";
                }
            }
            else
            {
                lb_WarningE.ForeColor = System.Drawing.Color.Red;
                lb_WarningE.Text = "Invalid e Value!";
            }
        }

        public static int ModularInverse(int e, int u)
        {
            int x = 0, y = 0;
            int r = ExtendedGCD(e, u, ref x, ref y);

            if (r == 1)
            {
                x = (x % u + u) % u; // Make sure x is positive
                return x;
            }
            return -1; // Modular inverse doesn't exist
        }

        static int ExtendedGCD(int a, int b, ref int x, ref int y)
        {
            x = 1;
            y = 0;

            if (b == 0)
                return a;

            int new_x = 0;
            int new_y = 1;
            int new_r = b;
            int r = a;
            int quotient, tmp;

            while (new_r != 0)
            {
                quotient = r / new_r;

                tmp = r;
                r = new_r;
                new_r = tmp - quotient * new_r;

                tmp = x;
                x = new_x;
                new_x = tmp - quotient * new_x;

                tmp = y;
                y = new_y;
                new_y = tmp - quotient * new_y;
            }

            return r;
        }
        private void bt_CalcD_Click(object sender, EventArgs e)
        {
            if (Int32.TryParse(tb_eValue.Text, out int eValue))
            {
                int uValue = Int32.Parse(tb_uValue.Text);

                int dValue = ModularInverse(eValue, uValue);

                tb_dValue.Text = dValue.ToString();
            }
            else
            {
                MessageBox.Show("Missing input value. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tb_dValue_TextChanged(object sender, EventArgs e)
        {

            if (Int32.TryParse(tb_eValue.Text, out int bigE)
                && Int32.TryParse(tb_uValue.Text, out int bigU)
                && Int32.TryParse(tb_dValue.Text, out int bigD))
            {

                if (BigInt.Program.GCD(bigE * bigD, bigU) == 1)
                {

                    lb_WarningD.ForeColor = System.Drawing.Color.Green;
                    lb_WarningD.Text = "Valid d Value!";
                }
                else
                {
                    lb_WarningD.ForeColor = System.Drawing.Color.Red;
                    lb_WarningD.Text = "Invalid d Value!";
                }
            }
            else
            {
                lb_WarningD.ForeColor = System.Drawing.Color.Red;
                lb_WarningD.Text = "Invalid d Value!";
            }
        }

        private void bt_Clear_Click(object sender, EventArgs e)
        {
            tb_PrimeP.Clear();
            tb_PrimeQ.Clear();
            tb_eValue.Clear();
            tb_nValue.Clear();
            tb_uValue.Clear();
            tb_dValue.Clear();
            tb_PlainText.Clear();
            tb_CipherText.Clear();
            tb_DecryptedText.Clear();
            cipherTextList.Clear();
        }
    }




    //
    //          PLAYFAIR ENCRYPT HANDLING
    //
}

