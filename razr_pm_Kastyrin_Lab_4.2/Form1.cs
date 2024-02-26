using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;


namespace razr_pm_Kastyrin_Lab_4._2
{
    public partial class Form1 : Form
    {
        private int[] array; // ��������� ������ ��� ���� ������
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ArrayTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // ��������� ���� ������ ����, ����� �����, ������� � ��������
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-' && e.KeyChar != ',' && e.KeyChar != ' ')
            {
                e.Handled = true; // ���������� ���� �������
            }

            // ���������, ����� �� ��������� ��� ������� ������
            if (e.KeyChar == ' ' && (ArrayTextBox.Text.Length == 0 || ArrayTextBox.Text.EndsWith(" ") || ArrayTextBox.Text.EndsWith(",")))
            {
                e.Handled = true; // ���������� ���� �������
            }

            // ���������, ����� ����� ��� ���� ������ � ������ �����
            if (e.KeyChar == '-' && ArrayTextBox.Text.IndexOf('-') != -1)
            {
                e.Handled = true; // ���������� ���� ��������������� ������
            }

            // ��������� ������� � ������ ����� ������� ���������� �����
            if (char.IsDigit(e.KeyChar))
            {
                if (ArrayTextBox.Text.Length > 0 && !char.IsControl(ArrayTextBox.Text[ArrayTextBox.Text.Length - 1]) && ArrayTextBox.Text[ArrayTextBox.Text.Length - 1] != ',' && ArrayTextBox.Text[ArrayTextBox.Text.Length - 1] != ' ')
                {
                    ArrayTextBox.Text += ", ";
                    ArrayTextBox.SelectionStart = ArrayTextBox.Text.Length;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) // ��������� ��������� ���� �� ����������
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Text Files|*.txt";
            openFileDialog1.Title = "Select a Text File";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string filePath = openFileDialog1.FileName;
                    string fileContent = File.ReadAllText(filePath).Trim(); // ������� ������ ������� � ������ � ����� �����

                    // ���������, �������� �� ������ ������� � ������� ����� �������
                    if (fileContent.Contains(", ") || fileContent.Contains(",")) // ���� ����������� ��� ����, ������ �� ��������
                    {
                        ArrayTextBox.Text = fileContent;
                    }
                    else // ���� ������������ ���, ��������� ��
                    {
                        string[] numbers = fileContent.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries); // ��������� ������ �� �����
                        string formattedContent = string.Join(", ", numbers); // ���������� ����� � �������� ��� �������������
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
            int arraySize = 10; // ������ �������

            ArrayTextBox.Clear(); // ������� ���������� ���� ����� ���������� ����� ��������

            // ��������� ��������� ����� � �� ��������������� ���������� � ��������� ����
            for (int i = 0; i < arraySize; i++)
            {
                int randomNumber = random.Next(-100, 101); // ��������� ����� �� -100 �� 100

                if (i > 0) // ��������� ������� � ������ ����� ������ ������, ����� �������
                {
                    ArrayTextBox.Text += ", ";
                }

                ArrayTextBox.Text += randomNumber.ToString();
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SearchTextBox.Text)) // ���������, ������� �� �������� ��� ������
            {
                MessageBox.Show("����������, ������� �������� ��� ������.");
                return;
            }

            if (!string.IsNullOrEmpty(ArrayTextBox.Text)) // ���������, ���� �� ������ ����� ��� ������
            {
                string arrayText = ArrayTextBox.Text;
                string searchValueText = SearchTextBox.Text;

                int[] array;
                try
                {
                    array = arrayText.Split(',').Select(int.Parse).ToArray(); // ����������� ������ ������� ����� � ������ int
                }
                catch (FormatException)
                {
                    MessageBox.Show("������� ���������� ������ �����, ����������� ��������.");
                    return;
                }

                int searchValue;
                if (!int.TryParse(searchValueText, out searchValue))
                {
                    MessageBox.Show("������� ���������� �������� ��� ������.");
                    return;
                }

                int result = -1;

                if (BinarySearchRadioButton.Checked) // �������� ��� ������: �������� ��� ����������������
                {
                    result = BinarySearch(array, searchValue);
                }
                else if (SequentialSearchRadioButton.Checked)
                {
                    result = SequentialSearch(array, searchValue);
                }
                else
                {
                    MessageBox.Show("�������� ��� ������.");
                }

                displayResult(result, searchValue); // �������� ��������� �������� ������ � displayResult
            }
            else
            {
                MessageBox.Show("������� ������ ��� ������.");
            }
        }

        private void displayResult(int result, int searchValue)
        {
            if (result != -1)
            {
                string arrayText = ArrayTextBox.Text;
                List<int> numbers = new List<int>();

                foreach (string num in arrayText.Split(',')) // ��������� ����� �� ������ ������� � ��������� �� � ������
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

                    int minIndex = numbers.IndexOf(minVal) + 1; // �������� ������� ������������ ��������
                    int maxIndex = numbers.IndexOf(maxVal) + 1; // �������� ������� ������������� ��������

                    ResultLabel.Text = $"���������: �������� {searchValue} ������� �� ������� {result + 1}." + Environment.NewLine; // ����������� ��������� ��� ����������� � ResultLabel
                    ResultLabel.Text += $"����������� ��������: {minVal} (�� ������� {minIndex})" + Environment.NewLine;
                    ResultLabel.Text += $"������������ ��������: {maxVal} (�� ������� {maxIndex})";
                }
                else
                {
                    ResultLabel.Text = "������ �� �������� �����.";
                }
            }
            else
            {
                ResultLabel.Text = "�������� �� �������.";
            }
        }

        private int BinarySearch(int[] array, int value)
        {
            int[] sortedArray = (int[])array.Clone(); // ������� ����� ������� ��� ����������
            Array.Sort(sortedArray); // ��������� ������

            int left = 0;
            int right = sortedArray.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (sortedArray[mid] == value)
                {
                    // ������� ������ � �������� �������
                    int originalIndex = Array.IndexOf(array, sortedArray[mid]);
                    return originalIndex; // ���������� ������ ���������� �������� � �������� ����������������� �������
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

            return -1; // ������� - 1, ���� ������� �� ������
        }

        private int SequentialSearch(int[] array, int value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == value)
                {
                    return i; // ���������� ������ ���������� ��������
                }
            }

            return -1;
        }
    }
}