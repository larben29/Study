using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Diagnostics;


namespace Tyuiu.YushkovMI.Task1.V4
{
    public partial class FormLoginAuth_MI : Form
    {
        public string UserName { get; set; }
        private List<Book> books = new List<Book>();
        private string[] imagePaths;
        private int currentIndex = 0;

        public FormLoginAuth_MI()
        {
            InitializeComponent();
            InitializeComboBox();
            LoadImagePaths();
        }
        private void LoadImagePaths()
        {

            string imagePath = Path.Combine(Application.StartupPath, "Photo");


            imagePaths = Directory.GetFiles(imagePath);


            if (imagePaths.Length > 0)
            {
                pictureBox1.ImageLocation = imagePaths[currentIndex];
            }
        }
        private void FormLoginAuth_MI_Load(object sender, EventArgs e)
        {

            UpdateTotalBooksLabel();
        }

        private void UpdateTotalBooksLabel()
        {
            try
            {

                string[] lines = File.ReadAllLines("Books_data.csv");


                int objectCount = lines.Length - 1;

                labelTotalBooks_MI.Text = $"Всего книг в библиотеке: {objectCount}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при чтении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void InitializeComboBox()
        {
            comboBoxSortOptions_MI.Items.Add("Название");
            comboBoxSortOptions_MI.Items.Add("Автор");
            comboBoxSortOptions_MI.Items.Add("Год издания");
            comboBoxSortOptions_MI.Items.Add("Дата добавления");
        }

        private void SetupChart()
        {
            chartBookDates_MI.Series.Clear();
            var series = chartBookDates_MI.Series.Add("Книги добавлены");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            chartBookDates_MI.ChartAreas.Clear();
            chartBookDates_MI.ChartAreas.Add(new System.Windows.Forms.DataVisualization.Charting.ChartArea());

            UpdateChart();
        }
        private void UpdateChart()
        {
            var bookDateGroups = myLibraryBooks
                .GroupBy(b => b.DateAdded.Date)
                .Select(group => new { Date = group.Key, Count = group.Count() })
                .OrderBy(x => x.Date);

            chartBookDates_MI.Series["Книги добавлены"].Points.Clear();
            foreach (var group in bookDateGroups)
            {
                chartBookDates_MI.Series["Книги добавлены"].Points.AddXY(group.Date.ToShortDateString(), group.Count);
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadBooksData();
            LoadMyLibraryBooks();
            SetupChart();
        }

        private void LoadBooksData()
        {
            books.Clear();
            string filePath = "Books_data.csv";
            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var values = line.Split(',');
                        if (values.Length == 4)
                        {
                            books.Add(new Book(values[0].Trim(), values[1].Trim(), int.Parse(values[2].Trim()), DateTime.ParseExact(values[3].Trim(), "yyyy-MM-dd", CultureInfo.InvariantCulture)));
                        }
                    }
                }
            }
            UpdateBooksDataGridView();
        }
        private List<Book> myLibraryBooks = new List<Book>();

        private void LoadMyLibraryBooks()
        {
            myLibraryBooks.Clear();
            string filePath = $"{UserName}_Bibl.csv";
            if (File.Exists(filePath))
            {
                using (var reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var values = line.Split(',');
                        if (values.Length == 4)
                        {
                            myLibraryBooks.Add(new Book(values[0], values[1], int.Parse(values[2]), DateTime.ParseExact(values[3], "yyyy-MM-dd", CultureInfo.InvariantCulture)));
                        }
                    }
                }
            }
            UpdateMyLibraryDataGridView();
        }
        private void AddBookToMyLibrary(Book book)
        {
            string filePath = $"{UserName}_Bibl.csv";
            using (var writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{book.Title},{book.Author},{book.YearPublished},{book.DateAdded:yyyy-MM-dd}");
            }
            myLibraryBooks.Add(book);
            UpdateMyLibraryDataGridView();
        }


        private void UpdateMyLibraryDataGridView()
        {
            dataGridViewMyLibrary_MI.DataSource = myLibraryBooks
                .Select(b => new { b.Title, b.Author, b.YearPublished, b.DateAdded })
                .ToList();
            labelCountMyLibrary_MI.Text = $"Количество книг: {myLibraryBooks.Count}";
        }
        private void RemoveBookFromMyLibrary(int index)
        {
            if (index >= 0 && index < myLibraryBooks.Count)
            {
                myLibraryBooks.RemoveAt(index);
                string filePath = $"{UserName}_Bibl.csv";
                using (var writer = new StreamWriter(filePath))
                {
                    foreach (var book in myLibraryBooks)
                    {
                        writer.WriteLine($"{book.Title},{book.Author},{book.YearPublished},{book.DateAdded:yyyy-MM-dd}");
                    }
                }
                UpdateMyLibraryDataGridView();
            }
        }



