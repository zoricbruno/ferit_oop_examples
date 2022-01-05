using System.Collections.Generic;

namespace Examples.Examples_Av7.Articles
{
    public class CustomEditor : IEditor
    {
        public string Tag { get; set; }

        public CustomEditor(string tag)
        {
            Tag = tag;
        }

        public List<string> ExtractTags(List<Article> articles)
        {
            List<string> tags = new List<string>();
            decimal totalPrice = 0.0m;
            foreach (Article article in articles)
            {
                totalPrice += article.Price;
            }
            decimal averagePrice = totalPrice / articles.Count;
            foreach (Article article in articles)
            {
                if (article.Price < averagePrice)
                {
                    tags.AddRange(article.Tags);
                }
            }
            return tags;
        }

        public Article Find(List<Article> articles)
        {
            foreach (Article article in articles)
            {
                if (article.Tags.Contains(this.Tag))
                {
                    return article;
                }
            }
            return null;
        }
    }
}
