using Application.IRepository.IFormRepository;
using MediatR;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Queries.FormQueries.DetailForm
{
    public class DetailFormQueryHandler : IRequestHandler<DetailFormQueryRequest, DetailFormQueryResponse>
    {
        readonly IFormRead _formRead;

        public DetailFormQueryHandler(IFormRead formRead)
        {
            _formRead = formRead;
        }

        public async Task<DetailFormQueryResponse> Handle(DetailFormQueryRequest request, CancellationToken cancellationToken)
        {
            DetailFormQueryResponse response = new();

            try
            {
                var form = await _formRead.GetById(request.Id)
                    .Include(x=>x.FormFields)
                    .FirstOrDefaultAsync();

                if (form != null)
                {
                    response.Form = form;
                    response.IsSuccess = true;
                }
            }
            catch (Exception ex)
            {
                //loglanabilir
            }

            return response;
        }
    }
}
