using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsvezivacVazduhaApp.BiznisLogika
{
    public delegate void ZagusenjePromenjeno(Prostorija objavljivac, ZagusenjePromenjenoEventArgs e);
    public class Prostorija
    {
        public event ZagusenjePromenjeno OnZagusenjePromenjeno = null;
        Red<OsvezivacVazduha> osvezivaciVazduha;
        private double procenatZagusljivosti = 0;

        public Red<OsvezivacVazduha> OsvezivaciVazduha { get => osvezivaciVazduha;  }
        public double ProcenatZagusljivosti 
        {
            get => procenatZagusljivosti;
            set
            {
                if (this.procenatZagusljivosti != value)
                {
                    this.procenatZagusljivosti = value;
                    if (this.OnZagusenjePromenjeno != null)
                    {
                        this.OnZagusenjePromenjeno(this, new ZagusenjePromenjenoEventArgs(value));
                    }
                }
            }
        }

        public Prostorija()
        {
            this.osvezivaciVazduha = new Red<OsvezivacVazduha>();
        }

        public void Dodaj(OsvezivacVazduha ov)
        {
            this.osvezivaciVazduha.Dodaj(ov);
            this.OnZagusenjePromenjeno += ov.StatusPromenjen;
        }
    }

    public class ZagusenjePromenjenoEventArgs:EventArgs
    {
        public readonly double procenatZagusljivosti;
        public ZagusenjePromenjenoEventArgs(double x)
        {
            this.procenatZagusljivosti = x;
        }
    }
}
