using InterViewProject.Data.DAOs;
using InterViewProject.Data.Entities;
using InterViewProject.Models;
using InterViewProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InterViewProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string sex)
        {
            FamilyDAO familyDAO = new FamilyDAO();
            var result=familyDAO.GetFamilysBySex(sex);
            List<IndexFamilyResultModel> indexFamilysViewModel = GetFamilyResultToViewModel(result);
            IndexFamilyViewModel indexFamilyViewModel=new IndexFamilyViewModel();
            indexFamilyViewModel.IndexFamilyResultModelList = indexFamilysViewModel;
            return View(indexFamilyViewModel);
        }
        public List<IndexFamilyResultModel> GetFamilyResultToViewModel(List<FamilyEntities> familyEntities)
        {
            List<IndexFamilyResultModel> IndexFamilyResultModelList = new List<IndexFamilyResultModel>();
            try
            {
                if (familyEntities.Count == 0)
                {
                    return IndexFamilyResultModelList;
                }
                else
                {
                    foreach (FamilyEntities familyEntity in familyEntities)
                    {
                        IndexFamilyResultModel indexFamilyViewModel = new IndexFamilyResultModel()
                        {
                            FamilyId = familyEntity.FamilyId,
                            FamilyName = familyEntity.FamilyName,
                            FamilySex = familyEntity.FamilySex,
                            BirthDate = familyEntity.BirthDate,
                            PhoneNumber = familyEntity.PhoneNumber
                        };
                        IndexFamilyResultModelList.Add(indexFamilyViewModel);
                    }
                    return IndexFamilyResultModelList;
                }
            }
            catch (Exception ex)
            {
                return IndexFamilyResultModelList;
            }            
        }
    }
}
