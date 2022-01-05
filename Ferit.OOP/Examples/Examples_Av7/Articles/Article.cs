using System.Collections.Generic;

namespace Examples.Examples_Av7.Articles
{
    public class Article
    {
        public string Title { get; private set; }
        public decimal Price { get; private set; }
        public List<string> Tags { get; private set; }

        public Article(string title, decimal price)
        {
            this.Title = title;
            this.Price = price;
            Tags = new List<string>();
        }

        public void Tag(string tag) { Tags.Add(tag); }
    }
}
