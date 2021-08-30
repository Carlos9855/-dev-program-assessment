using System.Linq;
using System;
using Assessment;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssessmentTest
{
    [TestClass]
    public class PaginationTest
    {
        private const string COMMA_SAMPLE = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z";
        private const string PIPE_SAMPLE = "a|b|c|d|e|f|g|h|i|j|k|l|m|n|o|p|q|r|s|t|u|v|w|x|y|z";
        private const string COMMA_NUMBER_SAMPLE = "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30";

        [TestMethod]
        public void TestFirstPage()
        {
            IElementsProvider<string> provider = new StringProvider();
            IPagination<string> pagination = new PaginationString(COMMA_SAMPLE, 5, provider);
            pagination.FirstPage();
            string [] expectedElements = {"a", "b", "c", "d", "e"};
            CollectionAssert.AreEqual(expectedElements, pagination.GetVisibleItems().ToList());
        }

        [TestMethod]
        public void TestNextPage()
        {
            IElementsProvider<string> provider = new StringProvider();
            IPagination<string> pagination = new PaginationString(COMMA_SAMPLE, 5, provider);
            pagination.NextPage();
            string [] expectedElements = {"f", "g", "h", "i", "j"};
            CollectionAssert.AreEqual(expectedElements, pagination.GetVisibleItems().ToList());
        }

        [TestMethod]
        public void TestPreviousPage()
        {
            IElementsProvider<string> provider = new StringProvider();
            IPagination<string> pagination = new PaginationString(COMMA_SAMPLE, 5, provider);
            pagination.GoToPage(3);
            pagination.PrevPage();
            string[] expectedElements = { "f", "g", "h", "i", "j" };
            CollectionAssert.AreEqual(expectedElements, pagination.GetVisibleItems().ToList());
        }

        [TestMethod]
        public void TestLastPage()
        {
            IElementsProvider<string> provider = new StringProvider();
            IPagination<string> pagination = new PaginationString(COMMA_SAMPLE, 5, provider);
            pagination.LastPage();
            //string [] expectedElements = {"v", "w", "x", "y", "z"};
            //en la ultima pagina habria solo un elemento ya que el abecedario tiene 26 letras y en cada hoja entran 5 letras para este test
            string[] expectedElements = { "z" };
            CollectionAssert.AreEqual(expectedElements, pagination.GetVisibleItems().ToList());
        }

        [TestMethod]
        public void TestFirstPageWith10PageSize()
        {
            IElementsProvider<string> provider = new StringProvider();
            IPagination<string> pagination = new PaginationString(COMMA_SAMPLE, 10, provider);
            pagination.FirstPage();
            string [] expectedElements = {"a", "b", "c", "d", "e", "f", "g", "h", "i", "j"};
            CollectionAssert.AreEqual(expectedElements, pagination.GetVisibleItems().ToList());
        }

        [TestMethod]
        public void TestLastPageWith10PageSize()
        {
            IElementsProvider<string> provider = new StringProvider();
            IPagination<string> pagination = new PaginationString(COMMA_SAMPLE, 10, provider);
            pagination.LastPage();
            string[] expectedElements = { "u", "v", "w", "x", "y", "z" };
            CollectionAssert.AreEqual(expectedElements, pagination.GetVisibleItems().ToList());
        }

        [TestMethod]
        public void TestGoToPageWith10PageSize()
        {
            IElementsProvider<string> provider = new StringProvider();
            IPagination<string> pagination = new PaginationString(COMMA_SAMPLE, 10, provider);
            pagination.GoToPage(3);
            string[] expectedElements = { "u", "v", "w", "x", "y", "z" };
            CollectionAssert.AreEqual(expectedElements, pagination.GetVisibleItems().ToList());
        }

         [TestMethod]
        public void TestFirstPageWithPipeSample()
        {
            IElementsProvider<string> provider = new StringProvider();
            IPagination<string> pagination = new PaginationString(PIPE_SAMPLE, 5, provider);
            pagination.FirstPage();
            string [] expectedElements = {"a", "b", "c", "d", "e"};
            CollectionAssert.AreEqual(expectedElements, pagination.GetVisibleItems().ToList());
        }

        [TestMethod]
        public void TestPreviousPageException()
        {
            IElementsProvider<string> provider = new StringProvider();
            IPagination<string> pagination = new PaginationString(COMMA_SAMPLE, 5, provider);
            pagination.PrevPage();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException), "Invalid page number.")]
        public void TestGoToPageException()
        {
            IElementsProvider<string> provider = new StringProvider();
            IPagination<string> pagination = new PaginationString(COMMA_SAMPLE, 5, provider);
            pagination.GoToPage(1000000);
        }

        [TestMethod]
        public void GetVisibleItems()
        {
            IElementsProvider<string> provider = new StringProvider();
            IPagination<string> pagination = new PaginationString(COMMA_NUMBER_SAMPLE, 5, provider);
            pagination.FirstPage();
            string[] expectedElements = { "1", "2", "3", "4", "5" };
            CollectionAssert.AreEqual(expectedElements, pagination.GetVisibleItems().ToList());
        }

        [TestMethod]
        public void NextPage()
        {
            IElementsProvider<string> provider = new StringProvider();
            IPagination<string> pagination = new PaginationString(COMMA_NUMBER_SAMPLE, 5, provider);
            pagination.NextPage();
            string[] expectedElements = { "6", "7", "8", "9", "10" };
            CollectionAssert.AreEqual(expectedElements, pagination.GetVisibleItems().ToList());
        }

        [TestMethod]
        public void GoToPage()
        {
            IElementsProvider<string> provider = new StringProvider();
            IPagination<string> pagination = new PaginationString(COMMA_NUMBER_SAMPLE, 5, provider);
            pagination.GoToPage(5);
            string[] expectedElements = { "21", "22", "23", "24", "25" };
            CollectionAssert.AreEqual(expectedElements, pagination.GetVisibleItems().ToList());
        }
    }
}
