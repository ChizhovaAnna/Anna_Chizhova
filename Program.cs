using System;

using System.Collections;
using System.Collections.Generic;


namespace basic
{
    class Program
    {


        public static List<int> GetIntegersFromList(List<object> list)
        {
            List<int> new_list = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] is int)
                {
                    new_list.Add((int)list[i]);
                }
            }
            return new_list;
        }

        public static string first_non_repeating_letter (string text)
        {
            string symbol = "";
            string lower = text.ToLower();

            for (int i = 0; i < lower.Length; i++)
            {
                if (lower.IndexOf(lower[i]) == lower.LastIndexOf(lower[i]))
                {
                     symbol = text[i].ToString();
                    break;
                }
            }
             return symbol;
        }

        public static int digital_root (int numb)
        {
            int count=100;
            while (count >=10)
            {
                count = 0;
                while (numb > 0)
                {
                    
                    if (numb < 10)
                    {
                        count += numb;
                        break;
                    }
                    count += numb % 10;
                    numb = numb / 10;
                    
                }
                numb = count;
            }
            
            return count;

        }

        public static int func_4 (int[] massive, int target)
        {
            int pairs = 0;
            for (int i=0; i<massive.Length; i++)
            {
                for (int j=i+1; j<massive.Length; j++)
                {
                    if (massive[i] + massive[j] == target)
                    {
                        pairs += 1;
                    }
                }
            }
            return pairs;

        }

        public static string meeting (string s)
        {
            
            string[] arr = s.Split(';');
            string[] result = new string[(arr.Length)];
            string name;
            string surname;
            string res="";
            for (int i = 0; i < arr.Length; i++)
            {
                surname = arr[i].Substring(arr[i].IndexOf(':') + 1);
                name = arr[i].Substring(0, arr[i].IndexOf(':'));
                result[i] = "(" + surname + "," + name + ")";
            }
            Array.Sort(result);
            for (int i = 0; i < arr.Length; i++)
                res += result[i];
            return res;
        }




        static void Main(string[] args)
        {
            List<object> list1 = new List<object>() { { "123" }, { "ann" }, { 9 }, { "hsis7" }, { 7783 } };
            List<int> numbers1 = new List<int>(){ 9, 7783 };
            string is_equal1="";
            List<int> numberss1 = GetIntegersFromList(list1);
            for (int i=0; i<numbers1.Count; i++)
            {
                if (numbers1[i]!=numberss1[i])
                {
                    is_equal1="False";
                    break;
                }
                is_equal1 = "True";
            }

            Console.WriteLine("1.1 "+ is_equal1);
            List<object> list2 = new List<object>() { { "Ok" }, { 81}, { 13}, { "ola" }, { "rock" } };
            List<int> numbers2 = new List<int>() { 81, 13 };
            string is_equal2 = "";
            List<int> numberss2 = GetIntegersFromList(list2);
            for (int i = 0; i < numbers2.Count; i++)
            {
                if (numbers2[i] != numberss2[i])
                {
                    is_equal2 = "False";
                    break;
                }
                is_equal2 = "True";
            }
            Console.WriteLine("1.2 "+ is_equal2);

            //unit test 2
            Console.WriteLine("2.1 "+  (first_non_repeating_letter("hahayo") == "y"));
            Console.WriteLine("2.2 "+ (first_non_repeating_letter("WhatIsTHatWow") == "I"));
            //unit test 3
            Console.WriteLine("3.1 "+ (digital_root(682)==7));
            Console.WriteLine("3.2 "+ (digital_root(1214) == 8));
            //unit test 4
            int[] mas1 ={1, 2, 5, 6, 3, 4};
            int[] mas2 = {2, 4, 6, 7, 3, 0, 4, 1};
            Console.WriteLine("4.1 "+ (func_4(mas1, 5)==2));
            Console.WriteLine("4.2 "+ (func_4(mas2, 6) == 3));
            //unit test 5 
            Console.WriteLine("5.1 "+ (meeting("Fired:Corwill;Wilfred:Corwill;Barney:TornBull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill")
                == "(Corwill,Alfred)(Corwill,Fired)(Corwill,Raphael)(Corwill,Wilfred)(TornBull,Barney)(Tornbull,Betty)(Tornbull,Bjon)"));
            Console.WriteLine("5.2 "+ (meeting("Anna:Chizhova;Dmytro:Radchenko;Artem:Pyshniuk;Adam:Kotler;Nickita:Chizhova")
                == "(Chizhova,Anna)(Chizhova,Nickita)(Kotler,Adam)(Pyshniuk,Artem)(Radchenko,Dmytro)"));

        }
    }
}



