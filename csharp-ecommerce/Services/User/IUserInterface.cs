using csharp_ecommerce.DTOs;
using csharp_ecommerce.Models;
using System.Runtime.CompilerServices;

namespace csharp_ecommerce.Services.User
{
    public interface IUserInterface
    {
        Task<ResponseModel<List<UserModel>>> FindAllUsers();
        Task<ResponseModel<UserModel>> FindUserById(int userId);
        Task<ResponseModel<UserDTO>> CreateUser(UserDTO userDto);
        Task<ResponseModel<UserDTO>> UpdateUser(int userId, UserDTO userDTO);
        Task<ResponseModel<UserDTO>> DeleteUser(int userId);
    }
}
