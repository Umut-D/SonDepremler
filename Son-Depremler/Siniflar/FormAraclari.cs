using System;
using System.Drawing;
using System.Windows.Forms;

namespace Son_Depremler.Siniflar
{
    abstract class FormAraclari
    {
        // Depremlerin şiddetine göre renklendirme yap
        protected static void OlcekRenklendir(ListView lvListe)
        {
            foreach (ListViewItem lvNesne in lvListe.Items)
            {
                lvNesne.UseItemStyleForSubItems = false;

                for (int i = 0; i < 1; i++)
                {
                    double olcek = Convert.ToDouble(lvNesne.SubItems[4].Text);
                    if (olcek <= 29)
                    {
                        lvNesne.SubItems[4].BackColor = Color.GreenYellow;
                        lvNesne.SubItems[4].ForeColor = Color.Black;
                    }
                    else if (olcek >= 30 && olcek <= 41)
                    {
                        lvNesne.SubItems[4].BackColor = Color.DarkGreen;
                        lvNesne.SubItems[4].ForeColor = Color.White;
                    }
                    else if (olcek >= 42 && olcek <= 60)
                    {
                        lvNesne.SubItems[4].BackColor = Color.Orange;
                        lvNesne.SubItems[4].ForeColor = Color.Black;
                    }
                    else if (olcek >= 61 && olcek <= 73)
                    {
                        lvNesne.SubItems[4].BackColor = Color.OrangeRed;
                        lvNesne.SubItems[4].ForeColor = Color.White;
                    }
                    else // Allah korusun
                    {
                        lvNesne.SubItems[4].BackColor = Color.DarkRed;
                        lvNesne.SubItems[4].ForeColor = Color.White;
                    }
                }
            }
        }

        protected void TimerSifirla(Timer zamanlayici)
        {
            zamanlayici.Stop();
            zamanlayici.Start();
            zamanlayici.Interval = 1000 * 60 * 5; // 5 dakikada bir istem yap
        }
    }
}