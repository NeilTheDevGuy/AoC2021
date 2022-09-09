namespace AoC2021.Days
{
    public static class Day4
    {
        public static async Task Run()
        {
            var input = await InputGetter.GetFromLinesAsString(4);
            await PartOne(input);
            await PartTwo(input);
        }

        private static async Task PartOne(string[] input)
        {
            var boards = BuildBoards(input);
            var drawNumbers = input[0].Split(',');

            foreach (var drawNumber in drawNumbers)
            {
                foreach (var board in boards)
                {
                    foreach(var boardLine in board.BoardLines)
                    {
                        foreach(var lineNumber in boardLine.Numbers) 
                        {
                            if (lineNumber.Key == int.Parse(drawNumber) )
                            {
                                boardLine.Numbers[lineNumber.Key] = true;
                            }
                        }
                    }
                }
                var check = CheckBoards(boards);
                if (check.Item1)
                {
                    //We have a winner!
                    PrintBoard(check.Item2);

                    var sum = 0;
                    foreach (var line in check.Item2.BoardLines)
                    {
                        foreach (var number in line.Numbers)
                        {
                            if (number.Value == false)
                                sum += number.Key;
                        }
                    }                    
                    
                    Console.WriteLine($"Sum of Unmarked Numbers: {sum}");
                    Console.WriteLine($"Final Score: {sum * int.Parse(drawNumber)}");
                    break;
                }
            }            
        }

        private static async Task PartTwo(string[] input)
        {

        }

        private static void PrintBoard(BingoBoard board)
        {
            foreach (var line in board.BoardLines)
            {
                foreach (var number in line.Numbers)
                {
                    Console.Write(number.Key);
                    if (number.Value == true)
                        Console.Write("x ");
                    Console.Write(" ");
                }
                Console.WriteLine("");
            }
        }

        //Returns true or false, and the winning board
        private static (bool,BingoBoard) CheckBoards(List<BingoBoard> boards)
        {
            foreach (var board in boards)
            {
                foreach (var line in board.BoardLines)
                {
                    if (line.Numbers.Values.All(v => v == true)) 
                    {
                        return (true, board);
                    }
                }
            }
            return (false, null);
        }

        private static List<BingoBoard> BuildBoards(string[] input)
        {
            var boards = new List<BingoBoard>();

            var board = new BingoBoard();
            var boardLines = new List<BoardLine>();

            for (int i = 2; i < input.Length; i++)
            {
                var line = input[i];
                if (line.Length > 0)
                {
                    var numbers = line.Split(' ').ToList();
                    numbers = numbers.Where(n => !string.IsNullOrEmpty(n)).ToList();
                    var boardLine = new BoardLine();
                    foreach (var num in numbers)
                    {
                        boardLine.Numbers.Add(int.Parse(num), false);
                    }
                    board.BoardLines.Add(boardLine);
                }
                
                if (line.Length == 0 || i == input.Length - 1)
                {
                    boards.Add(board);
                    board = new BingoBoard();
                }
            }

            return boards;
        }


        private class BingoBoard
        {
            public List<BoardLine> BoardLines { get; set; } = new List<BoardLine>();
        }        

        private class BoardLine
        {
            public Dictionary<int,bool> Numbers { get; set; } = new Dictionary<int,bool>();
        }
    }   
}
