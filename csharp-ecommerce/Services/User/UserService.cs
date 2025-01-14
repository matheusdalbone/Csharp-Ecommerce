using csharp_ecommerce.Data;
using csharp_ecommerce.DTOs;
using csharp_ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace csharp_ecommerce.Services.User
{
    public class UserService : IUserInterface
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<ResponseModel<UserDTO>> CreateUser(UserDTO userDto)
        {
            ResponseModel<UserDTO> response = new ResponseModel<UserDTO>();
            try
            {
                var user = new UserModel()
                {
                    Name = userDto.Name,
                    Email = userDto.Email,
                    Password = userDto.Password,
                    PhoneNumber = userDto.PhoneNumber,
                    UserRole = userDto.UserRole,
                    CreationDate = DateTime.Now
                };

                _context.Add(user);
                await _context.SaveChangesAsync();

                var CreatedUserDTO = new UserDTO(user.Name, user.Email, user.Password, user.PhoneNumber, user.UserRole);

                response.Value = CreatedUserDTO;
                response.Message = "User created successful";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsError = true;

                return response;
            }
        }

        public async Task<ResponseModel<List<UserModel>>> FindAllUsers()
        {
            ResponseModel<List<UserModel>> response = new ResponseModel<List<UserModel>>();
            try
            {
                var users = await _context.Users.ToListAsync();

                response.Value = users;
                response.Message = "Successful";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsError = true;

                return response;
            }
        }

        public async Task<ResponseModel<UserModel>> FindUserById(int userId)
        {
            ResponseModel<UserModel> response = new ResponseModel<UserModel>();

            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(userDb => userDb.Id == userId);

                if (user != null)
                {
                    response.Value = user;
                    response.Message = "Successful";
                    response.IsError = false;
                }
                else
                {
                    response.Value = null;
                    response.Message = "User not found";
                    response.IsError = true;
                }
                
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.IsError= true;

                return response;
            }
        }
        public async Task<ResponseModel<UserDTO>> UpdateUser(int userId, UserDTO userDTO)
        {
            ResponseModel<UserDTO> response = new ResponseModel<UserDTO>();

            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(userDb => userDb.Id == userId);

                if (user == null)
                {
                    response.Value = null;
                    response.Message = "User not found";
                    response.IsError = true;

                    return response;
                }

                user.Name = userDTO.Name;
                user.Email = userDTO.Email;
                user.Password = userDTO.Password;
                user.PhoneNumber = userDTO.PhoneNumber;
                user.UserRole = userDTO.UserRole;

                await _context.SaveChangesAsync();

                var updatedUserDTO = new UserDTO(user.Name, user.Email, user.Password, user.PhoneNumber, user.UserRole);
                
                response.Value = updatedUserDTO;
                response.Message = "User update success";
                response.IsError = false;

                return response;
            }
            catch (Exception ex)
            {

                response.Message = ex.Message;
                response.IsError= true;

                return response;
            }
        }

        public async Task<ResponseModel<UserDTO>> DeleteUser(int userId)
        { 
            ResponseModel<UserDTO> response = new ResponseModel<UserDTO>();

            try
            {
                var deletedUser = await _context.Users.FirstOrDefaultAsync(user => user.Id == userId);

                if (deletedUser == null)
                { 
                    response.Value = null;
                    response.Message = "User not found.";
                    response.IsError = true;

                    return response;
                }

                _context.Remove(deletedUser);
                await _context.SaveChangesAsync();

                UserDTO deletedUserDTO = new UserDTO(deletedUser.Name, deletedUser.Email, deletedUser.Password, deletedUser.PhoneNumber, deletedUser.UserRole);

                response.Value = deletedUserDTO;
                response.Message = "User successfully deleted";
                response.IsError = false;

                return response;
            }
            catch (Exception ex)
            {
                response.Value = null;
                response.Message = ex.Message;
                response.IsError = true;

                return response;
            }

        }
    }
}
