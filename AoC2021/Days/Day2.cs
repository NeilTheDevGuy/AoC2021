namespace AoC2021.Days
{
    public static class Day2
    {
        public static async Task Run()
        {
            var input = await InputGetter.GetFromLinesAsString(2);
            await PartOne(input);
            await PartTwo(input);
        }

        private static async Task PartOne(string[] input)
        {
            var pos = 0;
            var depth = 0;
            foreach (var line in input)
            {
                var num = int.Parse(line.Split(" ")[1]);

                switch (line[0])
                {
                    case 'f':
                        pos += num;
                        break;
                    case 'd':
                        depth += num;
                        break;
                    case 'u':
                        depth -= num;
                        break;
                }
            }
            Console.WriteLine(pos * depth);
        }

        private static async Task PartTwo(string[] input)
        {
            var pos = 0;
            var depth = 0;
            var aim = 0;
            foreach (var line in input)
            {
                var num = int.Parse(line.Split(" ")[1]);

                switch (line[0])
                {
                    case 'f':
                        pos += num;
                        depth += aim * num;
                        break;
                    case 'd':
                        aim += num;
                        break;
                    case 'u':
                        aim -= num;
                        break;
                }
            }
            Console.WriteLine(pos * depth);
        }
    }
}
