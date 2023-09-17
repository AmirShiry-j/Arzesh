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

namespace Application.Project_DevelopmentService.Command
{
    public interface IAddProject_DevelopmentService
    {
        Task<ResultDto<int>> Execute(CreateProject_DevelopmentDto ProjectDto, string UserId);
    }
    public class AddProject_DevelopmentService : IAddProject_DevelopmentService
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IValidateService _validateService;
        public AddProject_DevelopmentService
(IDataBaseContext dbContext,
            IMapper mapper,
            IValidateService validateService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _validateService = validateService;
        }
        public async Task<ResultDto<int>> Execute(CreateProject_DevelopmentDto ProjectDto, string UserId)
        {
            //Map
            var newProject = _mapper.Map<Project>(ProjectDto);
            newProject.ProjectTypeId = (int)ProjectTypeEnum.Development;
            newProject.UserId = UserId;
            //
            newProject.P_Development = _mapper.Map<Project_Development>(ProjectDto);

            //Industry
            var resultCheckIndustry = await _validateService.CheckIndustry((int)newProject.IndustryId);
            if (!resultCheckIndustry.IsSuccess)
                return _mapper.Map<ResultDto<int>>(resultCheckIndustry);

            //RentType
            var resultCheckRentType = await _validateService.CheckRentType((int)newProject.P_Development.RentTypeId, newProject.P_Development.PlaceOfImplementation);
            if (!resultCheckRentType.IsSuccess)
                return _mapper.Map<ResultDto<int>>(resultCheckRentType);
            else
                if (newProject.P_Development.PlaceOfImplementation != PlaceOfImplementation.Rent)
                newProject.P_Development.RentTypeId = null;

            ////Asset
            var resultCheckAssets = await _validateService.CheckAssets(newProject.Assets.ToList());
            if (!resultCheckAssets.IsSuccess)
                return _mapper.Map<ResultDto<int>>(resultCheckAssets);

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
    public class CreateProject_DevelopmentDto
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
        public long AmountCapitalDemand { get; set; }
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

        //طرح توسعه شما منجر به افزایش
        public DevPlanLeadsToIncrease DevPlanLeadsToIncrease { get; set; }
        //کلیه مجوزهایی که تا کنون اخذ نموده اید
        public bool HaveAllLicences { get; set; }

        //محل اجرای طرح
        public PlaceOfImplementation PlaceOfImplementation { get; set; }
        //اجاره
        public int RentTypeId { get; set; }

        //آیا طرح توجیهی برای ایده تدوین شده است؟
        public bool JustificationPlan { get; set; }
        //در کدام قسمت قصد مشارکت دارید
        public WhichPartIntendParticipate WhichPartIntendParticipate { get; set; }
        //آیا صورت‌ مالی دارید؟
        public bool HaveFinancialStatement { get; set; }

        //واگذاری
        //قیمت پیشنهادی
        public long ProposedPrice { get; set; }
        //مشارکت
        //میزان مشارکت مورد نیاز
        public int AmountOfParticipationRequired { get; set; }
        //خالص ارزش فعلی پروژه
        public long NetPresentValue { get; set; }

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
        //تسهیلات
        public List<CreateFacilitiRelProjectDto> Facilitis { get; set; }
        //سرمایه گذاری ها
        public List<CreateFundRelProjectDto> Funds { get; set; }
    }

}
