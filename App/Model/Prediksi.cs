using System;

namespace COBA2.App.Model
{
    public class Prediksi
    {
        // Properti private
        private double LuasLahan { get; set; }
        private string Komoditas { get; set; }
        private string JenisPupuk { get; set; }

        // Konstruktor untuk menginisialisasi nilai
        public Prediksi(double luasLahan, string komoditas, string jenisPupuk)
        {
            LuasLahan = luasLahan;
            Komoditas = komoditas;
            JenisPupuk = jenisPupuk;
        }

        // Metode untuk menghitung prediksi
        public double HitungPrediksi()
        {
            // Konversi luas lahan ke hektar
            double luasLahanHektar = LuasLahan / 10000;

            // Tentukan kebutuhan pupuk per hektar berdasarkan komoditas dan jenis pupuk
            double kebutuhanPerHektar = (Komoditas, JenisPupuk) switch
            {
                ("Padi", "Phonska") => 300,
                ("Padi", "Urea") => 250,
                ("Padi", "NPK") => 200,
                ("Jagung", "Phonska") => 280,
                ("Jagung", "Urea") => 230,
                ("Jagung", "NPK") => 190,
                ("Jeruk", "Phonska") => 320,
                ("Jeruk", "Urea") => 270,
                ("Jeruk", "NPK") => 220,
                ("Tomat", "Phonska") => 290,
                ("Tomat", "Urea") => 240,
                ("Tomat", "NPK") => 210,
                _ => 0 // Default jika tidak ada kecocokan
            };

            // Hitung total kebutuhan pupuk
            return luasLahanHektar * kebutuhanPerHektar;
        }
    }
}
