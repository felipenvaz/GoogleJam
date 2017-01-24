using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GoogleJam
{
    class StoreCreditProblem
    {
        public StoreCreditProblem(string filePath)
        {
            var strings = File.ReadLines(filePath).ToList();
            var finalResult = new List<string>();
            var samplesNumber = Convert.ToInt32(strings[0]);
            var iterator = 1;
            var current = 1;
            while (current <= samplesNumber)
            {
                var credit = Convert.ToInt32(strings[iterator++]);
                var itemsNumber = strings[iterator++];
                var items = strings[iterator++].Split(' ').ToList().ConvertAll(i => Convert.ToInt32(i));
                int bestMatch = credit;
                var result = string.Empty;

                for (var i = 0; i < items.Count && bestMatch != 0; i++)
                {
                    var creditTemp = credit;
                    creditTemp -= items[i];
                    for (var i2 = 0; i2 < items.Count && bestMatch != 0; i2++)
                    {
                        if (i2 == i) {
                            continue;
                        }
                        var creditTemp2 = creditTemp - items[i2];
                        if(creditTemp2 >= 0 && creditTemp2 < bestMatch)
                        {
                            bestMatch = creditTemp2;
                            result = (i + 1) + " " + (i2 + 1);
                        }
                    }
                }
                
                finalResult.Add("Case #" + current + ": " + result);

                current++;
            }

            File.WriteAllLines("result.out", finalResult);
        }
    }
}
