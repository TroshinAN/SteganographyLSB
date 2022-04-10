using System;
using System.IO;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace StenographyLSB
{
    /// <summary>
    /// Пользовательские методы расширения
    /// </summary>
    public static class ExtentionMethods
    {
        /// <summary>
        /// Преобразует текущее значение объекта <see cref="T:System.Collections.BitArray" /> в массив последовательности байтов.
        /// </summary>
        /// <param name="value">Преобразуемое значение.</param>
        /// <returns>Возвращает массив последовательности байтов.</returns>
        public static byte[] ToBytes(this BitArray value)
        {
            var result = new byte[value.Length / 8];
            value.CopyTo(result, 0);
            return result;
        }

        /// <summary>
        /// Преобразует строку в последовательность битов типа <see cref="T:System.Collections.BitArray" />.
        /// В первые 4 байта кодируется длина строки.
        /// </summary>
        /// <param name="value">Преобразуемая строка.</param>
        /// <returns>Возвращает последовательность битов типа <see cref="T:System.Collections.BitArray" />.</returns>
        public static BitArray ToBitArray(this string value)
        {
            var byteMessage = Steganography.Encoding.GetBytes(value);
            var byteMessageLength = BitConverter.GetBytes(byteMessage.Length);
            var byteFullMessage = byteMessageLength.Concat(byteMessage).ToArray();
            return new BitArray(byteFullMessage);
        }
    }

    /// <summary>
    /// Предоставляет класс с информацией о пикселе изображения.
    /// </summary>
    public class Pixel
    {
        /// <summary>
        /// Возвращает или задаёт значение красного компонента пикселя.
        /// </summary>
        public byte Red { get; set; }
        /// <summary>
        /// Возвращает или задаёт значение зелёного компонента пикселя.
        /// </summary>
        public byte Green { get; set; }
        /// <summary>
        /// Возвращает или задаёт значение синего компонента пикселя.
        /// </summary>
        public byte Blue { get; set; }
        /// <summary>
        /// Положение пикселя в изображении по оси X.
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Положение пикселя в изображении по оси Y.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса с информацией о пикселе изображения.
        /// </summary>
        /// <param name="red">Значение красного компонента пикселя.</param>
        /// <param name="green">Значение зелёного компонента пикселя.</param>
        /// <param name="blue">Значение синего компонента пикселя.</param>
        /// <param name="x">Положение пикселя в изображении по оси X.</param>
        /// <param name="y">Положение пикселя в изображении по оси Y.</param>
        public Pixel(byte red, byte green, byte blue, int x, int y)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
            this.X = x;
            this.Y = y;
        }
    }

    /// <summary>
    /// Предоставляет класс шифрования/дешифрования текстовых сообщений в изображении.
    /// </summary>
    public class Steganography
    {
        /// <summary>
        /// Унифицированная кодировка представления строки.
        /// </summary>
        public static Encoding Encoding { get; } = Encoding.UTF8;

        /// <summary>
        /// Предоставляет последний разряд дробной части чисел Math.PI и Math.E.
        /// </summary>
        public decimal EndPositionBitStep { get; } = 16;

        /// <summary>
        /// Последнее сообщение об ошибке.
        /// </summary>
        public string LastError { get; set; }

        /// <summary>
        /// Шифрует сообщение в указанный файл с определённым набором шагов пикселей и сохраняет шифрованное изображение.
        /// </summary>
        /// <param name="inFile">Полный путь к исходному файлу изображения.</param>
        /// <param name="message">Шифруемое сообщение.</param>
        /// <param name="steps">Строка с определённым набором сдвигов кодируемых пикселей.</param>
        /// <param name="startPositionPixelStep">Начальная позиция шага в строке steps</param>
        /// <param name="outDirectory">Директория для сохранения шифрованного изображения.</param>
        public void Encrypt(string inFile, string message, string steps, decimal startPositionPixelStep, string outDirectory)
        {
            var image = GetImage(inFile);

            if (image != null)
            {
                var bitmap = new Bitmap(image);
                var pixels = GetPixels(bitmap);

                if (pixels != null)
                {
                    var bitMessage = message.ToBitArray();

                    if (EncryptedMessage(pixels, steps, startPositionPixelStep, bitMessage))
                    {
                        if (EncryptedBitmap(pixels, ref bitmap))
                        {
                            var fileInfo = new FileInfo(inFile);
                            //bitmap.Save($"{ outDirectory }\\{ DateTime.Now.ToString("dd.MM.yy - HH.mm.ss") }{ fileInfo.Extension }", image.RawFormat);
                            bitmap.Save($"{ outDirectory }\\New{ fileInfo.Name }", image.RawFormat);
                        }
                    }
                }

                bitmap.Dispose();
                image.Dispose();
            }
        }

        /// <summary>
        /// Дешифрует сообщение из указанного шифрованного изображения с определённым набором битовых шагов
        /// </summary>
        /// <param name="inFile">Полный путь к зашифрованному файлу изображения.</param>
        /// <param name="steps">Строка с определённым набором сдвигов кодируемых пикселей.</param>
        /// <param name="startPositionPixelStep">Начальная позиция шага в строке steps</param>
        /// <param name="message">Возвращаемое. Расшифрованное сообщение.</param>
        public void Decrypt(string inFile, string steps, decimal startPositionPixelStep, ref string message)
        {
            var image = GetImage(inFile);

            if (image != null)
            {
                var bitmap = new Bitmap(image);
                var pixels = GetPixels(bitmap);

                if (pixels != null)
                {
                    DecriptMessage(pixels, steps, startPositionPixelStep, ref message);
                }

                bitmap.Dispose();
                image.Dispose();
            }
        }

        /// <summary>
        /// Создаёт <see cref="T:System.Drawing.Image" /> из указанного файла.
        /// </summary>
        /// <param name="file">Строка, содержащая имя файла, из которого создается <see cref="T:System.Drawing.Image" />.</param>
        /// <returns>Объект <see cref="T:System.Drawing.Image" />, создаваемый этим методом.</returns>
        private Image GetImage(string file)
        {
            try
            {
                var image = Image.FromFile(file);
                return image;
            }
            catch (OutOfMemoryException)
            {
                LastError = "Формат файла не является допустимым форматом изображения.";
                return null;
            }
            catch (FileNotFoundException)
            {
                LastError = $"Файл \"{ file }\" не существует";
                return null;
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                return null;
            }
        }

        /// <summary>
        /// Получает массив пикселей из изображения типа <see cref="T:System.Drawing.Bitmap" />.
        /// </summary>
        /// <param name="bitmap">Изображение типа <see cref="T:System.Drawing.Bitmap" />.</param>
        /// <returns>Возвращает массив пикселей, полученный из изображения.</returns>
        private List<Pixel> GetPixels(Bitmap bitmap)
        {
            var list = new List<Pixel>();

            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    try
                    {
                        var color = bitmap.GetPixel(j, i);
                        list.Add(new Pixel(color.R, color.G, color.B, j, i));
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        LastError = "Координаты пикселя изображения выходят за пределы изображения.";
                        return null;
                    }
                    catch (Exception ex)
                    {
                        LastError = ex.Message;
                        return null;
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Шифрует сообщение, представленное битовой последовательностью типа <see cref="T:System.Collections.BitArray" /> в массив пикселей изображение.
        /// </summary>
        /// <param name="pixels">Массив пикселей изображения.</param>
        /// <param name="steps">Строка с определённым набором сдвигов кодируемых пикселей.</param>
        /// <param name="startPositionPixelStep">Начальная позиция шага в строке steps.</param>
        /// <param name="bitMessage">Битовая последовательность сообщения типа <see cref="T:System.Collections.BitArray" />.</param>
        /// <returns>Указывает, удалось ли зашифровать битовую последовательность сообщения в пиксели изображения.</returns>
        private bool EncryptedMessage(List<Pixel> pixels, string steps, decimal startPositionPixelStep, BitArray bitMessage)
        {
            int pixelIterator = 0, colorIterator = 1;
            var currentPossitionPixelStep = (int)(startPositionPixelStep - 1);

            foreach (bool bit in bitMessage)
            {
                if (pixelIterator >= pixels.Count)
                {
                    LastError = "Сообщение слишком длинное и не может быть закодировано.";
                    return false;
                }

                var pixel = pixels[pixelIterator];

                if (colorIterator == 1)
                {
                    pixel.Red = (byte)((pixel.Red >> 1 << 1) | (bit ? 1 : 0));
                    colorIterator++;
                }
                else if (colorIterator == 2)
                {
                    pixel.Green = (byte)((pixel.Green >> 1 << 1) | (bit ? 1 : 0));
                    colorIterator++;
                }
                else
                {
                    pixel.Blue = (byte)((pixel.Blue >> 1 << 1) | (bit ? 1 : 0));
                    colorIterator = 1;
                    pixelIterator += GetIteratorFromSteps(steps, ref currentPossitionPixelStep);
                }
            }

            return true;
        }

        /// <summary>
        /// Дешифрует сообщение из массива пикселей изображения.
        /// </summary>
        /// <param name="pixels">Массив пикселей изображения.</param>
        /// <param name="steps">Строка с определённым набором сдвигов кодируемых пикселей.</param>
        /// <param name="startPositionPixelStep">Начальная позиция шага в строке steps.</param>
        /// <param name="message">Возвращаемое. Расшифрованное сообщение.</param>
        private void DecriptMessage(List<Pixel> pixels, string steps, decimal startPositionPixelStep, ref string message)
        {
            int pixelIterator = 0, colorIterator = 1;
            var currentPositionPixelStep = (int)(startPositionPixelStep - 1);
            var lengthMessage = GetLengthMessage(pixels, steps, ref currentPositionPixelStep, ref pixelIterator, ref colorIterator);
            var messageBitCount = lengthMessage * 8;

            if (messageBitCount > 0)
            {
                var bitArrayMessage = new BitArray(messageBitCount, false);

                for (int i = 0; i < messageBitCount; i++)
                {
                    if (pixelIterator >= pixels.Count)
                    {
                        LastError = "Неверный ключ шифрования.";
                        return;
                    }

                    var pixel = pixels[pixelIterator];

                    if (colorIterator == 1)
                    {
                        bitArrayMessage.Set(i, (pixel.Red & 1) == 1);
                        colorIterator++;
                    }
                    else if (colorIterator == 2)
                    {
                        bitArrayMessage.Set(i, (pixel.Green & 1) == 1);
                        colorIterator++;
                    }
                    else
                    {
                        bitArrayMessage.Set(i, (pixel.Blue & 1) == 1);
                        colorIterator = 1;
                        pixelIterator += GetIteratorFromSteps(steps, ref currentPositionPixelStep);
                    }
                }

                var bytes = bitArrayMessage.ToBytes();
                message = Steganography.Encoding.GetString(bytes);
            }
            else if (messageBitCount < 0)
            {
                LastError = "Неверный ключ шифрования.";
            }
        }

        /// <summary>
        /// Получает длину зашифрованного сообщения из массива пикселей изображения.
        /// </summary>
        /// <param name="pixels">Массив пикселей изображения.</param>
        /// <param name="steps">Строка с определённым набором сдвигов кодируемых пикселей.</param>
        /// <param name="currentPositionPixelStep">Возвращаемое. Текущая позиция шага в строке steps.</param>
        /// <param name="currentPixelIterator">Возвращаемое. Текущий итератор массива пикселей.</param>
        /// <param name="currentColorIterator">Возвращаемое. Текущий итератор цвета в пикселе.</param>
        /// <returns>Возвращает длину закодированного сообщения.</returns>
        private int GetLengthMessage(List<Pixel> pixels, string steps, ref int currentPositionPixelStep, ref int currentPixelIterator, ref int currentColorIterator)
        {
            var intBitsCount = 32;      // Количество бит в числе типа int.
            var length = 0;
            var bitLength = new BitArray(intBitsCount, false);

            for (int i = 0; i < intBitsCount; i++)
            {
                if (currentPixelIterator >= pixels.Count)
                {
                    LastError = "Неверный ключ шифрования.";
                    return length;
                }

                var pixel = pixels[currentPixelIterator];

                if (currentColorIterator == 1)
                {
                    bitLength.Set(i, (pixel.Red & 1) == 1);
                    currentColorIterator++;
                }
                else if (currentColorIterator == 2)
                {
                    bitLength.Set(i, (pixel.Green & 1) == 1);
                    currentColorIterator++;
                }
                else
                {
                    bitLength.Set(i, (pixel.Blue & 1) == 1);
                    currentColorIterator = 1;
                    currentPixelIterator += GetIteratorFromSteps(steps, ref currentPositionPixelStep);
                }
            }

            var byteLength = bitLength.ToBytes();
            length = BitConverter.ToInt32(byteLength, 0);

            return length;
        }

        /// <summary>
        /// Заменяет исходные пиксели изображения закодированными пикселями.
        /// </summary>
        /// <param name="pixels">Массив закодированных пикселей.</param>
        /// <param name="bitmap">Исходное изображение типа <see cref="T:System.Drawing.Bitmap" />.</param>
        /// <returns>Указывает, удалось ли заменить исходные пиксели изображения закодированными пикселями.</returns>
        private bool EncryptedBitmap(List<Pixel> pixels, ref Bitmap bitmap)
        {
            try
            {
                foreach (var pixel in pixels)
                {
                    bitmap.SetPixel(pixel.X, pixel.Y, Color.FromArgb(pixel.Red, pixel.Green, pixel.Blue));
                }
            }
            catch (Exception ex)
            {
                LastError = ex.Message;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Получает значение следующего сдвига из строки с определённым набором битовых шагов.
        /// </summary>
        /// <param name="steps">Строка с определённым набором сдвигов кодируемых пикселей.</param>
        /// <param name="currentPositionPixelStep">Возвращаемое. Текущая позиция шага в строке steps.</param>
        /// <returns>Возвращает значение следующего сдвига.</returns>
        private int GetIteratorFromSteps(string steps, ref int currentPositionPixelStep)
        {
            var result = Int32.Parse(steps[currentPositionPixelStep].ToString());
            currentPositionPixelStep = currentPositionPixelStep == (EndPositionBitStep - 1) ? 0 : (currentPositionPixelStep + 1);
            return result == 0 ? 10 : result;
        }
    }
}
