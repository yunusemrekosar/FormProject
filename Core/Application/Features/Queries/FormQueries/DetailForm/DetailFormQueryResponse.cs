using Application.CQRS;
using Domain.Entities;

namespace Application.Features.Queries.FormQueries.DetailForm
{
    public class DetailFormQueryResponse : BaseResponse
    {
        public Form Form { get; set; }
    }
}