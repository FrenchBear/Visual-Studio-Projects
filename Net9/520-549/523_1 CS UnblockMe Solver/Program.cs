// UnblockMeSolver
// Helper for UnblockMe app
//
// 2014-07-17   PV
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System;
using System.Collections.Generic;
using static System.Console;

namespace CS523a;

internal class Program
{
    // Describes the blocks of a specific game
    // Puzzle 1602
    private static readonly Block[] Pieces = [
        new() { IsHorizontal = true, RowCol = 0, Length = 3 },
        new() { IsHorizontal = true, RowCol = 1, Length = 2 },
        new() { IsHorizontal = true, RowCol = 2, Length = 2 },
        new() { IsHorizontal = true, RowCol = 4, Length = 2 },
        new() { IsHorizontal = true, RowCol = 5, Length = 3 },
        new() { IsHorizontal = false, RowCol = 0, Length = 3 },
        new() { IsHorizontal = false, RowCol = 2, Length = 2 },
        new() { IsHorizontal = false, RowCol = 3, Length = 3 },
        new() { IsHorizontal = false, RowCol = 4, Length = 3 },
    ];

    private static readonly byte redPiece = 2;

    private static Config Configuration = new() { Length = 9, Pos = [0, 2, 2, 4, 0, 1, 3, 3, 0] };

    private static readonly SortedSet<int> History = [];

    private static void Main(string[] args)
    {
        //for (int i = 32; i < 256; i++)
        //{
        //    Console.Write(i);
        //    Console.Write((char)i);
        //}
        //WriteLine();
        ShowConfig(Configuration);

        WriteLine(Configuration.IsValid(Pieces) ? "Config Ok" : "Invalid config!");

        _ = History.Add(Configuration.Signature());
        _ = Move(1, Configuration);

        WriteLine("{0} configurations analyzed, {1} moves for solution", nbConfig, solutionMoves);
    }

    private static bool foundSolution; // = false;
    private static int nbConfig; //= 0;
    private static int solutionMoves; //= 0;

    private static bool Move(int depth, Config config)
    {
        nbConfig++;

        // is it a winning combination?
        if (config.Pos[redPiece] + Pieces[redPiece].Length == 6)
        {
            ShowConfig(config);
            WriteLine("Solution found, depth={0}", depth);
            foundSolution = true;
            return true;
        }

        // try to move each piece in both directions 1 step
        for (var i = 0; i < config.Length; i++)
        {
            // Move left/up 1 position
            var newConfig = config.Clone();
            newConfig.Pos[i]--;
            if (!History.Contains(newConfig.Signature()) && newConfig.IsValid(Pieces))
            {
                _ = History.Add(newConfig.Signature());
                //ShowConfig(newConfig);
                if (Move(depth + 1, newConfig))
                {
                    //ShowConfig(newConfig);
                    solutionMoves++;
                    return true;
                }
            }
            if (foundSolution)
                return false;

            // Move right/down 1 position
            newConfig = config.Clone();
            newConfig.Pos[i]++;
            if (!History.Contains(newConfig.Signature()) && newConfig.IsValid(Pieces))
            {
                _ = History.Add(newConfig.Signature());
                //ShowConfig(newConfig);
                if (Move(depth + 1, newConfig))
                {
                    //ShowConfig(newConfig);
                    solutionMoves++;
                    return true;
                }
                if (foundSolution)
                    return false;
            }
        }
        return false;
    }

    private static readonly ConsoleColor[] Colors = [(ConsoleColor)1, (ConsoleColor)2, (ConsoleColor)3, (ConsoleColor)5, (ConsoleColor)6, (ConsoleColor)8, (ConsoleColor)9, (ConsoleColor)10, (ConsoleColor)11, (ConsoleColor)12, (ConsoleColor)13, (ConsoleColor)14, (ConsoleColor)15];

    private static void ShowConfig(Config config)
    {
        WriteLine();
        for (var r = 0; r < 6; r++)
        {
            for (var c = 0; c < 6; c++)
            {
                byte i;
                for (i = 0; i < config.Length; i++)
                    if (Pieces[i].IsHorizontal)
                        if (Pieces[i].RowCol == r && c >= config.Pos[i] && c <= config.Pos[i] + Pieces[i].Length - 1)
                            break;
                        else
                        if (Pieces[i].RowCol == c && r >= config.Pos[i] && r <= config.Pos[i] + Pieces[i].Length - 1)
                            break;

                BackgroundColor = i == config.Length ? ConsoleColor.Black : i == redPiece ? ConsoleColor.Red : Colors[i];
                var ch = (char)183;     // centered dot
                Write(ch);
                Write(ch);
            }
            BackgroundColor = ConsoleColor.Black;
            WriteLine();
        }
    }
}

// Represents one wooden block in the game
internal class Block
{
    public bool IsHorizontal;
    public byte RowCol;
    public byte Length;
}

internal struct Config
{
    public byte Length;
    public byte[] Pos;

    public Config Clone()
    {
        Config c2 = new()
        {
            Length = Length,
            Pos = (byte[])Pos.Clone()
        };
        return c2;
    }

    // Equivalent of Pos, but packed in a 32-bit integer
    public readonly int Signature() => Pos[0] + (Pos[1] << 3) + (Pos[2] << 6) + (Pos[3] << 9) + (Pos[4] << 12) + (Pos[5] << 15) + (Pos[6] << 18) + (Pos[7] << 21) + (Pos[8] << 24); // +(Pos[9] << 27);

    // Check the validity of a configuration
    public readonly bool IsValid(Block[] Pieces)
    {
        for (var i = 0; i < Length; i++)
        {
            // Check that the piece is in the board
            if (Pos[i] == 255 || Pos[i] + Pieces[i].Length > 6)
                return false;

            // Check that it doesn't cover another piece
            for (var j = 0; j < Length; j++)
                if (j != i)
                    // Same orientation?
                    if (Pieces[i].IsHorizontal == Pieces[j].IsHorizontal)
                        // Only check for overlap if they are in the same row/col
                        if (Pieces[i].RowCol == Pieces[j].RowCol)
                            if (Pos[i] < Pos[j])
                                if (Pos[i] + Pieces[i].Length - 1 >= Pos[j])
                                    return false;
                                else if (Pos[j] + Pieces[j].Length - 1 >= Pos[i])
                                    return false;
                                else
                        // Check for intersection: piece j rowcol is in the rowcol range of piece i, and piece i rowcol is in the range of piece j
                        if (Pieces[j].RowCol >= Pos[i] && Pieces[j].RowCol <= Pos[i] + Pieces[i].Length - 1)
                                    if (Pieces[i].RowCol >= Pos[j] && Pieces[i].RowCol <= Pos[j] + Pieces[j].Length - 1)
                                        return false;
        }
        return true;
    }
}
