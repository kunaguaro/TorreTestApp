using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.Domain.Entities;
using Web.Domain.Entities.ListElement;
using Web.Domain.Pagination;
using Web.Domain.Views.ListElement;

namespace Web.Domain.Interfaces.RootServices
{
    public interface IRootElementService
    {
        Task<Root> FindUserAsync(string userName);
        Task<ListElement.Root> ListadoResult(ListElementCriteria criteria, int page);
        PagingList<ListElement.Result> GetPaginateResultOrdersListView(ListElementCriteria criteria, int pageNo, bool firstLoad);
      
    }

}
