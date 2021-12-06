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

        public string deletePemesanan(string ID_Reservasi)
        {
            throw new NotImplementedException();
        }

        public List<Lokasi> Lokasi()
        {
            List<Lokasi> LokasiFull = new List<Lokasi>();
            try
            {
                string sql = "select ID_Lokasi, Nama_lokasi, Deskripsi_Singkat, Deskripsi_Full, Kuota from dbo.Lokasi";
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

        public string editPemesanan(string ID_Reservasi, string Nama_Customer)
        {
            throw new NotImplementedException();
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
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
                a = "sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }

        public List<Pemesanan> Pemesanan()
        {
            throw new NotImplementedException();
        }

        public List<CekLokasi> ReviewLokasi()
        {
            throw new NotImplementedException();
        }

        public List<Lokasi> DetailLokasi()
        {
            throw new NotImplementedException();
        }
    }
}