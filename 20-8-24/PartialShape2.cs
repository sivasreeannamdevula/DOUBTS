public abstract partial class Shape
{
    public Shape(string name,int id)
    {
       this.Name=name;
       this.ID=id;
    }
    public abstract void Draw();
     public void Move()
    {

    }

}