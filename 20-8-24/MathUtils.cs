public static class MathUtils
{
	public static int Add(int a, int b)
	{
		return a + b;
	}
	public static int Subtract(int a, int b)
	{
		return a - b;
	}
	public static int Mutliply(int a, int b)
	{
		return a * b;
	}
	public static float Divide(int a, int b)
	{
		try
		{
			int c = a / b;
			return c;
		}
		catch (DivideByZeroException d)
		{
			System.Console.WriteLine("Division by zero not possible");
			return -1;
		}
		catch (Exception ex)
		{
			System.Console.WriteLine("Handle the exception properly");
			return -1;
		}
	}
}