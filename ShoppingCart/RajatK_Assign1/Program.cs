using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Text;

namespace RajatK_Assign1
{
    class Program
    {
        static void Main(string[] args)
        {
            //OutputEncoding = Encoding.Default;
            OutputEncoding = Encoding.UTF8;  //for currency values changing
            WriteLine("Welcome to the wholesale products ordering sytem!");
            WriteLine("You can place orders for three different products!");

            WriteLine("\n\nThe products we have in stock");

            Product fistProduct = new Product("Disposable Masks pack", 12.99); /// created 3 objects and pass Product name and price per unit in them
            Product secondProduct = new Product("Hand Sanitizer", 6.99);
            Product thirdProduct = new Product("Printer Paper", 17.99);

            

            UpdateProductQty(fistProduct.ProductName, fistProduct.PricePerUnit);   // call method or function UpdateProductQuantity to update quantity they want to buy
            UpdateProductQty(secondProduct.ProductName, secondProduct.PricePerUnit);
            UpdateProductQty(thirdProduct.ProductName, thirdProduct.PricePerUnit);

            WriteLine("\n\nLet Us Begin by entering the quantities for each of these products");

            Quan(fistProduct.ProductName, out int Quantit); //method created to enter the quantity by user and use out 
            int QuanFor1 = Quantit;   // assign value of Quantit to variable Quanfor1 and doing the same for all 3 quantities given name as Quantit
            Quan(secondProduct.ProductName, out Quantit);
            int QuanFor2 = Quantit;      
            Quan(thirdProduct.ProductName, out Quantit);
            int QuanFor3 = Quantit;


            fistProduct.Quantity = QuanFor1;    //assign product quantity in objects for all 3 products
            secondProduct.Quantity = QuanFor2;
            thirdProduct.Quantity = QuanFor3;

            

            WriteLine("The quantities for each product has been entered");
            GetCartTotalsSummary(fistProduct, secondProduct, thirdProduct, out double totalBeforeDiscount, out double DiscountAmount); //GetCartTotalsSummary method is called
            double totaftDisc = GetCartTotalsSummary(fistProduct, secondProduct, thirdProduct, out totalBeforeDiscount, out DiscountAmount); //assigns GetCartSummary return value to a new variable

            string asterikline = new string('*', 80); //declare formatted output in main 


            ChooseAction(out int Choice); //to select from 3 choices

            if (Choice == 1) //if user call for view cart
            {
                Clear();
                ViewCart(fistProduct, secondProduct, thirdProduct);  //call view cart function
                
               
                WriteLine("\n");
                WriteLine("*{0,38}:  {1,-38}*", "Total Before Discount: ", totalBeforeDiscount.ToString("C"));

                if (totalBeforeDiscount > 100)  //if discount value is greater than 100
                {
                    WriteLine("*{0,38}:  {1,-38}*", "Discount: ", DiscountAmount.ToString("C"));
                    
                  
                    WriteLine("*{0,38}:  {1,-38}*", "Total After Discount: ", totaftDisc.ToString("C")); //after view cart Discount and total before discount is added in formatted 
                    
                    WriteLine(asterikline);
                    ChooseAction(out Choice);

                    if (Choice == 3) //if user call 3 method to get out
                    {
                        Clear();
                        WriteLine("Thank you for ordering the products. Good Bye!");
                    }

                    

                    else if (Choice == 2)  //if user selected the update cart first
                    {
                        Clear();
                        UpdateCart(fistProduct, secondProduct, thirdProduct, out int Choice1);

                        if (Choice1 == 1) // if user select 1 disposable mask option to update
                        {
                            Write("Enter the new quantity for " + fistProduct.ProductName + " : ");
                            int choiceForProduct1 = int.Parse(ReadLine());
                            fistProduct.Quantity = choiceForProduct1;
                            WriteLine("Great! Quantity for" + fistProduct.ProductName + "has been updated to : " + choiceForProduct1);
                        }

                        else if (Choice1 == 2) // if user select 2 Hand sanitizer option to update
                        {
                            Write("Ente the new quantity for  " + secondProduct.ProductName + " : ");
                            int choiceForProduct2 = int.Parse(ReadLine());
                            secondProduct.Quantity = choiceForProduct2;
                            WriteLine("Great! Quantity for" + secondProduct.ProductName + "has been updated to : " + choiceForProduct2);
                        }

                        else if (Choice1 == 3) // if user select 3 printed paper option to update
                        {
                            Write("Enter the new quantity for  " + thirdProduct.ProductName + " : ");
                            int choiceForProduct3 = int.Parse(ReadLine());
                            thirdProduct.Quantity = choiceForProduct3;
                            WriteLine("Great! Quantity for " + thirdProduct.ProductName + "has been updated to : " + choiceForProduct3);
                        }

                        ChooseAction(out Choice);

                        if (Choice == 1) // if user selected the view cart after updating the order
                        {
                            Clear();
                            ViewCart(fistProduct, secondProduct, thirdProduct);
                            WriteLine("\n");
                            GetCartTotalsSummary(fistProduct, secondProduct, thirdProduct, out totalBeforeDiscount, out DiscountAmount);
                            totaftDisc = GetCartTotalsSummary(fistProduct, secondProduct, thirdProduct, out totalBeforeDiscount, out DiscountAmount);

                            WriteLine("\n");
                            WriteLine("*{0,38}:  {1,-38}*", "Total Before Discount: ", totalBeforeDiscount.ToString("C"));
                            WriteLine("*{0,38}:  {1,-38}*", "Discount: ", DiscountAmount.ToString("C"));
                            WriteLine("*{0,38}:  {1,-38}*", "Total After Discount: ", totaftDisc.ToString("C"));
                            WriteLine(asterikline);
                            ChooseAction(out Choice);


                        }

                        if (Choice == 3) //if user call 3 method to get out 
                        {
                            Clear();
                            WriteLine("Thank you for ordering the products. Good Bye!");
                        }


                    }

                }


                else if (totalBeforeDiscount < 100) // if discount is less than 100
                {
                    WriteLine(asterikline);
                }
                
            }

            else if (Choice == 2)  //if user selected the update cart first
            {
               
                Clear();

                UpdateCart(fistProduct, secondProduct, thirdProduct, out int Choice1);

                if (Choice1 == 1)  // enter the new quantity for disposable mask 
                {
                    Write("Enter the new quantity for  " + fistProduct.ProductName + " : ");
                    int choiceForProduct1 = int.Parse(ReadLine());
                    fistProduct.Quantity = choiceForProduct1;
                    WriteLine("Great! Quantity for : " + fistProduct.ProductName + "has been updated to : " + choiceForProduct1);
                }

                else if (Choice1 == 2) //enter the new quantity for hand sanitizer
                {
                    Write("Ente the new quantity for " + secondProduct.ProductName + " : ");
                    int choiceForProduct2 = int.Parse(ReadLine());
                    secondProduct.Quantity = choiceForProduct2;
                    WriteLine("Great! Quantity for : " + secondProduct.ProductName + "has been updated to : " + choiceForProduct2);
                }

                else if (Choice1 == 3) //enter the new quantity for printed paper
                {
                    Write("Enter the new quantity for " + thirdProduct.ProductName + " : ");
                    int choiceForProduct3 = int.Parse(ReadLine());
                    thirdProduct.Quantity = choiceForProduct3;
                    WriteLine("Great! Quantity for : " + thirdProduct.ProductName + "has been updated to : " + choiceForProduct3);
                }

                ChooseAction(out Choice);

                if (Choice == 1) // if user selected the view cart after updating the order
                {
                    Clear();
                    ViewCart(fistProduct, secondProduct, thirdProduct);
                    WriteLine("\n");
                    GetCartTotalsSummary(fistProduct, secondProduct, thirdProduct, out totalBeforeDiscount, out  DiscountAmount); 
                    totaftDisc = GetCartTotalsSummary(fistProduct, secondProduct, thirdProduct, out totalBeforeDiscount, out DiscountAmount);

                    WriteLine("\n");
                    WriteLine("*{0,38}:  {1,-38}*", "Total Before Discount: ", totalBeforeDiscount.ToString("C"));
                    WriteLine("*{0,38}:  {1,-38}*", "Discount: ", DiscountAmount.ToString("C"));
                    WriteLine("*{0,38}:  {1,-38}*", "Total After Discount: ", totaftDisc.ToString("C"));
                    WriteLine(asterikline);
                    ChooseAction(out Choice);


                }

                else if (Choice == 3)
                {
                    Clear();

                }

               
            }

            else if (Choice == 3) //if user select choice 3 i.e. to quit the application
            {
                Clear();
            }

            

                  
            ReadKey();
           
            
        }

