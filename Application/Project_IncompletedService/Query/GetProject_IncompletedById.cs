using Application.Common;
using Application.Interfaces.Contexts;
using AutoMapper;
using Domain.Project;
using Domain.ProjectEnums;
using Domain.ProjectNeeds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Project_IncompletedService.Query
{
    public interface IGetProject_IncompletedById
    {
        Task<ResultDto<Project_IncompletedDetailDto>> Execute(int Id, string UserId);

    }

    public class GetProject_IncompletedById : IGetProject_IncompletedById
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public GetProject_IncompletedById(IDataBaseContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ResultDto<Project_IncompletedDetailDto>> Execute(int Id, string UserId)
        {
            //get Incompleted from db
            var project = _dbContext.P_Incompleteds.Where(p => p.Id.Equals(Id))
                .Include(p => p.Industry)
                .Include(p => p.Address)
                .ThenInclude(p=>p.City)
                .ThenInclude(p=>p.United)
                .Include(p => p.Licences)
                .ThenInclude(p => p.Licence)
                .Include(p => p.Facilitis)
                .ThenInclude(p => p.FacilitiNature)
                .Include(p => p.Facilitis)
                .ThenInclude(p => p.FacilitiStatus)
                .Include(p => p.Funds)
                .ThenInclude(p => p.Fund)
                .FirstOrDefault();


            //check is exist
            if (project == null)
            {
                return new ResultDto<Project_IncompletedDetailDto>
                {
                    IsSuccess = false,
                    Message = "پروژه ای با آیدی ارسالی موجود نیست"
                };
            }

            //check is for user
            if (!project.UserId.Equals(UserId))
            {
                return new ResultDto<Project_IncompletedDetailDto>
                {
                    IsSuccess = false,
                    Message = "این آیدی پروژه متعلق به شما نیست"
                };
            }

            var dto = _mapper.Map<Project_IncompletedDetailDto>(project);

            return new ResultDto<Project_IncompletedDetailDto>
            {
                IsSuccess = true,
                Data = dto
            };

        }
    }
    public class Project_IncompletedDetailDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public AssignmentOrParticipation AssignmentOrParticipation { get; set; }
        public int PercentParticipation { get; set; }
        public int AmountOfExperience { get; set; }
        public bool HaveAllLicences { get; set; }
        public PlaceOfImplementation PlaceOfImplementation { get; set; }
        public int RentTypeId { get; set; }
        public int IndustryId { get; set; }
        public string IndustryName { get; set; }
        public bool JustificationPlan { get; set; }
        public int ProposedPrice { get; set; }
        public int RequiredCapitalPlan { get; set; }
        public int AmountCapitalDemand { get; set; }
        public string WhatTopicsNeedParticipate { get; set; }
        public int ReturnInvestmentRate { get; set; }
        public int NetPresentValue { get; set; }
        public bool HaveReceivedFaciliti { get; set; }
        public AddressDetailDto Address { get; set; }


        //مجوز ها
        public ICollection<LicenceRelProjectDetailDto> Licences { get; set; }
        //تسهیلات
        public ICollection<FacilitiRelProjectDetailDto> Facilitis { get; set; }
        //سرمایه گذاری ها
        public ICollection<FundRelProjectDetailDto> Funds { get; set; }
        public List<Link> Links { get; set; }
    }
    public class AddressDetailDto
    {
        public int Id { get; set; }
        //استان
        public int UnitedId { get; set; }
        public string UnitedName { get; set; }
        //شهرستان
        public int CityId { get; set; }
        public string CityName { get; set; }
        //شهر
        public string TownName { get; set; }
        //روستا/ شهرک صنعتی/ ناحیه صنعتی
        public string Part_Village { get; set; }
        //خیابان / پلاک
        public string Street { get; set; }
        //کد پستی
        public string PostalCode { get; set; }
    }
    public class LicenceRelProjectDetailDto
    {
        public int Id { get; set; }

        public DateTime ValidityDate { get; set; }
        //Licence
        public int LicenceId { get; set; }
        public string LicenceName { get; set; }
    }
    public class FacilitiRelProjectDetailDto
    {
        public int Id { get; set; }
        //نوع تسهیلات
        public FacilitiType FacilitiType { get; set; }
        //وضعیت
        public int FacilitiStatusId { get; set; }
        public string FacilitiStatusName { get; set; }
        //ماهیت
        public int FacilitiNatureId { get; set; }
        public string FacilitiNatureName { get; set; }
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
    public class FundRelProjectDetailDto
    {
        public int Id { get; set; }
        //نام سرمایه گذاری
        public int FundId { get; set; }
        public string FundName { get; set; }
        //درصد پیشرفت فیزیکی
        public int PercenPhysicalProgress { get; set; }
        //مبلغ هزینه شده
        public int AmountSpent { get; set; }
        //بر آورد کل مبلغ مورد نیاز
        public int TotalAmountNeeded { get; set; }
    }
}

