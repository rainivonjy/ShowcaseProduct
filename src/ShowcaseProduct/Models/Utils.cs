using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowcaseProduct.Models
{
    public class Utils : IUtils
    {
        public string GetValueWithIndexAfterSplit(char separator, int index, string text)
        {
            string textValue = string.Empty;
            var nameAfterSplit = text.Split(separator);
            if (index > 0 && nameAfterSplit.Count() >= index)
            {
                textValue = nameAfterSplit[nameAfterSplit.Count() - index];
            }
            return textValue;
        }
    }
}
