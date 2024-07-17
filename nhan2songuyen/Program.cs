using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nhan2songuyen
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap so nguyen thu nhat: ");
            string X = Console.ReadLine();

            Console.Write("Nhap so nguyen thu hai: ");
            string Y = Console.ReadLine();

            string result = BigNumberMulti(X, Y);
            Console.WriteLine("Ket qua: " + result);

            Console.ReadLine();
        }
        static string BigNumberMulti(string X, string Y)
        {
            int n = Math.Max(X.Length, Y.Length);

            //Pad với các số không đứng đầu để làm cho độ dài bằng nhau và đồng đều
            X = X.PadLeft(n, '0');
            Y = Y.PadLeft(n, '0');
            if (n % 2 != 0)
            {
                X = X.PadLeft(n + 1, '0');
                Y = Y.PadLeft(n + 1, '0');
                n += 1;
            }

            return BigNumberMultiHelper(X, Y, n);
        }

        static string BigNumberMultiHelper(string X, string Y, int n)
        {
            //Trường hợp cơ sở cho đệ quy
            if (n == 1)
            {
                return (int.Parse(X) * int.Parse(Y)).ToString();
            }

            //Tách X và Y
            int half = n / 2;
            string A = X.Substring(0, half);
            string B = X.Substring(half);
            string C = Y.Substring(0, half);
            string D = Y.Substring(half);

            //Gọi đệ quy
            string m1 = BigNumberMultiHelper(A, C, half);
            string m2 = BigNumberMultiHelper(Add(A, B), Add(C, D), half);
            string m3 = BigNumberMultiHelper(B, D, half);

            string term1 = m1 + new string('0', n);
            string term2 = Subtract(Subtract(m2, m1), m3) + new string('0', n / 2);

            return Add(Add(term1, term2), m3);
        }

        static string Add(string num1, string num2)
        {
            int carry = 0;
            int maxLength = Math.Max(num1.Length, num2.Length);
            num1 = num1.PadLeft(maxLength, '0');
            num2 = num2.PadLeft(maxLength, '0');
            char[] result = new char[maxLength];

            for (int i = maxLength - 1; i >= 0; i--)
            {
                int sum = (num1[i] - '0') + (num2[i] - '0') + carry;
                carry = sum / 10;
                result[i] = (char)((sum % 10) + '0');
            }

            string resultStr = new string(result);
            return carry > 0 ? carry + resultStr : resultStr;
        }

        static string Subtract(string num1, string num2)
        {
            int borrow = 0;
            int maxLength = Math.Max(num1.Length, num2.Length);
            num1 = num1.PadLeft(maxLength, '0');
            num2 = num2.PadLeft(maxLength, '0');
            char[] result = new char[maxLength];

            for (int i = maxLength - 1; i >= 0; i--)
            {
                int diff = (num1[i] - '0') - (num2[i] - '0') - borrow;
                if (diff < 0)
                {
                    diff += 10;
                    borrow = 1;
                }
                else
                {
                    borrow = 0;
                }
                result[i] = (char)(diff + '0');
            }

            return new string(result).TrimStart('0');
        }
    }
}
