class Department : Employee
{

  public static int y = 9;
  static Department()
  {
    System.Console.WriteLine("dept ctor called");


  }
  public static void DeptMethod(string d)
  {
    System.Console.WriteLine(d);
  }

}