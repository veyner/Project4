using System;

namespace Dodger
{
    /// <summary>
    ///  Управляет жизненным циклом игры
    /// </summary>
    internal class Game
    {
        private int _maxWidth, _maxHeight;
        private Random _random;
        private GameObject[] opponents = new GameObject[5];
        private Point player = new Point();
        private bool _isGameOver;

        public Game(int width, int height)
        {
            _maxWidth = width;
            _maxHeight = height;
            _random = new Random();
            StartGame();
        }

        private void StartGame()
        {
            for (int i = 0; i < 5; i++)
            {
                opponents[i] = GameObject.CreateOpponent(_random, _maxWidth, _maxHeight);
            }
            player.X = _maxWidth / 2;
            player.Y = _maxHeight / 2;
            _isGameOver = false;
        }

        private bool CheckOpp(GameObject gameObject)
        {
            return gameObject.Position.X <= 1 || gameObject.Position.X >= _maxWidth - 2 ||
                gameObject.Position.Y <= 1 || gameObject.Position.Y >= _maxHeight - 2;
        }

        /// <summary>
        /// Функция отрисовки экрана (вызывает 5 раз в секунду)
        /// </summary>
        /// <param name="screen"></param>
        public void Draw(Screen screen)
        {
            DrawBorder(screen);
            if (!_isGameOver)
            {
                // Рисуем игрока
                screen.SetPixel(player.X, player.Y, '■');

                for (int i = 0; i < opponents.Length; i++)
                {
                    opponents[i].Position.Move(opponents[i].Speed);
                    if (CheckOpp(opponents[i]))
                    {
                        opponents[i] = GameObject.CreateOpponent(_random, _maxWidth, _maxHeight);
                    }
                    // Рисуем оппонента
                    screen.SetPixel(opponents[i].Position.X, opponents[i].Position.Y, '@');
                    if (opponents[i].Position.Equals(player))
                    {
                        _isGameOver = true;
                    }
                }
            }
            else
            {
                GameOver(screen);
            }
        }

        /// <summary>
        /// прорисовка "Завершения игры и рестарта"
        /// </summary>
        /// <param name="screen"></param>
        private void GameOver(Screen screen)
        {
            string gameOver = "GAME OVER";
            var screenCenter = new Point((_maxWidth - gameOver.Length) / 2, _maxHeight / 2);
            screen.DrawString(screenCenter, gameOver);
            string restart = "Press Space to restart";
            var startPoint = new Point((_maxWidth - restart.Length) / 2, _maxHeight / 2 + 1);
            screen.DrawString(startPoint, restart);
        }

        private void DrawBorder(Screen screen)
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
            screen.SetPixel(_maxWidth - 1, 0, '┐');
            screen.SetPixel(0, _maxHeight - 1, '└');
            screen.SetPixel(_maxWidth - 1, _maxHeight - 1, '┘');
        }

        /// <summary>
        /// Вызывается при нажатии на кнопку клавиатуры
        /// </summary>
        /// <param name="key"></param>
        public void KeyDown(ConsoleKey key)
        {
            if (!_isGameOver)
            {
                // При нажатии...
                switch (key)
                {
                    // ...стрелки вниз...
                    case ConsoleKey.DownArrow:
                        if (player.Y + 2 == _maxHeight)
                        {
                            break;
                        }
                        player.Y++; // ...сдвигаем игрока вниз
                        break;

                    case ConsoleKey.UpArrow:
                        if (player.Y - 1 == 0)
                        {
                            break;
                        }
                        player.Y--;
                        break;

                    case ConsoleKey.RightArrow:
                        if (player.X + 2 == _maxWidth)
                        {
                            break;
                        }
                        player.X++;
                        break;

                    case ConsoleKey.LeftArrow:
                        if (player.X - 1 == 0)
                        {
                            break;
                        }
                        player.X--;
                        break;
                }
                for (int i = 0; i < opponents.Length; i++)
                {
                    if (opponents[i].Position.Equals(player))
                    {
                        _isGameOver = true;
                    }
                }
            }
            else
            {
                if (ConsoleKey.Spacebar == key)
                {
                    StartGame();
                }
            }
        }
    }
}