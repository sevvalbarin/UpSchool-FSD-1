using Domain.Enums;

namespace Domain.Dtos
{
    public class SeleniumLogDto
    {
        public string Message { get; set; }
        public DateTimeOffset SentOn { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public SeleniumLogDto(string message, OrderStatus status)
        {
            Message = message;

            OrderStatus = status;

            SentOn = DateTimeOffset.Now;
        }
    }
}