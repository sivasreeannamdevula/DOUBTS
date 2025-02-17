//if we write like below we have to pass marks for every student we call the TotalMarksOfStudent() marks method
//the varaibles that are related i.e; maths,physics,chemistry are called as data clumps.
// class Student
// {
//     public int TotalMarksOfStudent(int maths,int physics,int chemistry)
//    {
//      return maths+physics+chemistry;
//    }
// }

//instead we can do as below
class Student{
   int maths;
   int physics;
   int chemistry;
   public int TotalMarksOfStudent()
   {
    return maths+physics+chemistry;
   }
}