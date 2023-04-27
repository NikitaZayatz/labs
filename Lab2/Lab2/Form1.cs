using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;


namespace Lab2
{
    public partial class Form1 : Form
    {
        private CMS_LS cms = new CMS_LS();


        public Form1()
        {
            InitializeComponent();
            btnModify.Enabled = false;
            button2.Enabled = false;
            btnSaveLS.Enabled = false;
        }       

        private void Form1_Load(object sender, EventArgs e)
        {
          /*  Asap.File_Load("start_param.txt");
            Asap.Planning();
            ViewResults(); */           
        }

        private void ViewResults()
        {    
            //LS
            // шаги
            richTextBox2.Text = "Всего шагов: " + (cms.steps.Count - 1);

            for (int i = 0; i < cms.steps.Count; i++)
            {
                richTextBox2.Text += "\nНа " + (i) + " шаге запланированы следующие операции: ";

                for (int k = 0; k < cms.steps[i].Count; k++)
                {
                    richTextBox2.Text += " " + (cms.steps[i][k] + 1);
                }
                richTextBox2.Text += "\nСостояние списка: ( ";
                for (int t = 0; t < cms.List_operations_on_steps[i][0].Count; t++)
                {
                    if (t == cms.List_operations_on_steps[i][0].Count - 1)
                        richTextBox2.Text += (cms.List_operations_on_steps[i][0][t] + 1) + " ";
                    else
                        richTextBox2.Text += (cms.List_operations_on_steps[i][0][t] + 1) + ", ";
                }
                richTextBox2.Text += "| ";
                for (int t = 0; t < cms.List_operations_on_steps[i][1].Count; t++)
                {
                    if (t == cms.List_operations_on_steps[i][1].Count - 1)
                        richTextBox2.Text += (cms.List_operations_on_steps[i][1][t] + 1) + " ";
                    else
                        richTextBox2.Text += (cms.List_operations_on_steps[i][1][t] + 1) + ", ";
                }
                richTextBox2.Text += ")";

            }
        }

        private void viewInitData() { 

            // типы операций

            dataGridView1.ColumnCount = cms.countTypes + 1;
            dataGridView1.RowCount = cms.countOperations + 3;
            dataGridView1.Rows[0].Cells[0].Value = "Operation \\  type";
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            for (int i = -1; i < cms.countTypes; i++)
            {
                dataGridView1.Rows[0].Cells[i + 1].Style.BackColor = Color.FromArgb(255, 247, 0);
                if (i > -1)
                {
                    dataGridView1.Rows[0].Cells[i + 1].Value = i + 1;
                    dataGridView1.Columns[i + 1].Width = 32;
                }
            }

            for (int i = 0; i < cms.countOperations; i++)
            {
                dataGridView1.Rows[i + 1].Cells[0].Style.BackColor = Color.FromArgb(255, 247, 0);
                dataGridView1.Rows[i + 1].Cells[0].Value = i + 1;
                
            }

            for (int i = 0; i < cms.countTypes; i++)
            {
                for (int k = 0; k < cms.arrayTypes[i].Length; k++)
                {
                    dataGridView1.Rows[cms.arrayTypes[i][k]].Cells[i + 1].Style.BackColor = Color.FromArgb(255, 15, 192);
                }
            }
            dataGridView1.Rows[cms.countOperations + 1].Cells[0].Value = "Кол-во процессоров";
            dataGridView1.Rows[cms.countOperations + 1].Cells[0].Style.BackColor = Color.Aquamarine;
            for (int i = 0; i < cms.countTypes; i++)
            {
                dataGridView1.Rows[cms.countOperations + 1].Cells[i+1].Style.BackColor = Color.Aquamarine;
                dataGridView1.Rows[cms.countOperations + 1].Cells[i+1].Value = cms.countProcessorsByTypes[i];
            }
            dataGridView1.Rows[cms.countOperations + 2].Cells[0].Value = "Время выполнения операции";
            dataGridView1.Rows[cms.countOperations + 2].Cells[0].Style.BackColor = Color.Aquamarine;
            for (int i = 0; i < cms.countTypes; i++)
            {
                dataGridView1.Rows[cms.countOperations + 2].Cells[i + 1].Style.BackColor = Color.Aquamarine;
                dataGridView1.Rows[cms.countOperations + 2].Cells[i + 1].Value = cms.TimeCalculationByTypes[i];
            }
            // матрица смежности
            dataGridView2.ColumnCount = cms.countOperations + 1;
            dataGridView2.RowCount = cms.countOperations + 1;            
            dataGridView2.ColumnHeadersVisible = false;
            dataGridView2.RowHeadersVisible = false;           

            for (int i = 0; i < cms.countOperations + 1; i++)
            {
                // по вертикали
                dataGridView2.Rows[i].Cells[0].Style.BackColor = Color.FromArgb(255, 247, 0);
                dataGridView2.Rows[i].Cells[0].Value = i;
                // по горизонали
                dataGridView2.Rows[0].Cells[i].Style.BackColor = Color.FromArgb(255, 247, 0);
                dataGridView2.Rows[0].Cells[i].Value = i;
                dataGridView2.Columns[i].Width = 50;
            }

            dataGridView2.Rows[0].Cells[0].Value = "Operation \\  operation";
            for (int i = 0; i < cms.countOperations; i++)
            {
                for (int k = 0; k < cms.arrayH[i].Length; k++)
                {
                    if (cms.arrayH[i][k] == 1)
                    {
                        dataGridView2.Rows[i + 1].Cells[k + 1].Style.BackColor = Color.FromArgb(252, 15, 192);
                    }
                }
            }
        }

