using System;
using System.Text;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace StenographyLSB
{
    /// <summary>
    /// Режим шифрования.
    /// </summary>
    public enum TypeCoding
    {
        /// <summary>
        /// Шифрование.
        /// </summary>
        ENCODING,
        /// <summary>
        /// Дешифрование.
        /// </summary>
        DECODING
    }

    /// <summary>
    /// Модификация шифрования.
    /// </summary>
    public enum ModifyCoding
    {
        /// <summary>
        /// Без модификации.
        /// </summary>
        EMPTY,
        /// <summary>
        /// По числу Пи.
        /// </summary>
        PI,
        /// <summary>
        /// По числу Е.
        /// </summary>
        E
    }

    public partial class MainForm : Form
    {
        /// <summary>
        /// Режим шифрования.
        /// </summary>
        public TypeCoding TypeCoding { get; set; } = TypeCoding.ENCODING;

        public ModifyCoding ModifyCoding { get; set; } = ModifyCoding.PI;

        /// <summary>
        /// Путь к исходному изображению.
        /// </summary>
        public string InPicturePath { get => txtInPictureFilePath.Text; set => txtInPictureFilePath.Text = value; }

        /// <summary>
        /// Путь к файлу с кодируемым текстом. Только для режима шифрования.
        /// </summary>
        public string InTextFilePath { get => txtInTextFilePath.Text; set => txtInTextFilePath.Text = value; }

        /// <summary>
        /// Директория выгрузки результата.
        /// </summary>
        public string OutDirectory { get => txtOutFilesPath.Text; set => txtOutFilesPath.Text = value; }

        /// <summary>
        /// Кодируемый текст.
        /// </summary>
        public string CodingText { get => txtCodingText.Text; set => txtCodingText.Text = value; }

        /// <summary>
        /// Начальная позиция точности числа модификации шифрования для сдвига битов.
        /// </summary>
        public decimal CapacityModify { get => numCapacityModify.Value; set => numCapacityModify.Value = value; }

        /// <summary>
        /// Количество символов в кодируемом тексте
        /// </summary>
        public int CodingTextCharCount { get => Convert.ToInt32(txtCodingCharCount.Text); set => txtCodingCharCount.Text = value.ToString(); }

        /// <summary>
        /// Наименование кнопки запуска шифрование/дешифрования.
        /// </summary>
        public string ButtonStartCodingName { get => btnStartCoding.Text; set => btnStartCoding.Text = value; }

        public MainForm()
        {
            InitializeComponent();
            SetDefaultParameterComponents();
        }

        private void SetDefaultParameterComponents()
        {
            InPicturePath = String.Empty;
            InTextFilePath = String.Empty;
            OutDirectory = String.Empty;
            CodingText = String.Empty;
            CodingTextCharCount = 0;
            pbInPictureFile.Image?.Dispose();
            pbInPictureFile.Image = null;
            lblInTextFilePath.Visible = TypeCoding == TypeCoding.ENCODING;
            txtInTextFilePath.Visible = TypeCoding == TypeCoding.ENCODING;
            btnInTextFile.Visible = TypeCoding == TypeCoding.ENCODING;
            btnSaveTextFile.Visible = TypeCoding == TypeCoding.DECODING;
            btnSaveTextFile.Enabled = false;
            txtCodingText.ReadOnly = TypeCoding == TypeCoding.DECODING;
            CheckStartButton();
        }

        private void RbEncoding_CheckedChanged(object sender, EventArgs e)
        {
            if (TypeCoding != TypeCoding.ENCODING)
            {
                TypeCoding = TypeCoding.ENCODING;
                SetDefaultParameterComponents();
                ButtonStartCodingName = "Начать шифрование";
            }
        }

        private void RbDecoding_CheckedChanged(object sender, EventArgs e)
        {
            if (TypeCoding != TypeCoding.DECODING)
            {
                TypeCoding = TypeCoding.DECODING;
                SetDefaultParameterComponents();
                ButtonStartCodingName = "Начать дешифрование";
            }
        }

        private void BtnOpenInImageFile_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                InitialDirectory = Environment.CurrentDirectory,
                Title = "Укажите файл с изображением.",
                Filter = "Image Files(*.BMP;*.PNG)|*.BMP;*.PNG"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                InPicturePath = dialog.FileName;
                pbInPictureFile.Image?.Dispose();
                pbInPictureFile.Image = Image.FromFile(InPicturePath);

                if (String.IsNullOrEmpty(OutDirectory))
                {
                    OutDirectory = new FileInfo(InPicturePath).Directory.FullName;
                }

                CheckSaveTextFile();
                CheckStartButton();
            }

            dialog.Dispose();
        }

        private void BtnInTextFile_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                InitialDirectory = Environment.CurrentDirectory,
                Title = "Укажите текстовый файл.",
                Filter = "txt files (*.txt)|*.txt"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                InTextFilePath = dialog.FileName;
                CodingText = File.ReadAllText(InTextFilePath, Encoding.Default);
            }

            dialog.Dispose();
        }

        private void TxtCodingText_TextChanged(object sender, EventArgs e)
        {
            CodingTextCharCount = CodingText.Length;
            CheckSaveTextFile();
            CheckStartButton();
        }

        private void RbModifyCodingPi_CheckedChanged(object sender, EventArgs e)
        {
            if (ModifyCoding != ModifyCoding.PI)
            {
                ModifyCoding = ModifyCoding.PI;
            }
        }

        private void RbModifyCodingE_CheckedChanged(object sender, EventArgs e)
        {
            if (ModifyCoding != ModifyCoding.E)
            {
                ModifyCoding = ModifyCoding.E;
            }
        }

        private void rbModifyCodingEmpty_CheckedChanged(object sender, EventArgs e)
        {
            if (ModifyCoding != ModifyCoding.EMPTY)
            {
                ModifyCoding = ModifyCoding.EMPTY;
            }
        }

        private void BtnOpenOutFilesPath_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog
            {
                SelectedPath = String.IsNullOrEmpty(OutDirectory) ? Environment.CurrentDirectory : OutDirectory
            };


            if (dialog.ShowDialog() == DialogResult.OK)
            {
                OutDirectory = dialog.SelectedPath;
                CheckSaveTextFile();
                CheckStartButton();
            }

            dialog.Dispose();
        }

        private void BtnSaveTextFile_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(CodingText) && !String.IsNullOrEmpty(OutDirectory))
            {
                var txtPath = $"{ OutDirectory }\\Decrypt text.txt";

                using (StreamWriter writer = new StreamWriter(txtPath, true, Encoding.Default))
                {
                    writer.Write(CodingText);
                    writer.Close();
                }

                System.Diagnostics.Process.Start(txtPath);
            }
        }

        private void BtnStartCoding_Click(object sender, EventArgs e)
        {
            switch (TypeCoding)
            {
                case TypeCoding.ENCODING:
                    StartEncrypt();
                    break;
                case TypeCoding.DECODING:
                    StartDecrypt();
                    break;

                default:
                    break;
            }
        }

        private void StartEncrypt()
        {
            var code = new Steganography();

            code.Encrypt(InPicturePath, CodingText, GetBitSteps(), CapacityModify, OutDirectory);

            if (String.IsNullOrEmpty(code.LastError))
            {
                MessageBox.Show("Шифрование прошло успешно.", "Результат шифрования", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(code.LastError, "Ошибка шифрования", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StartDecrypt()
        {
            var message = String.Empty;
            var code = new Steganography();

            code.Decrypt(InPicturePath, GetBitSteps(), CapacityModify, ref message);
            CodingText = message;

            if (String.IsNullOrEmpty(code.LastError))
            {
                var resultInfoMessage = CodingText.Length == 0 ? "Зашифрованное сообщение отсутствует" : "";
                MessageBox.Show($"Дешифрование прошло успешно.\n{ resultInfoMessage }", "Результат дешифрования", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(code.LastError, "Ошибка дешифрования", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetBitSteps()
        {
            var bitSteps = String.Empty;

            switch (ModifyCoding)
            {
                case ModifyCoding.PI:
                    bitSteps = Convert.ToInt64(Math.PI % 3 * Math.Pow(10, 16)).ToString();
                    break;
                case ModifyCoding.E:
                    bitSteps = Convert.ToInt64(Math.E % 2 * Math.Pow(10, 16)).ToString();
                    break;

                default:
                    bitSteps = "1111111111111111";
                    break;
            }

            return bitSteps;
        }

        private void CheckStartButton()
        {
            btnStartCoding.Enabled = !String.IsNullOrEmpty(InPicturePath)
                && !String.IsNullOrEmpty(OutDirectory);

            if (btnStartCoding.Enabled && TypeCoding == TypeCoding.ENCODING)
            {
                btnStartCoding.Enabled = CodingText.Length > 0;
            }
        }

        private void CheckSaveTextFile()
        {
            btnSaveTextFile.Enabled = CodingTextCharCount > 0 && OutDirectory.Length > 0;
        }
    }
}
