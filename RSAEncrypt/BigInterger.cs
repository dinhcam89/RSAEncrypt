using System;
using System.Collections.Generic;

namespace LargeNumber
{
    class BigInt
    {
        public List<int> elements; // List to store individual elements of the large number

        public BigInt()
        {
            elements = new List<int>();
        }

        // Constructor to initialize the large number with a string
        public BigInt(string numberString)
        {
            elements = new List<int>();
            ParseFromString(numberString);
        }

        // Constructor to generate a random large number with a specified length
        public BigInt(int length)
        {
            elements = new List<int>();
            GenerateRandomNumber(length);
        }

        // Parse a string and store its digits in the list
        public void ParseFromString(string numberString)
        {
            elements.Clear(); // Clear the existing elements

            foreach (char digitChar in numberString)
            {
                if (char.IsDigit(digitChar))
                {
                    int digit = int.Parse(digitChar.ToString());
                    elements.Add(digit);
                }
            }
        }

        // Generate a random large number with the specified length
        public void GenerateRandomNumber(int length)
        {
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                int digit = random.Next(10); // Random digit between 0 and 9
                elements.Add(digit);
            }
        }

        // Convert the large number to a string
        public override string ToString()
        {
            return string.Join("", elements);
        }

        bool isGreaterOrEqual(BigInt a, BigInt b)
        {
            if (a.elements.Count != b.elements.Count)
            {
                return a.elements.Count > b.elements.Count;
            }
            for (int i = a.elements.Count - 1; i >= 0; --i)
            {
                if (a.elements[i] != b.elements[i])
                {
                    return a.elements[i] > b.elements[i];
                }
            }
            return true; // a và b bằng nhau
        }
        BigInt subtract(BigInt a, BigInt b)
        {
            BigInt result = new BigInt();
            int carry = 0;
            for (int i = 0; i < a.elements.Count; ++i)
            {
                int sub = a.elements[i] - carry - (i < b.elements.Count ? b.elements[i] : 0);
                if (sub < 0)
                {
                    sub += 10;
                    carry = 1;
                }
                else
                {
                    carry = 0;
                }
                result.elements.Add(sub);
            }
            while (result.elements.Count > 1 && result.elements[result.elements.Count - 1] == 0)
            {
                result.elements.RemoveAt(result.elements.Count - 1);
            }
            return result;
        }

        BigInt mod(BigInt num, BigInt a)
        {
            while (isGreaterOrEqual(num, a))
            {
                num = subtract(num, a);
            }
            return num;
        }
        private bool isZero(BigInt a)
        {
            foreach (int element in a.elements)
            {
                if (element == 0) return false;
            }
            return true;
        }
        bool lessThan(BigInt a, BigInt b)
        {
            if (a.elements.Count != b.elements.Count)
            {
                return a.elements.Count < b.elements.Count;
            }
            for (int i = a.elements.Count - 1; i >= 0; --i)
            {
                if (a.elements[i] != b.elements[i])
                {
                    return a.elements[i] < b.elements[i];
                }
            }
            return false; // a và b bằng nhau
        }
        BigInt gcd(BigInt a, BigInt b)
        {
            if (isZero(b)) return a;
            if (lessThan(a, b)) return gcd(b, a);

            return gcd(b, mod(a, b));
        }
        public BigInt Pow(int exponent)
        {
            if (exponent < 0)
            {
                throw new ArgumentException("Exponent must be non-negative.");
            }

            if (exponent == 0)
            {
                return new BigInt("1");
            }

            BigInt result = new BigInt(this.ToString());

            for (int i = 1; i < exponent; i++)
            {
                result = result.Multiply(this);
            }

            return result;
        }

        // Multiply the large number with another BigInt
        public BigInt Multiply(BigInt other)
        {
            // Implement multiplication logic here, e.g., long multiplication
            // You need to perform multiplication element by element and handle carry.
            // This depends on how you store and manipulate elements in your BigInt class.
            // This is a simplified example for illustration.
            BigInt product = new BigInt("0");

            for (int i = 0; i < elements.Count; i++)
            {
                BigInt term = new BigInt(other.ToString()); // Create a copy of the other number
                term.MultiplyByDigit(elements[i]); // Multiply the term by a single digit

                // Shift the term left by i positions (multiply by 10^i)
                for (int j = 0; j < i; j++)
                {
                    term.ShiftLeft(1); // This function should shift digits to the left
                }

                product = product.Add(term); // Add the term to the running product
            } 

            return product;
        }


        // Multiply the large number by a single digit
        public void MultiplyByDigit(int digit)
        {
            // Implement multiplication by a single digit here
            // This depends on how you store and manipulate elements in your BigInt class.
            // This is a simplified example for illustration.
            int carry = 0;

            for (int i = 0; i < elements.Count; i++)
            {
                int product = elements[i] * digit + carry;
                elements[i] = product % 10; // Store the result in the current element
                carry = product / 10; // Carry the remaining value
            }

            while (carry > 0)
            {
                elements.Add(carry % 10); // Add remaining digits as new elements
                carry /= 10;
            }
        }

        // Shift the large number to the left by a specified number of positions
        public void ShiftLeft(int positions)
        {
            // Implement left shift logic here
            // This depends on how you store and manipulate elements in your BigInt class.
            // This is a simplified example for illustration.
            for (int i = 0; i < positions; i++)
            {
                elements.Insert(0, 0); // Insert zeros at the beginning to shift left
            }
        }

        // Add another BigInt to this BigInt
        public BigInt Add(BigInt other)
        {
            // Implement addition logic here
            // This depends on how you store and manipulate elements in your BigInt class.
            // This is a simplified example for illustration.
            BigInt sum = new BigInt();
            int carry = 0;

            int maxLength = Math.Max(elements.Count, other.elements.Count);

            for (int i = 0; i < maxLength; i++)
            {
                int element1 = (i < elements.Count) ? elements[i] : 0;
                int element2 = (i < other.elements.Count) ? other.elements[i] : 0;

                int digitSum = element1 + element2 + carry;
                sum.elements.Add(digitSum % 10);
                carry = digitSum / 10;
            }

            while (carry > 0)
            {
                sum.elements.Add(carry % 10);
                carry /= 10;
            }

            return sum;
        }

    }
}