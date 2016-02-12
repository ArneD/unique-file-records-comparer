using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;

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

            for (var i = 0; i < valuesToCombine.Count; i++)
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

        public bool IsEqualTo(IList<string> rowColumnHeadersToCompare, Row targetRow, IList<string> targetColumnHeadersToCompare)
        {
            var targetCombinations = targetRow.GetValueCombinations(targetColumnHeadersToCompare);
            return (GetValueCombinations(rowColumnHeadersToCompare)
                .Any(x => targetCombinations.Any(y => RemoveDiacritics(x).IndexOf(RemoveDiacritics(y), StringComparison.OrdinalIgnoreCase) >= 0))
                    || targetCombinations.Any(target => HasTargetStringAllHeaders(target, rowColumnHeadersToCompare)));
        }

        private bool HasTargetStringAllHeaders(string target, IEnumerable<string> rowColumnHeadersToCompare)
        {
            var allValues = rowColumnHeadersToCompare.Select(GetColumnValueByHeader).ToList();

            return allValues.All(value => RemoveDiacritics(target).IndexOf(RemoveDiacritics(value), StringComparison.OrdinalIgnoreCase) >= 0);
        }

        private static string RemoveDiacritics(string text)
        {
            return string.Concat(
                text.Normalize(NormalizationForm.FormD)
                .Where(ch => CharUnicodeInfo.GetUnicodeCategory(ch) !=
                                              UnicodeCategory.NonSpacingMark)
              ).Normalize(NormalizationForm.FormC).Replace('\'', ' ');
        }
    }
}
