using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RajatK_Assign1
{
    class Product
    {
        public string ProductName { get; }  //Auto properties read-only

        public double PricePerUnit { get; }

        public int Quantity { get; set; } //read-write

        public double ProductTotalBeforeTax   //Calculating producttotal auto computed by multiplying price and quantity
        { 
            get
            {
                return (PricePerUnit * Quantity);
            }
        }

        public double ProductTax  //ProductTax auto-computed
        {
            get
            {
                return (ProductTotalBeforeTax * 8/100);
            }
        }

        public double ProductAfterTax  //product after tax calculated auto-computed properties
        {
            get
            {
                return (ProductTotalBeforeTax + ProductTax);
            }
        }


        public Product(string productName, double pricePerUnit) //constructor taking two values as default
        {
            ProductName = productName;
            PricePerUnit = pricePerUnit;
        }
        

       

        public override string ToString()  //converting TOstring method changes value to string and C is for currency

        {
            
            string outputStr = "\nProductName : " + ProductName + "" + "\nPricePerUnit : " + PricePerUnit.ToString("C")
                + "\nQuantity : " + Quantity + "\nProductTotalBeforeTax : " + ProductTotalBeforeTax.ToString("C") + "\nProductTax : " + ProductTax.ToString("C")
                + "\nProductTotalAfterTax : " + ProductAfterTax.ToString("C");

            return outputStr;
        }

    }
}
