using Application.CQRS;
using MediatR;

namespace Application.Features.Queries.FormQueries.ListForms
{
    public class ListFormsQueryRequest : BaseRequest, IRequest<ListFormsQueryResponse>
    {
        public string? Search { get; set; }
    }
}
