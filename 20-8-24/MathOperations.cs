public class MathOperations
{
    public double DivideNumbers(int numerator,int denominator)
    {
        try{
            int c=numerator/denominator;
            if(denominator%2!=0)
            {
                throw new OddException();
            }
            return c;
        }
        catch(DivideByZeroException ex)
        {
            System.Console.WriteLine("You are dividing by zero");
            return -1;
        }
        catch(FormatException ex)
        {
            System.Console.WriteLine("Enter the input format correctly");
            return -1;
        }
        catch(OddException ex)
        {
            System.Console.WriteLine(ex.Message);
            return -1;
        }
        catch(Exception ex)
        {
            System.Console.WriteLine("Handle the exception properly");
            return -1;
        }
    }
}