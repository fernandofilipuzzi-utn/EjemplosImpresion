using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Margenes
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        string PathDirectoryPdf = "";
        string PathFilePdf = "";
        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            PathDirectoryPdf = Path.GetFullPath(@"salida\");
            PathFilePdf = Path.Combine(Path.GetDirectoryName(PathDirectoryPdf), "salida.pdf");
            //lnklbficheroPDF.Text = Path.GetFileName(PathFilePdf);
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            //elegir impresora, papel, margenes de impresion
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.PrinterSettings = printDialog1.PrinterSettings;
                printDocument1.Print();
            }
        }

        

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            List<string> personas = new List<string> { "López, Ana María del Carmen",
                                                        "Martinez, Betiana",
                                                        "De la Vega, Diego"};

            Graphics g = e.Graphics;

            Pen pen = new Pen(Color.Black);

            /* asociados a la configuración de la pagina.
            g.PageUnit
            g.PageScale
            e.PageSettings.Bounds
            e.PageSettings.PrintableArea
            */

            //no siempre la impresora permite elegir los margenes, asique
            //se puede hacer de otra forma, a partir del tamaño de papel elegido
            g.DrawRectangle(pen,
                                e.MarginBounds.Left,
                                e.MarginBounds.Top,
                                e.MarginBounds.Width,
                                e.MarginBounds.Height);

            float x = e.MarginBounds.Left + 10;
            float y = e.MarginBounds.Top + 20;
            Font font = new Font("Arial", 12);
            Brush brush = new SolidBrush(Color.Black);

            foreach (string persona in personas)
            {
                y += 20;
                g.DrawString(persona, font, brush, x, y);
            }
        }

        
    }
}
