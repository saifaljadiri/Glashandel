using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Glashandel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        int gewoonGlas = 30;
        int snijKostenGewoon = 10;
        int speciaalGlas = 55;
        int snijKostenSpeciaal = 25;
        double korting = 0.95;
        double restantGlas = 0;
        double kostenGewoonGlas = 0;
        double kostenSpeciaalGlas = 0;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Empty(textBox1))
            {
                double aantalM2 = Convert.ToDouble(textBox1.Text);
                double totaalKosten = 0;
                if (IsRestantGlasOver(aantalM2))
                {
                    totaalKosten = BerekenRestantGlas(aantalM2, gewoonGlas);
                }
                else
                {
                    totaalKosten = Math.Ceiling(aantalM2) * gewoonGlas + snijKostenGewoon;
                    if (aantalM2 - Math.Floor(aantalM2) == 0)
                    {
                        restantGlas += 0;
                    }
                    else
                    {
                        restantGlas += 1 - (aantalM2 - Math.Floor(aantalM2));
                    }
                    lbl_restant.Text = Convert.ToString(restantGlas);
                }


                // if statment als bedrag 145 hoger is hoef je geen snijkostengewoon tebtalen//
                if (totaalKosten >= 145)
                {
                    totaalKosten -= snijKostenGewoon;
                }
                if (totaalKosten >= 250) //als bedrag hoger dan 250 dan komt 5% korting op het totale bedrag//
                {
                    totaalKosten *= korting;
                }
                kostenGewoonGlas = totaalKosten;
                textBox3.Text = Convert.ToString(kostenGewoonGlas + kostenSpeciaalGlas);
            }
            else
            {
                kostenGewoonGlas = 0;
                textBox3.Text = Convert.ToString(kostenGewoonGlas + kostenSpeciaalGlas);
            }

            if (!Empty(textBox2))
            {
                double aantalM2 = Convert.ToDouble(textBox2.Text);
                double totaalKosten = 0;
                if (IsRestantGlasOver(aantalM2))
                {
                    totaalKosten = BerekenRestantGlas(aantalM2, speciaalGlas);
                }
                else
                {
                    totaalKosten = Math.Ceiling(aantalM2) * speciaalGlas + snijKostenSpeciaal;
                    if (aantalM2 - Math.Floor(aantalM2) == 0)
                    {
                        restantGlas += 0;
                    }
                    else
                    {
                        restantGlas += 1 - (aantalM2 - Math.Floor(aantalM2));
                    }
                    lbl_restant.Text = Convert.ToString(restantGlas);
                }


                // if statment als bedrag 145 hoger is hoef je geen snijkostengewoon tebtalen//
                if (totaalKosten >= 145)
                {
                    totaalKosten -= snijKostenSpeciaal;
                }
                if (totaalKosten >= 250) //als bedrag hoger dan 250 dan komt 5% korting op het totale bedrag//
                {
                    totaalKosten *= korting;
                }
                kostenSpeciaalGlas = totaalKosten;
                textBox3.Text = Convert.ToString(kostenGewoonGlas + kostenSpeciaalGlas);
            }
            else
            {
                kostenSpeciaalGlas = 0;
                textBox3.Text = Convert.ToString(kostenGewoonGlas + kostenSpeciaalGlas);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            kostenGewoonGlas = 0;
            kostenSpeciaalGlas = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private bool Empty(TextBox textbox)
        {
            if (string.IsNullOrWhiteSpace(textbox.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsRestantGlasOver(double aantalM2)
        {
            if (restantGlas >= aantalM2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private double BerekenRestantGlas(double aantalM2, double glasKosten)
        {
            double kostenRestantGlas = 0;
            double restKosten = 0;

            // bereken de kosten voor het restante glas.
            kostenRestantGlas = glasKosten * restantGlas;

            // bereken de kosten voor het overgehouden (niet restante) glas.
            aantalM2 -= restantGlas;
            restantGlas = 0;
            restKosten = Math.Ceiling(aantalM2) * glasKosten;

            // bepaal de nieuwe restante glas
            if (aantalM2 - Math.Floor(aantalM2) == 0)
            {
                restantGlas = 0;
            }
            else
            {
                restantGlas = 1 - (aantalM2 - Math.Floor(aantalM2));
            }

            // update de restantGlas label
            lbl_restant.Text = Convert.ToString(restantGlas);

            // beiden kosten returnen
            return kostenRestantGlas + restKosten;
        }
    }
}
