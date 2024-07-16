using Application.CQRS;
using MediatR;

namespace Application.Features.Queries.FormQueries.DetailForm
{
    public class DetailFormQueryRequest: BaseRequest ,IRequest<DetailFormQueryResponse>
    {
        public int Id { get; set; }
    }
}