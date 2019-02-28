using pv03_Ade_Prianto_1700502.Model;
using pv03_Ade_Prianto_1700502.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pv03_Ade_Prianto_1700502
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        public void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int ind = e.RowIndex;
            DataGridViewRow selectedRows = dataGridView1.Rows[ind];
            tbIdDelete.Text = selectedRows.Cells[0].Value.ToString();
            tbIdUpdate.Text = selectedRows.Cells[0].Value.ToString();

            tbIdUpdate.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TodoRepository todo = new TodoRepository();

            tbNim.Enabled = false;

            string nim = tbNim.Text;

            btnAdd.Enabled = true;
            submitNim.Enabled = false;

            if (todo.checkNim(nim) == 1)
            {
                dataGridView1.DataSource = todo.getByNim(nim);
            }
            else
            {
                MessageBox.Show("Nim Tidak Ada Di Tabel Mahasiswa");
            }
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Todo temp = new Todo();

            temp.NimMhs = tbNim.Text;
            temp.Nama = tbNama.Text; 
            temp.Kategori = tbKategori.Text;

            TodoRepository todo = new TodoRepository();

            todo.addTodo(temp);

            string nim = tbNim.Text;

            dataGridView1.DataSource = todo.getByNim(nim);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(tbIdDelete.Text);

            TodoRepository todo = new TodoRepository();

            todo.delTodo(id);

            string nim = tbNim.Text;

            dataGridView1.DataSource = todo.getByNim(nim);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(tbIdUpdate.Text);

            Todo temp = new Todo();
            temp.Nama = tbNamaUpdate.Text;
            temp.Kategori = tbKategoriUpdate.Text;

            TodoRepository todo = new TodoRepository();

            todo.updateTodo(temp, id);

            string nim = tbNim.Text;

            dataGridView1.DataSource = todo.getByNim(nim);
        }
    }
}
