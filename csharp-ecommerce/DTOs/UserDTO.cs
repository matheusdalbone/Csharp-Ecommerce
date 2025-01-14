using csharp_ecommerce.Enums;

namespace csharp_ecommerce.DTOs
{
    public record UserDTO(string Name, string Email, string Password,string PhoneNumber, UserRoles UserRole)
    {
    }
}
