using FluentValidation;

namespace Api_monopoly.Apps.ManageApi.Dtos
{
    public class AdminLoginDto
    {
        public string UserName { get; set; }    
        public string Password { get; set; }    


        public class AdminLoginDtoValidator : AbstractValidator<AdminLoginDto>
        {
            public AdminLoginDtoValidator()
            {
                RuleFor(x=>x.UserName).MaximumLength(20);   
                RuleFor(x=>x.Password).MaximumLength(20).MinimumLength(8);

            }
        }
    }
}
