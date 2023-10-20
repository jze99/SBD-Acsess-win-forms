using bd3.testDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace bd3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testDataSet1.Отчисленные". При необходимости она может быть перемещена или удалена.
            this.отчисленныеTableAdapter.Fill(this.testDataSet1.Отчисленные);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testDataSet1.п340". При необходимости она может быть перемещена или удалена.
            this.п340TableAdapter.Fill(this.testDataSet1.п340);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "testDataSet.Отчисленные". При необходимости она может быть перемещена или удалена.
            this.отчисленныеTableAdapter.Fill(this.testDataSet1.Отчисленные);
            this.п340TableAdapter.Fill(this.testDataSet1.п340);
            dataGridView2.Visible = false;
            Return.Visible = false;
            dell.Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                DialogResult drе = MessageBox.Show("Нет записей", "Лол", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.OK)
            {
                if (dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells != null)
                {
                    DataRow nRow = testDataSet1.Tables[0].NewRow();
                    int rc = dataGridView2.RowCount + 1;
                    nRow[0] = rc;
                    nRow[1] = testDataSet1.Tables[1].Rows[dataGridView1.CurrentRow.Index][1];
                    nRow[2] = testDataSet1.Tables[1].Rows[dataGridView1.CurrentRow.Index][2];
                    nRow[3] = testDataSet1.Tables[1].Rows[dataGridView1.CurrentRow.Index][3];
                    nRow[4] = testDataSet1.Tables[1].Rows[dataGridView1.CurrentRow.Index][4];
                    testDataSet1.Tables[0].Rows.Add(nRow);
                    отчисленныеTableAdapter.Update(testDataSet1);
                    testDataSet1.Tables[0].AcceptChanges();
                    dataGridView2.Refresh();
                    отчисленныеTableAdapter.Fill(testDataSet1.Отчисленные);

                    dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                    п340TableAdapter.Update(testDataSet1);
                    testDataSet1.Tables[1].AcceptChanges();
                    dataGridView1.Refresh();
                    п340TableAdapter.Fill(testDataSet1.п340);
                }
            }
        }

        private void add_Click(object sender, EventArgs e)
        {
            AddForm af = new AddForm();
            af.Owner = this;
            af.Show();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0 && dataGridView2.SelectedRows.Count == 0)
            {
                DialogResult drе = MessageBox.Show("Нет записей", "Лол", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ChangeForm af = new ChangeForm();
            af.Owner = this;
            af.Show();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            п340TableAdapter.Update(testDataSet1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = true;
            Return.Visible = true;
            dell.Visible = true;
            database.Text = "Отчисленные";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
            Return.Visible = false;
            dell.Visible = false;
            database.Text = "П340";
        }

        private void Return_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                DialogResult drе = MessageBox.Show("Нет записей", "Лол", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult dr = MessageBox.Show("Вернуть запись?", "Возвращение", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.OK)
            {
                if (dataGridView2.Rows[dataGridView2.CurrentRow.Index].Cells != null)
                {
                    DataRow nRow = testDataSet1.Tables[1].NewRow();
                    int rc = dataGridView1.RowCount + 1;
                    nRow[0] = rc;
                    nRow[1] = testDataSet1.Tables[0].Rows[dataGridView2.CurrentRow.Index][1];
                    nRow[2] = testDataSet1.Tables[0].Rows[dataGridView2.CurrentRow.Index][2];
                    nRow[3] = testDataSet1.Tables[0].Rows[dataGridView2.CurrentRow.Index][3];
                    nRow[4] = testDataSet1.Tables[0].Rows[dataGridView2.CurrentRow.Index][4];
                    testDataSet1.Tables[1].Rows.Add(nRow);
                    п340TableAdapter.Update(testDataSet1);
                    testDataSet1.Tables[1].AcceptChanges();
                    dataGridView1.Refresh();
                    п340TableAdapter.Fill(testDataSet1.п340);

                    dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
                    отчисленныеTableAdapter.Update(testDataSet1);
                    testDataSet1.Tables[0].AcceptChanges();
                    dataGridView2.Refresh();
                    отчисленныеTableAdapter.Fill(testDataSet1.Отчисленные);
                }
            }
        }

        private void dell_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 0)
            {
                DialogResult drе = MessageBox.Show("Нет записей", "Лол", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult dr = MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dr == DialogResult.OK)
            {
                dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
                отчисленныеTableAdapter.Update(testDataSet1);
                testDataSet1.Tables[0].AcceptChanges();
                dataGridView2.Refresh();
                отчисленныеTableAdapter.Fill(testDataSet1.Отчисленные);
            }
        }
    }
}
