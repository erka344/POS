using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
//using System.Windows.Forms;
using System.Threading.Tasks;

namespace PosLibrary.serve
{
    class PrintServe
    {
        private CartServe cart;
        private int totalAmount;
        private int paidAmount;
        private int changeAmount;
        private DateOnly date;

        public PrintServe(CartServe cart, int totalAmount, int paidAmount, int changeAmount)
        {
            this.cart = cart;
            this.totalAmount = totalAmount;
            this.paidAmount = paidAmount;
            this.changeAmount = changeAmount;
            date = DateOnly.FromDateTime(DateTime.Now);
        }
        
        private void MakeReceipt()
        {
            StringBuilder receipt = new StringBuilder();
            receipt.AppendLine("----- Receipt -----");
            receipt.AppendLine($"Date: {date}");
            receipt.AppendLine("-------------------");
            receipt.AppendLine("Items:");
            foreach (var item in cart.Products)
            {
                receipt.AppendLine($"{item.Name} x{item.Quantity} - ${item.price * item.Quantity}");
            }
            receipt.AppendLine("-------------------");
            receipt.AppendLine($"Total: ${totalAmount}");
            receipt.AppendLine($"Paid: ${paidAmount}");
            receipt.AppendLine($"Change: ${changeAmount}");
            receipt.AppendLine("-------------------");
            receipt.AppendLine("Thank you for your purchase!");
            Console.WriteLine(receipt.ToString());
        }

        public void PrintReceipt()
        {
            //PrintDocument printDocument = new PrintDocument();
            //printDocument.PrintPage += MakeReceipt ;

            //using (PrintDialog printDialog = new PrintDialog())
            //{
            //    printDialog.Document = printDocument;
            //    if (printDialog.ShowDialog() == DialogResult.OK)
            //    {
            //        printDocument.PrinterSettings = printDialog.PrinterSettings;
            //        printDocument.Print();
            //    }
            //}
            
        }   
    }
}