        private void AddBookToFile(Book book)
        {
            string filePath = "Books_data.csv";
            using (var writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"{book.Title},{book.Author},{book.YearPublished},{book.DateAdded:yyyy-MM-dd}");
            }
        }


        private void UpdateBooksDataGridView()
        {
            UpdateBooksDataGridView("");
        }

        private void UpdateBooksDataGridView(string filter)
        {
            dataGridViewBookList_MI.DataSource = books
                .Where(b => string.IsNullOrEmpty(filter) || b.Title.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0)
                .Select(b => new { b.Title, b.Author, b.YearPublished, b.DateAdded })
                .ToList();
        }


        private void UpdateStatisticsLabels()
        {
            labelTotalBooks_MI.Text = $"Всего книг: {books.Count}";
            if (books.Count > 0)
            {
                labelMinBooks_MI.Text = $"Минимальное количество книг за день: {books.GroupBy(b => b.DateAdded.Date).Min(g => g.Count())}";
                labelMaxBooks_MI.Text = $"Максимальное количество книг за день: {books.GroupBy(b => b.DateAdded.Date).Max(g => g.Count())}";
            }
        }

        private void comboBoxSortOptions_MI_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxSortOptions_MI.SelectedItem.ToString())
            {
                case "Название":
                    books = books.OrderBy(b => b.Title).ToList();
                    break;
                case "Автор":
                    books = books.OrderBy(b => b.Author).ToList();
                    break;
                case "Год издания":
                    books = books.OrderBy(b => b.YearPublished).ToList();
                    break;
                case "Дата добавления":
                    books = books.OrderByDescending(b => b.DateAdded).ToList();
                    break;
            }
            UpdateBooksDataGridView();
        }

        private void textBoxFilterTitle_MI_TextChanged(object sender, EventArgs e)
        {
            UpdateBooksDataGridView(textBoxFilterTitle_MI.Text);
        }

        private void buttonAddBook_MI_Click(object sender, EventArgs e)
        {
            try
            {
                var title = textBoxTitle_MI.Text.Trim(); // Удаление пробельных символов с обоих концов строки
                var author = textBoxAuthor_MI.Text.Trim();
                var yearPublishedString = textBoxYearPublished_MI.Text.Trim();

                if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) || string.IsNullOrWhiteSpace(yearPublishedString))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int yearPublished = int.Parse(yearPublishedString);
                var dateAdded = DateTime.Now;
                var book = new Book(title, author, yearPublished, dateAdded);

                string folderPath = Path.Combine(Application.StartupPath, "DataBookInfo");
                Directory.CreateDirectory(folderPath); // Создание папки, если не существует

                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Выберите файл книги";
                openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string originalFilePath = openFileDialog.FileName;
                    string fileExtension = Path.GetExtension(originalFilePath); // Получение расширения файла
                    string newFileName = title + fileExtension; // Создание нового имени файла из названия книги и исходного расширения
                    string newFilePath = Path.Combine(folderPath, newFileName); // Полный путь к новому файлу
                    File.Copy(originalFilePath, newFilePath, true); // Копирование и переименование файла

                    string csvPath = Path.Combine(Application.StartupPath, "DataBookInfo.csv");
                    using (StreamWriter sw = new StreamWriter(csvPath, true))
                    {
                        sw.WriteLine($"{title},{author},{yearPublished},{dateAdded:yyyy-MM-dd},{newFilePath}");
                    }

                    books.Add(book);
                    UpdateBooksDataGridView();
                    UpdateTotalBooksLabel();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении книги: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void buttonAddToMyLibrary_MI_Click(object sender, EventArgs e)
        {
            if (dataGridViewBookList_MI.CurrentRow != null)
            {
                int index = dataGridViewBookList_MI.CurrentRow.Index;
                if (index >= 0 && index < books.Count)
                {
                    Book selectedBook = books[index];
                    AddBookToMyLibrary(selectedBook);
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите книгу для добавления", "Ошибка выбора", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        private void buttonDeleteBook_MI_Click(object sender, EventArgs e)
        {
            if (dataGridViewBookList_MI.CurrentRow != null)
            {
                int index = dataGridViewBookList_MI.CurrentRow.Index;
                if (index >= 0 && index < books.Count)
                {
                    books.RemoveAt(index);
                    UpdateBooksDataGridView();
                    UpdateTotalBooksLabel();
                }
            }
        }
        private void buttonRemoveFromMyLibrary_MI_Click(object sender, EventArgs e)
        {
            if (dataGridViewMyLibrary_MI.CurrentRow != null)
            {
                int index = dataGridViewMyLibrary_MI.CurrentRow.Index;
                if (index >= 0 && index < myLibraryBooks.Count)
                {
                    RemoveBookFromMyLibrary(index);
                }
                else
                {
                    MessageBox.Show("Пожалуйста, выберите книгу для удаления", "Ошибка выбора", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void panelDragAuth_MI_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void buttonCloseAuth_MI_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonMinimizeAuth_MI_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void btnPrevious_Click_Click(object sender, EventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                pictureBox1.ImageLocation = imagePaths[currentIndex];
            }
        }

        private void btnNext_Click_Click(object sender, EventArgs e)
        {
            if (currentIndex < imagePaths.Length - 1)
            {
                currentIndex++;
                pictureBox1.ImageLocation = imagePaths[currentIndex];
            }
        }

        private void MainBiblButton_Click(object sender, EventArgs e)
        {
            panelOne.Visible = true;
            panelOne.Enabled = true;
            panelTwo.Visible = false;
            panelTwo.Enabled = false;
            PanelThree.Visible = false;
            PanelThree.Enabled = false;
            panelFour.Visible = false;
            panelFour.Enabled = false;
            panelFive.Visible = false;
            panelFive.Enabled = false;
        }

        private void MyBiblButton_Click(object sender, EventArgs e)
        {
            panelOne.Visible = false;
            panelOne.Enabled = false;
            panelTwo.Visible = true;
            panelTwo.Enabled = true;
            PanelThree.Visible = false;
            PanelThree.Enabled = false;
            panelFour.Visible = false;
            panelFour.Enabled = false;
            panelFive.Visible = false;
            panelFive.Enabled = false;
        }

        private void StatsBiblButton_Click(object sender, EventArgs e)
        {
            UpdateChart();
            panelOne.Visible = false;
            panelOne.Enabled = false;
            panelTwo.Visible = false;
            panelTwo.Enabled = false;
            PanelThree.Visible = true;
            PanelThree.Enabled = true;
            panelFour.Visible = false;
            panelFour.Enabled = false;
            panelFive.Visible = false;
            panelFive.Enabled = false;

        }

        private void ManualBiblData_Click(object sender, EventArgs e)
        {
            panelOne.Visible = false;
            panelOne.Enabled = false;
            panelTwo.Visible = false;
            panelTwo.Enabled = false;
            PanelThree.Visible = false;
            PanelThree.Enabled = false;
            panelFour.Visible = true;
            panelFour.Enabled = true;
            panelFive.Visible = false;
            panelFive.Enabled = false;
        }

        private void AboutBiblButton_Click(object sender, EventArgs e)
        {
            panelOne.Visible = false;
            panelOne.Enabled = false;
            panelTwo.Visible = false;
            panelTwo.Enabled = false;
            PanelThree.Visible = false;
            PanelThree.Enabled = false;
            panelFour.Visible = false;
            panelFour.Enabled = false;
            panelFive.Visible = true;
            panelFive.Enabled = true;
        }

        private void LearningBook_Click(object sender, EventArgs e)
        {
            if (dataGridViewMyLibrary_MI.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите книгу из вашей библиотеки", "Выбор книги", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var title = dataGridViewMyLibrary_MI.CurrentRow.Cells["Title"].Value.ToString();
            var author = dataGridViewMyLibrary_MI.CurrentRow.Cells["Author"].Value.ToString();

            string csvPath = Path.Combine(Application.StartupPath, "DataBookInfo.csv");
            if (File.Exists(csvPath))
            {
                using (var reader = new StreamReader(csvPath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var values = line.Split(',');
                        if (values.Length > 4 && values[0].Equals(title, StringComparison.OrdinalIgnoreCase) && values[1].Equals(author, StringComparison.OrdinalIgnoreCase))
                        {
                            string filePath = values[4]; // Путь к файлу книги
                            string extension = Path.GetExtension(filePath).ToLower();

                            // Определение программы для открытия файла на основе его расширения
                            switch (extension)
                            {
                                case ".txt":
                                    Process.Start("notepad.exe", filePath);
                                    break;
                                case ".pdf":
                                    Process.Start(filePath); // Открыть PDF в программе по умолчанию
                                    break;
                                case ".doc":
                                case ".docx":
                                    Process.Start("winword.exe", filePath); // Открыть в Microsoft Word, если установлен
                                    break;
                                default:
                                    Process.Start(filePath); // Для всех других расширений попытаемся открыть файл в программе по умолчанию
                                    break;
                            }
                            return;
                        }
                    }
                }
            }

            MessageBox.Show("Файл книги не найден", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public int YearPublished { get; set; }
            public DateTime DateAdded { get; set; }

            public Book(string title, string author, int yearPublished, DateTime dateAdded)
            {
                Title = title;
                Author = author;
                YearPublished = yearPublished;
                DateAdded = dateAdded;
            }
        }
    }
}
