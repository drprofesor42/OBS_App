﻿namespace OBS_App.Data
{
    public class Fakulte
    {
        public int Id { get; set; }
        public string FakulteAd { get; set; }
        public Int32  FakulteOgretmenSayisi { get; set; }
        public Int32 FakulteOgrenciSayisi { get; set; }
        public DateOnly OlusturmaTarihi { get; set; }
        public ICollection<Ogrencis> Ogrencisler { get; set; } = new List<Ogrencis>();
        public ICollection<Bolum> Bolumler { get; set; } = new List<Bolum>();
        public ICollection<Ogretmens> Ogretmensler { get; set; } = new List<Ogretmens>();
        public ICollection<OkulDonemDers> OkulDonemDersler { get; set; } = new List<OkulDonemDers>();
    }
}
