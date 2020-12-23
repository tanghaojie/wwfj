using Abp.Domain.Repositories;
using Abp.UI;
using Backend.Entities;
using Backend.JTAuthenticate;
using Backend.Web.Host.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Backend.Web.Host.Controllers
{
    [Route("api/services/app/[controller]")]
    [ApiController, IgnoreAntiforgeryToken]
    public class UserController : BackendWebHostControllerBase
    {
        //private readonly IRepository<User> _userRepository;
        //public UserController(IRepository<User> userRepository)
        //{
        //    _userRepository = userRepository;
        //}


        //[HttpPost]
        //public async Task<int> AddUser(AddUserInput input)
        //{
        //    if (string.IsNullOrWhiteSpace(input.Username) || string.IsNullOrWhiteSpace(input.Password))
        //    {
        //        throw new UserFriendlyException("请输入用户名或密码");
        //    }
        //    if (!new Regex(@"^[a-zA-Z\u4e00-\u9fa5][a-zA-Z0-9\u4e00-\u9fa5_]{1,13}$").Match(input.Username).Success)
        //    {
        //        throw new UserFriendlyException("请输入字母或中文开头，只包含字母中文数字下划线，长度为2~12字符的用户名");
        //    }
        //    if (input.Department == Department.KanTanYeWu && string.IsNullOrWhiteSpace(input.RegionCode))
        //    {
        //        throw new UserFriendlyException("请输入所在市区县");
        //    }
        //    if (!new Regex(@"^[0-9a-zA-Z]\w{5,17}$").Match(input.Password).Success)
        //    {
        //        throw new UserFriendlyException("以字母开头，长度在6~18之间，只能包含字母、数字和下划线的密码");
        //    }
        //    if (!string.IsNullOrWhiteSpace(input.Phone) && !new Regex(@"^1[345789]\d{9}$").Match(input.Phone).Success)
        //    {
        //        throw new UserFriendlyException("手机号错误");
        //    }
        //    if (_userRepository.Count(x => x.Username == input.Username) > 0)
        //    {
        //        throw new UserFriendlyException("用户名已存在");
        //    }
        //    if (!string.IsNullOrWhiteSpace(input.Phone) && _userRepository.Count(x => x.Phone == input.Phone) > 0)
        //    {
        //        throw new UserFriendlyException("电话已存在");
        //    }
        //    return await _userRepository.InsertAndGetIdAsync(ObjectMapper.Map<User>(input));
        //}

        //[HttpGet]
        //public async Task<List<UserOutput>> Get()
        //{
        //    var list = await _userRepository.GetAll().OrderByDescending(x => x.Id).ToListAsync();
        //    return ObjectMapper.Map<List<UserOutput>>(list);
        //}

    }
}
