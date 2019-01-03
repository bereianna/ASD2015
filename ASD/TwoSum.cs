﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ASD
{
    class TwoSum
    {
        public static int count(int[] arr)
        {
            int contor = 0;
            int n;
            n = arr.Length;
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                    if (arr[i] + arr[j] == 0)
                    {
                        contor++;
                    }
            return contor;
        }
        public static int countFast(int[] arr)
        {
            int contor = 0;
            int n;
            n = arr.Length;
            Array.Sort(arr);

            for (int i = 0; i < n; i++)
                if (BinarySearch.rank(-arr[i], arr) > i)
                    contor++;
            return contor;
        }
        public static int countFaster(int[] arr)
        {
            int contor = 0;
            int n;
            n = arr.Length;
            Array.Sort(arr);

            // trebuie scrisa o secventa liniara care determina cate perechi de numere din vectorul arr au suma 0
            // TODO
            int j = arr.Length - 1;
            i = 0;
            while(i<j)
            {
                if(arr[i]+arr[j]==0&&arr[i]<0&&arr[j]>0)
                {
                    contor++;
                    j--;
                    i++;
                }else
                {
                    if (arr[i] + arr[j] < 0 && arr[i] < 0 && arr[j] > 0)
                    {
                        i++;

                    }else
                    {
                        if (arr[i] + arr[j] > 0 && arr[i] < 0 && arr[j] > 0)
                        {
                            j--;
                        }
                        else
                        {
                            break; //no pair
                        }

                    }
                }
            }
            return contor;
        }
        public static void Main(string[] args)
        {

            Stopwatch sw = new Stopwatch();

            sw.Start();
            int[] arr = Util.readInts("1Kints.txt");
            Console.WriteLine(count(arr) + " triplete cu suma 0");
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            sw.Restart();
            arr = Util.readInts("2Kints.txt");
            Console.WriteLine(count(arr) + " triplete cu suma 0");
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            sw.Restart();
            arr = Util.readInts("4Kints.txt");
            Console.WriteLine(countFast(arr) + " triplete cu suma 0");
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            sw.Restart();
            arr = Util.readInts("8Kints.txt");
            Console.WriteLine(countFast(arr) + " triplete cu suma 0");
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }
    }
}
