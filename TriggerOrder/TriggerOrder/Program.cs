using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using TriggerOrder.data;

namespace TriggerOrder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProjectDB11Entities1 context = new ProjectDB11Entities1();
            string number;
            Console.WriteLine("## Stok Sistemi ##");
            Console.WriteLine();
            Console.WriteLine("1-Ürün Listesi");
            Console.WriteLine("2-Sipariş Listesi");
            Console.WriteLine("3-Kasa Durumu");
            Console.WriteLine("4-Yeni Ürün Satışı");
            Console.WriteLine("5-İşlem Sayacı:");
            Console.WriteLine("## Stok Sistemi ##");
            Console.WriteLine();
            Console.WriteLine("-------------------------");
            Console.WriteLine();
            Console.WriteLine("Lütfen Bir İşlem Seçiniz.");
            number = Console.ReadLine();
            Console.WriteLine();
            if (number == "1")
            {
                Console.WriteLine("Ürün Listesi:");
                var values = context.tblP.ToList();

                foreach (var item in values)
                {
                    Console.WriteLine(item.ProductID + " - " + item.ProductName +
                        " Stok: " + item.Stock + " Fiyat: " + item.Price + " TL");
                }
            }



            if (number == "2")
            {
                Console.WriteLine("Sipariş Listesi:");
                var values = context.tblO.ToList();

                foreach (var item in values)
                {
                    Console.WriteLine(item.OrderID + " - " + item.tblP.ProductName +
                        " Birim Fiyat: " + item.UnitPrice + " Adet: " + item.Quantity +
                        " Toplam: " + item.TotalPrice);
                }
            }



            if (number == "3")
            {
                Console.WriteLine("Kasa Durumu:");

                var balance = context.tblregister.Select(x => x.Balance).FirstOrDefault();


                Console.WriteLine("Toplam Tutar: " + balance + " TL");
            }
            {
            }
            if (number == "4")
            {
                Console.WriteLine("Yeni Ürün Satışı :");

                Console.WriteLine("Müşteri Adı:");
                int ProductID = int.Parse(Console.ReadLine());

                Console.WriteLine("Ürün Adet:");
                int quantity = int.Parse(Console.ReadLine());

                var productUnitPrice = context.tblP.Where(x => x.ProductID == ProductID).Select(y => y.Price).FirstOrDefault();

                Console.WriteLine("Birim Fiyat: " + productUnitPrice);
                decimal totalPrice = quantity * decimal.Parse(productUnitPrice.ToString());
                Console.WriteLine("Toplam Fiyat:" + totalPrice);
                Console.WriteLine ();
                Console.WriteLine("---Ürün Bilgisi---");
                tblO tblO=new tblO();
                tblO.UnitPrice = productUnitPrice;
                tblO.ProductID = ProductID;
                tblO.Quantity= quantity;
                tblO.TotalPrice= totalPrice;
               
            }

            if (number == "5")
            {
                var value = context.tblcess.Select(x => x.Process).FirstOrDefault();
                Console.WriteLine("Toplam İşlem Sayısı " + value);
            }
            Console.Read();
        }
    }     
}
