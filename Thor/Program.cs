﻿using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 * ---
 * Hint: You can use the debug stream to print initialTX and initialTY, if Thor seems not follow your orders.
 **/
class Player
{
    static void Main(string[] args)
    {
        
        string[] inputs = Console.ReadLine().Split(' ');
        int lightX = int.Parse(inputs[0]); // the X position of the light of power
        int lightY = int.Parse(inputs[1]); // the Y position of the light of power
        int initialTX = int.Parse(inputs[2]); // Thor's starting X position
        int initialTY = int.Parse(inputs[3]); // Thor's starting Y position
   
        // game loop
        while (true)
        {
            int remainingTurns = int.Parse(Console.ReadLine()); // The remaining amount of turns Thor can move. Do not remove this line.
            if (initialTX < lightX && initialTY < lightY)
            {
                initialTX++;
                initialTY++;
                Console.WriteLine("SE");
            }
            else if (initialTX < lightX && initialTY > lightY)
            {
                initialTX++;
                initialTY--;
                Console.WriteLine("NE");
            }
            else if (initialTX > lightX && initialTY < lightY)
            {
                initialTX--;
                initialTY++;
                Console.WriteLine("SW");
            }
            else if (initialTX > lightX && initialTY >lightY)
            {
                initialTX--;
                initialTY++;
                Console.WriteLine("NW");
            }
            else if (initialTX < lightX)
            {
                initialTX++;
                Console.WriteLine("E");
            }
            else if (initialTY < lightY)
            {
                initialTY++;
                Console.WriteLine("S");
            }
            else if (initialTX > lightX)
            {
                initialTX--;
                Console.WriteLine("W");
            }
            else if (initialTY>lightY)
            {
                initialTY--;
                Console.WriteLine("N");
            }
            
            // Write an action using Console.WriteLine()
            // To debug: Console.Error.WriteLine("Debug messages...");


            // A single line providing the move to be made: N NE E SE S SW W or NW
            
        }
    }
}