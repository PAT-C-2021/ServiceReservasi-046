namespace ServiceReservasi
{
    public class Lokasi
    {
        public string ID_Lokasi { get; internal set; }
        public string Deskripsi_Singkat { get; internal set; }
        public string Nama_Lokasi { get; internal set; }
        public string Deskripsi_Full { get; internal set; }
        public int Kuota { get; internal set; }
    }
}