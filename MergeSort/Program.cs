using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap so phan tu cua mang: ");
            int n = int.Parse(Console.ReadLine());

            int[] A = new int[n];

            Console.WriteLine("Nhap cac phan tu cua mang:");
            for (int i = 0; i < n; i++)
            {
                Console.Write("Phan tu " + (i + 1) + ": ");
                A[i] = int.Parse(Console.ReadLine());
            }

            MergeSort(A, 0, n - 1);

            Console.WriteLine("Mang duoc sap xep:");
            for (int i = 0; i < n; i++)
            {
                Console.Write(A[i] + " ");
            }
            Console.ReadLine();
        }
        static void MergeSort(int[] A, int left, int right)
        {
            if (left < right)
            {
                int mid = (left + right) / 2; // Vị trí phần tử ở giữa dãy

                MergeSort(A, left, mid); // Gọi hàm MergeSort cho nửa dãy con đầu
                MergeSort(A, mid + 1, right); // Gọi hàm MergeSort cho nửa dãy con cuối

                Merge(A, left, mid, right); // Hàm trộn 2 dãy con có thứ tự thành dãy ban đầu có thứ tự
            }
        }

        static void Merge(int[] A, int left, int mid, int right)
        {
            int n1 = mid - left + 1; // Độ dài nửa dãy đầu của A
            int n2 = right - mid; // Độ dài nửa dãy sau của A

            int[] L = new int[n1];
            int[] R = new int[n2];

            for (int i = 0; i < n1; i++)
                L[i] = A[left + i]; // Chép nửa dãy đầu của A vào L
            for (int j = 0; j < n2; j++)
                R[j] = A[mid + 1 + j]; // Chép nửa dãy sau của A vào R

            int i1 = 0, j1 = 0, k = left;
            while (i1 < n1 && j1 < n2)
            {
                if (L[i1] <= R[j1])
                {
                    A[k] = L[i1];
                    i1++;
                }
                else
                {
                    A[k] = R[j1];
                    j1++;
                }
                k++;
            }

            while (i1 < n1)
            {
                A[k] = L[i1];
                i1++;
                k++;
            }

            while (j1 < n2)
            {
                A[k] = R[j1];
                j1++;
                k++;
            }
        }
    }
}