        private void ClearView()
        {
            dataGridView1.ColumnCount = 1;
            dataGridView1.RowCount = 1;
            dataGridView2.ColumnCount = 1;
            dataGridView2.RowCount = 1;            
        }

      
        private void button2_Click_1(object sender, EventArgs e)
        {
            cms.Planning();
            ViewResults();
            btnSaveLS.Enabled = true;
        }

        private void btnRead_Click(object sender, EventArgs e)
        {
            cms.Clear_Object();
            ClearView();
            string filePath;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "txt files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
            }
            else return;
            cms.File_Load(filePath);
            viewInitData();
            btnModify.Enabled = true;
            button2.Enabled = true;
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < cms.countOperations; i++)
            {
                for (int k = 0; k < cms.arrayH[i].Length; k++)
                {
                    if (dataGridView2.Rows[i + 1].Cells[k + 1].Value != null)
                    {
                        if (dataGridView2.Rows[i + 1].Cells[k + 1].Value.ToString() == "1")
                        {
                            dataGridView2.Rows[i + 1].Cells[k + 1].Value = "";
                            dataGridView2.Rows[i + 1].Cells[k + 1].Style.BackColor = Color.FromArgb(252, 15, 192);
                            cms.arrayH[i][k] = 1;
                        }
                        else
                        if (dataGridView2.Rows[i + 1].Cells[k + 1].Value.ToString() == "0")
                        {
                            dataGridView2.Rows[i + 1].Cells[k + 1].Value = "";
                            dataGridView2.Rows[i + 1].Cells[k + 1].Style.BackColor = Color.FromArgb(255, 255, 255);
                            cms.arrayH[i][k] = 0;
                        }
                    }
                }
            }
            for (int i = 0; i < cms.countTypes; i++)
            {
                string proc = dataGridView1.Rows[cms.countOperations + 1].Cells[i + 1].Value.ToString();
                cms.countProcessorsByTypes[i]=Int32.Parse(proc);
                string time = dataGridView1.Rows[cms.countOperations + 2].Cells[i + 1].Value.ToString();
                cms.TimeCalculationByTypes[i] = Int32.Parse(time);
            }
            for (int i = 0; i < cms.countTypes; i++)
            {
                for (int k = 0; k < cms.arrayTypes[i].Length; k++)
                {
                    if (dataGridView1.Rows[k + 1].Cells[i + 1].Value != null)
                    {
                        if (dataGridView1.Rows[k + 1].Cells[i + 1].Value.ToString() == "1")
                        {
                            dataGridView1.Rows[k + 1].Cells[i + 1].Value = "";
                            dataGridView1.Rows[k + 1].Cells[i + 1].Style.BackColor = Color.FromArgb(252, 15, 192);
                            cms.arrayTypes[i][k] = 1;
                            for (int j = 0; j < cms.countTypes; j++)
                                if (j!=i)
                                {
                                    dataGridView1.Rows[k + 1].Cells[j + 1].Style.BackColor = Color.FromArgb(255, 255, 255);
                                    cms.arrayTypes[j][k] = 0;
                                }
                        }
                    }
                }
            }
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для изменения типа операции, в таблице типов операций поставьте 1 в столбце ссответствующей операции.\nДля редактирования матрицы смежности, поставьте 1 или 0 в ячейке, значение которой необходимо изменить", "Редактирование исходных данных");
        }

        private void btnSaveLS_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            string filePath;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog.FileName;
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    writer.WriteLine(richTextBox2.Text);
                }
            }
        }
    }
}
