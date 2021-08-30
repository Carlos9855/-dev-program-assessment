using System.Collections.Generic;
using System.Linq;

namespace Assessment
{
    public class PaginationString : IPagination<string>
    {
        private readonly IEnumerable<string> data;
        private readonly int pageSize;
        private int currentPage;
        private int nPages;

        public PaginationString(string source, int pageSize, IElementsProvider<string> provider)
        {
            data = provider.ProcessData(source);
            currentPage = 1;
            this.pageSize = pageSize;
            if (pageSize >= data.Count())
            {
                nPages = 1;
            }
            else
            {
                if (data.Count() % pageSize != 0)
                {
                    nPages = data.Count() / pageSize + 1;
                }
                else
                {
                    nPages = data.Count() / pageSize;
                }
            }
        }
        public void FirstPage()
        {
            currentPage = 1;
        }

        public void GoToPage(int page)
        {
            if (page <= 0 || page > nPages)
            {
                throw new System.InvalidOperationException();
            }
            else
            {
                currentPage = page;
            }
        }

        public void LastPage()
        {
            currentPage = nPages;
        }

        public void NextPage()
        {
            if (currentPage + 1 <= nPages)
            {
                currentPage++;
            }
        }

        public void PrevPage()
        {
            if (currentPage - 1 > 0)
            {
                currentPage--;
            }
        }

        public IEnumerable<string> GetVisibleItems()
        {
            return data.Skip((currentPage - 1) * pageSize).Take(pageSize);
        }

        public int CurrentPage()
        {
            return currentPage;
        }

        public int Pages()
        {
            return nPages;
        }
    }
}