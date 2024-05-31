using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tyuiu.YushkovMI.Task1.V4
{
    public partial class FormLoginRegistration_MI : Form
    {       
        private string loginPlaceholder = "Введите ваш логин";
        private string passwordPlaceholder = "Введите ваш пароль";
        public FormLoginRegistration_MI()
        {
            InitializeComponent();
            toolTip1.SetToolTip(textBoxLoginReg_MI, "Введите логин который бы вы хотели использовать в программе");
            toolTip1.SetToolTip(textBoxPasswordReg_MI, "Введите пароль который бы вы хотели использовать в программе");
            toolTip1.SetToolTip(buttonRegisterAccount_MI, "Зарегистрировать аккаунт");
            toolTip1.SetToolTip(buttonGoBack_MI, "Вернуться");
                       
            SetPlaceholder(textBoxLoginReg_MI, loginPlaceholder);
            SetPlaceholder(textBoxPasswordReg_MI, passwordPlaceholder);
        }
        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.ForeColor = SystemColors.GrayText;
            textBox.Text = placeholder;
        }

        
        private void RemovePlaceholder(TextBox textBox, string placeholder)
        {
            if (textBox.Text == placeholder)
            {
                textBox.Text = "";
                textBox.ForeColor = SystemColors.WindowText;
            }
        }

       
        private void textBoxLoginReg_MI_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(textBoxLoginReg_MI, loginPlaceholder);
        }

        
        private void textBoxLoginReg_MI_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxLoginReg_MI.Text))
            {
                SetPlaceholder(textBoxLoginReg_MI, loginPlaceholder);
            }
        }

       
        private void textBoxPasswordReg_MI_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(textBoxPasswordReg_MI, passwordPlaceholder);
            textBoxPasswordReg_MI.PasswordChar = '*'; 
        }

      
        private void textBoxPasswordReg_MI_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPasswordReg_MI.Text))
            {
                SetPlaceholder(textBoxPasswordReg_MI, passwordPlaceholder);
                textBoxPasswordReg_MI.PasswordChar = '\0'; 
            }
        }
        private void buttonRegisterAccount_MI_Click(object sender, EventArgs e)
        {
            string login = textBoxLoginReg_MI.Text;
            string password = textBoxPasswordReg_MI.Text;

            if (!IsValidLogin(login) || !IsValidPassword(password))
            {
                MessageBox.Show("Логин должен быть до 10 английских букв, пароль - 6 символов.", "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int readerId = GenerateReaderId();
            string onlineStatus = "offline";

            
            using (StreamWriter sw = File.AppendText("Data.csv"))
            {
                sw.WriteLine($"{login},{password},{readerId},{onlineStatus}");
            }

            
            CreatePersonalFile(login, password, readerId);

            MessageBox.Show("Регистрация успешна! Ваш номер читательского билета: " + readerId, "Регистрация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
        }

        private void CreatePersonalFile(string login, string password, int readerId)
        {
            string fileName = $"{login}_data.csv";
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine("Login,Password,ReaderID,BooksTaken,DateTaken,NumberOfBooks");
                sw.WriteLine($"{login},{password},{readerId},None,None,0");
            }
        }

        private bool IsValidLogin(string login)
        {
            return login.All(char.IsLetter) && login.Length <= 10;
        }

        private bool IsValidPassword(string password)
        {
            return password.Length == 6;
        }

        private int GenerateReaderId()
        {
            Random rnd = new Random();
            return rnd.Next(100000, 999999);
        }

        private void ClearFields()
        {
            textBoxLoginReg_MI.Clear();
            textBoxPasswordReg_MI.Clear();
        }

        private void buttonGoBack_MI_Click(object sender, EventArgs e)
        {
            this.Close();
            FormLogin_MI loginForm = new FormLogin_MI();
            loginForm.Show();
        }

        private void buttonCloseReg_MI_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMinimizeReg_MI_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessge(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void panelDragReg_MI_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessge(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
