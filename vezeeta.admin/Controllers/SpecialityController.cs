using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Localization;
using System.ComponentModel.DataAnnotations;
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
            ViewBag.mainSpecialitiesName = _unitOfManger.SpecialityManager.Index().Where(c => c.is_active == true);
            return View(speciality);
        }
        [HttpPost]
        public ActionResult Store(SpecialityDTO speciality, IFormFile logo)
        {
            //SpecialityValidation validator = new SpecialityValidation(localizer);
            //ValidationResult result = validator.Validate(speciality);

            //if (!result.IsValid)
            //{
            //    foreach (var err in result.Errors)
            //    {
            //        TempData[err.PropertyName] = err.ErrorMessage;
            //    }
            //    return RedirectToAction("Create", speciality);
            //}

            //bool find = _unitOfManger.SpecialityManager.Find(speciality);

            //if (find)
            //{
            //    TempData["error_msg"] = "Speciality already exist Before";
            //    return RedirectToAction("Create");
            //}

            //if (logo != null)
            //{
            //    string? checkImageExt = Helper.checkImageExt(logo);
            //    if (checkImageExt is not null)
            //    {
            //        TempData["error_msg"] = checkImageExt;
            //        return RedirectToAction("Create");
            //    }
            //    speciality.logo = Helper.uploadImage(logo, "speciality");
            //}

            //using (IDbContextTransaction transaction = vezeetaDB.Database.BeginTransaction())
            //{
            //    try
            //    {
            //        _unitOfManger.SpecialityManager.Add(speciality);
            //        transaction.Commit();
            //        TempData["success_msg"] = "Speciality Created Successfully!";
            //    }
            //    catch (Exception ex)
            //    {
            //        transaction.Rollback();
            //        TempData["error_msg"] = ex.Message;
            //        return RedirectToAction("Create");
            //    }
            //}
            return RedirectToAction("Index");
        }
    }
}
