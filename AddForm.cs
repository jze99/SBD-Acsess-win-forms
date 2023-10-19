using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace bd3
{
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void add_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            if (main != null)
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    DialogResult drе = MessageBox.Show("Неверная запись", "Лол", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                DataRow nRow = main.testDataSet1.Tables[1].NewRow();
                int rc = main.dataGridView1.RowCount + 1;
                nRow[0] = rc;
                nRow[1] = textBox1.Text;
                nRow[2] = textBox2.Text;
                nRow[3] = textBox3.Text;
                nRow[4] = dateTimePicker1.Text;
                main.testDataSet1.Tables[1].Rows.Add(nRow);
                main.п340TableAdapter.Update(main.testDataSet1.п340);
                main.testDataSet1.Tables[1].AcceptChanges();
                main.dataGridView1.Refresh();
                main.п340TableAdapter.Fill(main.testDataSet1.п340);
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                dateTimePicker1.Text = "";
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((TextBox)sender).Text.Length == 1)
                ((TextBox)sender).Text = ((TextBox)sender).Text.ToUpper();
            ((TextBox)sender).Select(((TextBox)sender).Text.Length, 0);
            if (e.KeyChar == (int)Keys.Space) e.KeyChar = '\0';
            else e.Handled = e.KeyChar != (char)Keys.Back && !char.IsSeparator(e.KeyChar) && !char.IsLetter(e.KeyChar) || char.IsNumber(e.KeyChar);

        }
    }
}
