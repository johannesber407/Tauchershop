using System;
using System.Data;
using System.Data.OleDb;
using System.Windows;
using System.Windows.Data;
using Tauchershop.TauchShopDataSetTableAdapters;

namespace Tauchershop
{
    //Class TDatenbank
    //public class TDatenbank : DependencyObject
    //{
    //    private static TauchShopDataSet Datenbank;
    //    private static ArtikelTableAdapter AdapterArtikel;
    //    private static DataView DataViewArtikel;
    //    private static bool Initialisiert = false;
    //    public TDatenbank()
    //    {
    //        if (!Initialisiert)
    //        {
    //            InitialisiereDatenbank();
    //            Initialisiert = true;
    //        }
    //    }

    //    private void InitialisiereDatenbank()
    //    {
    //        OleDbConnection Verbindung;
    //        // Datenbank anlegen
    //        Datenbank = new TauchShopDataSet();
    //        // Verbindung
    //        Verbindung = new OleDbConnection(ConnectionString());
    //        // Artikel
    //        AdapterArtikel = new ArtikelTableAdapter();
    //        AdapterArtikel.Connection = Verbindung;
    //        AdapterArtikel.Fill(Datenbank.Artikel);
    //        DataViewArtikel = Datenbank.Artikel.DefaultView;
    //    }
    //    // +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    //    private string ConnectionString()
    //    {
    //        const string StandardTeil = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=";
    //        //const string DesignTimePfad = "H:\\<Design-Time-Pfad>\\TauchShop\\";
    //        const string DesignTimePfad = "C:\\Users\\Lukas\\source\\repos\\Tauchershop\\Tauchershop";
    //        const string DatenbankDatei = "TauchShop.accdb";
    //        string VerbindungsStr;
    //        VerbindungsStr = StandardTeil;
    //        // Design-Time oder Run-Time?
    //        if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
    //        {
    //            // Bei Design-Time absoluten Pfad setzen
    //            VerbindungsStr += DesignTimePfad;
    //        }
    //        else
    //        {
    //            // Bei Run-Time Exe-Pfad ermitteln
    //            VerbindungsStr += AppDomain.CurrentDomain.BaseDirectory;
    //        }
    //        VerbindungsStr += DatenbankDatei;
    //        return VerbindungsStr;
    //    }

    //    public DataView GetDataViewArtikel()
    //    {
    //        LoescheSortierung(DataViewArtikel);
    //        return DataViewArtikel;
    //    }

    //    private void LoescheSortierung(DataView View)
    //    {
    //        BindingListCollectionView BindingView;
    //        View.Sort = "";
    //        BindingView = (BindingListCollectionView)(CollectionViewSource.GetDefaultView(View));
    //        BindingView.SortDescriptions.Clear();
    //        BindingView.Refresh();
    //    }
    //}
}