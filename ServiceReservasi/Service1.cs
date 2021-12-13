using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceReservasi
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service : IService1
    {
        string constring = "Data Source=DESKTOP-RB36HA3/UNANG;Initial Catalog=WCFReservasi;Persist Security Info=True;User ID=sa;Password=123";
        SqlConnection connection;
        SqlCommand com;

        public List<Lokasi> Lokasi()
        {
            List<Lokasi> LokasiFull = new List<Lokasi>();
            try
            {
                string sql = "select ID_Lokasi, Nama_Lokasi, Deskripsi_Singkat, Deskripsi_Full, Kuota from dbo.Lokasi";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Lokasi data = new Lokasi();
                    data.ID_Lokasi = reader.GetString(0);
                    data.Nama_Lokasi = reader.GetString(1);
                    data.Deskripsi_Singkat = reader.GetString(2);
                    data.Deskripsi_Full = reader.GetString(3);
                    data.Kuota = reader.GetInt32(3);
                    LokasiFull.Add(data);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return LokasiFull;
        }

        public string pemesanan(string ID_Reservasi, string Nama_Customer, string No_Telpon, int Jumlah_Pemesanan, string ID_Lokasi)
        {
            string a = "gagal";
            try
            {
                string sql = "insert into dbo.pemesanan values ('" + ID_Reservasi + "', '" + Nama_Customer + "','" + No_Telpon + "','" + Jumlah_Pemesanan + "','" + ID_Lokasi + "')";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }


        public string editPemesanan(string ID_Reservasi, string Nama_Customer)
        {
            string a = "gagal";
            try
            {
                string sql = "delete from dbo.Pemesanan where ID_reservasi = '" + ID_Reservasi + "'";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
            
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public List<Pemesanan> Pemesanan()
        {
            List<Pemesanan> pemesanans = new List<Pemesanan>();
            try
            {
                string sql = " select ID_reservasi, Nama_customer, No_telpon, " + "Jumlah_pemesanan, Nama_Lokasi from dbo.Pemesanan p join dbo.Lokasi l on p.ID_lokasi = l.ID_lokasi";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Pemesanan data = new Pemesanan();
                    data.ID_Pemesanan = reader.GetString(0);
                    data.Nama_Customer = reader.GetString(1);
                    data.No_Telpon = reader.GetString(2);
                    data.Jumlah_Pemesanan = reader.GetInt32(3);
                    
                    pemesanans.Add(data);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return pemesanans;
        }
            public List<CekLokasi> ReviewLokasi()
        {
            throw new NotImplementedException();
        }

        public List<Lokasi> DetailLokasi()
        {
            throw new NotImplementedException();
        }

        public string deletePemesanan(string IDPemesanan)
        {
            throw new NotImplementedException();
        }
    }
}