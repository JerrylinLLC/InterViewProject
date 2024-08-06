using InterViewProject.Data.DAOs;
using InterViewProject.Data.Entities;
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
            List<IndexFamilyViewModel> indexFamilysViewModel = GetFamilyResultToViewModel(result);
            return View(indexFamilysViewModel);
        }
        public List<IndexFamilyViewModel> GetFamilyResultToViewModel(List<FamilyEntities> familyEntities)
        {
            List<IndexFamilyViewModel> indexFamilysViewModel= new List<IndexFamilyViewModel>();
            try
            {
                if (familyEntities.Count == 0)
                {
                    return indexFamilysViewModel;
                }
                else
                {
                    foreach (FamilyEntities familyEntity in familyEntities)
                    {
                        IndexFamilyViewModel indexFamilyViewModel = new IndexFamilyViewModel()
                        {
                            FamilyId = familyEntity.FamilyId,
                            FamilyName = familyEntity.FamilyName,
                            FamilySex = familyEntity.FamilySex,
                            BirthDate = familyEntity.BirthDate,
                            PhoneNumber = familyEntity.PhoneNumber
                        };
                        indexFamilysViewModel.Add(indexFamilyViewModel);
                    }
                    return indexFamilysViewModel;
                }
            }
            catch (Exception ex)
            {
                return indexFamilysViewModel;
            }            
        }
    }
}
