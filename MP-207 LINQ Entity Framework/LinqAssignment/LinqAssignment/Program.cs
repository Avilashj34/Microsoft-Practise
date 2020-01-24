using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            int j =0,price;
            string name;
            IList<Product> productlist = Product.GetInstance().Showproductlist();
            Product obj = Product.GetInstance();
            Console.WriteLine("How Many Product you want to add");
            int count = Convert.ToInt32(Console.ReadLine());
            for (int i= 0;i<count;i++)
            {
                /*Product p = new Product()
                {
                    Name = Console.ReadLine(),
                    Price = Convert.ToInt32(Console.ReadLine())
                };
                productlist.Add(p);*/
                Console.WriteLine("Enter Product Name");
                name = Console.ReadLine();
                Console.WriteLine("Enter Product Price");
                price = Convert.ToInt32(Console.ReadLine());
             
                obj.AddProduct(name, price);
            }
            var productresult = from p in productlist
                                select p;
            foreach (var i in productlist)
            {
                Console.WriteLine("Your "+ j++ +" Product Detail : "+i.Name+" "+i.Price);
            }
            j = 0;
            Console.WriteLine("Filter Product using Price\n Enter the price");
            int filterprice = Convert.ToInt32(Console.ReadLine());
            var filterresult = from p in productlist
                               where p.Price > filterprice
                               select p;
            Console.WriteLine("Filter Product Count : "+filterresult.Count());
            foreach (var i in filterresult)
            {
                Console.WriteLine("Your " + j++ + " Product Detail : " + i.Name + " " + i.Price);
            }

            var ascresult = from p in productlist
                            orderby p.Name
                            select p;
            j = 0;
            Console.WriteLine("Filter Product in ascending order : ");
            foreach (var i in ascresult)
            {
                Console.WriteLine("Your " + j++ + " Product Detail : " + i.Name + " " + i.Price);
            }
        }
    }
}
