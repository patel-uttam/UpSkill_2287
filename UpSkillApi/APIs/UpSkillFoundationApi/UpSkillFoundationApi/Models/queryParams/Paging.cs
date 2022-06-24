using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UpSkillFoundationApi.Models
{
    public class Paging
    {

        private int PageNumber;
        private int ItemPerPage;

        public Paging()
        {
            pageNumber = 1;
            itemPerPage = 5;
        }

        public Paging(int pagenumber, int itemperpage)
        {
            pageNumber = pagenumber < 1 ? 1 : pagenumber;
            itemPerPage = itemperpage < 1 || itemperpage > 100 ? 10 : itemperpage;
        }

        public int pageNumber
        {
            get { return PageNumber; }
            set { PageNumber = value; }
        }

        public int itemPerPage
        {
            get { return ItemPerPage; }
            set { ItemPerPage = value; }
        }
    }
}
