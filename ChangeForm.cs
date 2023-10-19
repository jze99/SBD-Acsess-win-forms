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

namespace bd3
{
    public partial class ChangeForm : Form
    {
        public ChangeForm()
        {
            InitializeComponent();
        }

        

        private void ChangeForm_Load(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            if (main.dataGridView1.Rows[main.dataGridView1.CurrentRow.Index].Cells != null && main.dataGridView1.Visible!= false)
            {
                textBox1.Text = main.dataGridView1.Rows[main.dataGridView1.CurrentRow.Index].Cells[1].Value.ToString();
                textBox2.Text = main.dataGridView1.Rows[main.dataGridView1.CurrentRow.Index].Cells[2].Value.ToString();
                textBox3.Text = main.dataGridView1.Rows[main.dataGridView1.CurrentRow.Index].Cells[3].Value.ToString();
                dateTimePicker1.Text = main.dataGridView1.Rows[main.dataGridView1.CurrentRow.Index].Cells[4].Value.ToString();
            }
            else if (main.dataGridView2.Rows[main.dataGridView2.CurrentRow.Index].Cells != null && main.dataGridView2.Visible != false)
            {
                textBox1.Text = main.dataGridView2.Rows[main.dataGridView2.CurrentRow.Index].Cells[1].Value.ToString();
                textBox2.Text = main.dataGridView2.Rows[main.dataGridView2.CurrentRow.Index].Cells[2].Value.ToString();
                textBox3.Text = main.dataGridView2.Rows[main.dataGridView2.CurrentRow.Index].Cells[3].Value.ToString();
                dateTimePicker1.Text = main.dataGridView2.Rows[main.dataGridView2.CurrentRow.Index].Cells[4].Value.ToString();
            }
        }

        private void change_Click(object sender, EventArgs e)
        {
            Form1 main = this.Owner as Form1;
            if (main != null)
            {
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    DialogResult drе = MessageBox.Show("Неверная запись", "Лол", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (main.dataGridView1.Rows[main.dataGridView1.CurrentRow.Index].Cells != null && main.dataGridView1.Visible != false)
                {
                    main.testDataSet1.Tables[1].Rows[main.dataGridView1.CurrentRow.Index][1] = textBox1.Text;
                    main.testDataSet1.Tables[1].Rows[main.dataGridView1.CurrentRow.Index][2] = textBox2.Text;
                    main.testDataSet1.Tables[1].Rows[main.dataGridView1.CurrentRow.Index][3] = textBox3.Text;
                    main.testDataSet1.Tables[1].Rows[main.dataGridView1.CurrentRow.Index][4] = dateTimePicker1.Text;
                    main.п340TableAdapter.Update(main.testDataSet1);
                    main.testDataSet1.Tables[1].AcceptChanges();
                    main.dataGridView1.Refresh();
                    main.п340TableAdapter.Fill(main.testDataSet1.п340);
                }
                else if(main.dataGridView2.Rows[main.dataGridView2.CurrentRow.Index].Cells != null && main.dataGridView2.Visible != false)
                {
                    main.testDataSet1.Tables[0].Rows[main.dataGridView2.CurrentRow.Index][1] = textBox1.Text;
                    main.testDataSet1.Tables[0].Rows[main.dataGridView2.CurrentRow.Index][2] = textBox2.Text;
                    main.testDataSet1.Tables[0].Rows[main.dataGridView2.CurrentRow.Index][3] = textBox3.Text;
                    main.testDataSet1.Tables[0].Rows[main.dataGridView2.CurrentRow.Index][4] = dateTimePicker1.Text;
                    main.отчисленныеTableAdapter.Update(main.testDataSet1);
                    main.testDataSet1.Tables[0].AcceptChanges();
                    main.dataGridView2.Refresh();
                    main.отчисленныеTableAdapter.Fill(main.testDataSet1.Отчисленные);
                }
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
