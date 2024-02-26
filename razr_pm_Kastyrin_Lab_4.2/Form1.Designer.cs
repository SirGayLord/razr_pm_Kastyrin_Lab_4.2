namespace razr_pm_Kastyrin_Lab_4._2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ReadArrayFromFileButton = new Button();
            GenerateRandomArrayButton = new Button();
            ArrayTextBox = new TextBox();
            BinarySearchRadioButton = new RadioButton();
            SequentialSearchRadioButton = new RadioButton();
            label1 = new Label();
            label2 = new Label();
            SearchTextBox = new TextBox();
            SearchButton = new Button();
            ResultLabel = new Label();
            SuspendLayout();
            // 
            // ReadArrayFromFileButton
            // 
            ReadArrayFromFileButton.Location = new Point(38, 42);
            ReadArrayFromFileButton.Name = "ReadArrayFromFileButton";
            ReadArrayFromFileButton.Size = new Size(150, 40);
            ReadArrayFromFileButton.TabIndex = 0;
            ReadArrayFromFileButton.Text = "Загрузить массив из файла";
            ReadArrayFromFileButton.UseVisualStyleBackColor = true;
            ReadArrayFromFileButton.Click += button1_Click;
            // 
            // GenerateRandomArrayButton
            // 
            GenerateRandomArrayButton.Location = new Point(38, 114);
            GenerateRandomArrayButton.Name = "GenerateRandomArrayButton";
            GenerateRandomArrayButton.Size = new Size(150, 40);
            GenerateRandomArrayButton.TabIndex = 1;
            GenerateRandomArrayButton.Text = "Сгенерировать массив";
            GenerateRandomArrayButton.UseVisualStyleBackColor = true;
            GenerateRandomArrayButton.Click += GenerateRandomArrayButton_Click;
            // 
            // ArrayTextBox
            // 
            ArrayTextBox.Location = new Point(275, 42);
            ArrayTextBox.Multiline = true;
            ArrayTextBox.Name = "ArrayTextBox";
            ArrayTextBox.Size = new Size(353, 61);
            ArrayTextBox.TabIndex = 2;
            ArrayTextBox.KeyPress += ArrayTextBox_KeyPress;
            // 
            // BinarySearchRadioButton
            // 
            BinarySearchRadioButton.AutoSize = true;
            BinarySearchRadioButton.Location = new Point(38, 254);
            BinarySearchRadioButton.Name = "BinarySearchRadioButton";
            BinarySearchRadioButton.Size = new Size(118, 19);
            BinarySearchRadioButton.TabIndex = 3;
            BinarySearchRadioButton.TabStop = true;
            BinarySearchRadioButton.Text = "Бинарный поиск";
            BinarySearchRadioButton.UseVisualStyleBackColor = true;
            // 
            // SequentialSearchRadioButton
            // 
            SequentialSearchRadioButton.AutoSize = true;
            SequentialSearchRadioButton.Location = new Point(38, 296);
            SequentialSearchRadioButton.Name = "SequentialSearchRadioButton";
            SequentialSearchRadioButton.Size = new Size(168, 19);
            SequentialSearchRadioButton.TabIndex = 4;
            SequentialSearchRadioButton.TabStop = true;
            SequentialSearchRadioButton.Text = "Последовательный поиск";
            SequentialSearchRadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 215);
            label1.Name = "label1";
            label1.Size = new Size(128, 15);
            label1.TabIndex = 5;
            label1.Text = "Выберите тип поиска:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(275, 127);
            label2.Name = "label2";
            label2.Size = new Size(215, 15);
            label2.TabIndex = 6;
            label2.Text = "Введите число, которое нужно найти:";
            // 
            // SearchTextBox
            // 
            SearchTextBox.Location = new Point(275, 160);
            SearchTextBox.Multiline = true;
            SearchTextBox.Name = "SearchTextBox";
            SearchTextBox.Size = new Size(215, 50);
            SearchTextBox.TabIndex = 7;
            // 
            // SearchButton
            // 
            SearchButton.Location = new Point(334, 236);
            SearchButton.Name = "SearchButton";
            SearchButton.Size = new Size(78, 32);
            SearchButton.TabIndex = 8;
            SearchButton.Text = "Поиск";
            SearchButton.UseVisualStyleBackColor = true;
            SearchButton.Click += SearchButton_Click;
            // 
            // ResultLabel
            // 
            ResultLabel.AutoSize = true;
            ResultLabel.Location = new Point(275, 287);
            ResultLabel.Name = "ResultLabel";
            ResultLabel.Size = new Size(63, 15);
            ResultLabel.TabIndex = 9;
            ResultLabel.Text = "Результат:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 468);
            Controls.Add(ResultLabel);
            Controls.Add(SearchButton);
            Controls.Add(SearchTextBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(SequentialSearchRadioButton);
            Controls.Add(BinarySearchRadioButton);
            Controls.Add(ArrayTextBox);
            Controls.Add(GenerateRandomArrayButton);
            Controls.Add(ReadArrayFromFileButton);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ReadArrayFromFileButton;
        private Button GenerateRandomArrayButton;
        private TextBox ArrayTextBox;
        private RadioButton BinarySearchRadioButton;
        private RadioButton SequentialSearchRadioButton;
        private Label label1;
        private Label label2;
        private TextBox SearchTextBox;
        private Button SearchButton;
        private Label ResultLabel;
    }
}