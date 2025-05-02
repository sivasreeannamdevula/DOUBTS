using System;
using System.ComponentModel;
using System.Reflection.Metadata;
class Program2
{
   public static void Add(string s1,string s2)
   {
       if (s1.Length > s2.Length){
        string t = s1;
        s1 = s2;
        s2 = t;
      }
      string ans="";
       char[] ch1=s1.ToCharArray();
       char[] ch2=s2.ToCharArray();
       
       Array.Reverse(ch1);
       Array.Reverse(ch2);
       
       int carry=0;
       int sum=0;
       for(int i=0;i<s1.Length;i++)
       {
          sum=(ch1[i] - '0') + (ch2[i] - '0') + carry;
          carry=sum/10;
          sum=sum%10;
          ans+=(char)(sum + '0');
        
       }
        for(int i=s1.Length;i<s2.Length;i++)
        {
          sum=(ch2[i]-'0') + carry;
          carry=sum/10;
          sum=sum%10;
          ans+=(char)(sum + '0');
        }
       if(carry>0)
       {
        ans+=(char)(carry + '0');
       }
       char[] ans1=ans.ToCharArray();
       Array.Reverse(ans1);
       System.Console.WriteLine();
       System.Console.WriteLine();
       System.Console.WriteLine();
       foreach(char c in ans1)
       {
        System.Console.Write(c);
       }
   }
  
   public static void Main(string[] args)
   {
      string str1=Console.ReadLine();
      string str2=Console.ReadLine();
      Add(str1,str2);
   }

 }