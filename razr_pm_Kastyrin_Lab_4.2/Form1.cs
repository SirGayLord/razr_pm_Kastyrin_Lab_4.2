using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace razr_pm_Kastyrin_Lab_4._2
{
    public partial class Form1 : Form
    {
        private int[] array; // Объявляем массив как поле класса
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ArrayTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем ввод только цифр, знака минус, запятой и пробелов
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != ',' && e.KeyChar != ' ')
            {
                e.Handled = true; // Игнорируем ввод символа
            }

            // Проверяем, чтобы не вводилось два пробела подряд
            if (e.KeyChar == ' ' && (ArrayTextBox.Text.Length == 0 || ArrayTextBox.Text.EndsWith(" ") || ArrayTextBox.Text.EndsWith(",")))
            {
                e.Handled = true; // Игнорируем ввод пробела
            }

            // Проверяем, чтобы минус мог быть только в начале числа
            if (e.KeyChar == '-' && ArrayTextBox.Text.IndexOf('-') != -1)
            {
                e.Handled = true; // Игнорируем ввод дополнительного минуса
            }

            // Вставляем запятую и пробел после каждого введенного числа
            if (char.IsDigit(e.KeyChar))
            {
                if (ArrayTextBox.Text.Length > 0 && !char.IsControl(ArrayTextBox.Text[ArrayTextBox.Text.Length - 1]) && ArrayTextBox.Text[ArrayTextBox.Text.Length - 1] != ',' && ArrayTextBox.Text[ArrayTextBox.Text.Length - 1] != ' ')
                {
                    ArrayTextBox.Text += ", ";
                    ArrayTextBox.SelectionStart = ArrayTextBox.Text.Length;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) // открывает текстовый файл на компьютере
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Text Files|*.txt";
            openFileDialog1.Title = "Select a Text File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog1.FileName;
                    string fileContent = File.ReadAllText(filePath).Trim(); // Удаляем лишние пробелы в начале и конце файла

                    // Проверяем, содержит ли строка запятые и пробелы между числами
                    if (fileContent.Contains(", ") || fileContent.Contains(",")) // Если разделитель уже есть, ничего не изменяем
                    {
                        ArrayTextBox.Text = fileContent;
                    }
                    else // Если разделителей нет, добавляем их
                    {
                        string[] numbers = fileContent.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries); // Разбиваем строку на числа
                        string formattedContent = string.Join(", ", numbers); // Объединяем числа с запятыми как разделителями
                        ArrayTextBox.Text = formattedContent;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading the file: " + ex.Message);
                }
            }
        }

        private void GenerateRandomArrayButton_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            int arraySize = 10; // Размер массива

            ArrayTextBox.Clear(); // Очистка текстового поля перед генерацией новых значений

            // Генерация случайных чисел и их форматированное добавление в текстовое поле
            for (int i = 0; i < arraySize; i++)
            {
                int randomNumber = random.Next(-100, 101); // Генерация чисел от -100 до 100

                if (i > 0) // Добавляем запятую и пробел перед каждым числом, кроме первого
                {
                    ArrayTextBox.Text += ", ";
                }

                ArrayTextBox.Text += randomNumber.ToString();
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SearchTextBox.Text)) // Проверяем, введено ли значение для поиска
            {
                MessageBox.Show("Пожалуйста, введите значение для поиска.");
                return;
            }

            if (!string.IsNullOrEmpty(ArrayTextBox.Text)) // Проверяем, есть ли массив чисел для поиска
            {
                string arrayText = ArrayTextBox.Text;
                string searchValueText = SearchTextBox.Text;

                int[] array;
                try
                {
                    array = arrayText.Split(',').Select(int.Parse).ToArray(); // Преобразуем строку массива чисел в массив int
                }
                catch (FormatException)
                {
                    MessageBox.Show("Введите корректный массив чисел, разделенных запятыми.");
                    return;
                }

                int searchValue;
                if (!int.TryParse(searchValueText, out searchValue))
                {
                    MessageBox.Show("Введите корректное значение для поиска.");
                    return;
                }

                int result = -1;

                if (BinarySearchRadioButton.Checked) // Выбираем тип поиска: бинарный или последовательный
                {
                    result = BinarySearch(array, searchValue);
                }
                else if (SequentialSearchRadioButton.Checked)
                {
                    result = SequentialSearch(array, searchValue);
                }
                else
                {
                    MessageBox.Show("Выберите тип поиска.");
                }

                displayResult(result, searchValue); // Передаем найденное значение поиска в displayResult
            }
            else
            {
                MessageBox.Show("Введите массив для поиска.");
            }
        }

        private void displayResult(int result, int searchValue)
        {
            if (result != -1)
            {
                string arrayText = ArrayTextBox.Text;
                List<int> numbers = new List<int>();

                foreach (string num in arrayText.Split(',')) // Извлекаем числа из строки массива и добавляем их в список
                {
                    if (int.TryParse(num, out int parsedNum))
                    {
                        numbers.Add(parsedNum);
                    }
                }

                if (numbers.Any())
                {
                    int minVal = numbers.Min();
                    int maxVal = numbers.Max();

                    int minIndex = numbers.IndexOf(minVal) + 1; // Получаем позицию минимального значения
                    int maxIndex = numbers.IndexOf(maxVal) + 1; // Получаем позицию максимального значения

                    ResultLabel.Text = $"Результат: Значение {searchValue} найдено на позиции {result + 1}." + Environment.NewLine; // Форматируем результат для отображения в ResultLabel
                    ResultLabel.Text += $"Минимальное значение: {minVal} (на позиции {minIndex})" + Environment.NewLine;
                    ResultLabel.Text += $"Максимальное значение: {maxVal} (на позиции {maxIndex})";
                }
                else
                {
                    ResultLabel.Text = "Массив не содержит чисел.";
                }
            }
            else
            {
                ResultLabel.Text = "Значение не найдено.";
            }
        }

        private int BinarySearch(int[] array, int value)
        {
            int[] sortedArray = (int[])array.Clone(); // Создаем копию массива для сортировки
            Array.Sort(sortedArray); // Сортируем массив

            int left = 0;
            int right = sortedArray.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (sortedArray[mid] == value)
                {
                    // Находим индекс в исходном массиве
                    int originalIndex = Array.IndexOf(array, sortedArray[mid]);
                    return originalIndex; // Возвращаем индекс найденного элемента в исходном неотсортированном массиве
                }

                if (sortedArray[mid] < value)
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }

            return -1; // Возврат - 1, если элемент не найден
        }

        private int SequentialSearch(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    return i; // Возвращаем индекс найденного элемента
                }
            }

            return -1;
        }
    }
}