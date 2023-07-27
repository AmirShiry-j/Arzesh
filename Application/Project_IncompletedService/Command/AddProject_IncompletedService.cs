using Application.Common;
using Application.CommonServices.Query;
using Application.Interfaces.Contexts;
using AutoMapper;
using Domain.Projects;
using Domain.ProjectEnums;
using Domain.ProjectNeeds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.CreateDtoes;

namespace Application.Project_IncompletedService.Command
{
    public interface IAddProject_IncompletedService
    {
        Task<ResultDto<int>> Execute(CreateProject_IncompletedDto ProjectDto, string UserId);
    }
    public class AddProject_IncompletedService : IAddProject_IncompletedService
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IValidateService _validateService;
        public AddProject_IncompletedService
(IDataBaseContext dbContext,
            IMapper mapper,
            IValidateService validateService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _validateService = validateService;
        }
        public async Task<ResultDto<int>> Execute(CreateProject_IncompletedDto ProjectDto, string UserId)
        {
            //Map
            var newProject = _mapper.Map<Project>(ProjectDto);
            newProject.ProjectTypeId = (int)ProjectTypeEnum.Incompleted;
            newProject.UserId = UserId;
            //
            newProject.P_Incompleted = _mapper.Map<Project_Incompleted>(ProjectDto);

            //Industry
            var resultCheckIndustry = await _validateService.CheckIndustry((int)newProject.IndustryId);
            if (!resultCheckIndustry.IsSuccess)
                return _mapper.Map<ResultDto<int>>(resultCheckIndustry);

            //RentType
            var resultCheckRentType = await _validateService.CheckRentType((int)newProject.P_Incompleted.RentTypeId, newProject.P_Incompleted.PlaceOfImplementation);
            if (!resultCheckRentType.IsSuccess)
                return _mapper.Map<ResultDto<int>>(resultCheckRentType);
            else
                if (newProject.P_Incompleted.PlaceOfImplementation != PlaceOfImplementation.Rent)
                newProject.P_Incompleted.RentTypeId = null;

            ////Licence
            var resultCheckLicences = await _validateService.CheckLicences(newProject.Licences.ToList());
            if (!resultCheckLicences.IsSuccess)
                return _mapper.Map<ResultDto<int>>(resultCheckLicences);

            ////Faciliti
            var resultCheckFacilitis = await _validateService.CheckFacilitis(newProject.Facilitis.ToList());
            if (!resultCheckFacilitis.IsSuccess)
                return _mapper.Map<ResultDto<int>>(resultCheckFacilitis);


            ////Fund
            var resultCheckFunds = await _validateService.CheckFunds(newProject.Funds.ToList());
            if (!resultCheckFunds.IsSuccess)
                return _mapper.Map<ResultDto<int>>(resultCheckFunds);

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
    public class CreateProject_IncompletedDto
    {
        public string Name { get; set; }
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

        //ایده شما در چه صنعت و بخشی است؟
        public int IndustryId { get; set; }
        //آیا طرح توجیهی برای ایده تدوین شده است؟
        public bool JustificationPlan { get; set; }
        //واگذاری
        //قیمت پیشنهادی
        public int ProposedPrice { get; set; }
        //مشارکت
        //کل سرمایه مورد نیاز طرح
        public int RequiredCapitalPlan { get; set; }
        //میزان سرمایه مورد تقاضا
        public int AmountCapitalDemand { get; set; }
        //مشارکت
        //در چه سرفصل‌هایی نیاز به مشارکت دارید؟
        public string WhatTopicsNeedParticipate { get; set; }
        //نرخ بازگشت سرمایه طرح
        public int ReturnInvestmentRate { get; set; }
        //خالص ارزش فعلی پروژه
        public int NetPresentValue { get; set; }
        //درصد پیشرفت کلی طرح تا کنون
        public int OverallProgressPercent { get; set; }


        //آیا تاکنون در خصوص طرح مذکور تسهیلات دریافت نموده‌اید؟
        public bool HaveReceivedFaciliti { get; set; }
        public CreateAddressDto Address { get; set; }

        public List<CreateLicenceRelProjectDto> Licences { get; set; }
        //تسهیلات
        public List<CreateFacilitiRelProjectDto> Facilitis { get; set; }
        //سرمایه گذاری ها
        public List<CreateFundRelProjectDto> Funds { get; set; }

    }

}
