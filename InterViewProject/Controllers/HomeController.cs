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
            var result = familyDAO.GetFamilysBySex(sex);
            List<IndexFamilyResultModel> indexFamilysViewModel = GetFamilyResultToViewModel(result);
            IndexFamilyViewModel indexFamilyViewModel = new IndexFamilyViewModel();
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
        [HttpGet]
        [Route("api/GetFamilys")]
        [Produces("application/json")]
        public IActionResult GetFamilys(string sex)
        {
            FamilyDAO familyDAO = new FamilyDAO();
            var result = familyDAO.GetFamilysBySex(sex);
            List<IndexFamilyResultModel> indexFamilysViewModel = GetFamilyResultToViewModel(result);
            return new JsonResult(indexFamilysViewModel);
        }

        [HttpPost]
        [Route("api/PostFamily")]
        [Produces("application/json")]
        public IActionResult PostFamily([FromBody] FamilyQueryModel familyQueryModel)
        {
            ResultModel resultModel = new ResultModel();
            FamilyDAO familyDAO = new FamilyDAO();
            try
            {
                var insertResult = familyDAO.InsertFamily(familyQueryModel);
                if (insertResult == 0)
                {
                    resultModel.IsOK = false;
                    resultModel.Message = "Insert失敗";
                }
                else
                {
                    resultModel.IsOK = true;
                    resultModel.Message = "";
                }
            }
            catch (Exception ex)
            {
                resultModel.IsOK = false;
                resultModel.Message = "Insert失敗";
            }
            return new JsonResult(resultModel);
        }

        //[HttpPut]
        //[Route("api/UpdateFamily")]
        //[Produces("application/json")]
        //public IActionResult UpdateFamily([FromRoute] string name, [FromBody] FamilyQueryModel familyQueryModel)
        //{
        //    ResultModel resultModel = new ResultModel();
        //    FamilyDAO familyDAO = new FamilyDAO();
        //    try
        //    {
        //        var insertResult = familyDAO.UpdateFamily(name,familyQueryModel);
        //        if (insertResult == 0)
        //        {
        //            resultModel.IsOK = false;
        //            resultModel.Message = "Update失敗";
        //        }
        //        else
        //        {
        //            resultModel.IsOK = true;
        //            resultModel.Message = "";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resultModel.IsOK = false;
        //        resultModel.Message = "Update失敗";
        //    }
        //    return new JsonResult(resultModel);
        //}
    }
}
