using System.Collections.Generic;

namespace Assessment
{
    public class StringProvider : IElementsProvider<string>
    {
        private readonly string[] separator = {",","|"," "};


        public IEnumerable<string> ProcessData(string source)
        {
            for(int i=0; i< separator.Length; i++)
            {
                if(source.Contains(separator[i]))
                {
                    return source.Split(separator[i]);
                }
            }
            return null;
        }
    }
}