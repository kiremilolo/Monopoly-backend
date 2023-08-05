using Api_monopoly.Apps.Client.Dtos.Chat;
using FluentValidation;

namespace Api_monopoly.Apps.Client.Dtos.ChatDtos
{
    public class ChatDto
    {
        public string ChatText { get; set; }
        public string User { get; set; }
        public DateTime date { get; set; }
    }




    public class ChatDtoValidator : AbstractValidator<ChatDto>
    {
        public ChatDtoValidator()
        {
            RuleFor(x => x.ChatText).NotEmpty().NotNull();
        }
    }


}
