namespace Api_monopoly.Apps.Client.Dtos.ChatDtos
{
    public class ChatGetDto
    {
        public int ChatId { get; set; }
        public string ChatText { get; set; }
        public string User { get; set; }
        public DateTime date { get; set; }
    }
}
