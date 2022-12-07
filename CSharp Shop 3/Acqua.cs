using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpShop3
{
    public class Acqua : Prodotto
    {
        private float litriAcqua;
        private int livelloPh;
        private string sorgente;
        private float acquaBevuta;
        private float acquaRiempita;

        //public Acqua(int Codice, string Nome, string Descrizione, float Prezzo, int Iva, float litriAcqua, int livelloPh, string sorgente, float acquaBevuta = 0, float acquaRiempita = 0) : base(Codice, Nome, Descrizione, Prezzo, Iva)
        public Acqua(string name, string description, double prezzo, double IVA, float LitriAcqua, int LivelloPh, string Sorgente, float AcquaBevuta, float AcquaRiempita) : base(name, description, prezzo, IVA)
        {
            if (LitriAcqua <= 0)
            {
                throw new ContenutoNegativoException($"'{nameof(LitriAcqua)}' non può essere negativo.");
            }
            if(LivelloPh <= 0)
            {
                throw new ContenutoNegativoException($"'{nameof(LivelloPh)}' non può essere negativo.");
            }else if(LivelloPh > 10)
            {
                throw new ContenutoPhSuperioreException($"'{nameof(LivelloPh)}' non può essere maggiore di 10");
            }
            this.litriAcqua = LitriAcqua;
            this.livelloPh = LivelloPh ;
            this.sorgente = Sorgente ?? throw new ArgumentNullException(nameof(Sorgente), $"{nameof(Sorgente)} non può essere nullo.");
            this.acquaBevuta = AcquaBevuta;
            this.acquaRiempita = AcquaRiempita;
        }

        public float GetLitriAcqua()
        {
            return litriAcqua;
        }

        public int GetLivelloPh()
        {
            return livelloPh;
        }

        public string GetSorgente()
        {
            return sorgente;
        }

        public void SetLitriAcqua(float LitriAcqua)
        {
            if (LitriAcqua > 0 && LitriAcqua <= 1.5)
            {
                this.litriAcqua = LitriAcqua;
            }
            else
            {
                Console.WriteLine("Hai inserito un valore non valido!!");
            }
        }

        public void SetAcquaBevuta(float AcquaBevuta)
        {
            if (AcquaBevuta > 0 && AcquaBevuta < this.litriAcqua)
            {
                this.acquaBevuta = AcquaBevuta;
            }
            else
            {
                Console.WriteLine("Hai inserito un valore non valido!!");
            }

        }


        public override void StampaProdotto()
        {
            string stringaProdotto = "Litri d'acqua: \t" + AcquaRimasta(this.acquaBevuta) + " l" +
                "\nLivello di PH: \t\t" + this.livelloPh +
                "\nSorgente: " + this.sorgente;
            base.StampaProdotto();
            Console.WriteLine(stringaProdotto);
        }
        public float AcquaRimasta(float AcquaBevuta)
        {
            if (AcquaBevuta != 0)
            {
                this.litriAcqua -= this.acquaBevuta;
            }
            return this.litriAcqua;
        }
        public class ContenutoNegativoException : NotSupportedException
        {
            public ContenutoNegativoException() : base() { }

            public ContenutoNegativoException(string message) : base(message) { }
        }

        public class ContenutoPhSuperioreException : NotSupportedException
        {
            public ContenutoPhSuperioreException() : base() { }

            public ContenutoPhSuperioreException(string message) : base(message) { }
        }
    }
}

