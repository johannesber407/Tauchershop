using System;
using System.Data;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Data;
using Tauchershop;
using Tauchershop.TauchShopDataSetTableAdapters;

namespace Tauchershop
{
    // Class TDatenbank
    public class TDatenbank : DependencyObject
    {
        private static TauchShopDataSet Datenbank;
        private static ArtikelTableAdapter AdapterArtikel;
        private static KundenTableAdapter AdapterKunden;
        private static LieferantenTableAdapter AdapterLieferanten;
        private static MitarbeiterTableAdapter AdapterMitarbeiter;
        private static AuftraegeTableAdapter AdapterAuftraege;
        private static PositionenTableAdapter AdapterPositionen;
        private static DataView DataViewArtikel, DataViewKunden, DataViewLieferanten, DataViewMitarbeiter, DataViewAuftraege, DataViewPositionen;
        private static bool Initialisiert = false;

        public TDatenbank()
        {
            if (!Initialisiert)
            {
                InitialisiereDatenbank();
                Initialisiert = true;
            }
        }
        private void InitialisiereDatenbank()
        {
            OleDbConnection Verbindung;
            Datenbank = new TauchShopDataSet();
            Verbindung = new OleDbConnection(ConnectionString());

            AdapterArtikel = new ArtikelTableAdapter();
            AdapterArtikel.Connection = Verbindung;
            AdapterArtikel.Fill(Datenbank.Artikel);
            DataViewArtikel = Datenbank.Artikel.DefaultView;

            AdapterKunden = new KundenTableAdapter();
            AdapterKunden.Connection = Verbindung;
            AdapterKunden.Fill(Datenbank.Kunden);
            DataViewKunden = Datenbank.Kunden.DefaultView;

            AdapterLieferanten = new LieferantenTableAdapter();
            AdapterLieferanten.Connection = Verbindung;
            AdapterLieferanten.Fill(Datenbank.Lieferanten);
            DataViewLieferanten = Datenbank.Lieferanten.DefaultView;

            AdapterMitarbeiter = new MitarbeiterTableAdapter();
            AdapterMitarbeiter.Connection = Verbindung;
            AdapterMitarbeiter.Fill(Datenbank.Mitarbeiter);
            DataViewMitarbeiter = Datenbank.Mitarbeiter.DefaultView;

            AdapterAuftraege = new AuftraegeTableAdapter();
            AdapterAuftraege.Connection = Verbindung;
            AdapterAuftraege.Fill(Datenbank.Auftraege);
            DataViewAuftraege = Datenbank.Auftraege.DefaultView;

            AdapterPositionen = new PositionenTableAdapter();
            AdapterPositionen.Connection = Verbindung;
            AdapterPositionen.Fill(Datenbank.Positionen);
            DataViewPositionen = Datenbank.Positionen.DefaultView;
        }
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        private string ConnectionString()
        {
            const string StandardTeil = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=";
            const string DesignTimePfad = "C:\\Users\\Lukas\\source\\repos\\Tauchershop\\Tauchershop\\";
            const string DatenbankDatei = "TauchShop.accdb";
            string VerbindungsStr;
            VerbindungsStr = StandardTeil;

            // Design-Time oder Run-Time?
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                // Design-Time
                VerbindungsStr += DesignTimePfad;
            }
            else
            {
                // Run-Time
                VerbindungsStr += AppDomain.CurrentDomain.BaseDirectory;
            }

            VerbindungsStr += DatenbankDatei;
            return VerbindungsStr;
        }
        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        public DataView GetDataViewArtikel()
        {
            LoescheSortierung(DataViewArtikel);
            return DataViewArtikel;
        }

        public DataView GetDataViewKunden()
        {
            LoescheSortierung(DataViewKunden);
            return DataViewKunden;
        }

        public DataView GetDataViewLieferanten()
        {
            LoescheSortierung(DataViewLieferanten);
            return DataViewLieferanten;
        }

        public DataView GetDataViewMitarbeiter()
        {
            LoescheSortierung(DataViewMitarbeiter);
            return DataViewMitarbeiter;
        }

        public DataView GetDataViewAuftraege()
        {
            LoescheSortierung(DataViewAuftraege);
            return DataViewAuftraege;
        }

        public DataView GetDataViewPositionen()
        {
            LoescheSortierung(DataViewPositionen);
            return DataViewPositionen;
        }

        public DataView GetDataViewPositionenNachAuftrag(int AuftragsNr)
        {
            DataView View = GetDataViewPositionen();
            View.RowFilter = string.Format("AuftragsNr='{0}'", AuftragsNr);
            return View;
        }

        private void LoescheSortierung(DataView View)
        {
            BindingListCollectionView BindingView;
            View.Sort = "";
            BindingView = (BindingListCollectionView)(CollectionViewSource.GetDefaultView(View));
            BindingView.SortDescriptions.Clear();
            BindingView.Refresh();
        }
    }
}
