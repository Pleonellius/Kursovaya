using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Kursovaya
{
    public partial class Form1 : Form
    {
        string id_selected_ima;
        string id_selected_special;
        string id_selected_staj;
        string id_selected_kabinet;
        public void GetSelectedIDString()
        {
            //Переменная для индекс выбранной строки в гриде
            string index_selected_ima;
            string index_selected_special;
            string index_selected_staj;
            string index_selected_kabinet;
            //Индекс выбранной строки
            index_selected_ima = dataGridView1.SelectedCells[1].RowIndex.ToString();
            index_selected_special = dataGridView1.SelectedCells[2].RowIndex.ToString();
            index_selected_staj = dataGridView1.SelectedCells[3].RowIndex.ToString();
            index_selected_kabinet = dataGridView1.SelectedCells[5].RowIndex.ToString();
            //ID конкретной записи в Базе данных, на основании индекса строки
            id_selected_ima = dataGridView1.Rows[Convert.ToInt32(index_selected_ima)].Cells[1].Value.ToString();
            id_selected_special = dataGridView1.Rows[Convert.ToInt32(index_selected_special)].Cells[2].Value.ToString();
            id_selected_staj = dataGridView1.Rows[Convert.ToInt32(index_selected_staj)].Cells[3].Value.ToString();
            id_selected_kabinet = dataGridView1.Rows[Convert.ToInt32(index_selected_kabinet)].Cells[5].Value.ToString();
        }
        public Form1()
        {
            InitializeComponent();
        }
        //Переменная соединения
        MySqlConnection conn;
        //DataAdapter представляет собой объект Command , получающий данные из источника данных.
        private MySqlDataAdapter MyDA = new MySqlDataAdapter();
        //Объявление BindingSource, основная его задача, это обеспечить унифицированный доступ к источнику данных.
        private BindingSource bSource = new BindingSource();
        //DataSet - расположенное в оперативной памяти представление данных, обеспечивающее согласованную реляционную программную 
        //модель независимо от источника данных.DataSet представляет полный набор данных, включая таблицы, содержащие, упорядочивающие 
        //и ограничивающие данные, а также связи между таблицами.
        private DataSet ds = new DataSet();
        //Представляет одну таблицу данных в памяти.
        private DataTable table = new DataTable();
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
        public void GetListUsers()
        {
            //Запрос для вывода строк в БД
            string commandStr = "SELECT IMAVraha AS 'ФИО', Special AS 'Специальность', staj AS 'Стаж', obrazovanie AS 'Образование', kabinet AS 'Кабинет' FROM Vrahi";
            //Открываем соединение
            conn.Open();
            //Объявляем команду, которая выполнить запрос в соединении conn
            MyDA.SelectCommand = new MySqlCommand(commandStr, conn);
            //Заполняем таблицу записями из БД
            MyDA.Fill(table);
            //Указываем, что источником данных в bindingsource является заполненная выше таблица
            bSource.DataSource = table;
            //Указываем, что источником данных ДатаГрида является bindingsource 
            dataGridView1.DataSource = bSource;
            //Закрываем соединение
            conn.Close();
        }

        private void button1_BackgroundImageLayoutChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            // строка подключения к БД
            string connStr = "server=caseum.ru;port=33333;user=st_2_1_19;database=st_2_1_19;password=68201560;";
            // создаём объект для подключения к БД
            conn = new MySqlConnection(connStr);
            //Вызываем метод для заполнение дата Грида
            GetListUsers();
            //Видимость полей в гриде
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[2].Visible = true;
            dataGridView1.Columns[3].Visible = true;
            //Ширина полей
            dataGridView1.Columns[1].FillWeight = 40;
            dataGridView1.Columns[2].FillWeight = 15;
            dataGridView1.Columns[3].FillWeight = 15;
            //Режим для полей "Только для чтения"
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[2].ReadOnly = true;
            dataGridView1.Columns[3].ReadOnly = true;
            //Растягивание полей грида
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //Убираем заголовки строк
            dataGridView1.RowHeadersVisible = false;
            //Показываем заголовки столбцов
            dataGridView1.ColumnHeadersVisible = true;
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!e.RowIndex.Equals(-1) && !e.ColumnIndex.Equals(-1) && e.Button.Equals(MouseButtons.Left))
            {
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];

                dataGridView1.CurrentRow.Selected = true;
                
            }
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripComboBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (toolStripComboBox1.SelectedIndex)
            {
                
                case 0:
                    bSource.Filter =  "";
                    break;
                case 1:
                    bSource.Filter = $"[Специальность] LIKE'" + "Хирург" + "%'";
                    break;
                case 2:
                    bSource.Filter = $"[Специальность] LIKE'" + "Дерматолог" + "%'";
                    break;
                case 3:
                    bSource.Filter = $"[Специальность] LIKE'" + "Окулист" + "%'";
                    break;
                case 4:
                    bSource.Filter = $"[Специальность] LIKE'" + "Терапевт" + "%'";
                    break;
            }
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
           
            bSource.Filter = "[Специальность] LIKE'" + toolStripTextBox1.Text + "%'";
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Selected == true)
            {
                //Объявляем переменную для передачи значения в другую форму
                string variable = id_selected_ima;
                string ae = id_selected_special;
                string ue = id_selected_staj;
                string vae = id_selected_kabinet;
                //Класс SomeClass объявлен в файле Program.cs, в нём объявлено простое поле. Наша задача, присвоить этому полю значение, 
                //а в другой форме его вытащить.
                SomeClass.variable_class = variable;
                SomeClass.new_inserted_id = ae;
                SomeClass.new_inserted_mainOrder_id = ue;
                SomeClass.aeee = vae;
                Form5 frm = new Form5();
                frm.ShowDialog();

            }
        }
    }
}
