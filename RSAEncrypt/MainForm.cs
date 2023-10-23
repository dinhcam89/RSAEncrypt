using System.CodeDom.Compiler;
using System.Numerics;
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

        public List<BigInteger> cipherText = new List<BigInteger>();
        static Dictionary<char, BigInteger> alphabetDictionary = new Dictionary<char, BigInteger>();

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

        //
        //  VALID CHECK FOR P, Q VALUE
        //
        private void tb_PrimeP_TextChanged(object sender, EventArgs e)
        {
            if (BigInteger.TryParse(tb_PrimeP.Text, out BigInteger bigInt))
            {
                //Check prime for "int" value
                if (bigInt < Int32.MaxValue)
                {
                    int smallInt = (int)bigInt;
                    if (IsPrime(smallInt))
                    {
                        lb_WarningP.ForeColor = System.Drawing.Color.Green;
                        lb_WarningP.Text = $"{bigInt} is a prime number!";
                    }
                    else
                    {
                        lb_WarningP.ForeColor = System.Drawing.Color.Red;
                        lb_WarningP.Text = $"{bigInt} is not a prime number.";
                    }
                }
                //Check prime for "BigInt" value
                else
                {
                    if (BigInt.Program.isPrime(bigInt))
                    {
                        lb_WarningP.ForeColor = System.Drawing.Color.Green;
                        lb_WarningP.Text = $"{bigInt} is a prime number!";
                    }
                    else
                    {
                        lb_WarningP.ForeColor = System.Drawing.Color.Red;
                        lb_WarningP.Text = $"{bigInt} is not a prime number.";
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
            if (BigInteger.TryParse(tb_PrimeQ.Text, out BigInteger bigInt))
            {
                //Check prime for "int" value
                if (bigInt < Int32.MaxValue)
                {
                    int smallInt = (int)bigInt;
                    if (IsPrime(smallInt))
                    {
                        lb_WarningQ.ForeColor = System.Drawing.Color.Green;
                        lb_WarningQ.Text = $"{bigInt} is a prime number!";
                    }
                    else
                    {
                        lb_WarningQ.ForeColor = System.Drawing.Color.Red;
                        lb_WarningQ.Text = $"{bigInt} is not a prime number.";
                    }
                }
                //Check prime for "BigInt" value
                else
                {
                    if (BigInt.Program.isPrime(bigInt))
                    {
                        lb_WarningQ.ForeColor = System.Drawing.Color.Green;
                        lb_WarningQ.Text = $"{bigInt} is a prime number!";
                    }
                    else
                    {
                        lb_WarningQ.ForeColor = System.Drawing.Color.Red;
                        lb_WarningQ.Text = $"{bigInt} is not a prime number.";
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
        //
        //

        //TESTING PURPOSE
        public static string RemoveSpecialCharacters(string str)
        {
            return Regex.Replace(str, "[^a-zA-Z0-9_.]+", "", RegexOptions.Compiled);
        }

        //
        //MAPPING STRING PARTS WITH CORRESPONDING INTERGER POSITION
        //
        static BigInteger ConvertToAlphabetIndex(string input)
        {
            char[] nonAlphabetCharacters = {
                ' ', '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',',
                '-', '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^',
                '_', '`', '{', '|', '}', '~'
            };

            Dictionary<char, BigInteger> characterIndexMap = new Dictionary<char, BigInteger>();

            int currentIndex = 52; // Start the index from 52

            foreach (char c in nonAlphabetCharacters)
            {
                characterIndexMap[c] = currentIndex;
                currentIndex++;
            }

            List<BigInteger> indicesList = new List<BigInteger>();
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
                    BigInteger index = characterIndexMap[c];
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
            alphabetDictionary = characterIndexMap;

            return result;
        }
        static string ConvertIndicesToOriginalString(List<BigInteger> indices)
        {
            char[] nonAlphabetCharacters = {
                ' ', '!', '"', '#', '$', '%', '&', '\'', '(', ')', '*', '+', ',',
                '-', '.', '/', ':', ';', '<', '=', '>', '?', '@', '[', '\\', ']', '^',
                '_', '`', '{', '|', '}', '~'
            };

            Dictionary<BigInteger, char> indexCharacterMap = new Dictionary<BigInteger, char>();

            BigInteger currentIndex = 52; // Start the index from 52

            foreach (char c in nonAlphabetCharacters)
            {
                indexCharacterMap[currentIndex] = c;
                currentIndex++;
            }

            string result = "";

            foreach (BigInteger index in indices)
            {
                string indexString = index.ToString();

                if (index < 1000)
                {
                    indexString = indexString.PadLeft(4, '0');
                }

                string part1 = indexString.Substring(0, 2);
                string part2 = indexString.Substring(2, 2);

                if (int.TryParse(part1, out int partIndex1) && int.TryParse(part2, out int partIndex2))
                {
                    char character1 = ' ';
                    char character2 = ' ';

                    // Check if the part indices are in the indexCharacterMap Dictionary map
                    if (indexCharacterMap.ContainsKey(partIndex1))
                    {
                        character1 = indexCharacterMap[partIndex1];
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
                        // EXCEPTION
                    }

                    if (indexCharacterMap.ContainsKey(partIndex2))
                    {
                        character2 = indexCharacterMap[partIndex2];
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
        static List<BigInteger> ConvertAndStoreIndexParts(string input, int partLength)
        {
            List<BigInteger> integerList = new List<BigInteger>();

            foreach (string part in SplitStringIntoParts(input, partLength))
            {
                integerList.Add(ConvertToAlphabetIndex(part));
            }
            return integerList;
        }

        private List<BigInteger> rsaEncrypt(List<BigInteger> intList)
        {
            List<BigInteger> encryptedInt = new List<BigInteger>();

            BigInteger eValue = BigInteger.Parse(tb_eValue.Text);
            BigInteger nValue = BigInteger.Parse(tb_nValue.Text);

            foreach (BigInteger intValue in intList)
            {
                BigInteger temp = BigInteger.ModPow(intValue, eValue, nValue);
                encryptedInt.Add(temp);
                cipherText.Add(temp);
            }

            return encryptedInt;
        }

        private void bt_Encrypt_Click(object sender, EventArgs e)
        {
            if (tb_PlainText.Text.Length % 2 == 1)
                tb_PlainText.Text += '\b';

            if (lb_WarningD.Text == "Invalid input. Please enter a valid integer." ||
                lb_WarningE.Text == "Invalid input. Please enter a valid integer." ||
                lb_WarningP.Text == "Invalid input. Please enter a valid integer." ||
                lb_WarningQ.Text == "Invalid input. Please enter a valid integer." ||
                lb_WarningD.Text == "" ||
                lb_WarningE.Text == "" ||
                lb_WarningP.Text == "" ||
                lb_WarningQ.Text == "")
            {
                MessageBox.Show("Invalid input. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string input = tb_PlainText.Text;
                List<BigInteger> indices;
                indices = ConvertAndStoreIndexParts(input, 2);

                List<BigInteger> encryptedCipherText = new List<BigInteger>();

                //int eValue = Int32.Parse(tb_eValue.Text.ToString());
                //int dValue = Int32.Parse(tb_dValue.Text.ToString());

                encryptedCipherText = rsaEncrypt(indices);
                foreach (int intValue in indices)
                {
                    foreach (BigInteger bigInt in encryptedCipherText)
                    {
                        tb_CipherText.AppendText(bigInt.ToString());
                        tb_CipherText.AppendText(" ");
                    }

                }
            }
        }

        private List<BigInteger> rsaDecrypt(List<BigInteger> intList)
        {
            List<BigInteger> encryptedInt = new List<BigInteger>();

            BigInteger dValue = BigInteger.Parse(tb_dValue.Text);
            BigInteger nValue = BigInteger.Parse(tb_nValue.Text);

            foreach (BigInteger intValue in intList)
            {
                BigInteger temp = BigInteger.ModPow(intValue, dValue, nValue);
                encryptedInt.Add(temp);
            }

            return encryptedInt;
        }

        private void bt_Decrypt_Click(object sender, EventArgs e)
        {
            List<BigInteger> decryptedCipherText = new List<BigInteger>();

            //int eValue = Int32.Parse(tb_eValue.Text.ToString());
            //int dValue = Int32.Parse(tb_dValue.Text.ToString());

            decryptedCipherText = rsaDecrypt(cipherText);
            //int eValue = Int32.Parse(tb_eValue.Text.ToString());
            //int dValue = Int32.Parse(tb_dValue.Text.ToString());

            string decryptedText = ConvertIndicesToOriginalString(decryptedCipherText);
            textBox1.Text = decryptedText;
        }

        private void bt_CalcN_Click(object sender, EventArgs e)
        {
            BigInteger pValue = BigInteger.Parse(tb_PrimeP.Text);
            BigInteger qValue = BigInteger.Parse(tb_PrimeQ.Text);

            BigInteger nValue = pValue * qValue;
            tb_nValue.Text = nValue.ToString();
        }

        private void bt_CalcU_Click(object sender, EventArgs e)
        {
            BigInteger pValue = BigInteger.Parse(tb_PrimeP.Text);
            BigInteger qValue = BigInteger.Parse(tb_PrimeQ.Text);

            //
            BigInteger uValue = (pValue - 1) * (qValue - 1);
            tb_uValue.Text = uValue.ToString();
        }

        //
        // GENERATE RANDOM P AND Q PRIME VALUE
        //
        private void bt_GenerateP_Click(object sender, EventArgs e)
        {
            BigInteger bigInt = BigInt.Program.GenerateRandomPrime(5);
            tb_PrimeP.Text = bigInt.ToString();
        }

        private void bt_GenerateQ_Click(object sender, EventArgs e)
        {
            BigInteger bigInt = BigInt.Program.GenerateRandomPrime(5);
            tb_PrimeQ.Text = bigInt.ToString();
        }

        //
        // GENERATE RANDOM PRIME E VALUE THAT E COPRIME WITH U(N) AND E SMALLER THAN U(N)
        //
        private void bt_GenerateE_Click(object sender, EventArgs e)
        {
            BigInteger eValue = new BigInteger();
            BigInteger uValue = BigInteger.Parse(tb_uValue.Text);
            do
            {
                eValue = BigInt.Program.GenerateRandomPrime(5);

            } while (eValue >= uValue);

            tb_eValue.Text = eValue.ToString();

        }

        private void tb_eValue_TextChanged(object sender, EventArgs e)
        {
            if (BigInteger.TryParse(tb_eValue.Text, out BigInteger bigE)
                && BigInteger.TryParse(tb_uValue.Text, out BigInteger bigU))
            {
                BigInteger eValue = BigInteger.Parse(tb_eValue.Text);
                BigInteger uValue = BigInteger.Parse(tb_uValue.Text);

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

        private void bt_CalcD_Click(object sender, EventArgs e)
        {
            if (BigInteger.TryParse(tb_eValue.Text, out BigInteger eValue))
            {
                BigInteger uValue = BigInteger.Parse(tb_uValue.Text);

                BigInteger dValue = BigInt.Program.ModularInverse(eValue, uValue);

                tb_dValue.Text = dValue.ToString();
            }
            else
            {
                MessageBox.Show("Missing input value. Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tb_dValue_TextChanged(object sender, EventArgs e)
        {

            if (BigInteger.TryParse(tb_eValue.Text, out BigInteger bigE)
                && BigInteger.TryParse(tb_uValue.Text, out BigInteger bigU)
                && BigInteger.TryParse(tb_dValue.Text, out BigInteger bigD))
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


    }
}

