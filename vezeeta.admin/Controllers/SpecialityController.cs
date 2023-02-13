using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Localization;
//using System.ComponentModel.DataAnnotations; //ValidationResult
using vezeeta.admin.Validations;
using vezeeta.BL;
using vezeeta.BL.DTOs.Center;
using vezeeta.BL.DTOs.Speciality;
using vezeeta.DBL;

namespace vezeeta.admin.Controllers
{
    public class SpecialityController : _Controller
    {
        private readonly VezeetaDB vezeetaDB;
        private readonly IUnitOfManger _unitOfManger;
        private const string IVIEW = "Views/Speciality/";
        private readonly IStringLocalizer<SpecialityController> localizer;
        public SpecialityController(VezeetaDB vezeetaDB, IUnitOfManger unitOfManger,
        IStringLocalizer<SpecialityController> _localizer)
        {
            this.vezeetaDB = vezeetaDB;
            this._unitOfManger = unitOfManger;
            localizer = _localizer;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SpecialityDTO>> Index()
        {
            this.TableColumns(true, "name", "main_speciality", "activate");
            return View();
        }
        [HttpGet]
        public ActionResult Create(SpecialityDTO? speciality)
        {
            ViewBag.mainSpecialitiesName = _unitOfManger.SpecialityManager.Index().Where(c=>c.MainSpecialityId==null);
            return View(speciality);
        }
        [HttpPost]
        public ActionResult Store(SpecialityDTO speciality,IFormFile logo)
        {
            SpecialityValidation validator = new SpecialityValidation(localizer);
            ValidationResult result = validator.Validate(speciality);

            if(!result.IsValid)
            {
                foreach (var err in result.Errors)
                {
                    TempData[err.PropertyName] = err.ErrorMessage;
                }
                return RedirectToAction("Create", speciality);
            }

            bool find = _unitOfManger.SpecialityManager.Find(speciality);

            if (find)
            {
                TempData["error_msg"] = "Speciality already exist Before";
                return RedirectToAction("Create");
            }

            if (logo != null)
            {
                string? checkImageExt = Helper.checkImageExt(logo);
                if (checkImageExt is not null)
                {
                    TempData["error_msg"] = checkImageExt;
                    return RedirectToAction("Create");
                }
                speciality.logo = Helper.uploadImage(logo, "speciality");
            }
            else
            {
                // speciality.logo=Helper.imageUrl(logo);
                speciality.logo = @"/images/DefaultImage.jpeg";
            }
           
            using (IDbContextTransaction transaction = vezeetaDB.Database.BeginTransaction())
            {
                try
                {
                    _unitOfManger.SpecialityManager.Add(speciality);
                    transaction.Commit();
                    TempData["success_msg"] = "Speciality Created Successfully!";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    TempData["error_msg"] = ex.Message;
                    return RedirectToAction("Create");
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            ViewBag.mainSpecialitiesName = _unitOfManger.SpecialityManager.Index().Where(c => c.MainSpecialityId == null);
            SpecialityDTO? specialty = _unitOfManger.SpecialityManager.GetByID(id);

            if (specialty is null)
            {
                TempData["error_msg"] = "Center Not Found";
                return RedirectToAction("index");
            }
            return View(specialty);
        }
        [HttpPost]
        public ActionResult Update(Guid? id, SpecialityDTO speciality, IFormFile logo)
        {

            SpecialityValidation validator = new SpecialityValidation(this.localizer);
            ValidationResult result = validator.Validate(speciality);
            if (!result.IsValid)
            {
                foreach (var err in result.Errors)
                {
                    TempData[err.PropertyName] = err.ErrorMessage;
                }
                return RedirectToAction("Edit", new { id = speciality.Id });
            }

            bool find = _unitOfManger.SpecialityManager.Index()
                .Where(c => c.Id != speciality.Id)
                .Any(c => c.name_en == speciality.name_en || c.name_ar == speciality.name_ar);

            if (find)
            {
                TempData["error_msg"] = "center already exist Before";
                return RedirectToAction("Edit", new { id = speciality.Id });
            }

            if (logo != null)
            {
                string? checkImageExt = Helper.checkImageExt(logo);
                if (checkImageExt is not null)
                {
                    TempData["error_msg"] = checkImageExt;
                    return RedirectToAction("Edit", new { id = speciality.Id });
                }
                speciality.logo = Helper.uploadImage(logo, "speciality");
            }

            using (IDbContextTransaction transaction = vezeetaDB.Database.BeginTransaction())
            {
                try
                {
                    var update = _unitOfManger.SpecialityManager.Update(speciality);
                    if (!update)
                    {
                        TempData["error_msg"] = "speciality Not Found!";
                        return RedirectToAction("Index");
                    }
                    transaction.Commit();
                    TempData["success_msg"] = "speciality data updated Successfully!";
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    TempData["error_msg"] = ex.Message;
                }
            }

            return RedirectToAction("Edit", new { id = speciality.Id });
        }

        public ActionResult Delete(Guid id)
        {
            var result = new Dictionary<string, object>();

            SpecialityDTO? special = _unitOfManger.SpecialityManager.GetByID(id);

            if (special is null)
            {
                TempData["error_msg"] = "Speciality Not Found";
                result.Add("msg", "Speciality is not found");
                result.Add("status", 404);
                return Json(result);
            }
           
            using (IDbContextTransaction transaction = vezeetaDB.Database.BeginTransaction())
            {
                try
                {
                    if (special.MainSpecialityId == null )
                    {
                        IEnumerable<SpecialityDTO> child = _unitOfManger.SpecialityManager.Index().Where(c => c.MainSpecialityId == special.Id);//Enumeration yielded no results in case partent hasn't child
                        if (child.Count()!=0)//child != null
                        {
                            result.Add("msg", "forbiden deleted /you can't this specialty because there are specialities is included in this speciality");
                            result.Add("status", 404);
                            return Json(result);
                        }
                       
                    }
                    bool del = this._unitOfManger.SpecialityManager.Delete(id);
                    if (!del)
                    {
                        TempData["error_msg"] = "Speciality Not Found";
                        result.Add("msg", "Speciality is not found");
                        result.Add("status", 404);
                        return Json(result);
                    }
                    transaction.Commit();
                    result.Add("msg", "Speciality has been deleted Successfully!");
                    result.Add("status", 202);
                    return Json(result);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    result.Add("msg", e.Message);
                    result.Add("status", 400);
                    return Json(result);
                }

            }
          }//405

        public ActionResult Activate(Guid id)
        {
            var result = new Dictionary<string, object>();
            SpecialityDTO? special = _unitOfManger.SpecialityManager.GetByID(id);

            if (special is null)
            {
                TempData["error_msg"] = "speciality Not Found";
                result.Add("msg", "speciality is not found");
                result.Add("status", 404);
                return Json(result);
            }

            using (IDbContextTransaction transaction = vezeetaDB.Database.BeginTransaction())
            {
                try
                {
                    bool active_found = this._unitOfManger.SpecialityManager.Activate(id);
                    if (!active_found)
                    {
                        TempData["error_msg"] = "Speciality Not Found";
                        result.Add("msg", "speciality is not found");
                        result.Add("status", 404);
                        return Json(result);
                    }
                    if (special.MainSpecialityId == null)
                    {
                       
                        IEnumerable<SpecialityDTO> childs = _unitOfManger.SpecialityManager.Index().Where(c => c.MainSpecialityId == special.Id);//Enumeration yielded no results in case partent hasn't child
                        if(childs.Count() != 0)
                        {
                            foreach (var child in childs)
                            {
                                child.is_active = special.is_active;
                            }
                        }
                       
                    }
                    transaction.Commit();
                    result.Add("msg", "Active of speciality has Changed Successfully!");
                    result.Add("status", 202);
                    return Json(result);
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    result.Add("msg", e.Message);
                    result.Add("status", 400);
                    return Json(result);
                }
            }
        }


        public ActionResult LoadData()
        {
            var iEData = _unitOfManger.SpecialityManager.LoadData();
            var _speciality = this.DataTable(iEData);
            return _speciality;
        }

    }
}
