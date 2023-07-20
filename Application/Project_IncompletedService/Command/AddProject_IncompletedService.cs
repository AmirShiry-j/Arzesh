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
            var newProject = _mapper.Map<Project_Incompleted>(ProjectDto);
            newProject.UserId = UserId;

            //Industry
            var resultCheckIndustry = await _validateService.CheckIndustry((int)newProject.IndustryId);
            if (!resultCheckIndustry.IsSuccess)
                return _mapper.Map<ResultDto<int>>(resultCheckIndustry);

            ////Licence
            var resultCheckLicences = await _validateService.CheckLicences(newProject.Licences.ToList());
            if (!resultCheckLicences.IsSuccess)
                return _mapper.Map<ResultDto<int>>(resultCheckLicences);
            newProject.Licences.ToList().ForEach(p =>
            {
                p.ProjectType = ProjectType.Incompleted;
            });

            ////Faciliti
            var resultCheckFacilitis = await _validateService.CheckFacilitis(newProject.Facilitis.ToList());
            if (!resultCheckFacilitis.IsSuccess)
                return _mapper.Map<ResultDto<int>>(resultCheckFacilitis);
            newProject.Facilitis.ToList().ForEach(p =>
            {
                p.ProjectType = ProjectType.Incompleted;
            });


            ////Fund
            var resultCheckFunds = await _validateService.CheckFunds(newProject.Funds.ToList());
            if (!resultCheckFunds.IsSuccess)
                return _mapper.Map<ResultDto<int>>(resultCheckFunds);
            newProject.Funds.ToList().ForEach(p =>
            {
                p.ProjectType = ProjectType.Incompleted;
            });

            ////Address
            var resultCheckAddress = await _validateService.CheckAddress(newProject.Address);
            if (!resultCheckAddress.IsSuccess)
                return _mapper.Map<ResultDto<int>>(resultCheckAddress);
            newProject.Address.ProjectType = ProjectType.Incompleted;

            //save in db
            _dbContext.P_Incompleteds.Add(newProject);
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
        public int AmountOfExperience { get; set; }
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
        //آیا تاکنون در خصوص طرح مذکور تسهیلات دریافت نموده‌اید؟
        public bool HaveReceivedFaciliti { get; set; }
        public CreateAddressDto Address { get; set; }

        public List<CreateLicenceRelProjectDto> Licences { get; set; }
        //تسهیلات
        public List<CreateFacilitiRelProjectDto> Facilitis { get; set; }
        //سرمایه گذاری ها
        public List<CreateFundRelProjectDto> Funds { get; set; }

    }
    public class CreateAddressDto
    {
        public int UnitedId { get; set; }
        //شهرستان
        public int CityId { get; set; }
        //شهر
        public string TownName { get; set; }
        //روستا/ شهرک صنعتی/ ناحیه صنعتی
        public string Part_Village { get; set; }
        //خیابان / پلاک
        public string Street { get; set; }
        //کد پستی
        public string PostalCode { get; set; }
        //
    }
    public class CreateLicenceRelProjectDto
    {
        public DateTime ValidityDate { get; set; }
        //Licence
        public int LicenceId { get; set; }
    }
    public class CreateFacilitiRelProjectDto
    {
        //نوع تسهیلات
        public FacilitiType FacilitiType { get; set; }
        //وضعیت
        public int FacilitiStatusId { get; set; }
        //ماهیت
        public int FacilitiNatureId { get; set; }
        //تاریخ اخذ تسهیلات
        public DateTime ReceivingDate { get; set; }
        //تاریخ شروع اقساط
        public DateTime InstallmentStartDate { get; set; }
        //مدت بازپرداخت
        public int RepaymentPeriod { get; set; }
        //محل تامین - بانک
        public string placeSupply_Bank { get; set; }
        //درصد سود
        public int InterestRate { get; set; }
        //نوع وثیقه
        public string CollateralName { get; set; }
    }
    public class CreateFundRelProjectDto
    {
        public int FundId { get; set; }
        //درصد پیشرفت فیزیکی
        public int PercenPhysicalProgress { get; set; }
        //مبلغ هزینه شده
        public int AmountSpent { get; set; }
        //بر آورد کل مبلغ مورد نیاز
        public int TotalAmountNeeded { get; set; }
    }
}
