using System.Runtime.Intrinsics.Arm;


class A
{
    public static void Main()
    {
        DictionaryWrapperClass<Employee, Student> c = new DictionaryWrapperClass<Employee, Student>();
        c.Adding();
        c.Retrieve();
        c.Updating();
        c.Retrieve();
    }
}