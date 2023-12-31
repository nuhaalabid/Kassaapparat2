using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kassaapparat2
{
    internal class ShoppingProgram
    {
        private double budget;
        private double totalCost;
        private double discount;

        // Lista över tillgängliga varor

        private List<Product> varaList;

        // Konstruktor för variabler och lista med varor
        public ShoppingProgram()
        {
            budget = 400.0;
            totalCost = 0.0;
            discount = 0.2;

            varaList = new List<Product>()
          
            {
            new  Product("vara1", 50.0),
            new  Product("vara2", 100.0),
            new  Product("vara3", 80.0),
            new  Product("vara4", 50),
            new  Product("discount coupon", 0.2)
           };
           }
           // Metod för att köra huvudprogrammet
            public void Run()
            {
            Console.WriteLine("Välkommen till inköpsprogrammet!");
            Console.WriteLine($"Din nuvarande budget är: {budget} kr");

            while (true)
            {

              // Be användaren ange namnet på varan eller sluta.
              Console.Write("Ange namnet på varan (eller 'sluta' för att avsluta): ");
              string varaName = Console.ReadLine();

              if (varaName.ToLower() == "sluta")
                  break; // Avsluta loopen om användaren väljer att sluta


              // Hitta varan i listan baserat på användarens inmatning

              Product varaPris = varaList.Find(item => item.Name.ToLower() == varaName.ToLower());

              if (varaPris == null)
             {
              Console.WriteLine("Varan finns inte i listan. Försök igen.");
                continue; //Hoppa till nästa iteration om varan inte hittas
             }

                //Hantera för rabattkupong
                switch (varaPris.Name.ToLower())
                {
                    case "discount coupon":
                        discount = 0.2; // 20% rabatt för rabattkupongen
                        break;
                    default:
                        break;
                }

               // Lägg till varans pris till totala kostnaden
               totalCost += varaPris.Price;

                // Visa kostnad och totalt spenderat 
               Console.WriteLine($"Varan kostar {varaPris.Price} kr. Totalt spenderat : {totalCost} kr.");

               // Fråga användarena om de vill lägga till en annan vara
              Console.Write("Vill du lägga till en annan vara? (ja/nej): ");
              string shopping = Console.ReadLine();

              if (shopping.ToLower() != "ja")
                break;

            }
          
            // Applicera rabatten och visa resultatet
            ApplyDiscount();
            DisplayResult();
            
          }
           // Metod för att applicera rabatten på totala kostnaden
             private void ApplyDiscount()
             {
             totalCost -= totalCost * discount;
             }

            // Metod för att visa resultatet baserat på användarens budget och totala kostnad
             private void DisplayResult()
            {

             Console.WriteLine($"Totalt spenderat efter rabatt: {totalCost} kr.");

            if (totalCost > budget)
            {
                Console.WriteLine("Tyvärr, du har inte råd att köpa dessa varor.");
            }
            else
            {
                Console.WriteLine($"Du har handlat följande varor och har {budget - totalCost} kr kvar:");

            }
        }
       
    }










}
    
        
    
