
    // The CreditCard interface declares the operations that all 
    // concrete products must implement.
    public interface CreditCard
    {
        string GetCardType();
        int GetCreditLimit();
        int GetAnnualCharge();
    }




    // MoneyBack Product provides implementations of the CreditCard interface methods.
    public class MoneyBack : CreditCard
    {
        public string GetCardType()
        {
            return "MoneyBack";
        }
        public int GetCreditLimit()
        {
            return 15000;
        }
        public int GetAnnualCharge()
        {
            return 500;
        }
    }



    //Titanium Product provides implementations of the CreditCard interface methods.
    public class Titanium : CreditCard
    {
        public string GetCardType()
        {
            return "Titanium Edge";
        }
        public int GetCreditLimit()
        {
            return 25000;
        }
        public int GetAnnualCharge()
        {
            return 1500;
        }
    }



    //Platinum Product provides implementations of the CreditCard interface methods.
    public class Platinum : CreditCard
    {
        public string GetCardType()
        {
            return "Platinum Plus";
        }
        public int GetCreditLimit()
        {
            return 35000;
        }
        public int GetAnnualCharge()
        {
            return 2000;
        }
    }


    // The CreditCardFactory Creator class declares the factory method 
    // that is going to return an object of a Product class. 
    // The CreditCardFactory subclasses usually provide the implementation of the MakeProduct method.
    public abstract class CreditCardFactory
    {
        protected abstract CreditCard MakeProduct();
        // Also note that The Creator's primary responsibility is not creating products. 
        // Usually, it contains some core business logic that relies on Product objects, returned by the factory method. 
        public CreditCard CreateProduct()
        {
            //Call the MakeProduct which will create and return the appropriate object 
            CreditCard creditCard = this.MakeProduct();
            //Return the Object to the Client
            return creditCard;
        }
    }


    // PlatinumFactory Concrete Creators override the factory MakeProduct method
    // to create and return the Platinum Product
    public class PlatinumFactory : CreditCardFactory
    {
        // The signature of the method uses the abstract product CreditCard type,
        // Even though the concrete Platinum product is returned from the method.
        // This way the Abstract Creator CreditCardFactory can stay independent of concrete product classes.
        protected override CreditCard MakeProduct()
        {
            CreditCard product = new Platinum();
            return product;
        }
    }



    // MoneyBackFactory Concrete Creators override the factory MakeProduct method
    // to create and return the MoneyBack Product
    public class MoneyBackFactory : CreditCardFactory
    {
        // The signature of the method still uses the abstract product CreditCard type
        // Even though the concrete MoneyBack product is actually returned from the method.
        // This way the Creator can stay independent of concrete product classes.
        protected override CreditCard MakeProduct()
        {
            CreditCard product = new MoneyBack();
            return product;
        }
    }



    // TitaniumFactory Concrete Creators override the factory MakeProduct method
    // to create and return the Platinum Product
    public class TitaniumFactory : CreditCardFactory
    {
        // The signature of the method uses the abstract product CreditCard type,
        // Even though the concrete Titanium product is returned from the method.
        // This way the Abstract Creator CreditCardFactory can stay independent of concrete product classes.
        protected override CreditCard MakeProduct()
        {
            CreditCard product = new Titanium();
            return product;
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            // The client code works with an instance of a concrete creator
            // The CreateProduct will return the actual product instance via the product interface

            //PlatinumFactory CreateProduct method will return an instance of Platinum Product via the CreditCard interface
            CreditCard creditCard = new PlatinumFactory().CreateProduct();
            if (creditCard != null)
            {
                Console.WriteLine("Card Type : " + creditCard.GetCardType());
                Console.WriteLine("Credit Limit : " + creditCard.GetCreditLimit());
                Console.WriteLine("Annual Charge :" + creditCard.GetAnnualCharge());
            }
            else
            {
                Console.Write("Invalid Card Type");
            }
            Console.WriteLine("--------------");
            //MoneyBackFactory CreateProduct method will return an instance of Platinum Product via the CreditCard interface
            creditCard = new MoneyBackFactory().CreateProduct();
            if (creditCard != null)
            {
                Console.WriteLine("Card Type : " + creditCard.GetCardType());
                Console.WriteLine("Credit Limit : " + creditCard.GetCreditLimit());
                Console.WriteLine("Annual Charge :" + creditCard.GetAnnualCharge());
            }
            else
            {
                Console.Write("Invalid Card Type");
            }
            Console.ReadLine();
        }
    }




//unlike factory design pattern where when a new creditcard added we have to modify the existing factory method i.e; if-else
//logic so it is tight coupling
//but in factory method pattern if we wanted to add a new creditcard we can simply add the below code without changing the 
//existing code

//    public class NewFactory : CreditCardFactory
//     {
//         protected override CreditCard MakeProduct()
//         {
//             CreditCard product = new NewClass();
//             return product;
//         }
//     }
