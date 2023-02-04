using System;
public enum Walls
{
    Width = 30,
    Height = 20
}
public class Board
{
    static public void Write()
    {
        int WidthBoard = (int)Walls.Width;
        int HeightBoard = (int)Walls.Height;

        Console.ForegroundColor = ConsoleColor.Red;
        for (int i = 1; i <= (WidthBoard + 2); i++)
        {
            Console.SetCursorPosition(i, 0);
            Console.Write("-");
        }
        for (int i = 1; i <= (WidthBoard + 2); i++)
        {
            Console.SetCursorPosition(i, (HeightBoard + 2));
            Console.Write("-");
        }
        for (int i = 0; i <= (HeightBoard + 2); i++)
        {
            Console.SetCursorPosition(0, i);
            Console.Write("|");
        }
        for (int i = 0; i <= (HeightBoard + 2); i++)
        {
            Console.SetCursorPosition((WidthBoard + 2), i);
            Console.Write("|");
        }

        Console.ForegroundColor = ConsoleColor.White;
    }
}