using iTextSharp.text.pdf;
using Productos_wpf.Models;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;

namespace Productos_wpf.ViewModel.Services
{
    
    public class TicketService
    {
        private PrintDocument printDocument;

        public TicketService()
        {
            printDocument = new();
            printDocument.PrintPage += new PrintPageEventHandler(printDocumentHandler);
        }
        public string Header { get; set; }
        public string Detail { get; set; }

        private void printDocumentHandler(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString(Header, new Font("Times new Roman", 10f), Brushes.Black, 10f, 0f);
            e.Graphics.DrawString(Detail, new Font("Times new Roman", 10f), Brushes.Black, 20f, 100f);

            Image image = Image.FromFile("code123.png");
            e.Graphics.DrawImage(image, 40, 200, image.Width, image.Height);
            image.Dispose();
        }

        public void Print(Product product ) 
        {

            Header = "Bienvenidos a la tienda DW \n esto es un texto de bienvenida \n";
            Header += "sucursal 12, Telefono 33-96-55-55 \n esto es el final del header";

            Detail = $"El codigo del producto es {product.Id} \n  {product.Description} \n";
            Detail += $"El precio del producto es {product.Price}";

            Barcode128 barCode = new Barcode128
            {
                CodeType = 9,
                ChecksumText = true,
                GenerateChecksum = true,
                BarHeight = 80,
                Code = "0123456687"
            };

            Bitmap bitmap = new Bitmap(barCode.CreateDrawingImage(Color.Black, Color.White));
            bitmap.Save("code123.png", ImageFormat.Png);
            bitmap.Dispose();
                

            printDocument.Print();
        }
    }
}
