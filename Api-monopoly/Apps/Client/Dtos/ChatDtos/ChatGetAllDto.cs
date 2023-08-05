using Api_monopoly.Apps.Client.Dtos.ChatDtos;
using FluentValidation;

namespace Api_monopoly.Apps.Client.Dtos.Chat
{
    public class ChatGetAllDto
    {
        public string ChatText { get; set; }        
        public string User { get; set; }        
        public DateTime date { get; set; }  
    }


    public class ChatGetAllDtoValidator : AbstractValidator<ChatGetAllDto>
    {
        public ChatGetAllDtoValidator()
        {
            RuleFor(x => x.ChatText).NotEmpty().NotNull();
        }
    }
}
