using System;
using System.Collections.Generic;
using System.Linq;

namespace Examples.Examples_Av7.Articles
{
    public static class Utilities
    {
        public static int FindIndexOfFirstLarger<T>(List<T> data, T value) where T : IComparable<T>
        {
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].CompareTo(value) == 1) 
                {
                    return i;
                }
            }
            return -1;
        }

        public static decimal FindLeastTaggedArticlePrice(List<Article> articles)
        {
            return articles.OrderBy(it => it.Tags.Count)
                .First()
                .Price;
        }
    }
}
