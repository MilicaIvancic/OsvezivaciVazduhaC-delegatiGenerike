using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsvezivacVazduhaApp.BiznisLogika
{
    public enum OsvezivacStatus { Iskljucen, Ukljucen }
    public class OsvezivacVazduha
    {
        private const double DifoltniProcenatUkljucivanja = 20;
        private OsvezivacStatus status = OsvezivacStatus.Iskljucen;
        private double procenatUkljucivanja; // ide od 1-100 

        private double ProcenatUkljucivanja
        {
            get
            {
                return this.procenatUkljucivanja;
            }
        }

        public OsvezivacStatus Status
        {
            get => status;
            set
            {
                if (this.status != value)
                {
                    this.status = value;
                }
            }
        }

        public OsvezivacVazduha(double x= DifoltniProcenatUkljucivanja)
        {
            this.procenatUkljucivanja = x;
        }


        public void StatusPromenjen(Prostorija objavljivac, ZagusenjePromenjenoEventArgs e)
        {
            if(e.procenatZagusljivosti>= procenatUkljucivanja)
            {
                if (this.status != OsvezivacStatus.Ukljucen)
                {
                    this.status = OsvezivacStatus.Ukljucen;
                }
            }
            else
            {
                if (this.status != OsvezivacStatus.Iskljucen)
                {
                    this.status = OsvezivacStatus.Iskljucen;
                }
            }
        }





    }
}
