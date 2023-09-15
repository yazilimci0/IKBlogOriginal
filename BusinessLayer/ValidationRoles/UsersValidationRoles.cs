using EFLayer.Class;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRoles
{
    public class UsersValidationRoles : AbstractValidator<User>
    {
        public UsersValidationRoles()
        {
            RuleFor(x => x.UserAdi).NotNull().WithMessage("Ad Boş geçilemez!");
            RuleFor(x => x.UserAdi).Length(2, 50).WithMessage("Minimum 2 maksimum 50 karakter girilebilir.");
            RuleFor(x => x.Password).NotNull().WithMessage("Soyad Boş geçilemez!");
            RuleFor(x => x.Password).Length(2, 25).WithMessage("Minimum 2 maksimum 25 karakter girilebilir.");
        }
    }
}

///using EFLayer.Class;
//using FluentValidation;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BusinessLayer.ValidationRoles
//{
//    public class UsersValidationRoles : AbstractValidator<User>
//    {
//    }
//}
