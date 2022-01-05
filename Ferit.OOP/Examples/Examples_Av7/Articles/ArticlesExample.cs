using System.Collections.Generic;
using System.Diagnostics;

namespace Examples.Examples_Av7.Articles
{
    public static class ArticlesExample
    {
        public static void RunDemo()
        {
            // Z7:
            Article article = new Article("Hello world", 29.99m);
            article.Tag("C#");
            Debug.Assert(article.Tags.Contains("C#"));

            // Z8:
            List<Article> articles = new List<Article>()
            {
                new Article("A", 123.0m),
                new Article("B", 456.0m),
                new Article("C", 789.0m),
            };
            articles[0].Tag("One");
            articles[2].Tag("One");
            articles[2].Tag("Two");

            IEditor editor = new CustomEditor("One");
            Article found = editor.Find(articles);
            Debug.Assert(found.Title == "A", "Incorrect article found.");
            List<string> tags = editor.ExtractTags(articles);
            Debug.Assert(tags.Count == 1, "Some tags incorrect or not found.");


            // Z9:
            List<int> data = new List<int>() { 2, 3, 2, 4, 8, 5, 9, 6 };
            int index = Utilities.FindIndexOfFirstLarger(data, 8);
            Debug.Assert(index == 6, "Incorrect index");

            // Z10:
            Debug.Assert(Utilities.FindLeastTaggedArticlePrice(articles) == 456m);
        }
    }
}
