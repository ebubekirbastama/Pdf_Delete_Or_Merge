using iText.Kernel.Pdf;
using iText.Kernel.Utils;
using System;
using System.Windows.Forms;

namespace PdfSayfaSilme
{
    public class pdfbirlestir
    {
       public static void PDFDosyalarınıBirleştir(string[] pdfYolları, string çıktıDosyaYolu)
        {
            try
            {
                using (PdfWriter writer = new PdfWriter(çıktıDosyaYolu))
                {
                    using (PdfDocument mergedPdf = new PdfDocument(writer))
                    {
                        PdfMerger pdfMerger = new PdfMerger(mergedPdf);

                        foreach (var pdfYolu in pdfYolları)
                        {
                            using (PdfReader reader = new PdfReader(pdfYolu))
                            {
                                using (PdfDocument pdf = new PdfDocument(reader))
                                {
                                    int totalPages = pdf.GetNumberOfPages();
                                    pdfMerger.Merge(pdf, 1, totalPages);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}
