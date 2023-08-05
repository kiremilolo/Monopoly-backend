using FluentValidation;

namespace Api_monopoly.Apps.Client.Dtos.UserDtos
{
    public class UserLoginDto
    {
        public string Email { get; set; }  
        public string Password { get; set; }    
    }
    public class UserLoginDtoValidator: AbstractValidator<UserLoginDto>
    {
        public UserLoginDtoValidator()
        {
            RuleFor(x => x.Email).MaximumLength(20).MinimumLength(4).NotEmpty().Matches("^\\S+@\\S+\\.\\S+$");
            RuleFor(x => x.Password).MaximumLength(20).MinimumLength(8).NotEmpty();
        }
    }
}
