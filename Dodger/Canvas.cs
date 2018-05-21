using System;

namespace Dodger
{
    /// <summary>
    /// Экран
    /// </summary>
    internal class Screen
    {
        public Screen(int width, int height)
        {
            Width = width;
            Height = height;
            Data = new Pixel[height][];

            for (int i = 0; i < height; i++)
            {
                Data[i] = new Pixel[width];
                for (int j = 0; j < width; j++)
                {
                    Data[i][j] = new Pixel();
                }
            }
        }

        /// <summary>
        /// Рисует на экране символ
        /// </summary>
        /// <param name="x">X координата отрисовки символа</param>
        /// <param name="y">Y координата отрисовки символа</param>
        /// <param name="symbol">Рисуемый символ</param>
        /// <param name="color">Цвет рисуемого символа</param>
        public void SetPixel(int x, int y, char symbol)
        {
            Data[y][x] = new Pixel
            {
                Symbol = symbol,
            };
        }

        #region Properties

        /// <summary>
        /// Ширина полотна экрана
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Высота полотна экрана
        /// </summary>
        public int Height { get; set; }

        public Pixel[][] Data { get; set; }

        #endregion Properties
    }

    internal class Pixel
    {
        public char Symbol { get; set; } = ' ';
    }
}