namespace StenographyLSB
{
    partial class MainForm
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
            this.grbTypeCoding = new System.Windows.Forms.GroupBox();
            this.rbDecoding = new System.Windows.Forms.RadioButton();
            this.rbEncoding = new System.Windows.Forms.RadioButton();
            this.txtInPictureFilePath = new System.Windows.Forms.TextBox();
            this.txtInTextFilePath = new System.Windows.Forms.TextBox();
            this.btnOpenInImageFile = new System.Windows.Forms.Button();
            this.btnInTextFile = new System.Windows.Forms.Button();
            this.pbInPictureFile = new System.Windows.Forms.PictureBox();
            this.txtCodingText = new System.Windows.Forms.TextBox();
            this.lblCodingCharCount = new System.Windows.Forms.Label();
            this.txtCodingCharCount = new System.Windows.Forms.TextBox();
            this.grbModifyCoding = new System.Windows.Forms.GroupBox();
            this.numCapacityModify = new System.Windows.Forms.NumericUpDown();
            this.rbModifyCodingE = new System.Windows.Forms.RadioButton();
            this.rbModifyCodingPi = new System.Windows.Forms.RadioButton();
            this.lblInPictureFilePath = new System.Windows.Forms.Label();
            this.lblInTextFilePath = new System.Windows.Forms.Label();
            this.lblOutFilesPath = new System.Windows.Forms.Label();
            this.txtOutFilesPath = new System.Windows.Forms.TextBox();
            this.btnOpenOutFilesPath = new System.Windows.Forms.Button();
            this.btnStartCoding = new System.Windows.Forms.Button();
            this.btnSaveTextFile = new System.Windows.Forms.Button();
            this.mainFormBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rbModifyCodingEmpty = new System.Windows.Forms.RadioButton();
            this.grbTypeCoding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInPictureFile)).BeginInit();
            this.grbModifyCoding.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacityModify)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grbTypeCoding
            // 
            this.grbTypeCoding.Controls.Add(this.rbDecoding);
            this.grbTypeCoding.Controls.Add(this.rbEncoding);
            this.grbTypeCoding.Location = new System.Drawing.Point(12, 12);
            this.grbTypeCoding.Name = "grbTypeCoding";
            this.grbTypeCoding.Size = new System.Drawing.Size(130, 65);
            this.grbTypeCoding.TabIndex = 0;
            this.grbTypeCoding.TabStop = false;
            this.grbTypeCoding.Text = "Режим шифрования";
            // 
            // rbDecoding
            // 
            this.rbDecoding.AutoSize = true;
            this.rbDecoding.Location = new System.Drawing.Point(5, 40);
            this.rbDecoding.Name = "rbDecoding";
            this.rbDecoding.Size = new System.Drawing.Size(104, 17);
            this.rbDecoding.TabIndex = 1;
            this.rbDecoding.Text = "Дешифрования";
            this.rbDecoding.UseVisualStyleBackColor = true;
            this.rbDecoding.CheckedChanged += new System.EventHandler(this.RbDecoding_CheckedChanged);
            // 
            // rbEncoding
            // 
            this.rbEncoding.AutoSize = true;
            this.rbEncoding.Checked = true;
            this.rbEncoding.Location = new System.Drawing.Point(5, 20);
            this.rbEncoding.Name = "rbEncoding";
            this.rbEncoding.Size = new System.Drawing.Size(90, 17);
            this.rbEncoding.TabIndex = 0;
            this.rbEncoding.TabStop = true;
            this.rbEncoding.Text = "Шифрование";
            this.rbEncoding.UseVisualStyleBackColor = true;
            this.rbEncoding.CheckedChanged += new System.EventHandler(this.RbEncoding_CheckedChanged);
            // 
            // txtInPictureFilePath
            // 
            this.txtInPictureFilePath.Location = new System.Drawing.Point(327, 24);
            this.txtInPictureFilePath.Name = "txtInPictureFilePath";
            this.txtInPictureFilePath.ReadOnly = true;
            this.txtInPictureFilePath.Size = new System.Drawing.Size(364, 20);
            this.txtInPictureFilePath.TabIndex = 1;
            // 
            // txtInTextFilePath
            // 
            this.txtInTextFilePath.Location = new System.Drawing.Point(327, 48);
            this.txtInTextFilePath.Name = "txtInTextFilePath";
            this.txtInTextFilePath.ReadOnly = true;
            this.txtInTextFilePath.Size = new System.Drawing.Size(364, 20);
            this.txtInTextFilePath.TabIndex = 2;
            // 
            // btnOpenInImageFile
            // 
            this.btnOpenInImageFile.Location = new System.Drawing.Point(697, 22);
            this.btnOpenInImageFile.Name = "btnOpenInImageFile";
            this.btnOpenInImageFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenInImageFile.TabIndex = 3;
            this.btnOpenInImageFile.Text = "Открыть";
            this.btnOpenInImageFile.UseVisualStyleBackColor = true;
            this.btnOpenInImageFile.Click += new System.EventHandler(this.BtnOpenInImageFile_Click);
            // 
            // btnInTextFile
            // 
            this.btnInTextFile.Location = new System.Drawing.Point(697, 49);
            this.btnInTextFile.Name = "btnInTextFile";
            this.btnInTextFile.Size = new System.Drawing.Size(75, 23);
            this.btnInTextFile.TabIndex = 4;
            this.btnInTextFile.Text = "Открыть";
            this.btnInTextFile.UseVisualStyleBackColor = true;
            this.btnInTextFile.Click += new System.EventHandler(this.BtnInTextFile_Click);
            // 
            // pbInPictureFile
            // 
            this.pbInPictureFile.BackColor = System.Drawing.Color.Black;
            this.pbInPictureFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbInPictureFile.Location = new System.Drawing.Point(12, 83);
            this.pbInPictureFile.Name = "pbInPictureFile";
            this.pbInPictureFile.Size = new System.Drawing.Size(400, 300);
            this.pbInPictureFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbInPictureFile.TabIndex = 5;
            this.pbInPictureFile.TabStop = false;
            // 
            // txtCodingText
            // 
            this.txtCodingText.Location = new System.Drawing.Point(418, 83);
            this.txtCodingText.Multiline = true;
            this.txtCodingText.Name = "txtCodingText";
            this.txtCodingText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCodingText.Size = new System.Drawing.Size(354, 300);
            this.txtCodingText.TabIndex = 6;
            this.txtCodingText.TextChanged += new System.EventHandler(this.TxtCodingText_TextChanged);
            // 
            // lblCodingCharCount
            // 
            this.lblCodingCharCount.AutoSize = true;
            this.lblCodingCharCount.Location = new System.Drawing.Point(420, 398);
            this.lblCodingCharCount.Name = "lblCodingCharCount";
            this.lblCodingCharCount.Size = new System.Drawing.Size(128, 13);
            this.lblCodingCharCount.TabIndex = 7;
            this.lblCodingCharCount.Text = "Символов шифрования:";
            // 
            // txtCodingCharCount
            // 
            this.txtCodingCharCount.Location = new System.Drawing.Point(554, 395);
            this.txtCodingCharCount.Name = "txtCodingCharCount";
            this.txtCodingCharCount.ReadOnly = true;
            this.txtCodingCharCount.Size = new System.Drawing.Size(100, 20);
            this.txtCodingCharCount.TabIndex = 8;
            this.txtCodingCharCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grbModifyCoding
            // 
            this.grbModifyCoding.Controls.Add(this.rbModifyCodingEmpty);
            this.grbModifyCoding.Controls.Add(this.numCapacityModify);
            this.grbModifyCoding.Controls.Add(this.rbModifyCodingE);
            this.grbModifyCoding.Controls.Add(this.rbModifyCodingPi);
            this.grbModifyCoding.Location = new System.Drawing.Point(12, 389);
            this.grbModifyCoding.Name = "grbModifyCoding";
            this.grbModifyCoding.Size = new System.Drawing.Size(400, 51);
            this.grbModifyCoding.TabIndex = 9;
            this.grbModifyCoding.TabStop = false;
            this.grbModifyCoding.Text = "Модификация шифрования";
            // 
            // numCapacityModify
            // 
            this.numCapacityModify.Location = new System.Drawing.Point(339, 21);
            this.numCapacityModify.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.numCapacityModify.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCapacityModify.Name = "numCapacityModify";
            this.numCapacityModify.Size = new System.Drawing.Size(55, 20);
            this.numCapacityModify.TabIndex = 3;
            this.numCapacityModify.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // rbModifyCodingE
            // 
            this.rbModifyCodingE.AutoSize = true;
            this.rbModifyCodingE.Font = new System.Drawing.Font("Bodoni MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbModifyCodingE.Location = new System.Drawing.Point(107, 19);
            this.rbModifyCodingE.Name = "rbModifyCodingE";
            this.rbModifyCodingE.Size = new System.Drawing.Size(93, 23);
            this.rbModifyCodingE.TabIndex = 1;
            this.rbModifyCodingE.Text = "e = 2.71...";
            this.rbModifyCodingE.UseVisualStyleBackColor = true;
            this.rbModifyCodingE.CheckedChanged += new System.EventHandler(this.RbModifyCodingE_CheckedChanged);
            // 
            // rbModifyCodingPi
            // 
            this.rbModifyCodingPi.AutoSize = true;
            this.rbModifyCodingPi.Checked = true;
            this.rbModifyCodingPi.Font = new System.Drawing.Font("Bodoni MT", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbModifyCodingPi.Location = new System.Drawing.Point(6, 19);
            this.rbModifyCodingPi.Name = "rbModifyCodingPi";
            this.rbModifyCodingPi.Size = new System.Drawing.Size(95, 23);
            this.rbModifyCodingPi.TabIndex = 0;
            this.rbModifyCodingPi.TabStop = true;
            this.rbModifyCodingPi.Text = "π = 3.14...";
            this.rbModifyCodingPi.UseVisualStyleBackColor = true;
            this.rbModifyCodingPi.CheckedChanged += new System.EventHandler(this.RbModifyCodingPi_CheckedChanged);
            // 
            // lblInPictureFilePath
            // 
            this.lblInPictureFilePath.AutoSize = true;
            this.lblInPictureFilePath.Location = new System.Drawing.Point(148, 27);
            this.lblInPictureFilePath.Name = "lblInPictureFilePath";
            this.lblInPictureFilePath.Size = new System.Drawing.Size(173, 13);
            this.lblInPictureFilePath.TabIndex = 10;
            this.lblInPictureFilePath.Text = "Путь к исходному изображению:";
            // 
            // lblInTextFilePath
            // 
            this.lblInTextFilePath.AutoSize = true;
            this.lblInTextFilePath.Location = new System.Drawing.Point(148, 51);
            this.lblInTextFilePath.Name = "lblInTextFilePath";
            this.lblInTextFilePath.Size = new System.Drawing.Size(139, 13);
            this.lblInTextFilePath.TabIndex = 11;
            this.lblInTextFilePath.Text = "Путь к текстовому файлу:";
            // 
            // lblOutFilesPath
            // 
            this.lblOutFilesPath.AutoSize = true;
            this.lblOutFilesPath.Location = new System.Drawing.Point(9, 453);
            this.lblOutFilesPath.Name = "lblOutFilesPath";
            this.lblOutFilesPath.Size = new System.Drawing.Size(183, 13);
            this.lblOutFilesPath.TabIndex = 12;
            this.lblOutFilesPath.Text = "Директория выгрузки результата:";
            // 
            // txtOutFilesPath
            // 
            this.txtOutFilesPath.Location = new System.Drawing.Point(198, 450);
            this.txtOutFilesPath.Name = "txtOutFilesPath";
            this.txtOutFilesPath.ReadOnly = true;
            this.txtOutFilesPath.Size = new System.Drawing.Size(418, 20);
            this.txtOutFilesPath.TabIndex = 13;
            // 
            // btnOpenOutFilesPath
            // 
            this.btnOpenOutFilesPath.Location = new System.Drawing.Point(622, 448);
            this.btnOpenOutFilesPath.Name = "btnOpenOutFilesPath";
            this.btnOpenOutFilesPath.Size = new System.Drawing.Size(150, 23);
            this.btnOpenOutFilesPath.TabIndex = 14;
            this.btnOpenOutFilesPath.Text = "Указать";
            this.btnOpenOutFilesPath.UseVisualStyleBackColor = true;
            this.btnOpenOutFilesPath.Click += new System.EventHandler(this.BtnOpenOutFilesPath_Click);
            // 
            // btnStartCoding
            // 
            this.btnStartCoding.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnStartCoding.Location = new System.Drawing.Point(260, 490);
            this.btnStartCoding.Name = "btnStartCoding";
            this.btnStartCoding.Size = new System.Drawing.Size(300, 30);
            this.btnStartCoding.TabIndex = 15;
            this.btnStartCoding.Text = "Начать шифрование";
            this.btnStartCoding.UseVisualStyleBackColor = true;
            this.btnStartCoding.Click += new System.EventHandler(this.BtnStartCoding_Click);
            // 
            // btnSaveTextFile
            // 
            this.btnSaveTextFile.Location = new System.Drawing.Point(622, 421);
            this.btnSaveTextFile.Name = "btnSaveTextFile";
            this.btnSaveTextFile.Size = new System.Drawing.Size(150, 23);
            this.btnSaveTextFile.TabIndex = 16;
            this.btnSaveTextFile.Text = "Выгрузить текст в файл";
            this.btnSaveTextFile.UseVisualStyleBackColor = true;
            this.btnSaveTextFile.Click += new System.EventHandler(this.BtnSaveTextFile_Click);
            // 
            // mainFormBindingSource
            // 
            this.mainFormBindingSource.DataSource = typeof(StenographyLSB.MainForm);
            // 
            // rbModifyCodingEmpty
            // 
            this.rbModifyCodingEmpty.AutoSize = true;
            this.rbModifyCodingEmpty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbModifyCodingEmpty.Location = new System.Drawing.Point(202, 21);
            this.rbModifyCodingEmpty.Name = "rbModifyCodingEmpty";
            this.rbModifyCodingEmpty.Size = new System.Drawing.Size(131, 19);
            this.rbModifyCodingEmpty.TabIndex = 4;
            this.rbModifyCodingEmpty.TabStop = true;
            this.rbModifyCodingEmpty.Text = "Без модификации";
            this.rbModifyCodingEmpty.UseVisualStyleBackColor = true;
            this.rbModifyCodingEmpty.CheckedChanged += new System.EventHandler(this.rbModifyCodingEmpty_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(784, 541);
            this.Controls.Add(this.btnSaveTextFile);
            this.Controls.Add(this.btnStartCoding);
            this.Controls.Add(this.btnOpenOutFilesPath);
            this.Controls.Add(this.txtOutFilesPath);
            this.Controls.Add(this.lblOutFilesPath);
            this.Controls.Add(this.lblInTextFilePath);
            this.Controls.Add(this.lblInPictureFilePath);
            this.Controls.Add(this.grbModifyCoding);
            this.Controls.Add(this.txtCodingCharCount);
            this.Controls.Add(this.lblCodingCharCount);
            this.Controls.Add(this.txtCodingText);
            this.Controls.Add(this.pbInPictureFile);
            this.Controls.Add(this.btnInTextFile);
            this.Controls.Add(this.btnOpenInImageFile);
            this.Controls.Add(this.txtInTextFilePath);
            this.Controls.Add(this.txtInPictureFilePath);
            this.Controls.Add(this.grbTypeCoding);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Стеганография";
            this.grbTypeCoding.ResumeLayout(false);
            this.grbTypeCoding.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbInPictureFile)).EndInit();
            this.grbModifyCoding.ResumeLayout(false);
            this.grbModifyCoding.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacityModify)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbTypeCoding;
        private System.Windows.Forms.RadioButton rbDecoding;
        private System.Windows.Forms.RadioButton rbEncoding;
        private System.Windows.Forms.TextBox txtInPictureFilePath;
        private System.Windows.Forms.TextBox txtInTextFilePath;
        private System.Windows.Forms.Button btnOpenInImageFile;
        private System.Windows.Forms.Button btnInTextFile;
        private System.Windows.Forms.PictureBox pbInPictureFile;
        private System.Windows.Forms.TextBox txtCodingText;
        private System.Windows.Forms.Label lblCodingCharCount;
        private System.Windows.Forms.TextBox txtCodingCharCount;
        private System.Windows.Forms.GroupBox grbModifyCoding;
        private System.Windows.Forms.RadioButton rbModifyCodingE;
        private System.Windows.Forms.RadioButton rbModifyCodingPi;
        private System.Windows.Forms.Label lblInPictureFilePath;
        private System.Windows.Forms.Label lblInTextFilePath;
        private System.Windows.Forms.Label lblOutFilesPath;
        private System.Windows.Forms.TextBox txtOutFilesPath;
        private System.Windows.Forms.Button btnOpenOutFilesPath;
        private System.Windows.Forms.Button btnStartCoding;
        private System.Windows.Forms.Button btnSaveTextFile;
        private System.Windows.Forms.BindingSource mainFormBindingSource;
        private System.Windows.Forms.NumericUpDown numCapacityModify;
        private System.Windows.Forms.RadioButton rbModifyCodingEmpty;
    }
}

