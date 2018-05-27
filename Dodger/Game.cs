using System;
using System.Collections.Generic;

namespace Dodger
{
    /// <summary>
    ///  Управляет жизненным циклом игры
    /// </summary>
    internal class Game
    {
        private int _maxWidth, _maxHeight;
        private Random _random;
        private List<GameObject> _opponents = new List<GameObject>();
        private Point _player = new Point();
        private bool _isGameOver;
        private int _result = 0;

        public Game(int width, int height)
        {
            _maxWidth = width;
            _maxHeight = height;
            _random = new Random();
            StartGame();
        }

        private void StartGame()
        {
            _result = 0;
            for (int i = 0; i < 5; i++)
            {
                _opponents.Add(GameObject.CreateOpponent(_random, _maxWidth, _maxHeight));
            }
            _player.X = _maxWidth / 2;
            _player.Y = _maxHeight / 2;
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
                screen.SetPixel(_player.X, _player.Y, '■');

                for (int i = 0; i < _opponents.Count; i++)
                {
                    _opponents[i].Position.Move(_opponents[i].Speed);
                    if (CheckOpp(_opponents[i]))
                    {
                        _opponents[i] = GameObject.CreateOpponent(_random, _maxWidth, _maxHeight);
                    }
                    // Рисуем оппонента
                    screen.SetPixel(_opponents[i].Position.X, _opponents[i].Position.Y, '@');
                    if (_opponents[i].Position.Equals(_player))
                    {
                        _isGameOver = true;
                    }
                }
                _result++;
                if (_result % 30 == 0)
                {
                    _opponents.Add(GameObject.CreateOpponent(_random, _maxWidth, _maxHeight));
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
            var screenCenter = new Point((_maxWidth - gameOver.Length) / 2, _maxHeight / 2 - 1);
            screen.DrawString(screenCenter, gameOver);
            string lastResult = "Your score is " + _result;
            var resultPoint = new Point((_maxWidth - lastResult.Length) / 2, _maxHeight / 2);
            screen.DrawString(resultPoint, lastResult);
            string restart = "Press Space to restart";
            var startPoint = new Point((_maxWidth - restart.Length) / 2, _maxHeight / 2 + 2);
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
                        if (_player.Y + 2 == _maxHeight)
                        {
                            break;
                        }
                        _player.Y++; // ...сдвигаем игрока вниз
                        break;

                    case ConsoleKey.UpArrow:
                        if (_player.Y - 1 == 0)
                        {
                            break;
                        }
                        _player.Y--;
                        break;

                    case ConsoleKey.RightArrow:
                        if (_player.X + 2 == _maxWidth)
                        {
                            break;
                        }
                        _player.X++;
                        break;

                    case ConsoleKey.LeftArrow:
                        if (_player.X - 1 == 0)
                        {
                            break;
                        }
                        _player.X--;
                        break;
                }
                for (int i = 0; i < _opponents.Count; i++)
                {
                    if (_opponents[i].Position.Equals(_player))
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