
using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Api_monopoly.Apps.Client.Dtos.UserDtos
{
    public class UserRegisterDto
    {
        public string Email { get; set; }   
        public string Password { get; set; }
        public string ConfirmPassword { get; set; } 
        public string Username { get; set; }        
    }


    public class UserRegisterDtoValidator : AbstractValidator<UserRegisterDto>
    {
        public UserRegisterDtoValidator()
        {
            RuleFor(x=>x.Email).MinimumLength(4).NotEmpty().Matches("^\\S+@\\S+\\.\\S+$");   
            RuleFor(x=>x.Username).MaximumLength(100).MinimumLength(4).NotEmpty();
            RuleFor(x=>x.Password).MaximumLength(100).MinimumLength(4).NotEmpty();
            RuleFor(x=>x.ConfirmPassword).MaximumLength(100).MinimumLength(4).NotEmpty();
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password);
        }
    }
}
