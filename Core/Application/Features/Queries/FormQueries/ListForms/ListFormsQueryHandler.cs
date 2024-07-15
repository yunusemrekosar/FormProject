using Application.IRepository.IFormRepository;
using Microsoft.EntityFrameworkCore;
using MediatR;

namespace Application.Features.Queries.FormQueries.ListForms
{
    public class ListFormsQueryHandler : IRequestHandler<ListFormsQueryRequest, ListFormsQueryResponse>
    {
        readonly IFormRead _formRead;

        public ListFormsQueryHandler(IFormRead formRead)
        {
            _formRead = formRead;
        }

        public async Task<ListFormsQueryResponse> Handle(ListFormsQueryRequest request, CancellationToken cancellationToken)
        {
            ListFormsQueryResponse response = new();
            try
            {
                var forms = await _formRead.GetUsersForms(request.LoggedUserId)
                    .Include(x=>x.FormFields)
                    .ToListAsync();

                if (forms != null)
                {
                    response.IsSuccess = true;
                    response.Forms = forms;
                    return response;
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
