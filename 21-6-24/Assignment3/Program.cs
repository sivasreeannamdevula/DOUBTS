// using System;
// using System.Reflection.Emit;

// class Program
// {
//    public static string Add(string s1,string s2,int carry)
//    {
//        if (s1.Length > s2.Length){
//         string t = s1;
//         s1 = s2;
//         s2 = t;
//       }
//       string ans="";
//        char[] ch1=s1.ToCharArray();
//        char[] ch2=s2.ToCharArray();
       
//        Array.Reverse(ch1);
//        Array.Reverse(ch2);
       
       
//        int sum=0;
//        for(int i=0;i<s1.Length;i++)
//        {
//           sum=(ch1[i] - '0') + (ch2[i] - '0') + carry;
//           carry=sum/10;
//           sum=sum%10;
//           ans+=(char)(sum + '0');
        
//        }
//         for(int i=s1.Length;i<s2.Length;i++)
//         {
//           sum=(ch2[i]-'0') + carry;
//           carry=sum/10;
//           sum=sum%10;
//           ans+=(char)(sum + '0');
//         }
//        if(carry>0)
//        {
//         ans+=(char)(carry + '0');
//        }
//        char[] ans1=ans.ToCharArray();
//        Array.Reverse(ans1);
       
//       //  foreach(char c in ans1)
//       //  {
//       //   System.Console.Write(c);
//       //  }
//        string s=new string(ans1);
//        return s;
//    }
//    public static string ToBinary(string s)
//    {
//       string ans="";
//       int i=Convert.ToInt32(s);
      
//       while(i>0)
//       {
//          int n=i%2;
//          ans=ans + Convert.ToString(n);
//          i=i/2; 
//       }
      
//      return ans;
//    }
   
//    public static void Main(string[] args)
//    {
//      double s1=Convert.ToDouble(Console.ReadLine());
//      double s2=Convert.ToDouble(Console.ReadLine());
//      string str1=s1.ToString();
//       string str2=s2.ToString(); 
//       string[] parts=str1.Split('.');
//       string str11=parts[0];
//       string str12=parts[1];
//       string[] part=str2.Split('.');
//       string str21=part[0];
//       string str22=part[1];
//       System.Console.WriteLine(str11 + " " + str12 + " " + str21 + " " + str22);
//       string bstr11=ToBinary(str11);
//       string bstr12=ToBinary(str12);
//       string bstr21=ToBinary(str21);
//       string bstr22=ToBinary(str22);
//       System.Console.WriteLine(bstr11 + " " + bstr12 + " " + bstr21 + " " + bstr22);
//       string rbstr11=new string(bstr11.Reverse().ToArray());
//       string rbstr12=new string(bstr12.Reverse().ToArray());
//       string rbstr21=new string(bstr21.Reverse().ToArray());
//       string rbstr22=new string(bstr22.Reverse().ToArray());
//       System.Console.WriteLine(rbstr11 + " " + rbstr12 + " " + rbstr21 + " " + rbstr22);
//       if(rbstr12.Length > rbstr22.Length)
//       {
//          string temp=rbstr12;
//          rbstr12=rbstr22;
//          rbstr22=temp;
//       }
//       rbstr12=rbstr12.PadLeft(rbstr22.Length,'0');
//       System.Console.WriteLine(rbstr12);
//       string ansr=Add(rbstr12,rbstr22,0);
//       int newcarry=0;
//       if(ansr.Length > rbstr22.Length)
//       {
//           newcarry=ansr[0];
//           ansr=ansr.Substring(1);
//       }
//       string ansl=Add(str11,str21,newcarry);
//       System.Console.WriteLine(ansl + "." + ansr);
//    }

// }