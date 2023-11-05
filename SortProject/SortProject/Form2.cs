using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SortProject
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (size == 0)
            {
                MessageBox.Show("Пожалуйста, сначала сгенерируйте массив.");
                return;
            }

            int[] array = textBox2.Text.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToArray();

            // Очищаем список с шагами сортировки перед новой сортировкой
            sortSteps.Clear();

            if (radioButton1.Checked)
            {
                InsertionSort(array);
            }
            else if (radioButton2.Checked)
            {
                RadixSort(array);
            }
            else if (radioButton3.Checked)
            {
                CombSort(array);
            }

            // Отображаем отсортированный массив в textBox3
            textBox3.Text = string.Join(", ", array);

            // Обновляем listBox2 с шагами сортировки
            UpdateListBox2();
        }
        private void UpdateListBox2()
        {
            listBox2.Items.Clear();
            listBox2.Items.AddRange(sortSteps.ToArray());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private int size;


        private void button2_Click_1(object sender, EventArgs e)
        {

            // Проверяем, введен ли корректный размер массива
            if (!int.TryParse(textBox1.Text, out size) || size < 0 || size > 20)
            {
                MessageBox.Show("Пожалуйста, введите корректный размер массива (от 0 до 20).");
                return;
            }

            // Создаем массив случайных чисел
            int[] array = GenerateRandomArray(size);

            // Отображаем сгенерированный массив в textBox2
            textBox2.Text = string.Join(", ", array);
        }

        private int[] GenerateRandomArray(int size)
        {
            Random random = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(100); // Генерируем случайные числа от 0 до 99
            }
            return array;
        }

        private List<string> sortSteps = new List<string>();

        private void InsertionSort(int[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                }

                array[j + 1] = key;
                string stepDescription = $"Перемещение элемента {key} на позицию {j + 1}.";
                sortSteps.Add(stepDescription);

            }
        }

        private void RadixSort(int[] array)
        {
            int max = array.Max();
            for (int exp = 1; max / exp > 0; exp *= 10)
                CountSort(array, exp);
            for (int i = 0; i < array.Length; i++)
            {
                string stepDescription = $"Перемещение элемента {array[i]} на позицию {i + 1}.";
                sortSteps.Add(stepDescription);
            }

        }

        private void CountSort(int[] array, int exp)
        {
            int[] output = new int[array.Length];
            int[] count = new int[10];

            for (int i = 0; i < 10; i++)
                count[i] = 0;

            for (int i = 0; i < array.Length; i++)
                count[(array[i] / exp) % 10]++;

            for (int i = 1; i < 10; i++)
                count[i] += count[i - 1];

            for (int i = array.Length - 1; i >= 0; i--)
            {
                output[count[(array[i] / exp) % 10] - 1] = array[i];
                count[(array[i] / exp) % 10]--;
            }

            for (int i = 0; i < array.Length; i++)
                array[i] = output[i];
        }



        private void CombSort(int[] array)
        {
            int gap = array.Length;
            bool swapped = true;

            while (gap > 1 || swapped)
            {
                gap = GetNextGap(gap);

                swapped = false;

                for (int i = 0; i < array.Length - gap; i++)
                {
                    if (array[i] > array[i + gap])
                    {
                        Swap(ref array[i], ref array[i + gap]);
                        swapped = true;

                        string stepDescription = $"Swapping elements {array[i]} and {array[i + gap]}.";
                        sortSteps.Add(stepDescription);
                    }
                }

            }
        }

        private int GetNextGap(int gap)
        {
            gap = (gap * 10) / 13;
            if (gap < 1)
                return 1;
            return gap;
        }

        private void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }


        


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (size == 0)
            {
                MessageBox.Show("Пожалуйста, сначала сгенерируйте массив.");
                return;
            }

            int[] array = textBox2.Text.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries)
                                      .Select(int.Parse)
                                      .ToArray();

            // Вызываем метод сортировки (например, InsertionSort)
            InsertionSort(array);
            
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Form3 form3 = new Form3();
                form3.Show();
            }
            else if (radioButton2.Checked)
            {
                Form4 form4 = new Form4();
                form4.Show();
            }
            else if (radioButton3.Checked)
            {
                Form5 form5 = new Form5();
                form5.Show();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
        }
    }
}
