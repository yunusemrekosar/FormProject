using Domain.Entities;

namespace Application.IRepository.IFormRepository
{
    public interface IFormRead : IReadRepository<Form>
    {
        public IQueryable<Form> GetUsersForms(int userId, string search, bool tracking = true);
    }
}
