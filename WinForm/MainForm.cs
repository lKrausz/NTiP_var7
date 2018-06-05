using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;
using NTiP_var7;

namespace WinForm
{
    //TODO: отключить в datagridview воможность пользователю вводить данные вручную, отключить столбец для выделения строк (САМЫЙ первый столбец с треугольничком)
    public partial class MainForm : Form
    {
        //newtonsoft JSON.NET
        public MainForm()
        {
            InitializeComponent();
        }

        //TODO: не нужна, см. замечания в бизнес-логике
        Complex j = Complex.ImaginaryOne;
        //TODO: неправильное именование закрытого поля
        private uint w;
        //TODO: неправильное именование закрытого поля
        private List<IPassiveElement> elements = new List<IPassiveElement>(); //IBindingSource

        private void Add_Click(object sender, EventArgs e)
        {
            NewObjectOnForm NewForm = new NewObjectOnForm();
            if (NewForm.ShowDialog() == DialogResult.OK)
            {
                var element = NewForm.Element;
                elements.Add(element);
                int n = dataGridView1.Rows.Add();
                //TODO: не надо в таблице показывать собственные значения элементов, только общие данные, 
                // которые есть у ВСЕХ IPassiveElement - это тип данных и это импеданс, 
                // рассчитанный для определенной частоты. Других столбцов не надо
                //TODO: Для отображения Inductance, Resistor и Capacitor надо перегрузить метод ToString() 
                // у классов бизнес-логики и вызывать здесь этот метод. 
                // Иначе СИЛЬНО усложняется поддержка программы - если появятся новые элементы, 
                // то разработчику нужно будет не только добавлять новый класс, 
                // но еще лазить исправлять твои if-ы по всей программе.
                if (element is Inductance inductance)
                {
                    dataGridView1.Rows[n].Cells[1].Value = "Inductance";
                    dataGridView1.Rows[n].Cells[2].Value = "L = " + (inductance.L);
                }
                else if (element is Resistor resistor)
                {
                    dataGridView1.Rows[n].Cells[1].Value = "Resistor";
                    dataGridView1.Rows[n].Cells[2].Value = "R = " + (resistor.R);
                }
                else if (element is Capacitor capacitor)
                {
                    dataGridView1.Rows[n].Cells[1].Value = "Capacitor";
                    dataGridView1.Rows[n].Cells[2].Value = "C = " + (capacitor.C);
                }
            }
            //TODO: Вся суть в том, чтобы MainForm НИЧЕГО не знала о конкретных видах элементов. 
            // Только про интерфейс IPassiveElement. Тогда главная форма становится независимой - 
            // её не придется переписывать каждый раз, когда у тебя появятся или удалятся элементы в программе. 
            // В этом и заключается вся суть ООП - сделать каждый класс максимально независимым от остальных.
            // Тогда программу легко поддерживать и модифицировать. Поэтому подобных if-ов быть не должно
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //TODO: Надо удалять не только в таблице, но и в списке elements, нет?
            dataGridView1.Rows.RemoveAt(e.RowIndex);
            //TODO: А почему удаление происходит при КЛИКЕ на ячейку? 
            // Разве это должно быть не по нажатию на кнопку Remove? Исправить!
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            w = (Convert.ToUInt32(WValueTextBox.Text));
            //TODO: Не работает - выходит за пределы списка
            int n = 1;
            //TODO: Забудь про while, он плохо читаем и используется редко
            // Заменить на foreach!
            while (n <= elements.Count)
            {
                //TODO: Зачем ты преобразуешь каждый элемент в конкретный тип данных,
                // если к методу ComplexImpedances() можно обратиться через интерфейс IPassiveElement?
                // Сделала полиморфизм и не пользуешься им. Заменить без if-ов
                if (elements[n] is Inductance inductance)
                {
                    dataGridView1.Rows[n].Cells[3].Value = inductance.ComplexImpedances(j, w);
                }
                else if (elements[n] is Resistor resistor)
                {
                    dataGridView1.Rows[n].Cells[3].Value = resistor.ComplexImpedances(j, w);
                }
                else if (elements[n] is Capacitor capacitor)
                {
                    dataGridView1.Rows[n].Cells[3].Value = capacitor.ComplexImpedances(j, w);
                }
                n++;
            }
        }
    }
}
