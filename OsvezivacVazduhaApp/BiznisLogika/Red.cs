using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsvezivacVazduhaApp.BiznisLogika
{
    public class Red<T>:IEnumerable<T>
    {
        private const int DifoltniKapacitet = 5;
        private T[] red;
        private int pozicija;
        
        public int Pozicija
        {
            get
            {
                return this.pozicija;
            }
        }

        public Red(int x=DifoltniKapacitet)
        {
            if (x > 1)
                this.red = new T[x];
        }

        public void Dodaj(T x)
        {
            if (this.pozicija == this.red.Length)
            {
                PovecajKapacitet();
            }
            this.red[pozicija] = x;
            this.pozicija++;
        }

        public void PovecajKapacitet()
        {
            T[] tmp = new T[this.red.Length * 2];
            for(int i=0; i<this.red.Length; i++)
            {
                tmp[i] = this.red[i];
            }
            this.red = tmp;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new RedIenumerator<T>(this.red, this.pozicija);
        }

        IEnumerator IEnumerable.GetEnumerator()//implicitno poziva GetEnumerator()
        {
            //throw new NotImplementedException(); ***
            return GetEnumerator();
        }
    }

    public class RedIenumerator<T> : IEnumerator<T>
    {
        private T[] red;
        private int pozicija;
        private int index = -1;

        public RedIenumerator(T[] x, int pozicija)
        {
            this.red = x;
            this.pozicija = pozicija;
        }
        public T Current
        {
            get
            {
                if ((this.index < 0) || (this.index >= this.pozicija))
                {
                    throw new IndexOutOfRangeException();
                }
                return this.red[index];
            }
        }

        object IEnumerator.Current//implicitno poziva svojstvo Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {
            //throw new NotImplementedException(); Rekao Milanko da treba da bude prazno
        }

        public bool MoveNext()
        {
            //throw new NotImplementedException();
            this.index++;
            return  index < pozicija ;
        }

        public void Reset()
        {
            //throw new NotImplementedException();
            this.index = -1;
        }
    }
}
