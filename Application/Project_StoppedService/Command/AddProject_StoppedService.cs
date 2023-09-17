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

namespace Application.Project_StoppedService.Command
{
    public interface IAddProject_StoppedService
    {
        Task<ResultDto<int>> Execute(CreateProject_StoppedDto ProjectDto, string UserId);
    }
    public class AddProject_StoppedService : IAddProject_StoppedService
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IValidateService _validateService;
        public AddProject_StoppedService
(IDataBaseContext dbContext,
            IMapper mapper,
            IValidateService validateService)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _validateService = validateService;
        }
        public async Task<ResultDto<int>> Execute(CreateProject_StoppedDto ProjectDto, string UserId)
        {
            //Map
            var newProject = _mapper.Map<Project>(ProjectDto);
            newProject.ProjectTypeId = (int)ProjectTypeEnum.Stopped;
            newProject.UserId = UserId;
            //
            newProject.P_Stopped = _mapper.Map<Project_Stopped>(ProjectDto);

            //Industry
            var resultCheckIndustry = await _validateService.CheckIndustry((int)newProject.IndustryId);
            if (!resultCheckIndustry.IsSuccess)
                return _mapper.Map<ResultDto<int>>(resultCheckIndustry);

            //RentType
            var resultCheckRentType = await _validateService.CheckRentType((int)newProject.P_Stopped.RentTypeId, newProject.P_Stopped.PlaceOfImplementation);
            if (!resultCheckRentType.IsSuccess)
                return _mapper.Map<ResultDto<int>>(resultCheckRentType);
            else
                if (newProject.P_Stopped.PlaceOfImplementation != PlaceOfImplementation.Rent)
                newProject.P_Stopped.RentTypeId = null;

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

            ////Debt
            var resultCheckDebts = await _validateService.CheckDebts(newProject.Debts.ToList());
            if (!resultCheckDebts.IsSuccess)
                return _mapper.Map<ResultDto<int>>(resultCheckDebts);

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
    public class CreateProject_StoppedDto
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
        //کلیه مجوزهایی که تا کنون اخذ نموده اید
        public bool HaveAllLicences { get; set; }
        //محل اجرای طرح
        public PlaceOfImplementation PlaceOfImplementation { get; set; }
        //اجاره
        public int RentTypeId { get; set; }
        //آیا طرح توجیهی برای ایده تدوین شده است؟
        public bool JustificationPlan { get; set; }


        //واگذاری
        //قیمت پیشنهادی
        public long ProposedPrice { get; set; }
        //مشارکت
        //میزان مشارکت مورد نیاز
        public long AmountOfParticipationRequired { get; set; }
        //مشارکت
        //مدت زمان غیرفعال بودن طرح (سال)
        public int DurationInactivityYear { get; set; }
        //ارزش کل سرمایه گذاری جدید
        public long TotalValueNewInvestment { get; set; }
        //خالص ارزش فعلی پروژه
        public long NetPresentValue { get; set; }
        //دلایل غیر فعال بودن طرح
        public int InactivityReasonId { get; set; }
        //توضیح 
        public string ExplanationReason { get; set; }
        //آیا تاکنون در خصوص طرح مذکور تسهیلات دریافت نموده‌اید؟
        public bool HaveReceivedFaciliti { get; set; }

        //دارایی ها
        public List<CreateAssetRelProjectDto> Assets { get; set; }
        //مجوز ها
        public List<CreateLicenceRelProjectDto> Licences { get; set; }
        //تسهیلات
        public List<CreateFacilitiRelProjectDto> Facilitis { get; set; }
        //بدهی ها
        public List<CreateDebtRelProjectDto> Debts { get; set; }
    }

}
