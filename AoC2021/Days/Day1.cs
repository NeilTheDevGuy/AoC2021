namespace AoC2021.Days
{
    public static class Day1
    {
        public static async Task Run()
        {
            var input = await InputGetter.GetFromLinesAsString(1);
            await PartOne(input);
            await PartTwo(input);
        }

        private static async Task PartOne(string[] input)
        {
            var increases = 0;
            for (var i = 0; i < input.Length - 1; i++)
            {
                if (int.Parse(input[i + 1]) > int.Parse(input[i]))
                    increases++;
            }

            Console.WriteLine(increases);
        }

        private static async Task PartTwo(string[] input)
        {
            var increases = 0;
            var prev = 0;
            for (var i = 2; i < input.Length - 2; i++)
            {
                var sum = int.Parse(input[i]) + int.Parse(input[i + 1]) + int.Parse(input[i + 2]);
                if (sum > prev)
                    increases++;
                prev = sum;
            }

            Console.WriteLine(increases);
        }
    }
}
