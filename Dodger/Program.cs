using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dodger
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            new GameLauncher(60, 25).Start();
        }
    }

    public class GameLauncher
    {
        private readonly Game _game;
        private readonly Thread _inputThread;
        private readonly Thread _renderThread;

        private readonly int _width = 20, _height = 20;

        public GameLauncher(int width, int height)
        {
            _width = width;
            _height = height;

            _game = new Game(width, height);
            _inputThread = new Thread(new ThreadStart(KeyListenerThread));
            _renderThread = new Thread(new ThreadStart(RenderThread));
        }

        public void Start()
        {
            _inputThread.Start();
            _renderThread.Start();
        }

        public void Stop()
        {
            _inputThread.Abort();
            _renderThread.Abort();
        }

        private void RenderThread()
        {
            while (true)
            {
                var screen = new Screen(_width, _height);
                _game.Draw(screen);

                Console.SetCursorPosition(0, 0);

                for (int i = 0; i < screen.Height; i++)
                {
                    Console.WriteLine(string.Join("", screen.Data[i].Select(x => x.Symbol)));
                }

                Thread.Sleep(250);
            }
        }

        private void KeyListenerThread()
        {
            while (true)
            {
                var key = Console.ReadKey();
                _game.KeyDown(key.Key);
            }
        }
    }
}