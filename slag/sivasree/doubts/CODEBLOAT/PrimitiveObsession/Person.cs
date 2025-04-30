class Person
{
   string FName;
   String LName;

//instead of creating these variables(streetname,lanenum) in Person class we can create a seperate class called like Address
//and pass these as arguements
//    string streetname;
//    int lanenum;
//  public Person(string f,string l,string streetName,int laneno)
//    {
//       FName=f;
//       LName=l;
//       a=ad;
//    }

   Address ad;
   public Person(string f,string l,Address a)
   {
      FName=f;
      LName=l;
      a=ad;
   }

   public static void Main()
   {
      Address newad=new Address("hanuman junction",89);
      Person p=new Person("siva","sree",newad);
   }
}
