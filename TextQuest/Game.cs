using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextQuest
{
    internal class Game
    {
        public void GameLoop(Arc arc, Screen screen, SelectionOptions selectionOption)
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
                        },
                        new Screen
                        {
                            Number=0,
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
        }
    }
}