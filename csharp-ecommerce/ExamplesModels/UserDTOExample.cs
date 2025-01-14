using csharp_ecommerce.DTOs;
using Swashbuckle.AspNetCore.Filters;

namespace csharp_ecommerce.Examples
{
    public class UserDTOExample : IExamplesProvider<UserDTO>
    {
        public UserDTO GetExamples()
        {
            return new UserDTO("John Doe", "johndoe@gmail.com", "johndoe123!", "22 93214-9583", Enums.UserRoles.User | Enums.UserRoles.Admin);
        }
    }
}
