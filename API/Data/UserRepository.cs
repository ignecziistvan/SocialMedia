using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Dtos;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class UserRepository(DataContext context, IMapper mapper) : IUserRepository
{
    public async Task<IEnumerable<UserDto>> GetAllUsers()
    {
        return await context.Users
            .ProjectTo<UserDto>(mapper.ConfigurationProvider)
            .ToListAsync();
    }

    public async Task<UserDto?> GetUser(string username)
    {
        return await context.Users
            .Where(user => user.UserName == username)
            .ProjectTo<UserDto>(mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
    }
}
