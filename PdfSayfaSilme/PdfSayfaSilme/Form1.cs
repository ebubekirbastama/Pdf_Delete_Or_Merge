using iText.Kernel.Pdf;
using System;
using System.IO;
using System.Windows.Forms;

namespace PdfSayfaSilme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OpenFileDialog op;
        private void button1_Click(object sender, EventArgs e)
        {
            DeletePage(textBox1.Text, Application.StartupPath + "\\Cikti\\" + Path.GetFileName(textBox1.Text));
            MessageBox.Show("Belirtilen sayfalar silindi.");
        }

        public void DeletePage(string inputPdfPath, string outputPdfPath)
        {
            try
            {
                using (PdfReader reader = new PdfReader(inputPdfPath))
                using (PdfWriter writer = new PdfWriter(outputPdfPath))
                {
                    using (PdfDocument pdf = new PdfDocument(reader, writer))
                    {
                        int totalPages = pdf.GetNumberOfPages();
                        pdf.RemovePage(int.Parse(textBox2.Text));
                        //for (int i = 0; i < int.Parse(textBox2.Text); i++)
                        //{
                        //    pdf.RemovePage(17);
                        //}

                    }
                }
                //Process.Start(Application.StartupPath + "\\Cikti\\");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = op.FileName.ToString();
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string[] pdfFiles = Directory.GetFiles(Application.StartupPath + "\\Girdi", "*.pdf");

            pdfbirlestir.PDFDosyalarınıBirleştir(pdfFiles, Application.StartupPath + "\\Cikti\\birlestirlmiş.pdf");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] pdfFiles = Directory.GetFiles(Application.StartupPath + "\\Girdi", "*.pdf");
            foreach (var yol in pdfFiles)
            {
                listBox2.Items.Add(yol);
                using (PdfReader reader = new PdfReader(yol))
                {
                    using (PdfDocument pdf = new PdfDocument(reader))
                    {
                        int totalPages = pdf.GetNumberOfPages();
                        listBox1.Items.Add(Path.GetFileName(yol) + " : Toplam Sayfa Adedi :" + totalPages.ToString());
                    }
                }
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = listBox2.Items[listBox1.SelectedIndex].ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            op = new OpenFileDialog();
            if (op.ShowDialog() == DialogResult.OK)
            {
                textBox3.Text = op.FileName.ToString();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DeletePagefor(textBox3.Text, Application.StartupPath + "\\Cikti\\" + Path.GetFileName(textBox3.Text));
            MessageBox.Show("Belirtilen sayfalar silindi.");
        }

        private void DeletePagefor(string inputPdfPath, string outputPdfPath)
        {
            try
            {
                using (PdfReader reader = new PdfReader(inputPdfPath))
                using (PdfWriter writer = new PdfWriter(outputPdfPath))
                {
                    using (PdfDocument pdf = new PdfDocument(reader, writer))
                    {
                        int totalPages = pdf.GetNumberOfPages();
                        for (int i = 0; i < int.Parse(textBox4.Text); i++)
                        {
                            pdf.RemovePage(1);
                        }

                    }
                }
                //Process.Start(Application.StartupPath + "\\Cikti\\");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
