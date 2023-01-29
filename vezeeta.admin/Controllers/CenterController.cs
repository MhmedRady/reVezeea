using FluentValidation.Results;

using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Localization;

using vezeeta.admin.Validations;
using vezeeta.BL;
using vezeeta.BL.DTOs.Center;
using vezeeta.DBL;

namespace vezeeta.admin.Controllers;

public class CenterController : _Controller
{
    private readonly VezeetaDB vezeetaDB;
    private readonly IUnitOfManger _unitOfManger;
    private const string IVIEW = "Views/Department/";

    private readonly IStringLocalizer<CenterController> localizer;

    public CenterController(VezeetaDB vezeetaDB, IUnitOfManger unitOfManger,
        IStringLocalizer<CenterController> _localizer)
    {
        this.vezeetaDB = vezeetaDB;
        this._unitOfManger = unitOfManger;
        localizer = _localizer;
    }
    [HttpGet]
    public ActionResult<IEnumerable<CenterDTO>> Index()
    {
        this.TableColumns(true,"name","email","mobile","phone","department_name", "activate");
        return View();
    }
    [HttpGet]
    public ActionResult Create(CenterDTO? center)
    {
        ViewBag.departmentsName = _unitOfManger.DepartmentManager.Index().Where(c => c.is_active == true);
        return View(center);
    }
    
    [HttpPost]
    public ActionResult Store(CenterDTO center,IFormFile logo)
    {
        CenterValidation validator = new CenterValidation(localizer);
        ValidationResult result = validator.Validate(center);
        if (!result.IsValid)
        {
            foreach (var err in result.Errors)
            {
                TempData[err.PropertyName] = err.ErrorMessage;
            }
            return RedirectToAction("Create",center);
        }

        bool find = _unitOfManger.CenterManager.Find(center);

        if(find)
        {
            TempData["error_msg"] = "center already exist Before";
            return RedirectToAction("Create");
        }

        using (IDbContextTransaction transaction = vezeetaDB.Database.BeginTransaction())
        {
            try
            {
                if (logo == null)
                {
                    center.logo = @"/images/DefaultImage.jpeg";
                }
                else
                {
                    if(!Helper.uploadeFile(logo, "center").Contains("."))
                    {
                        TempData["error_msg"] = "there is problem in format of image";
                        return RedirectToAction("Create");
                    }
                    center.logo = Helper.uploadeFile(logo, "center");

                }
                _unitOfManger.CenterManager.Add(center);
                transaction.Commit();
                TempData["success_msg"] = "center Created Successfully!";
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
        ViewBag.departmentsName = _unitOfManger.DepartmentManager.Index().Where(c => c.is_active == true);
        CenterDTO? center = _unitOfManger.CenterManager.GetByID(id);

        if (center is null)
        {
            TempData["error_msg"] = "Center Not Found";
            return RedirectToAction("index");
        }
        return View(center);
    }
    [HttpPost]
    public ActionResult Update(Guid? id, CenterDTO center, IFormFile logo)
    {

        CenterValidation validator = new CenterValidation(this.localizer);
        ValidationResult result = validator.Validate(center);
        if (!result.IsValid)
        {
            foreach (var err in result.Errors)
            {
                TempData[err.PropertyName] = err.ErrorMessage;
            }
            return RedirectToAction("Edit", center);
        }
        
        bool find = _unitOfManger.CenterManager.Index()
            .Where(dept => dept.Id != center.Id)
            .Any(dept => dept.name_en == center.name_en || dept.name_ar == center.name_ar);

        if (find)
        {
            TempData["error_msg"] = "center already exist Before";
            return RedirectToAction("Edit", center.Id);
        }

        using (IDbContextTransaction transaction = vezeetaDB.Database.BeginTransaction())
        {
            try
            {
                if (logo == null)
                {
                    center.logo = @"/images/DefaultImage.jpeg";
                }
                else
                {
                    if (!Helper.uploadeFile(logo, "center").Contains("."))
                    {
                        TempData["error_msg"] = "there is problem in format of image";
                        return RedirectToAction("Edit", center);
                    }
                    center.logo = Helper.uploadeFile(logo, "center");

                }
               
                var update = _unitOfManger.CenterManager.Update(center);
                if (!update)
                {
                    TempData["error_msg"] = "Center Not Found!";
                    return RedirectToAction("Index");
                }
                transaction.Commit();
                TempData["success_msg"] = "center data updated Successfully!";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                TempData["error_msg"] = ex.Message;
            }
        }

        return  RedirectToAction("Edit", new {id = center.Id});
    }

    public ActionResult Delete(Guid id)
    {
        var result = new Dictionary<string, object>();

        CenterDTO? center = _unitOfManger.CenterManager.GetByID(id);

        if (center is null)
        {
            TempData["error_msg"] = "Center Not Found";
            //return RedirectToAction("index");
            result.Add("msg", "Center is not found");
            result.Add("status", 404);
            return Json(result);
        }

        using (IDbContextTransaction transaction = vezeetaDB.Database.BeginTransaction())
        {
            try
            {
                bool del = this._unitOfManger.CenterManager.Delete(id);
                if (!del)
                {
                    TempData["error_msg"] = "Center Not Found";
                    //  return RedirectToAction("index");
                    result.Add("msg", "Center is not found");
                    result.Add("status", 404);
                    return Json(result);
                }
                transaction.Commit();
                result.Add("msg", "Center has been deleted Successfully!");
                result.Add("status", 202);
                return Json(result);
            }
            catch (Exception e)
            {
                transaction.Rollback();
                //TempData["error_msg"] = e.Message;
                result.Add("msg", e.Message);
                result.Add("status", 400);
                return Json(result);
            }
          
        }
    }//405

    public ActionResult Activate(Guid id)
    {
        var result = new Dictionary<string, object>();
        CenterDTO? center = _unitOfManger.CenterManager.GetByID(id);

        if (center is null)
        {
            TempData["error_msg"] = "Center Not Found";
            //return RedirectToAction("index");
            result.Add("msg", "Center is not found");
            result.Add("status", 404);
            return Json(result);
        }

        using (IDbContextTransaction transaction = vezeetaDB.Database.BeginTransaction())
        {
            try
            {
                bool active_found = this._unitOfManger.CenterManager.Activate(id);
                if (!active_found)
                {
                    TempData["error_msg"] = "Center Not Found";
                    //return RedirectToAction("index");
                    result.Add("msg", "Center is not found");
                    result.Add("status", 404);
                    return Json(result);
                }
                transaction.Commit();
                result.Add("msg", "Active of center has Changed Successfully!");
                result.Add("status", 202);
                return Json(result);
            }
            catch (Exception e)
            {
                transaction.Rollback();
               // TempData["error_msg"] = e.Message;
                result.Add("msg", e.Message);
                result.Add("status", 400);
                return Json(result);
            }
            //return RedirectToAction("Index");
        }
    }
    
    public ActionResult LoadData()
    {

        var iEData = _unitOfManger.CenterManager.LoadData();
       var x= iEData.FirstOrDefault();
      // var y = x.Department;
      //  Console.WriteLine(y);
        return this.DataTable(iEData);
    }
}
