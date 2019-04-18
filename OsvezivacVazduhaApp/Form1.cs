using OsvezivacVazduhaApp.BiznisLogika;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OsvezivacVazduhaApp
{
    public partial class Form1 : Form
    {
        Prostorija dnevnaSoba = new Prostorija();
     
        


        public Form1()
        {
            OsvezivacVazduha osvezivac1 = new OsvezivacVazduha();
            OsvezivacVazduha osvezivac2 = new OsvezivacVazduha(38.5);
            OsvezivacVazduha osvezivac3 = new OsvezivacVazduha();
            OsvezivacVazduha osvezivac4 = new OsvezivacVazduha(38.5);
            OsvezivacVazduha osvezivac5 = new OsvezivacVazduha();
            OsvezivacVazduha osvezivac6 = new OsvezivacVazduha(38.5);
            OsvezivacVazduha osvezivac7 = new OsvezivacVazduha();
            OsvezivacVazduha osvezivac8 = new OsvezivacVazduha(38.5);
            OsvezivacVazduha osvezivac9 = new OsvezivacVazduha();
            OsvezivacVazduha osvezivac10 = new OsvezivacVazduha(38.5);
            OsvezivacVazduha osvezivac11 = new OsvezivacVazduha();
            
            dnevnaSoba.Dodaj(osvezivac1);
            dnevnaSoba.Dodaj(osvezivac2);
            dnevnaSoba.Dodaj(osvezivac3);
            dnevnaSoba.Dodaj(osvezivac4);
            dnevnaSoba.Dodaj(osvezivac5);
            dnevnaSoba.Dodaj(osvezivac6);
            dnevnaSoba.Dodaj(osvezivac7);
            dnevnaSoba.Dodaj(osvezivac8);
            dnevnaSoba.Dodaj(osvezivac9);
            dnevnaSoba.Dodaj(osvezivac10);
            dnevnaSoba.Dodaj(osvezivac11);
           
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double procenatZagusljivosti = double.Parse(this.textBox2.Text);
            dnevnaSoba.ProcenatZagusljivosti = procenatZagusljivosti;

            foreach(var x in dnevnaSoba.OsvezivaciVazduha)
            {
                this.textBox1.Text += "Osvezivac vazduha je :" + x.Status+Environment.NewLine;
            }

            
        }
    }
}
