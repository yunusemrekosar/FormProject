using Application.IRepository.IFormRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.Commands.FormCommands.AddForm
{
    public class AddFormCommandHandler : IRequestHandler<AddFormCommandRequest, AddFormCommandResponse>
    {
        readonly IFormWrite _formWrite;

        public AddFormCommandHandler(IFormWrite formWrite)
        {
            _formWrite = formWrite;
        }

        public async Task<AddFormCommandResponse> Handle(AddFormCommandRequest request, CancellationToken cancellationToken)
        {
            AddFormCommandResponse response = new();

            try
            {
                if (request.FormFields.Count == 0)
                {
                    response.Message = "Alan eklemeden form oluşturamazsınız!";
                    return response;
                }

                var fields = new List<FormField>();

                foreach (var item in request.FormFields)
                {
                    fields.Add(new FormField()
                    {
                        Name = item.FieldName,
                        DataType = item.DataType,
                        Required = item.IsRequired
                    });
                }

                var form = new Form();
                form.Name = request.Name;
                form.Description = request.Description;
                form.CreatedBy = request.LoggedUserId;
                form.FormFields = fields;

                if (await _formWrite.AddAsync(form))
                    if (await _formWrite.SaveAsync() > 0)
                    {
                        response.IsSuccess = true;
                        response.Message = "Form Başarıyla Oluşturuldu";
                    }
            }
            catch (Exception ex)
            {

            }

            return response;
        }
    }
}
