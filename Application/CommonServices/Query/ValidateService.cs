using Application.Common;
using Application.Interfaces.Contexts;
using Application.Project_IdehService.Command;
using AutoMapper;
using Domain.ProjectNeeds;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.CommonServices.Query
{
    public interface IValidateService
    {
        Task<ResultDto> CheckIndustry(int Id);
        Task<ResultDto> CheckAddress(Address Address);
        Task<ResultDto> CheckLicences(List<LicenceRelProject> Licences);
        Task<ResultDto> CheckFacilitis(List<FacilitiRelProject> Facilitis);
        Task<ResultDto> CheckFunds(List<FundRelProject> Funds);
    }
    public class ValidateService : IValidateService
    {
        private readonly IDataBaseContext _dbContext;
        private readonly IMapper _mapper;
        public ValidateService(IDataBaseContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ResultDto> CheckIndustry(int Id)
        {
            var industry = _dbContext.Industries.Find(Id);
            if (industry == null)
            {
                return new ResultDto
                {
                    Message = "صنعت و بخشی با آیدی ارسالی موجود نیست"
                };
            }

            return new ResultDto
            {
                IsSuccess = true
            };
        }

        public async Task<ResultDto> CheckAddress(Address Address)
        {
            var City = _dbContext.Cities.Find(Address.CityId);
            if (City == null)
            {
                return new ResultDto
                {
                    Message = "شهرستانی با ایدی ارسالی موجود نیست"
                };
            }

            return new ResultDto
            {
                IsSuccess = true
            };
        }

        public async Task<ResultDto> CheckLicences(List<LicenceRelProject> Licences)
        {
            if (Licences == null || Licences.Count == 0)
            {
                return new ResultDto
                {
                    Message = "ثبت حداقل یک مجوز اجباری است"
                };
            }

            bool isExistLicenceBaIdNaMojood = false;
            List<string> IdsNaMojood = new List<string>();
            foreach (var licence in Licences)
            {
                var licenceInDb = _dbContext.Licences.Find(licence.LicenceId);
                if (licenceInDb == null)
                {
                    isExistLicenceBaIdNaMojood = true;
                    IdsNaMojood.Add(licence.LicenceId.ToString());
                }
            }

            if (isExistLicenceBaIdNaMojood)
            {
                var str = IdsNaMojood.Aggregate((s1, s2) => s1 + " , " + s2).ToString();
                return new ResultDto
                {
                    Message = $"مجوز هایی با آیدی های {str} موجود نیست"
                };
            }

            return new ResultDto
            {
                IsSuccess = true
            };
        }

        public async Task<ResultDto> CheckFacilitis(List<FacilitiRelProject> Facilitis)
        {
            if (Facilitis == null || Facilitis.Count == 0)
            {
                return new ResultDto
                {
                    Message = "ثبت حداقل یک مورد تسهیلات اجباری است"
                };
            }

            //FacilitiStatus
            var isExistFacilitiStatusBaIdNaMojood = false;
            List<string> facilitiStatusIdsNaMojood = new List<string>();
            foreach (var faciliti in Facilitis)
            {
                var facilitiStatusInDb = _dbContext.FacilitiStatuses.Find(faciliti.FacilitiStatusId);
                if (facilitiStatusInDb == null)
                {
                    isExistFacilitiStatusBaIdNaMojood = true;
                    facilitiStatusIdsNaMojood.Add(faciliti.FacilitiStatusId.ToString());
                }
            }
            if (isExistFacilitiStatusBaIdNaMojood)
            {
                var str = facilitiStatusIdsNaMojood.Aggregate((s1, s2) => s1 + " , " + s2).ToString();
                return new ResultDto
                {
                    Message = $"وضعیت های تسهیلات با آیدی های {str} موجود نیست"
                };
            }

            //FacilitiNature
            var isExistFacilitiNatureBaIdNaMojood = false;
            List<string> facilitiNatureIdsNaMojood = new List<string>();
            foreach (var faciliti in Facilitis)
            {
                var facilitiNatureInDb = _dbContext.FacilitiNatures.Find(faciliti.FacilitiNatureId);
                if (facilitiNatureInDb == null)
                {
                    isExistFacilitiNatureBaIdNaMojood = true;
                    facilitiNatureIdsNaMojood.Add(faciliti.FacilitiNatureId.ToString());
                }
            }
            if (isExistFacilitiNatureBaIdNaMojood)
            {
                var str = facilitiNatureIdsNaMojood.Aggregate((s1, s2) => s1 + " , " + s2).ToString();
                return new ResultDto
                {
                    Message = $"ماهیت های تسهیلات با آیدی های {str} موجود نیست"
                };
            }

            return new ResultDto
            {
                IsSuccess = true
            };
        }
        public async Task<ResultDto> CheckFunds(List<FundRelProject> Funds)
        {
            if (Funds == null || Funds.Count == 0)
            {
                return new ResultDto
                {
                    Message = "ثبت حداقل یک مورد سرمایه اجباری است"
                };
            }

            bool isExistFundBaIdNaMojood = false;
            List<string> IdsNaMojood = new List<string>();
            foreach (var fund in Funds)
            {
                var fundInDb = _dbContext.Funds.Find(fund.FundId);
                if (fundInDb == null)
                {
                    isExistFundBaIdNaMojood = true;
                    IdsNaMojood.Add(fund.FundId.ToString());
                }
            }

            if (isExistFundBaIdNaMojood)
            {
                var str = IdsNaMojood.Aggregate((s1, s2) => s1 + " , " + s2).ToString();
                return new ResultDto
                {
                    Message = $"سر فصل های سرمایه گذاری با آیدی های {str} موجود نیست"
                };
            }

            return new ResultDto
            {
                IsSuccess = true
            };
        }
    }
}
