using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextQuest
{
    internal class Game
    {
        public void GameLoop()
        {
            var arcs = new Arc[] {
                new Arc
                {
                    ID=0,
                    Screens=new Screen[]{
                        new Screen
                        {
                            Number=0,
                            Text="начало",
                            SelectionOption = new SelectionOptions[0]
                        },
                        new Screen
                        {
                            Number=1,
                            Text="вопрос",
                            SelectionOption = new SelectionOptions[]{
                                new SelectionOptions
                                {
                                    Text="вернуться в начало(Arc 0)",
                                    Destination=0
                                },
                                new SelectionOptions
                                {
                                    Text="перейти к Arc 1",
                                    Destination=1
                                },
                                new SelectionOptions
                                {
                                    Text="перейти к концовке (Arc 2)",
                                    Destination=2
                                },
                            }
                        }
                    }
                },
                new Arc
                {
                    ID=1,
                    Screens=new Screen[]{
                        new Screen
                        {
                            Number=0,
                            Text="основная часть",
                            SelectionOption = new SelectionOptions[0]
                        },
                        new Screen
                        {
                            Number=1,
                            Text="вопрос",
                            SelectionOption = new SelectionOptions[]{
                                new SelectionOptions
                                {
                                    Text="вернуться в начало (Arc 0)",
                                    Destination=0
                                },
                                new SelectionOptions
                                {
                                    Text="перейти к концовке",
                                    Destination=2
                                }
                            }
                        }
                    }
                },
                new Arc
                {
                    ID=2,
                    Screens=new Screen[]{
                        new Screen
                        {
                            Number=0,
                            Text="концовка",
                            SelectionOption = new SelectionOptions[0]
                        }
                    }
                }
            };
            var currentArc = arcs[0];
            var currentScreen = currentArc.Screens[0];
            while (true)
            {
                // Рисуем скрин
                Console.WriteLine("{0}", currentScreen.Text);
                // Рисуем выборы
                if (currentScreen.HasSelectionOption(currentScreen))
                {
                    currentScreen.DrawOptions(currentScreen);
                    var choice = int.Parse(Console.ReadLine()) - 1;
                    currentArc = arcs[currentScreen.SelectionOption[choice].Destination];
                    currentScreen = currentArc.Screens[0];
                }
                else
                {
                    if (currentArc.HasNextScreen(currentScreen))
                    {
                        // Далее...
                        Console.WriteLine("Далее");
                        Console.ReadLine();
                        // Переходим на следующий скрин
                        currentScreen = currentArc.Screens[currentScreen.Number + 1];
                    }
                    else
                    {
                        break;
                    }
                }
            }
            Console.ReadLine();
        }
    }
}