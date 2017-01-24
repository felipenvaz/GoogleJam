using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleJam
{
    class RopeIntranet
    {
        public RopeIntranet(string filePath)
        {
            var strings = File.ReadLines(filePath).ToList();
            var enumerator = strings.GetEnumerator();
            enumerator.MoveNext();
            int testsNumber = Convert.ToInt32(enumerator.Current);
            enumerator.MoveNext();
            int testCase = 1;
            var finalResult = new List<string>();

            while (testsNumber > 0)
            {
                int wiresNumber = Convert.ToInt32(enumerator.Current);
                enumerator.MoveNext();
                var wires = new List<Tuple<int, int>>();
                while (wiresNumber > 0)
                {
                    var wireString = enumerator.Current.Split(' ');
                    wires.Add(new Tuple<int, int>(Convert.ToInt32(wireString[0]), Convert.ToInt32(wireString[1])));
                    enumerator.MoveNext();
                    wiresNumber--;
                }

                int crosses = 0;
                for (var i = 0; i < wires.Count; i++)
                {
                    for (var i2 = i + 1; i2 < wires.Count; i2++)
                    {
                        if(wiresCross(wires[i], wires[i2]))
                        {
                            crosses++;
                        }
                    }
                }
                finalResult.Add("Case #" + testCase++ + ": " + crosses);
                testsNumber--;
            }

            File.WriteAllLines("result.out", finalResult);
        }

        public bool wiresCross(Tuple<int, int> wire1, Tuple<int, int> wire2)
        {
            return (wire1.Item1 < wire2.Item1 && wire1.Item2 > wire2.Item2)
                || (wire1.Item1 > wire2.Item1 && wire1.Item2 < wire2.Item2);
        }
    }
}
