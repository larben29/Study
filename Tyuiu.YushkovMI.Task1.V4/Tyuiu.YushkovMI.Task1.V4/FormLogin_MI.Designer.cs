namespace Tyuiu.YushkovMI.Task1.V4
{
    partial class FormLogin_MI
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin_MI));
            this.textBoxLogin_MI = new System.Windows.Forms.TextBox();
            this.textBoxPassword_MI = new System.Windows.Forms.TextBox();
            this.LabelPassword_MI = new System.Windows.Forms.Label();
            this.labelLogin_MI = new System.Windows.Forms.Label();
            this.buttonAuthorize_MI = new System.Windows.Forms.Button();
            this.buttonRegister_MI = new System.Windows.Forms.Button();
            this.panelDrag_MI = new System.Windows.Forms.Panel();
            this.buttonMinimize_MI = new System.Windows.Forms.Button();
            this.buttonClose_MI = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelDrag_MI.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxLogin_MI
            // 
            this.textBoxLogin_MI.AccessibleDescription = "";
            this.textBoxLogin_MI.AccessibleName = "";
            this.textBoxLogin_MI.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxLogin_MI.Location = new System.Drawing.Point(16, 129);
            this.textBoxLogin_MI.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxLogin_MI.Name = "textBoxLogin_MI";
            this.textBoxLogin_MI.Size = new System.Drawing.Size(341, 34);
            this.textBoxLogin_MI.TabIndex = 0;
            this.textBoxLogin_MI.Enter += new System.EventHandler(this.textBoxLogin_MI_Enter);
            this.textBoxLogin_MI.Leave += new System.EventHandler(this.textBoxLogin_MI_Leave);
            // 
            // textBoxPassword_MI
            // 
            this.textBoxPassword_MI.AccessibleDescription = "";
            this.textBoxPassword_MI.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxPassword_MI.Location = new System.Drawing.Point(16, 218);
            this.textBoxPassword_MI.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPassword_MI.Name = "textBoxPassword_MI";
            this.textBoxPassword_MI.PasswordChar = '*';
            this.textBoxPassword_MI.Size = new System.Drawing.Size(341, 34);
            this.textBoxPassword_MI.TabIndex = 1;
            this.textBoxPassword_MI.Enter += new System.EventHandler(this.textBoxPassword_MI_Enter);
            this.textBoxPassword_MI.Leave += new System.EventHandler(this.textBoxPassword_MI_Leave);
            // 
            // LabelPassword_MI
            // 
            this.LabelPassword_MI.AutoSize = true;
            this.LabelPassword_MI.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelPassword_MI.ForeColor = System.Drawing.Color.White;
            this.LabelPassword_MI.Location = new System.Drawing.Point(16, 171);
            this.LabelPassword_MI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LabelPassword_MI.Name = "LabelPassword_MI";
            this.LabelPassword_MI.Size = new System.Drawing.Size(105, 29);
            this.LabelPassword_MI.TabIndex = 2;
            this.LabelPassword_MI.Text = "Пароль";
            // 
            // labelLogin_MI
            // 
            this.labelLogin_MI.AutoSize = true;
            this.labelLogin_MI.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLogin_MI.ForeColor = System.Drawing.Color.White;
            this.labelLogin_MI.Location = new System.Drawing.Point(16, 82);
            this.labelLogin_MI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLogin_MI.Name = "labelLogin_MI";
            this.labelLogin_MI.Size = new System.Drawing.Size(88, 29);
            this.labelLogin_MI.TabIndex = 3;
            this.labelLogin_MI.Text = "Логин";
            // 
            // buttonAuthorize_MI
            // 
            this.buttonAuthorize_MI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(143)))), ((int)(((byte)(220)))));
            this.buttonAuthorize_MI.FlatAppearance.BorderSize = 0;
            this.buttonAuthorize_MI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAuthorize_MI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAuthorize_MI.ForeColor = System.Drawing.Color.White;
            this.buttonAuthorize_MI.Location = new System.Drawing.Point(16, 274);
            this.buttonAuthorize_MI.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAuthorize_MI.Name = "buttonAuthorize_MI";
            this.buttonAuthorize_MI.Size = new System.Drawing.Size(160, 42);
            this.buttonAuthorize_MI.TabIndex = 4;
            this.buttonAuthorize_MI.Text = "Авторизация";
            this.buttonAuthorize_MI.UseVisualStyleBackColor = false;
            this.buttonAuthorize_MI.Click += new System.EventHandler(this.buttonAuthorize_MI_Click);
            // 
            // buttonRegister_MI
            // 
            this.buttonRegister_MI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(143)))), ((int)(((byte)(220)))));
            this.buttonRegister_MI.FlatAppearance.BorderSize = 0;
            this.buttonRegister_MI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRegister_MI.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonRegister_MI.ForeColor = System.Drawing.Color.White;
            this.buttonRegister_MI.Location = new System.Drawing.Point(184, 274);
            this.buttonRegister_MI.Margin = new System.Windows.Forms.Padding(4);
            this.buttonRegister_MI.Name = "buttonRegister_MI";
            this.buttonRegister_MI.Size = new System.Drawing.Size(173, 42);
            this.buttonRegister_MI.TabIndex = 5;
            this.buttonRegister_MI.Text = "Регистрация";
            this.buttonRegister_MI.UseVisualStyleBackColor = false;
            this.buttonRegister_MI.Click += new System.EventHandler(this.buttonRegister_MI_Click);
            // 
            // panelDrag_MI
            // 
            this.panelDrag_MI.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(143)))), ((int)(((byte)(220)))));
            this.panelDrag_MI.Controls.Add(this.buttonMinimize_MI);
            this.panelDrag_MI.Controls.Add(this.buttonClose_MI);
            this.panelDrag_MI.Location = new System.Drawing.Point(-3, 0);
            this.panelDrag_MI.Margin = new System.Windows.Forms.Padding(4);
            this.panelDrag_MI.Name = "panelDrag_MI";
            this.panelDrag_MI.Size = new System.Drawing.Size(378, 36);
            this.panelDrag_MI.TabIndex = 6;
            this.panelDrag_MI.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelDrag_MI_MouseDown);
            // 
            // buttonMinimize_MI
            // 
            this.buttonMinimize_MI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonMinimize_MI.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonMinimize_MI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimize_MI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(143)))), ((int)(((byte)(220)))));
            this.buttonMinimize_MI.Image = ((System.Drawing.Image)(resources.GetObject("buttonMinimize_MI.Image")));
            this.buttonMinimize_MI.Location = new System.Drawing.Point(286, 1);
            this.buttonMinimize_MI.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMinimize_MI.Name = "buttonMinimize_MI";
            this.buttonMinimize_MI.Size = new System.Drawing.Size(33, 31);
            this.buttonMinimize_MI.TabIndex = 8;
            this.buttonMinimize_MI.UseVisualStyleBackColor = true;
            this.buttonMinimize_MI.Click += new System.EventHandler(this.buttonMinimize_MI_Click);
            // 
            // buttonClose_MI
            // 
            this.buttonClose_MI.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.buttonClose_MI.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonClose_MI.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose_MI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(143)))), ((int)(((byte)(220)))));
            this.buttonClose_MI.Image = ((System.Drawing.Image)(resources.GetObject("buttonClose_MI.Image")));
            this.buttonClose_MI.Location = new System.Drawing.Point(327, 2);
            this.buttonClose_MI.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClose_MI.Name = "buttonClose_MI";
            this.buttonClose_MI.Size = new System.Drawing.Size(33, 31);
            this.buttonClose_MI.TabIndex = 7;
            this.buttonClose_MI.UseVisualStyleBackColor = true;
            this.buttonClose_MI.Click += new System.EventHandler(this.buttonClose_MI_Click);
            // 
            // FormLogin_MI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(47)))), ((int)(((byte)(57)))));
            this.ClientSize = new System.Drawing.Size(370, 377);
            this.ControlBox = false;
            this.Controls.Add(this.panelDrag_MI);
            this.Controls.Add(this.buttonRegister_MI);
            this.Controls.Add(this.buttonAuthorize_MI);
            this.Controls.Add(this.labelLogin_MI);
            this.Controls.Add(this.LabelPassword_MI);
            this.Controls.Add(this.textBoxPassword_MI);
            this.Controls.Add(this.textBoxLogin_MI);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormLogin_MI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panelDrag_MI.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLogin_MI;
        private System.Windows.Forms.TextBox textBoxPassword_MI;
        private System.Windows.Forms.Label LabelPassword_MI;
        private System.Windows.Forms.Label labelLogin_MI;
        private System.Windows.Forms.Button buttonAuthorize_MI;
        private System.Windows.Forms.Button buttonRegister_MI;
        private System.Windows.Forms.Panel panelDrag_MI;
        private System.Windows.Forms.Button buttonMinimize_MI;
        private System.Windows.Forms.Button buttonClose_MI;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

