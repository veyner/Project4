using System;

namespace ConsoleRender
{
    /// <summary>
    ///  Управляет жизненным циклом игры
    /// </summary>
    internal class Game
    {
        private int maxWidth, maxHeight;

        public Game(int width, int height)
        {
            maxWidth = width;
            maxHeight = height;
        }

        private int _playerX = 1, _playerY = 1;

        /// <summary>
        /// Функция отрисовки экрана (вызывает 5 раз в секунду)
        /// </summary>
        /// <param name="screen"></param>
        public void Draw(Screen screen)
        {
            // Рисуем вертикальные границы экрана
            for (int i = 0; i < screen.Height; i++)
            {
                screen.SetPixel(0, i, '|');
                screen.SetPixel(screen.Width - 1, i, '|');
            }

            // Рисуем горизонтальные границы экрана
            for (int i = 0; i < screen.Width; i++)
            {
                screen.SetPixel(i, 0, '-');
                screen.SetPixel(i, screen.Height - 1, '-');
            }
            screen.SetPixel(0, 0, '┌');
            screen.SetPixel(maxWidth - 1, 0, '┐');
            screen.SetPixel(0, maxHeight - 1, '└');
            screen.SetPixel(maxWidth - 1, maxHeight - 1, '┘');
            // Рисуем игрока
            screen.SetPixel(_playerX, _playerY, '■');
        }

        /// <summary>
        /// Вызывается при нажатии на кнопку клавиатуры
        /// </summary>
        /// <param name="key"></param>
        public void KeyDown(ConsoleKey key)
        {
            // При нажатии...
            switch (key)
            {
                // ...стрелки вниз...
                case ConsoleKey.DownArrow:
                    if (_playerY + 2 == maxHeight)
                    {
                        break;
                    }
                    _playerY++; // ...сдвигаем игрока вниз
                    break;

                case ConsoleKey.UpArrow:
                    if (_playerY - 1 == 0)
                    {
                        break;
                    }
                    _playerY--;
                    break;

                case ConsoleKey.RightArrow:
                    if (_playerX + 2 == maxWidth)
                    {
                        break;
                    }
                    _playerX++;
                    break;

                case ConsoleKey.LeftArrow:
                    if (_playerX - 1 == 0)
                    {
                        break;
                    }
                    _playerX--;
                    break;
            }
        }
    }
}