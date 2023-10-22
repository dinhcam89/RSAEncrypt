using System.CodeDom.Compiler;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using LargeNumber;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace RSAEncrypt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Dictionary<int, char> alphabetDictionary = new Dictionary<int, char>();

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


        private void tb_PrimeQ_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(tb_PrimeQ.Text, out int number))
            {
                if (IsPrime(number))
                {
                    lb_WarningQ.ForeColor = System.Drawing.Color.Green;
                    lb_WarningQ.Text = $"{number} is a prime number!";
                }
                else
                {
                    lb_WarningQ.ForeColor = System.Drawing.Color.Red;
                    lb_WarningQ.Text = $"{number} is not a prime number.";
                }
            }
            else
            {
                lb_WarningQ.ForeColor = System.Drawing.Color.Red;
                lb_WarningQ.Text = "Invalid input. Please enter a valid integer.";
            }
        }

        private void tb_PrimeP_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(tb_PrimeP.Text, out int number))
            {
                if (IsPrime(number))
                {
                    lb_WarningQ.ForeColor = System.Drawing.Color.Green;
                    lb_WarningP.Text = $"{number} is a prime number!";
                }
                else
                {
                    lb_WarningQ.ForeColor = System.Drawing.Color.Red;
                    lb_WarningP.Text = $"{number} is not a prime number.";
                }
            }
            else
            {
                lb_WarningQ.ForeColor = System.Drawing.Color.Red;
                lb_WarningP.Text = "Invalid input. Please enter a valid integer.";
            }
        }

        //TESTING PURPOSE
        //private void test()
        //{
        //    // Fill the dictionary with alphabet characters and their indices
        //    for (int i = 0; i < 26; i++)
        //    {
        //        char letter = (char)('a' + i);
        //        alphabetDictionary[i] = letter;
        //    }

        //    //Upper characters
        //    for (int i = 26; i < 52; i++)
        //    {
        //        char uppercaseLetter = (char)('A' + (i - 26));
        //        alphabetDictionary[i] = uppercaseLetter;
        //    }
        //}
        public static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
        }

        //
        //MAPPING STRING PARTS INTO CORRESPONDING INTERGER POSITION
        //
        static int ConvertToAlphabetIndex(string input)
        {
            char[] nonAlphabetCharacters = {
            ' ', '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',',
            '-', '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^',
            '_', '`', '{', '|', '}', '~'
        };

            Dictionary<char, int> characterIndexMap = new Dictionary<char, int>();

            int currentIndex = 52; // Start the index from 52

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
                else
                {
                    // For characters not in the mapping, you can skip or store a suitable value
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

        static List<BigInteger> rsaEncrypt(List<int> intList)
        {
            List<BigInteger> encryptedInt = new List<BigInteger>();

            foreach (int intValue in intList)
            {
                BigInteger temp = BigInteger.ModPow(intValue, 11, 11023);
                encryptedInt.Add(temp);
            }

            return encryptedInt;
        }

        private void bt_Encrypt_Click(object sender, EventArgs e)
        {
            string input = "How_are_you";
            List<int> indices;
            indices = ConvertAndStoreIndexParts(input, 2);

            List<BigInteger> encryptedCipherText = new List<BigInteger>();

            //int eValue = Int32.Parse(tb_eValue.Text.ToString());
            //int dValue = Int32.Parse(tb_dValue.Text.ToString());

            encryptedCipherText = rsaEncrypt(indices);
            foreach (int intValue in indices)
            {
                tb_PlainText.AppendText(intValue.ToString());
                tb_PlainText.AppendText(" ");

                foreach (BigInteger bigInt in encryptedCipherText)
                {
                    tb_CipherText.AppendText(bigInt.ToString());
                    tb_CipherText.AppendText(" ");
                }

            }
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

        private void bt_GenerateP_Click(object sender, EventArgs e)
        {
            BigInt bigInt = new BigInt();
            bigInt.GenerateRandomNumber(3);

            BigInt bigInt2 = new BigInt();
            bigInt2.GenerateRandomNumber(3);

            BigInt bigInt3 = new BigInt();
            bigInt3 = bigInt.Pow(2);
            foreach (int intValue in bigInt3.elements)
            {
                tb_PrimeP.AppendText(intValue.ToString());
            }

            foreach(int qValue in bigInt.elements)
            {
                tb_PrimeQ.AppendText(qValue.ToString());
            }    
        }
        

    }  
}


