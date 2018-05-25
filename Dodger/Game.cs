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
            for (int i = 0; i < 5; i++)
            {
                opponents[i] = CreateOpponent();
            }
            player.X = _maxWidth / 2;
            player.Y = _maxHeight / 2;
        }

        private GameObject CreateOpponent()
        {
            GameObject opponent = new GameObject();
            int i = _random.Next(0, 4);
            if (i == 0)
            {
                opponent.Position.X = _maxWidth - 2;
                opponent.Position.Y = _random.Next(1, _maxHeight);
                opponent.Speed.X = -1;
            }
            else if (i == 1)
            {
                opponent.Position.X = 1;
                opponent.Position.Y = _random.Next(1, _maxHeight);
                opponent.Speed.X = 1;
            }
            else if (i == 2)
            {
                opponent.Position.X = _random.Next(1, _maxWidth);
                opponent.Position.Y = 1;
                opponent.Speed.Y = 1;
            }
            else if (i == 3)
            {
                opponent.Position.X = _random.Next(1, _maxWidth);
                opponent.Position.Y = _maxHeight - 2;
                opponent.Speed.Y = -1;
            }
            return opponent;
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
                        opponents[i] = CreateOpponent();
                    }
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

        private void GameOver(Screen screen)
        {
            string gameOver = "GAME OVER";
            var screenCenter = new Point(_maxWidth / 2, _maxHeight / 2);
            var stringLength = gameOver.Length;
            for (int i = 0; i < stringLength; i++)
            {
                screen.SetPixel(screenCenter.X - stringLength / 2 + i, screenCenter.Y, gameOver[i]);
            }
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
            }
        }
    }
}