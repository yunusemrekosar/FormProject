namespace Application.CQRS
{
    public abstract class BaseRequest
    {
        public int LoggedUserId { get; set; }
    }
}
