using Application.Common;
using Application.Interfaces.Contexts;
using Application.Project_IdehService.Command;
using AutoMapper;
using Domain.ProjectEnums;
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
        Task<ResultDto> CheckRentType(int Id, PlaceOfImplementation PlaceOfImplementation);
        Task<ResultDto> CheckAddress(Address Address);
        Task<ResultDto> CheckLicences(List<LicenceRelProject> Licences);
        Task<ResultDto> CheckFacilitis(List<FacilitiRelProject> Facilitis);
        Task<ResultDto> CheckFunds(List<FundRelProject> Funds);
        Task<ResultDto> CheckAssets(List<AssetRelProject> Assets);
        Task<ResultDto> CheckCapacities(List<CapacityRelProject> Capacities);
        Task<ResultDto> CheckDebts(List<DebtRelProject> Debts);
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
        public async Task<ResultDto> CheckRentType(int Id,PlaceOfImplementation PlaceOfImplementation)
        {
            if (PlaceOfImplementation == PlaceOfImplementation.Rent)
            {
                var rentType = _dbContext.RentTypes.Find(Id);
                if (rentType == null)
                {
                    return new ResultDto
                    {
                        Message = "نوع اجاره ای با آیدی ارسالی موجود نیست"
                    };
                }
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
        public async Task<ResultDto> CheckAssets(List<AssetRelProject> Assets)
        {
            if (Assets == null || Assets.Count == 0)
            {
                return new ResultDto
                {
                    Message = "ثبت حداقل یک مورد دارایی اجباری است"
                };
            }

            bool isExistAssetBaIdNaMojood = false;
            List<string> IdsNaMojood = new List<string>();
            foreach (var asset in Assets)
            {
                var fundInDb = _dbContext.Assets.Find(asset.AssetId);
                if (fundInDb == null)
                {
                    isExistAssetBaIdNaMojood = true;
                    IdsNaMojood.Add(asset.AssetId.ToString());
                }
            }

            if (isExistAssetBaIdNaMojood)
            {
                var str = IdsNaMojood.Aggregate((s1, s2) => s1 + " , " + s2).ToString();
                return new ResultDto
                {
                    Message = $"سر فصل های دارایی ها با آیدی های {str} موجود نیست"
                };
            }

            return new ResultDto
            {
                IsSuccess = true
            };
        }

        public async Task<ResultDto> CheckDebts(List<DebtRelProject> Debts)
        {
            if (Debts == null || Debts.Count == 0)
            {
                return new ResultDto
                {
                    Message = "ثبت حداقل یک مورد بدهی اجباری است"
                };
            }

            bool isExistDebtBaIdNaMojood = false;
            List<string> IdsNaMojood = new List<string>();
            foreach (var debt in Debts)
            {
                var fundInDb = _dbContext.Debts.Find(debt.DebtId);
                if (fundInDb == null)
                {
                    isExistDebtBaIdNaMojood = true;
                    IdsNaMojood.Add(debt.DebtId.ToString());
                }
            }

            if (isExistDebtBaIdNaMojood)
            {
                var str = IdsNaMojood.Aggregate((s1, s2) => s1 + " , " + s2).ToString();
                return new ResultDto
                {
                    Message = $"سر فصل های بدهی ها با آیدی های {str} موجود نیست"
                };
            }

            return new ResultDto
            {
                IsSuccess = true
            };
        }

        public async Task<ResultDto> CheckCapacities(List<CapacityRelProject> Capacities)
        {
            if (Capacities == null || Capacities.Count == 0)
            {
                return new ResultDto
                {
                    Message = "ثبت حداقل یک مورد ظرفیت اجباری است"
                };
            }

            return new ResultDto
            {
                IsSuccess = true
            };
        }
    }
}
