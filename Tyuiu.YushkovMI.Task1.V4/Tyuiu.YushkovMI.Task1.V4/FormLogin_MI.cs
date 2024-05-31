using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Tyuiu.YushkovMI.Task1.V4
{
    public partial class FormLogin_MI : Form
    {
        private string loginPlaceholder = "Введите ваш логин";
        private string passwordPlaceholder = "Введите ваш пароль";
        public FormLogin_MI()
        {
            InitializeComponent();
            SetPlaceholder(textBoxLogin_MI, loginPlaceholder);
            SetPlaceholder(textBoxPassword_MI, passwordPlaceholder);
            toolTip.SetToolTip(textBoxLogin_MI, "Введите ваш логин");
            toolTip.SetToolTip(textBoxPassword_MI, "Введите ваш пароль");
            toolTip.SetToolTip(buttonAuthorize_MI, "Авторизоваться");
            toolTip.SetToolTip(buttonRegister_MI, "Зарегистрироваться");
            toolTip.SetToolTip(buttonClose_MI, "Закрыть приложение");
            toolTip.SetToolTip(buttonMinimize_MI, "Свернуть окно");
        }

        private void SetPlaceholder(System.Windows.Forms.TextBox textBox, string placeholder)
        {
            textBox.ForeColor = SystemColors.GrayText;
            textBox.Text = placeholder;
        }

        private void RemovePlaceholder(System.Windows.Forms.TextBox textBox, string placeholder)
        {
            if (textBox.Text == placeholder)
            {
                textBox.Text = "";
                textBox.ForeColor = SystemColors.WindowText;
            }
        }


        private void textBoxLogin_MI_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(textBoxLogin_MI, loginPlaceholder);
        }

        private void textBoxLogin_MI_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxLogin_MI.Text))
            {
                SetPlaceholder(textBoxLogin_MI, loginPlaceholder);
            }
        }

        private void textBoxPassword_MI_Enter(object sender, EventArgs e)
        {
            RemovePlaceholder(textBoxPassword_MI, passwordPlaceholder);
            textBoxPassword_MI.PasswordChar = '*'; // Чтобы скрывать введенные символы
        }

        private void textBoxPassword_MI_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPassword_MI.Text))
            {
                SetPlaceholder(textBoxPassword_MI, passwordPlaceholder);
                textBoxPassword_MI.PasswordChar = '\0'; // Восстанавливаем видимость символов
            }
        }

        private string ValidateCredentials(string login, string password)
        {
            string[] lines = File.ReadAllLines("Data.csv");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts[0] == login && parts[1] == password)
                    return login;  // Возвращаем логин в случае успешной проверки
            }
            return null;  // Возвращаем null, если учетные данные неверны
        }

        private void buttonAuthorize_MI_Click(object sender, EventArgs e)
        {
            string userName = ValidateCredentials(textBoxLogin_MI.Text, textBoxPassword_MI.Text);
            if (userName != null)
            {
                FormLoginAuth_MI authForm = new FormLoginAuth_MI
                {
                    UserName = userName  // Установка имени пользователя перед показом формы
                };
                authForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Логин или пароль неверный.", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRegister_MI_Click(object sender, EventArgs e)
        {
            FormLoginRegistration_MI registrationForm = new FormLoginRegistration_MI();
            registrationForm.Show();
            this.Hide();
        }

        private void buttonClose_MI_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMinimize_MI_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessge(System.IntPtr hwnd, int wmsg, int wparam, int lparam);

        private void panelDrag_MI_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessge(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
