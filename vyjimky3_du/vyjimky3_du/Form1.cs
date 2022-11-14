using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace vyjimky3_du
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = new FileStream(@"../../Cisla.dat", FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                int n = int.Parse(textBox1.Text);
                double soucet = 0, aritm = 0;
                if (n <= 0)
                {
                    throw new Exception ("Nelze zadat nulu nebo záporné číslo, zkus to znovu.");
                }
                br.BaseStream.Position = 0;
                while (br.BaseStream.Position < n)
                {
                    checked
                    {
                        double realnecislo = br.ReadDouble();
                        soucet += realnecislo;
                        listBox1.Items.Add(realnecislo.ToString());
                    }
                }
                fs.Close();
                br.Close();
                checked
                {
                    aritm = soucet / n;
                }
                MessageBox.Show("Aritmetický průměr prvních " + n + " čísel se rovná: " + aritm, "Výsledek", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Soubor nenalezen.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FormatException)
            {
                MessageBox.Show("Zadej číslo!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(OverflowException)
            {
                MessageBox.Show("Přetečení čísla.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(EndOfStreamException)
            {
                MessageBox.Show("Nepovolené čtení za koncem streamu!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Nastala tato chyba: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                MessageBox.Show("Jsi na konci!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
                listBox1.Items.Clear();
            }
        }
    }
}
