using Application.Common;
using Application.Interfaces.Contexts;
using AutoMapper;
using Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProfileService.Query
{
    public interface IGetProfileService
    {
        public Task<ResultDto<ProfileDto>> Execute(string UserId);
    }
    public class GetProfileService : IGetProfileService
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly IDataBaseContext _dbContext;
        public GetProfileService(IDataBaseContext dbContext
            , UserManager<User> userManager
            , IMapper mapper)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<ResultDto<ProfileDto>> Execute(string UserId)
        {
            var user = await _userManager.FindByIdAsync(UserId.ToString());

            var profileDto = _mapper.Map<ProfileDto>(user);

            return new ResultDto<ProfileDto>
            {
                Data = profileDto,
                IsSuccess = true
            };
        }
    }
    public class ProfileDto
    {
        public string UserId { get; set; }

        public string Name { get; set; }
        public string Code { get; set; }
        public UserType UserType { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Link Link { get; set; }
    }
}
