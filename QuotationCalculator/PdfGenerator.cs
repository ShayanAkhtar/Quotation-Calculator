using PdfSharp;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using System.IO;
using System.Collections.Generic;
using ClassLibraryModel;
using PdfSharp.Fonts;
using PdfSharp.Snippets.Font;

public class PdfGenerator
{
    public static byte[] CreatePdf(QuotationDetails quotation, List<ItemDetails> itemDetails)
    {
        using (var memoryStream = new MemoryStream())
        {
            if (Capabilities.Build.IsCoreBuild)
                GlobalFontSettings.FontResolver = new FailsafeFontResolver();

            // Create a new PDF document.
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Quotation Details";

            // Create an empty page in this document.
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            // Set fonts
            XFont titleFont = new XFont("Times New Roman", 20, XFontStyleEx.Bold);
            XFont headerFont = new XFont("Times New Roman", 14, XFontStyleEx.Bold);
            XFont contentFont = new XFont("Times New Roman", 12, XFontStyleEx.Regular);

            // Draw title
            gfx.DrawString("Quotation Details", titleFont, XBrushes.Black,
                new XRect(0, 0, page.Width, 50), XStringFormats.Center);

            // Draw Quotation Details
            double yPoint = 60;
            gfx.DrawString($"Quotation ID: {quotation.QuotationId}", headerFont, XBrushes.Black, 50, yPoint);
            yPoint += 20;
            gfx.DrawString($"Date: {quotation.Date.ToString("yyyy-MM-dd")}", headerFont, XBrushes.Black, 50, yPoint);
            yPoint += 20;
            gfx.DrawString($"Customer Mobile: {quotation.CustomerMobile}", headerFont, XBrushes.Black, 50, yPoint);
            yPoint += 20;
            gfx.DrawString($"Remarks: {quotation.Remarks}", headerFont, XBrushes.Black, 50, yPoint);
            yPoint += 30;

            // Draw Item Details Table Header
            gfx.DrawString("Item Details", headerFont, XBrushes.Black, 50, yPoint);
            yPoint += 20;
            gfx.DrawLine(XPens.Black, 50, yPoint, page.Width - 50, yPoint);
            yPoint += 20;

            // Column Headers
            gfx.DrawString("Item ID", contentFont, XBrushes.Black, 50, yPoint);
            gfx.DrawString("Glass ID", contentFont, XBrushes.Black, 100, yPoint);
            gfx.DrawString("Windows ID", contentFont, XBrushes.Black, 150, yPoint);
            gfx.DrawString("Width", contentFont, XBrushes.Black, 250, yPoint);
            gfx.DrawString("Height", contentFont, XBrushes.Black, 300, yPoint);
            gfx.DrawString("Windows Rate", contentFont, XBrushes.Black, 350, yPoint);
            gfx.DrawString("Glass Rate", contentFont, XBrushes.Black, 450, yPoint);
            yPoint += 20;
            gfx.DrawLine(XPens.Black, 50, yPoint, page.Width - 50, yPoint);
            yPoint += 20;

            // Draw each item
            foreach (var item in itemDetails)
            {
                gfx.DrawString(item.ItemId.ToString(), contentFont, XBrushes.Black, 50, yPoint);
                gfx.DrawString(item.GId.ToString(), contentFont, XBrushes.Black, 100, yPoint);
                gfx.DrawString(item.WindowsId.ToString(), contentFont, XBrushes.Black, 175, yPoint);
                gfx.DrawString(item.Width.ToString(), contentFont, XBrushes.Black, 250, yPoint);
                gfx.DrawString(item.Height.ToString(), contentFont, XBrushes.Black, 300, yPoint);
                gfx.DrawString(item.WindowsRate.ToString(), contentFont, XBrushes.Black, 375, yPoint);
                gfx.DrawString(item.GlassRate.ToString(), contentFont, XBrushes.Black, 475, yPoint);
                yPoint += 20;
            }

            // Save the document to memory stream.
            document.Save(memoryStream);
            return memoryStream.ToArray();
        }
    }
}
