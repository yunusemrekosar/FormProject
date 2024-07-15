using Application.CQRS;
using Domain.Entities;

namespace Application.Features.Queries.FormQueries.ListForms
{
    public class ListFormsQueryResponse : BaseResponse
    {
        public List<Form> Forms { get; set; }
    }
}
