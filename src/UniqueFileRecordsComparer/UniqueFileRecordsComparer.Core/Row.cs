using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace UniqueFileRecordsComparer.Core
{
    public class Row : Collection<Column>
    {
        public string GetColumnValueByHeader(string header)
        {
            return Items.FirstOrDefault(column => string.Equals(column.Header, header, StringComparison.OrdinalIgnoreCase))?.Value;
        }

        public IEnumerable<string> GetValueCombinations(IEnumerable<string> headers)
        {
            var combinations = new List<string>();
            var valuesToCombine = headers.Select(GetColumnValueByHeader).ToList();

            if (valuesToCombine.Count == 1)
            {
                return valuesToCombine;
            }

            for (int i = 0; i < valuesToCombine.Count; i++)
            {
                for (var j = 0; j < valuesToCombine.Count; j++)
                {
                    if (i != j)
                    {
                        combinations.Add($"{valuesToCombine[i]} {valuesToCombine[j]}");
                        combinations.Add($"{valuesToCombine[j]} {valuesToCombine[i]}");
                    }
                }
            }

            return combinations;
        }
    }
}
