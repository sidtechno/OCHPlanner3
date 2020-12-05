﻿using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OCHPlanner3.Data.Interfaces;
using OCHPlanner3.Data.Models;
using OCHPlanner3.Helper.Comparer;
using OCHPlanner3.Models;
using OCHPlanner3.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OCHPlanner3.Services
{
    public class ReferenceService : IReferenceService
    {
        public readonly IReferenceFactory _referenceFactory;

        public ReferenceService(IReferenceFactory referenceFactory)
        {
            _referenceFactory = referenceFactory;
        }
        public async Task<IEnumerable<OilViewModel>> GetOilList(int garageId)
        {
            var oilList = await _referenceFactory.GetOilList(garageId);
            return oilList.Adapt<IEnumerable<OilViewModel>>();
        }

        public async Task<IEnumerable<MileageViewModel>> GetMileageList(int garageId, int mileageType = 1)
        {
            var mileageList = await _referenceFactory.GetMileageList(garageId, mileageType);
            return mileageList.Adapt<IEnumerable<MileageViewModel>>().OrderBy(x => x.Name, new SemiNumericComparer());
        }

        public async Task<IEnumerable<SelectListItem>> GetOilSelectListItem(int garageId, int selectedId = 0)
        {
            var oilList = await _referenceFactory.GetOilList(garageId);

            return oilList.Select(x => new SelectListItem()
            {
                Value = x.OilTypeId.ToString(),
                Text = x.OilTypeName,
                Selected = selectedId != 0 && selectedId == x.OilTypeId
            }).OrderBy(o => o.Text);
        }

        public async Task<IEnumerable<SelectListItem>> GetPeriodSelectListItem(int selectedId = 0)
        {
            var periodList = await _referenceFactory.GetPeriodList();

            return periodList.Where(p => p.Name.ToUpper() != "N/A").Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = selectedId != 0 && selectedId == x.Id
            }).OrderBy(x => x.Text, new SemiNumericComparer());
        }

        public async Task<IEnumerable<SelectListItem>> GetMileageSelectListItem(int garageId, int mileageTypeId, int selectedId = 0)
        {
            var mileages = await _referenceFactory.GetMileageList(garageId, mileageTypeId);
            return await BuildMileageSelectListItem(mileages.OrderBy(x => x.Name, new SemiNumericComparer()), selectedId);
        }

        private async Task<IEnumerable<SelectListItem>> BuildMileageSelectListItem(IEnumerable<MileageModel> mileageList, int selectedId = 0)
        {
            return mileageList.Where(p => p.Name.ToUpper() != "N/A").Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = selectedId != 0 && selectedId == x.Id
            });
        }

        public async Task<IEnumerable<SelectListItem>> GetMonthSelectListItem(int selectedId = 0)
        {
            return new List<SelectListItem>
            {
                new SelectListItem() { Value = "1", Text = "Janvier", Selected = selectedId != 0 && selectedId == 1 },
                new SelectListItem() { Value = "2", Text = "Février", Selected = selectedId != 0 && selectedId == 2 },
                new SelectListItem() { Value = "3", Text = "Mars", Selected = selectedId != 0 && selectedId == 3 },
                new SelectListItem() { Value = "4", Text = "Avril", Selected = selectedId != 0 && selectedId == 4 },
                new SelectListItem() { Value = "5", Text = "Mai", Selected = selectedId != 0 && selectedId == 5 },
                new SelectListItem() { Value = "6", Text = "Juin", Selected = selectedId != 0 && selectedId == 6 },
                new SelectListItem() { Value = "7", Text = "Juillet", Selected = selectedId != 0 && selectedId == 7 },
                new SelectListItem() { Value = "8", Text = "Août", Selected = selectedId != 0 && selectedId == 8 },
                new SelectListItem() { Value = "9", Text = "Septembre", Selected = selectedId != 0 && selectedId == 9 },
                new SelectListItem() { Value = "10", Text = "Octobre" , Selected = selectedId != 0 && selectedId == 10 },
                new SelectListItem() { Value = "11", Text = "Novembre" , Selected = selectedId != 0 && selectedId == 11 },
                new SelectListItem() { Value = "12", Text = "Décembre" , Selected = selectedId != 0 && selectedId == 12 }
            };
        }

        public async Task<IEnumerable<SelectListItem>> GetYearSelectListItem(int selectedId = 0)
        {
            var result = new List<SelectListItem>();

            for (int year = DateTime.Now.Year; year <= DateTime.Now.AddYears(5).Year; year++)
            {
                result.Add(new SelectListItem()
                {
                    Value = year.ToString(),
                    Text = year.ToString(),
                    Selected = selectedId != 0 && selectedId == year
                });
            }

            return result;
        }

        public async Task<IEnumerable<SelectListItem>> GetBannerSelectListItem(int selectedId = 0)
        {
            var banners = await _referenceFactory.GetBannerList();
            return await BuildBannerSelectListItem(banners.OrderBy(x => x.Name, new SemiNumericComparer()), selectedId);
        }

        private async Task<IEnumerable<SelectListItem>> BuildBannerSelectListItem(IEnumerable<BannerModel> bannerList, int selectedId = 0)
        {
            return bannerList.Where(p => p.Name.ToUpper() != "N/A").Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Name,
                Selected = selectedId != 0 && selectedId == x.Id
            });
        }

        public async Task<IEnumerable<SelectListItem>> GetLanguageSelectList(string language)
        {
            var languages = new List<SelectListItem>();

            languages.Add(new SelectListItem
            {
                Value = "FR",
                Text = language.ToUpper() == "FR" ? "Français" : "Anglais"
            });

            languages.Add(new SelectListItem
            {
                Value = "EN",
                Text = language.ToUpper() == "FR" ? "Anglais" : "English"
            });

            return languages;
        }

        public async Task<IEnumerable<SelectListItem>> GetDateFormatSelectList()
        {
            var languages = new List<SelectListItem>();

            languages.Add(new SelectListItem
            {
                Value = "dd/MM/yy",
                Text = "dd/mm/yy"
            });

            languages.Add(new SelectListItem
            {
                Value = "MM/dd/yy",
                Text = "mm/dd/yy"
            });

            return languages;
        }

    }
}
