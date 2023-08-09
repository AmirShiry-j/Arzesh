using Application.Common.CreateDtoes;
using Application.Common;
using Application.CommonServices.Query;
using Application.Interfaces.Contexts;
using AutoMapper;
using Domain.ProjectEnums;
using Domain.Projects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ProjectNeeds;
using Domain.Users;

namespace Application.Project_UnderCapacityService.Command
{
    public interface IAddProject_UnderCapacityService
    {
        Task<ResultDto<int>> Execute(CreateProject_UnderCapacityDto ProjectDto, string UserId);
    }
    public class AddProject_UnderCapacityService : IAddProject_UnderCapacityService
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IValidateService _validateService;
        public AddProject_UnderCapacityService
(IDataBaseContext dbContext,
            IMapper mapper,
            IValidateService validateService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _validateService = validateService;
        }
        public async Task<ResultDto<int>> Execute(CreateProject_UnderCapacityDto ProjectDto, string UserId)
        {
            //Map
            var newProject = _mapper.Map<Project>(ProjectDto);
            newProject.ProjectTypeId = (int)ProjectTypeEnum.UnderCapacity;
            newProject.UserId = UserId;
            //
            newProject.P_UnderCapacity = _mapper.Map<Project_UnderCapacity>(ProjectDto);

            //Industry
            var resultCheckIndustry = await _validateService.CheckIndustry((int)newProject.IndustryId);
            if (!resultCheckIndustry.IsSuccess)
                return _mapper.Map<ResultDto<int>>(resultCheckIndustry);

            //RentType
            var resultCheckRentType = await _validateService.CheckRentType((int)newProject.P_UnderCapacity.RentTypeId, newProject.P_UnderCapacity.PlaceOfImplementation);
            if (!resultCheckRentType.IsSuccess)
                return _mapper.Map<ResultDto<int>>(resultCheckRentType);
            else
                if (newProject.P_UnderCapacity.PlaceOfImplementation != PlaceOfImplementation.Rent)
                newProject.P_UnderCapacity.RentTypeId = null;

            ////Licence
            var resultCheckLicences = await _validateService.CheckLicences(newProject.Licences.ToList());
            if (!resultCheckLicences.IsSuccess)
                return _mapper.Map<ResultDto<int>>(resultCheckLicences);

            ////Faciliti
            var resultCheckFacilitis = await _validateService.CheckFacilitis(newProject.Facilitis.ToList());
            if (!resultCheckFacilitis.IsSuccess)
                return _mapper.Map<ResultDto<int>>(resultCheckFacilitis);

            ////Asset
            var resultCheckAssets = await _validateService.CheckAssets(newProject.Assets.ToList());
            if (!resultCheckAssets.IsSuccess)
                return _mapper.Map<ResultDto<int>>(resultCheckAssets);

            ////Capacity
            var resultCheckCapacities = await _validateService.CheckCapacities(newProject.Capacities.ToList());
            if (!resultCheckCapacities.IsSuccess)
                return _mapper.Map<ResultDto<int>>(resultCheckCapacities);

            ////Address
            var resultCheckAddress = await _validateService.CheckAddress(newProject.Address);
            if (!resultCheckAddress.IsSuccess)
                return _mapper.Map<ResultDto<int>>(resultCheckAddress);

            //save in db
            _dbContext.Projects.Add(newProject);
            _dbContext.SaveChanges();


            return new ResultDto<int>
            {
                IsSuccess = true,
                Data = newProject.Id
            };
        }
    }
    public class CreateProject_UnderCapacityDto
    {
        /// <summary>
        /// /Commons For Always
        /// </summary>
        //نام پروژه
        public string Name { get; set; }
        //ایده شما در چه صنعت و بخشی است؟
        public int IndustryId { get; set; }
        //نرخ بازگشت سرمایه طرح
        public int ReturnInvestmentRate { get; set; }
        //میزان سرمایه مورد تقاضا
        public int AmountCapitalDemand { get; set; }
        //آدرس
        public CreateAddressDto Address { get; set; }
        /// <summary>
        /// End Commons
        /// </summary>
        /// 

        //قصد واگذاری ایده را دارید یا به دنبال مشارکت هستید؟
        public AssignmentOrParticipation AssignmentOrParticipation { get; set; }
        //مشارکت
        //درصد مشارکت
        public int PercentParticipation { get; set; }
        //مشارکت
        //آیا در حوزه فعالیت طرح سابقه و یا تجربه دارید؟ 
        public string AmountOfExperience { get; set; }
        //کلیه مجوزهایی که تا کنون اخذ نموده اید
        public bool HaveAllLicences { get; set; }
        //محل اجرای طرح
        public PlaceOfImplementation PlaceOfImplementation { get; set; }
        //اجاره
        public int RentTypeId { get; set; }
        //آیا طرح توجیهی برای ایده تدوین شده است؟
        public bool JustificationPlan { get; set; }
        //آیا صورت مالی دارید؟
        public bool HaveFinancialStatement { get; set; }
        //واگذاری
        //قیمت پیشنهادی
        public int ProposedPrice { get; set; }
        //مشارکت
        //میزان مشارکت مورد نیاز
        public int AmountOfParticipationRequired { get; set; }
        //مشارکت
        //کل سرمایه مورد نیاز طرح
        public int RequiredCapitalPlan { get; set; }
        //مشارکت
        //در چه سرفصل‌هایی نیاز به مشارکت دارید؟
        public string WhatTopicsNeedParticipate { get; set; }
        //آیا پروژه شما در حال حاضر سودده می‌باشد
        public bool IsCurrentlyProfitable { get; set; }
        //بله
        //میزان سود سال گذشته
        public int LastYearProfit { get; set; }
        //خیر
        //میزان زیان سال گذشته
        public int LastYearLoss { get; set; }
        //آیا تاکنون در خصوص طرح مذکور تسهیلات دریافت نموده‌اید؟
        public bool HaveReceivedFaciliti { get; set; }

        //دارایی ها
        public List<CreateAssetRelProjectDto> Assets { get; set; }
        //مجوز ها
        public List<CreateLicenceRelProjectDto> Licences { get; set; }
        //ظرفیت ها
        public List<CreateCapacityRelProjectDto> Capacities { get; set; }
        //تسهیلات
        public List<CreateFacilitiRelProjectDto> Facilitis { get; set; }
    }

}
