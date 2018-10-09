using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowcaseProduct.Models
{
    public interface IUtils
    {
        string GetValueWithIndexAfterSplit(char separator, int index, string text);
        string CreatePathImg(string NameImage, bool rootWeb);


    }
}
