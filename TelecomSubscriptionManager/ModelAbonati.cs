using System;
using System.Collections;
using System.Xml.Serialization;

namespace Proiect_PAW
{
    // Delegate
    public delegate void SchimbareCuloareHandler();

    // Interface
    public interface ICalculabil
    {
        double CalculeazaFacturaTotala();
    }

    // Abstract class
    [XmlInclude(typeof(TipAbonament))]
    public abstract class ServiciuTelecomunicatii
    {
        public string DenumireServiciu { get; set; }

        public ServiciuTelecomunicatii()
        {
            DenumireServiciu = "Serviciu Standard";
        }

        public ServiciuTelecomunicatii(string denumire)
        {
            DenumireServiciu = denumire;
        }

        public abstract void AfiseazaDetaliiServiciu();
    }

    // Classes that implement ICloneable and IComparable
    // Class 1: ExtraOptiuni (extra options)
    public class ExtraOptiuni : ICloneable, IComparable
    {
        private string _numeOptiune;
        private double _pretLunar;

        public string NumeOptiune
        {
            get { return _numeOptiune; }
            set { _numeOptiune = value; }
        }

        public double PretLunar
        {
            get { return _pretLunar; }
            set { _pretLunar = value; }
        }

        public ExtraOptiuni()
        {
            NumeOptiune = "Necunoscută";
            PretLunar = 0.0;
        }

        public ExtraOptiuni(string numeOptiune, double pretLunar)
        {
            this._numeOptiune = numeOptiune;
            this._pretLunar = pretLunar;
        }

        // Operator overloading 1/2: compare options by price with > and <
        public static bool operator >(ExtraOptiuni a, ExtraOptiuni b)
        {
            return a.PretLunar > b.PretLunar;
        }

        public static bool operator <(ExtraOptiuni a, ExtraOptiuni b)
        {
            return a.PretLunar < b.PretLunar;
        }

        public override string ToString()
        {
            return $"{NumeOptiune} ({PretLunar} EUR)";
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            ExtraOptiuni altul = obj as ExtraOptiuni;
            if (altul != null) return this.PretLunar.CompareTo(altul.PretLunar);
            throw new ArgumentException("Obiectul nu este de tipul ExtraOptiuni");
        }
    }

    // Class 2: TipAbonament (subscription plan). It does not use IEnumerable, so XML saving works
    [Serializable]
    public class TipAbonament : ServiciuTelecomunicatii
    {
        public double PretBaza { get; set; }

        // Array of extra options
        public ExtraOptiuni[] OptiuniIncluse { get; set; }

        public TipAbonament() : base()
        {
            PretBaza = 10.0;
            OptiuniIncluse = new ExtraOptiuni[0];
        }

        public TipAbonament(string denumire, double pretBaza, ExtraOptiuni[] optiuni) : base(denumire)
        {
            this.PretBaza = pretBaza;
            this.OptiuniIncluse = optiuni ?? new ExtraOptiuni[0];
        }

        // Indexer for the options array
        public ExtraOptiuni this[int index]
        {
            get { return OptiuniIncluse[index]; }
            set { OptiuniIncluse[index] = value; }
        }

        // Operator overloading 2/2: + adds an option to a plan
        public static TipAbonament operator +(TipAbonament abonament, ExtraOptiuni nouaOptiune)
        {
            if (abonament != null && nouaOptiune != null)
            {
                int lungimeNoua = (abonament.OptiuniIncluse == null) ? 1 : abonament.OptiuniIncluse.Length + 1;
                ExtraOptiuni[] masivNou = new ExtraOptiuni[lungimeNoua];
                if (abonament.OptiuniIncluse != null)
                {
                    Array.Copy(abonament.OptiuniIncluse, masivNou, abonament.OptiuniIncluse.Length);
                }
                masivNou[lungimeNoua - 1] = nouaOptiune;
                abonament.OptiuniIncluse = masivNou;
            }
            return abonament;
        }

        // Method 1: total price of the extra options
        public double CalculeazaPretTotalOptiuni()
        {
            double total = 0;
            if (OptiuniIncluse != null)
            {
                // Loop over the options array
                foreach (ExtraOptiuni eo in OptiuniIncluse) total += eo.PretLunar;
            }
            return total;
        }

        public override void AfiseazaDetaliiServiciu() { }
    }

    // Collection class that supports foreach (IEnumerable)
    public class ColectieOptiuni : IEnumerable
    {
        private ExtraOptiuni[] _elemente;
        public ColectieOptiuni(ExtraOptiuni[] lista) { _elemente = lista; }
        public IEnumerator GetEnumerator() { return _elemente.GetEnumerator(); }
    }

    // Class 3: Clienti (clients). Implements ICloneable, IComparable and ICalculabil
    public class Clienti : ICloneable, IComparable, ICalculabil
    {
        // Skip the event when saving to XML
        [field: XmlIgnore]
        public event SchimbareCuloareHandler OnSchimbareCuloare;

        public int IdClient { get; set; }
        public string NumeClient { get; set; }
        public TipAbonament AbonamentClasa { get; set; }
        public double CostSuplimentarAparut { get; set; }

        public Clienti()
        {
            IdClient = 0;
            NumeClient = "Anonim";
            AbonamentClasa = new TipAbonament();
            CostSuplimentarAparut = 0.0;
        }

        public Clienti(int idClient, string numeClient, TipAbonament abonament, double costSuplimentar)
        {
            this.IdClient = idClient;
            this.NumeClient = numeClient;
            this.AbonamentClasa = abonament;
            this.CostSuplimentarAparut = costSuplimentar;
        }

        // Method 2: total monthly bill
        public double CalculeazaFacturaTotala()
        {
            if (AbonamentClasa == null) return CostSuplimentarAparut;
            return AbonamentClasa.PretBaza + AbonamentClasa.CalculeazaPretTotalOptiuni() + CostSuplimentarAparut;
        }

        public void DeclanșeazăNotificareVizuală()
        {
            if (OnSchimbareCuloare != null)
            {
                OnSchimbareCuloare();
            }
        }

        public override string ToString()
        {
            return $"Client #{IdClient}: {NumeClient} | Total: {CalculeazaFacturaTotala()} EUR";
        }

        public object Clone()
        {
            Clienti clona = (Clienti)this.MemberwiseClone();
            if (this.AbonamentClasa != null)
            {
                clona.AbonamentClasa = new TipAbonament(this.AbonamentClasa.DenumireServiciu, this.AbonamentClasa.PretBaza, this.AbonamentClasa.OptiuniIncluse);
            }
            return clona;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Clienti altul = obj as Clienti;
            if (altul != null) return this.IdClient.CompareTo(altul.IdClient);
            throw new ArgumentException("Tip de date invalid pentru comparatie!");
        }
    }
}