        public static void UpdateProductQty(string ProductName, double PricePerUnit )  //method to update the quantity
        {
            WriteLine(ProductName + " with price per unit  " + PricePerUnit.ToString("C"));

        }


        static void Quan(string ProductName,  out int Quantit) //method to enter the quantity and parse it into integer
        {
            Write("Enter the quantity for " + ProductName + ":");
            Quantit = int.Parse(ReadLine());
        }
        
        static void ChooseAction(out int Choice) //method to select from 3 choices
        {
            WriteLine("\n\n\n\nWhat would you like to do?");
            Write("\nPress 1 for View Cart, ");
            Write("Press 2 for Update Cart, ");
            Write("Press 3 for quiting the application :");

            Choice = int.Parse(ReadLine());  //converting string choice into integer value choice
            
        }

        static void ViewCart(Product product1, Product product2, Product product3)  //method to view cart and formatted output and C is for currency
        {
            WriteLine("Okay! Lets view your order!");
            WriteLine("\n\n");
            string asterikline = new string('*', 80);
            WriteLine(asterikline);
            WriteLine("*{0,38}:  {1,-38}*", "Product Name: ", product1.ProductName);   //formatted output for view cart
            WriteLine("*{0,38}:  {1,-38}*", "Price Per Unit: ", product1.PricePerUnit.ToString("C"));
            WriteLine("*{0,38}:  {1,-38}*", "Quantity: ", product1.Quantity);
            WriteLine("*{0,38}:  {1,-38}*", "Product Before Tax", product1.ProductTotalBeforeTax.ToString("C"));
            WriteLine("*{0,38}:  {1,-38}*", "Product Tax", product1.ProductTax.ToString("C"));
            WriteLine("*{0,38}:  {1,-38}*", "Product After Tax", product1.ProductAfterTax.ToString("C"));
            WriteLine("\n");
            WriteLine("*{0,38}:  {1,-38}*", "Product Name: ", product2.ProductName);
            WriteLine("*{0,38}:  {1,-38}*", "Price Per Unit: ", product2.PricePerUnit.ToString("C"));
            WriteLine("*{0,38}:  {1,-38}*", "Quantity: ", product2.Quantity);
            WriteLine("*{0,38}:  {1,-38}*", "Product Before Tax", product2.ProductTotalBeforeTax.ToString("C"));
            WriteLine("*{0,38}:  {1,-38}*", "Product Tax", product2.ProductTax.ToString("C"));
            WriteLine("*{0,38}:  {1,-38}*", "Product After Tax", product2.ProductAfterTax.ToString("C"));
            WriteLine("\n");
            WriteLine("*{0,38}:  {1,-38}*", "Product Name: ", product3.ProductName);
            WriteLine("*{0,38}:  {1,-38}*", "Price Per Unit: ", product3.PricePerUnit.ToString("C"));
            WriteLine("*{0,38}:  {1,-38}*", "Quantity: ", product3.Quantity);
            WriteLine("*{0,38}:  {1,-38}*", "Product Before Tax", product3.ProductTotalBeforeTax.ToString("C"));
            WriteLine("*{0,38}:  {1,-38}*", "Product Tax", product3.ProductTax.ToString("C"));
            WriteLine("*{0,38}:  {1,-38}*", "Product After Tax", product3.ProductAfterTax.ToString("C"));



           

        }

        static double GetCartTotalsSummary(Product product1, Product product2, Product product3, out double totalBeforeDiscount, out double DiscountAmount) //GetCartsummary method
        {
            totalBeforeDiscount = product1.ProductTotalBeforeTax + product2.ProductTotalBeforeTax + product3.ProductTotalBeforeTax; // to calculate totalbeforediscount and send as out
            
            DiscountAmount = (totalBeforeDiscount * 10) / 100;
            double totalAfterDiscount = totalBeforeDiscount - DiscountAmount;
            return (totalAfterDiscount);


        }

        static void UpdateCart(Product product1, Product product2, Product product3 , out int Choice1) //to update quantities for different products
        {
            WriteLine("Okay! Lets Update your order");
            WriteLine("\n");
            WriteLine("\n\nPress 1 to update quantity for " + product1.ProductName);
            WriteLine("\n\nPress 2 to update quantity for " + product2.ProductName);
            WriteLine("\n\nPress 3 to update quantity for " + product3.ProductName);
            Write("Enter the number (1,2 or 3) : ");

            Choice1 = int.Parse(ReadLine());   //choice1 is to update new quantities

         
            

           // return choice1;

        }

    }
}
