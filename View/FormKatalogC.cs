using COBA2.App.Context;
using COBA2.App.Core;
using COBA2.App.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace COBA2.View
{
    public partial class FormKatalogC : Form
    {
        public int userId;
        private Dictionary<string, int> kuantitas = new Dictionary<string, int>();

        public FormKatalogC(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView2.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
        }

        public void FormKatalogC_Load(object sender, EventArgs e)
        {
            LoadPupukData(dataGridView1);
            LoadBenihData(dataGridView2);
        }

        private void AddNoColumns(DataGridView targetGrid)
        {
            if (targetGrid.Columns["nomor"] == null)
            {
                DataGridViewTextBoxColumn nomorColumn = new DataGridViewTextBoxColumn
                {
                    HeaderText = "No",
                    Name = "nomor",
                    DisplayIndex = 0 
                };
                targetGrid.Columns.Add(nomorColumn);
            }
        }

        private void ResetCustomColumns(DataGridView targetGrid)
        {
            if (targetGrid.Columns["nomor"] != null)
                targetGrid.Columns.Remove("nomor");
            if (targetGrid.Columns["Tambah"] != null)
                targetGrid.Columns.Remove("Tambah");
            if (targetGrid.Columns["Kuantitas"] != null)
                targetGrid.Columns.Remove("Kuantitas");
            if (targetGrid.Columns["Kurang"] != null)
                targetGrid.Columns.Remove("Kurang");
        }

        private void AddAddLessColumns(DataGridView targetGrid)
        {
            if (targetGrid.Columns["Tambah"] == null)
            {
                DataGridViewButtonColumn tambahButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "Tambah",
                    HeaderText = "Tambahh",
                    Text = "+",
                    UseColumnTextForButtonValue = true,
                    DisplayIndex = 6 
                };
                targetGrid.Columns.Add(tambahButtonColumn);
            }

            
            if (targetGrid.Columns["Kuantitas"] == null)
            {
                DataGridViewTextBoxColumn kuantitasColumn = new DataGridViewTextBoxColumn
                {
                    Name = "Kuantitas",
                    HeaderText = "Kuantitas",
                    DisplayIndex = 5, 
                    ReadOnly = true,
                    ValueType = typeof(int),
                };
                targetGrid.Columns.Add(kuantitasColumn);

                
                foreach (DataGridViewRow row in targetGrid.Rows)
                {
                    row.Cells["Kuantitas"].Value = 0;
                }
            }

            
            if (targetGrid.Columns["Kurang"] == null)
            {
                DataGridViewButtonColumn kurangButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "Kurang",
                    HeaderText = "Kurang",
                    Text = "-",
                    UseColumnTextForButtonValue = true,
                    DisplayIndex = 4 
                };
                targetGrid.Columns.Add(kurangButtonColumn);
            }
        }

        private void LoadPupukData(DataGridView targetGrid)
        {
            try
            {
                ResetCustomColumns(targetGrid);
        
                DataTable pupukData = DatabaseWrapper.GetPupukData();

                dataGridView1.DataSource = pupukData; 

                if (dataGridView1.Columns["id_produk"] != null) dataGridView1.Columns["id_produk"].Visible = false;
                if (dataGridView1.Columns["id_kategori"] != null) dataGridView1.Columns["id_kategori"].Visible = false;
                if (dataGridView1.Columns["id_statusproduk"] != null) dataGridView1.Columns["id_statusproduk"].Visible = false;
                if (dataGridView1.Columns["nama_produk"] != null)
                    dataGridView1.Columns["nama_produk"].HeaderText = "Nama Produk";
                if (dataGridView1.Columns["harga"] != null)
                    dataGridView1.Columns["harga"].HeaderText = "Harga";
                if (dataGridView1.Columns["deskripsi_produk"] != null)
                    dataGridView1.Columns["deskripsi_produk"].HeaderText = "Deskripsi";
                if (dataGridView1.Columns["stok"] != null) dataGridView1.Columns["stok"].Visible = false;
                
                


                AddNoColumns(dataGridView1);
                AddAddLessColumns(dataGridView1);

                UpdateQuantityValues(dataGridView1, "id_produk");

               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDashCust frmDashCust = new FormDashCust(userId);
            frmDashCust.ShowDialog();
        }

        private void LoadBenihData(DataGridView targetGrid)
        {
            try
            {
                
                ResetCustomColumns(targetGrid);
                
                DataTable BenihData = DatabaseWrapper.GetBenihData();

                dataGridView2.DataSource = BenihData; 

                if (dataGridView2.Columns["id_produk"] != null) dataGridView2.Columns["id_produk"].Visible = false;
                if (dataGridView2.Columns["id_kategori"] != null) dataGridView2.Columns["id_kategori"].Visible = false;
                if (dataGridView2.Columns["id_statusproduk"] != null) dataGridView2.Columns["id_statusproduk"].Visible = false;
                if (dataGridView2.Columns["nama_produk"] != null)
                    dataGridView2.Columns["nama_produk"].HeaderText = "Nama Produk";
                if (dataGridView2.Columns["harga"] != null)
                    dataGridView2.Columns["harga"].HeaderText = "Harga";
                if (dataGridView2.Columns["deskripsi_produk"] != null)
                    dataGridView2.Columns["deskripsi_produk"].HeaderText = "Deskripsi";
                if (dataGridView2.Columns["stok"] != null) dataGridView2.Columns["stok"].Visible = false;


                AddNoColumns(dataGridView2);
                AddAddLessColumns(dataGridView2);

                UpdateQuantityValues(dataGridView2, "id_produk");

              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void UpdateQuantityValues(DataGridView grid, string idColumnName)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (!row.IsNewRow)
                {
                    if (row.Cells[idColumnName] != null && row.Cells[idColumnName].Value != null)
                    {
                        string id = row.Cells[idColumnName].Value.ToString();
                        row.Cells["nomor"].Value = row.Index + 1;

                        
                        int quantity = kuantitas.ContainsKey(id) ? kuantitas[id] : 0;
                        row.Cells["Kuantitas"].Value = quantity;
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Ambil data dari kedua DataGridView
            List<M_Produk> pupukData = GetProductsFromGrid(dataGridView1);
            List<M_Produk> benihData = GetProductsFromGrid(dataGridView2);

            // Gabungkan kedua data
            List<M_Produk> allProducts = new List<M_Produk>();
            allProducts.AddRange(pupukData);
            allProducts.AddRange(benihData);

            // Filter hanya produk yang kuantitasnya > 0
            List<M_Produk> selectedProducts = allProducts.FindAll(product => product.Quantity > 0);

            if (selectedProducts.Count == 0)
            {
                MessageBox.Show("Tidak ada produk yang dipilih. Silakan tambahkan produk terlebih dahulu.");
                return;
            }

            //Hitung total harga
            decimal totalHarga = 0;

            foreach (var produk in allProducts)
            {
                totalHarga += produk.harga * produk.Quantity;
            }

            // Tampilkan detail barang dan total harga
            string detailBarang = "Detail Barang yang Dipilih:\n\n";
            foreach (var product in selectedProducts)
            {
                detailBarang += $"{product.nama_produk} - Qty: {product.Quantity} x Rp {product.harga:N0} = Rp {(product.Quantity * product.harga):N0}\n";
            }

            detailBarang += $"\nTotal Harga: Rp {totalHarga:N0}";

            // Tampilkan detail barang dan total harga
            DialogResult result = MessageBox.Show(detailBarang, "Konfirmasi Pembelian", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                // Simpan data ke database PostgreSQL
                bool sukses = DatabaseWrapper.SimpanTransaksi(userId, selectedProducts, totalHarga);

                if (sukses)
                {
                    MessageBox.Show("Transaksi berhasil disimpan.");
                    this.Close(); 
                    FormDashCust formDashCust = new FormDashCust(userId);
                    formDashCust.ShowDialog();
                }
                else
                {
                   
                    MessageBox.Show(userId.ToString());
                }
            }
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void HandleCellClick(DataGridView grid, int rowIndex, int columnIndex)
        {
            if (rowIndex >= 0)
            {
                string columnName = grid.Columns[columnIndex].Name;
                string id = grid.Rows[rowIndex].Cells["id_produk"].Value.ToString();

                if (columnName == "Tambah")
                {
                    int currentQuantity = Convert.ToInt32(grid.Rows[rowIndex].Cells["Kuantitas"].Value);
                    int stok = Convert.ToInt32(grid.Rows[rowIndex].Cells["stok"].Value);

                    if (currentQuantity < stok) // Pastikan kuantitas tidak melebihi stok
                    {
                        grid.Rows[rowIndex].Cells["Kuantitas"].Value = currentQuantity + 1;
                        kuantitas[id] = currentQuantity + 1;
                        UpdateTotal();
                    }
                    else
                    {
                        MessageBox.Show("Kuantitas tidak dapat melebihi stok tersedia.");
                    }
                    
                }
                else if (columnName == "Kurang")
                {
                    int currentQuantity = Convert.ToInt32(grid.Rows[rowIndex].Cells["Kuantitas"].Value);

                    if (currentQuantity > 0)
                    {
                        grid.Rows[rowIndex].Cells["Kuantitas"].Value = currentQuantity - 1;
                        kuantitas[id] = currentQuantity - 1;
                        UpdateTotal();
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HandleCellClick(dataGridView1, e.RowIndex, e.ColumnIndex);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HandleCellClick(dataGridView2, e.RowIndex, e.ColumnIndex);
        }

        private void UpdateTotal()
        {
            int totalQuantity = 0;
            foreach (var quantity in kuantitas.Values)
            {
                totalQuantity += quantity;
            }
            // Update total
            label1.Text = totalQuantity.ToString();
        }

        private List<M_Produk> GetProductsFromGrid(DataGridView grid)
        {
            List<M_Produk> products = new List<M_Produk>();

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (!row.IsNewRow) // Skip empty/new rows
                {
                    int id = Convert.ToInt32(row.Cells["id_produk"].Value ?? 0);  // Assuming "id" is the column name for Id
                    string namaProduk = row.Cells["nama_produk"].Value?.ToString();  // Adjust based on your actual column name
                    decimal harga = Convert.ToDecimal(row.Cells["harga"].Value ?? 0);
                    string deskripsiProduk = row.Cells["deskripsi_produk"].Value?.ToString(); // Assuming "deskripsi_produk" is the column name
                    int stok = Convert.ToInt32(row.Cells["stok"].Value ?? 0);
                    int kuantitas = Convert.ToInt32(row.Cells["Kuantitas"].Value ?? 0);

                    // Create a new M_Produk object and add it to the list
                    M_Produk produk = new M_Produk(id, namaProduk, harga, deskripsiProduk, stok, 0)
                    {
                        Quantity = kuantitas // Update the quantity as well
                    };

                    products.Add(produk);
                }
            }

            return products;
        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
