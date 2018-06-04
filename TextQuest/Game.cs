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
                        }
                    }
                }
            };
            var CurrentArc = arcs[0];
            CurrentArc.HasNextScreen = true;
            while (CurrentArc.HasNextScreen == true)
            {
                if (CurrentArc.Screens.Length == 1)
                {
                    CurrentArc.HasNextScreen = false;
                }
                for (int i = 0; i < CurrentArc.Screens.Length; i++)
                {
                    Console.WriteLine("{0}", CurrentArc.Screens[i].Text);
                    Console.ReadLine();
                    if (CurrentArc.Screens[i].SelectionOption.Length != 0)
                    {
                        for (int j = 0; j < CurrentArc.Screens[i].SelectionOption.Length; j++)
                        {
                            Console.WriteLine("{0}", CurrentArc.Screens[i].SelectionOption[j].Text);
                        }
                        var choice = int.Parse(Console.ReadLine());
                        CurrentArc = arcs[CurrentArc.Screens[i].SelectionOption[choice].Destination];
                    }
                }
            }
            Console.WriteLine("{0}", CurrentArc.Screens[0].Text);
            Console.ReadLine();
        }
    }
}