using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
//using System.Windows.Forms;
using System.Threading.Tasks;

namespace PosLibrary.serve
{
    public class PrintServe
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
        
        private void MakeReceipt(object sender, PrintPageEventArgs e)
        {
            StringBuilder receipt = new StringBuilder();
            receipt.AppendLine("----- Receipt -----");
            receipt.AppendLine($"Date: {date}");
            receipt.AppendLine("-------------------");
            receipt.AppendLine("Items:");
            if (cart == null || cart.Products == null || cart.Products.Count == 0)
            {
                receipt.AppendLine("Cart is empty.");
            }
            else
            {
                foreach (var item in cart.Products)
                {
                    if (item == null) continue;
                    receipt.AppendLine($"{item.Name} x{item.Quantity} - ${item.price * item.Quantity}");
                }
            }

            receipt.AppendLine("-------------------");
            receipt.AppendLine($"Total: ${totalAmount}");
            receipt.AppendLine($"Paid: ${paidAmount}");
            receipt.AppendLine($"Change: ${changeAmount}");
            receipt.AppendLine("-------------------");
            receipt.AppendLine("Thank you for your purchase!");
            e.Graphics.DrawString(receipt.ToString(), new Font("Arial", 12), Brushes.Black, 50, 50);

        }

        public void PrintReceipt()
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.PrintPage += MakeReceipt;

            using (PrintDialog printDialog = new PrintDialog())
            {
                printDialog.Document = printDocument;
                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.PrinterSettings = printDialog.PrinterSettings;
                    printDocument.Print();
                }
            }

        }   
    }
}
