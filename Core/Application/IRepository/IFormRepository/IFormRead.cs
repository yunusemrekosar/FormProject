using Domain.Entities;

namespace Application.IRepository.IFormRepository
{
    public interface IFormRead : IReadRepository<Form>
    {
        IQueryable<Form> GetUsersForms(int userId, bool tracking = true);

    }
}
