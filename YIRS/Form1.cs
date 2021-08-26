using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YIRS
{
    public partial class Form1 : Form
    {
        public int size;
        public int[] array;
        public Form1()
        {
            InitializeComponent();
            
        }


        //метод для рекурсивного бинарного поиска
        int BinarySearch(int[] array, int searchedValue, int first, int last)
        {
            var stopWatch = Stopwatch.StartNew(); // начало отсчета таймера
            //средний индекс подмассива
            var middle = first + (last - first) / 2;
            //значение в средине подмассива
            var middleValue = array[middle];
           // MessageBox.Show("M" + middle + "  V" + middleValue);


            //границы сошлись
            if (first > last)
            {
                //элемент не найден
                // MessageBox.Show("first" + first + "  last" + last);
                stopWatch.Stop();
                label4.Text = stopWatch.ElapsedMilliseconds.ToString(); // в милисекундах 
                return -1;
               
            }

           
            if (middleValue == searchedValue)
            {
                stopWatch.Stop();
                label4.Text = stopWatch.ElapsedTicks.ToString(); // в тиках (1 тик = 100нс)
                return middle;
            }
            else
            {
                if (middleValue > searchedValue)
                {
                    //рекурсивный вызов поиска для левого подмассива
                  //  MessageBox.Show(" Больше" );
                    return BinarySearch(array, searchedValue, first, middle - 1);
                    

                }
                else
                {
                    //рекурсивный вызов поиска для правого подмассива
                   // MessageBox.Show("Меньше");
                    return BinarySearch(array, searchedValue, middle + 1, last);
                    
                }
            }

             
        }
         int[] BubbleSort(int[] mas)
        {
            var stopWatch = Stopwatch.StartNew(); // начало отсчета таймера
                                                 

            int temp;
            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i] > mas[j])
                    {
                        temp = mas[i];
                        mas[i] = mas[j];
                        mas[j] = temp;
                    }
                }

            }

            stopWatch.Stop();

            label3.Text = stopWatch.ElapsedMilliseconds.ToString(); // в милисекундах  

            return mas;

        }
      
        private void Button1_Click(object sender, EventArgs e)
        {
            size = Convert.ToInt32(textBox1.Text);
            array = new int[size];
            int temp;
            Random rand = new Random();
            for (int y = 0; y < size; y++)
            {
                temp = rand.Next(1, size+1);
                if (!array.Contains(temp))
                {
                    array[y] = temp;
                }
                else
                {
                    y-=1;
                }
            }
           // listBox1.Items.AddRange(Convert.ToString(array));
            listBox1.Items.Clear();

            for (int i = 0; i < array.Length; i++)
            {
                listBox1.Items.Add(array[i].ToString());
            }
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            BubbleSort(array);
            

            for (int i = 0; i < array.Length; i++)
            {
                listBox2.Items.Add(array[i].ToString());
            }


        }

        private void Button3_Click(object sender, EventArgs e)
        {
         
                var k = Convert.ToInt32(textBox2.Text);
                
                var searchResult = BinarySearch(array, k, 0, array.Length - 1);
            
            if (searchResult < 0)
                {
                MessageBox.Show(" "+ searchResult);
                MessageBox.Show("Элемент со значением " + k + " не найден");
                }
                else
                {
                    MessageBox.Show("Элемент найден. Индекс элемента со значением " + k + " равен " + searchResult);
                    searchResult = 0;
                }
            
        }
    }
}
