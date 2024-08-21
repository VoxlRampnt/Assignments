using System;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using static System.Console;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

class Progam
{
    static List<int> globalList = new List<int>(1000000);//using a static list to be used by all other methods to print to

    //set list size to 1 million
    static void Main(string[] args)
    {
        Thread mainThread = Thread.CurrentThread;
        mainThread.Name = "Main Thread";
        WriteLine(mainThread.Name);
        //Thread thread1 = new Thread(PrimeCounter.CountPrimeUp);
        //Thread thread2 = new Thread(PrimeCounter.CountPrimeDown);
        //Thread thread3 = new Thread(CountEvenNum);
        //thread1.Start();
        //thread2.Start();
        //thread3.Start();

        PrimeCounter.CountPrimeUp();
        PrimeCounter.CountPrimeDown();
        CountEvenNum();

        ShowList.PrintList();
       
        //ShowList.ShowOdd();
        //ShowList.ShowEven();

        ReadKey();
        
        XmlSerializer x = new XmlSerializer(globalList.GetType());
        x.Serialize(Console.Out, globalList);
        WriteLine();
        ReadLine();
    }
    public class ShowList
    {
        
        public static void PrintList()
        {
            globalList.Sort();//sort list in ascending order
            foreach (int i in globalList)
            {
                WriteLine("List of Sorted Values");
                WriteLine(i);
            }

        }
        //public static void ShowEven()
        //{
        //    var even = globalList.Where(even => even % 2 == 0);

        //    WriteLine("Number of even : " + even);
        //}

        //public static void ShowOdd()
        //{
        //    var odd = globalList.Where(odd => odd % 2 != 0);
        //    WriteLine("Number of odd : " + odd);
        //}
    }
    
      
        public static void CountEvenNum()
    {
        for(int even = 1; even <= 333334; even++)
        {
            if(even % 2 == 0)
            {
                globalList.Add(even);
               
               WriteLine("Even : " + even);
               Thread.Sleep(10);
            }
        }
    }

    public class PrimeCounter
    {

        public static void CountPrimeUp()//Count Random Primes
        {
            //as long as the count is smaller than the given LARGE number the count will continue
            for (var i = 2; i <= 333333; i++)
            {
                bool isPrime = true;

                for (var j = 2; j < i; j++)
                {

                    if (i % j == 0)
                    {//if 0 break chain
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    globalList.Add(i);
                    WriteLine("Prime #1 : " + i);
                    Thread.Sleep(10);
                }
            }
        }

        public static void CountPrimeDown()//Count Primes Negatively
        {   //Calculates a prime number in negative state

            for (var iN = -2; iN >= -333333; iN--)//as long as i is less than set MINIMUM number the count down will continue
            {
                bool isPrimeN = true;

                for (var j = -2; j > iN; j--)
                {
                    if (iN % j == 0)
                    {//if 0 break chain
                        isPrimeN = false;
                        break;
                    }
                }
                if (isPrimeN)
                {
                    globalList.Add(iN);
                    WriteLine("Prime #2 : " + iN);
                    Thread.Sleep(1);
                }
            }
        }

    }
}