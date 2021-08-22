using System;
using System.Drawing;
using System.Windows.Forms;

namespace SonDepremlerLibrary.Araclar
{
    public class DepremSiddeti
    {
        public void Renklendir(ListView lvListe)
        {
            foreach (ListViewItem lvNesne in lvListe.Items)
            {
                lvNesne.UseItemStyleForSubItems = false;

                for (int i = 0; i < 1; i++)
                {
                    double richterOlcegi = Convert.ToDouble(lvNesne.SubItems[4].Text);
                    if (richterOlcegi <= 29)
                    {
                        lvNesne.SubItems[4].BackColor = Color.GreenYellow;
                        lvNesne.SubItems[4].ForeColor = Color.Black;
                    }
                    else if (richterOlcegi >= 30 && richterOlcegi <= 41)
                    {
                        lvNesne.SubItems[4].BackColor = Color.DarkGreen;
                        lvNesne.SubItems[4].ForeColor = Color.White;
                    }
                    else if (richterOlcegi >= 42 && richterOlcegi <= 60)
                    {
                        lvNesne.SubItems[4].BackColor = Color.Orange;
                        lvNesne.SubItems[4].ForeColor = Color.Black;
                    }
                    else if (richterOlcegi >= 61 && richterOlcegi <= 73)
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
    }
}