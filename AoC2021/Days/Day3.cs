namespace AoC2021.Days
{
    public static class Day3
    {
        public static async Task Run()
        {
            var input = await InputGetter.GetFromLinesAsString(3);
            await PartOne(input);
            await PartTwo(input);
        }

        private static async Task PartOne(string[] input)
        {
            var numOfBits = input[1].Length;
            string gamma = "";
            string epsilon = "";
            for (int i = 0; i < numOfBits; i++)
            {
                var zeroCount = 0;
                var oneCount = 0;
                foreach (var line in input)
                {
                    if (line[i] == '0')
                        zeroCount++;
                    else
                        oneCount++;
                }
                if (zeroCount > oneCount)
                {
                    gamma = gamma + "0";
                    epsilon = epsilon + "1";
                }
                else
                {
                    gamma = gamma + "1";
                    epsilon = epsilon + "0";
                }            
            }
            var result = Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2);
            Console.WriteLine(result);
        }

        private static async Task PartTwo(string[] input)
        {
            var numOfBits = input[1].Length;
            string gamma = "";
            string epsilon = "";
            string[] thisInput = new string[input.Length];
            Array.Copy(input,thisInput, input.Length);

            //Oxygen
            for (int i = 0; i < numOfBits; i++)
            {
                var zeroCount = 0;
                var oneCount = 0;

                foreach (var line in thisInput)
                {
                    if (line[i] == '0')
                        zeroCount++;
                    else
                        oneCount++;
                }
                var toKeep = zeroCount > oneCount
                                    ? thisInput.Where(l => l[i] == '0').Select(l => l)
                                    : thisInput.Where(l => l[i] == '1').Select(l => l);

                thisInput = toKeep.ToArray();
                if (thisInput.Length == 1)
                    break;
            }
            var oxygenResult = Convert.ToInt32(thisInput[0], 2);
            Console.WriteLine($"Oxygen: {oxygenResult}");

            //Scrubber
            thisInput = new string[input.Length];
            Array.Copy(input, thisInput, input.Length);
            for (int i = 0; i < numOfBits; i++)
            {
                var zeroCount = 0;
                var oneCount = 0;

                foreach (var line in thisInput)
                {
                    if (line[i] == '0')
                        zeroCount++;
                    else
                        oneCount++;
                }
                var toKeep = zeroCount <= oneCount
                    ? thisInput.Where(l => l[i] == '0').Select(l => l)
                    : thisInput.Where(l => l[i] == '1').Select(l => l);

                thisInput = toKeep.ToArray();
                   
                if (thisInput.Length == 1)
                    break;
            }
            var scrubberResult = Convert.ToInt32(thisInput[0], 2);
            Console.WriteLine($"Scrubber: {scrubberResult}");
            Console.WriteLine($"Reasult: {oxygenResult * scrubberResult}");
        }
    }
}
