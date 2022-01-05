using System.Collections.Generic;

namespace Examples.Examples_Av7.Articles
{
    public interface IEditor 
    {
        Article Find(List<Article> articles);
        List<string> ExtractTags(List<Article> articles);
    }
}
