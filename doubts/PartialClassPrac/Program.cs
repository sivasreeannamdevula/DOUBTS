namespace Partial
{
    partial class MyPartial
  {
    private int x;
    //by default partial methods are private.
    partial void Method();
    MyPartial()
    {
        x=89;
    }
  //1.access-specifers
  //2.return type other than void
  //3.out parameters are present
  //4.virtual,override,sealed,new,extern are present
  
  //if any one of the above rules are satisfied then surely we must provide implementation for that 
  //PARTIAL METHOD or else no need bcus compiler internally igonres such declarations.

    public virtual  partial int Display(); 
    
  }
}