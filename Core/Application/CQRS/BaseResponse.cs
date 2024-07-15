namespace Application.CQRS
{
    public abstract class BaseResponse
    {
        public bool IsSuccess { get; set; } = false;

        public string Message { get; set; } = "Beklenmedik Bir Hata Oluştu, Lütfen Daha Sonra Tekrar Deneyiniz!";
    }
}
