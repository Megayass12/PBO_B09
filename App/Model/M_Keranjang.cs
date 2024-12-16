using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COBA2.App.Model
{
    public class M_Keranjang
    {
        public List<M_Produk> Products { get; set; } = new List<M_Produk>();
        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }

        public void AddProduct(M_Produk product)
        {
            Products.Add(product);
            UpdateCartSummary();
        }

        public void RemoveProduct(M_Produk product)
        {
            Products.Remove(product);
            UpdateCartSummary();
        }

        private void UpdateCartSummary()
        {
            TotalQuantity = Products.Sum(p => p.Quantity);
            TotalPrice = Products.Sum(p => p.harga * p.Quantity);
        }
    }
}
