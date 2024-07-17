using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buoi2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = { 1, 3, 5, 7, 9, 11 };
            int key = 5;
            int n = A.Length;

            int result = Binary_Search(A, n, key);

            if (result != -1)
            {
                Console.WriteLine("Phan tu duoc tim thay: " + result);
            }
            else
            {
                Console.WriteLine("Khong tim thay phan tu nao.");
            }
            Console.ReadLine();
        }
        static int Binary_Search(int[] A, int n, int key)
        {
            int left = 0;       // Vị trí phần tử đầu tiên trong mảng
            int right = n - 1;  // Vị trí phần tử cuối cùng trong mảng

            while (left <= right)
            {
                int mid = (left + right) / 2; // Vị trí giữa mảng

                if (A[mid] == key)
                    return mid;  // Tìm thấy key tại vị trí mid
                if (key < A[mid])
                    right = mid - 1;  // Tìm ở nửa trái của mảng
                else
                    left = mid + 1;   // Tìm ở nửa phải của mảng
            }
            return -1; // Không tìm thấy key trong mảng nên trả về -1
        }
    }
}
