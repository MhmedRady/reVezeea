using FluentValidation.Results;

using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using vezeeta.admin.Validations;
using vezeeta.BL;
using vezeeta.DBL;

namespace vezeeta.admin.Controllers;

public class DepartmentController : _Controller
{
    private readonly VezeetaDB vezeetaDB;
    private readonly IUnitOfManger _unitOfManger;
    private const string IVIEW = "Views/Department/";

    private readonly IStringLocalizer<DepartmentController> localizer;

    public DepartmentController(VezeetaDB vezeetaDB, IUnitOfManger unitOfManger,
        IStringLocalizer<DepartmentController> _localizer)
    {
        this.vezeetaDB = vezeetaDB;
        this._unitOfManger = unitOfManger;
        localizer = _localizer;
    }
    [HttpGet]
    public ActionResult<IEnumerable<DepartmentDTO>> Index()
    {
        this.TableColumns();
        return View();
    }
    [HttpGet]
    public ActionResult Create(DepartmentDTO? departmentDto)
    {
        return View(departmentDto);
    }
    
    [HttpPost]
    public ActionResult Store(DepartmentDTO department)
    {
        DepartmentValidation validator = new DepartmentValidation(localizer);
        ValidationResult result = validator.Validate(department);
        if (!result.IsValid)
        {
            foreach (var err in result.Errors)
            {
                TempData[err.PropertyName] = err.ErrorMessage;
            }
            return RedirectToAction("Create");
        }

        bool find = _unitOfManger.DepartmentManager.Find(department);

        if(find)
        {
            TempData["error_msg"] = "Department already exist Before";
            return RedirectToAction("Create");
        }

        using (IDbContextTransaction transaction = vezeetaDB.Database.BeginTransaction())
        {
            try
            {
                _unitOfManger.DepartmentManager.Add(department);
                transaction.Commit();
                TempData["success_msg"] = "Department Created Successfully!";
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
        DepartmentDTO? department = _unitOfManger.DepartmentManager.GetByID(id);

        if (department is null)
        {
            TempData["error_msg"] = "Department Not Found";
            return RedirectToAction("index");
        }
        return View(department);
    }
    [HttpPost]
    public ActionResult Update(Guid? id, SetDepartmentDTO department)
    {

        DepartmentValidation validator = new DepartmentValidation(localizer);
        ValidationResult result = validator.Validate(department);
        if (!result.IsValid)
        {
            foreach (var err in result.Errors)
            {
                TempData[err.PropertyName] = err.ErrorMessage;
            }
            return RedirectToAction("Edit", new {id = department.Id});
        }
        
        bool find = _unitOfManger.DepartmentManager.Index()
            .Where(dept => dept.Id != department.Id)
            .Any(dept => dept.name_en == department.name_en || dept.name_ar == department.name_ar);

        if (find is true)
        {
            TempData["error_msg"] = "Department already exist Before";
            return RedirectToAction("Edit", new {id = department.Id});
        }

        using (IDbContextTransaction transaction = vezeetaDB.Database.BeginTransaction())
        {
            try
            {
                var update = _unitOfManger.DepartmentManager.Update(department);
                if (!update)
                {
                    TempData["error_msg"] = "Department Not Found!";
                    return RedirectToAction("Index");
                }
                transaction.Commit();
                TempData["success_msg"] = "Department data updated Successfully!";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                TempData["error_msg"] = ex.Message;
            }
        }

        return  RedirectToAction("Edit", new {id = department.Id});
    }
    [HttpDelete]
    public ActionResult Delete(Guid id)
    {
        DepartmentDTO? department = _unitOfManger.DepartmentManager.GetByID(id);
        var result = new Dictionary<string, object>();
        if (department is null)
        {
            result.Add("msg", "Department is Not Exist");
            result.Add("status", 404);
            return Json(result);
        }

        using (IDbContextTransaction transaction = vezeetaDB.Database.BeginTransaction())
        {
            try
            {
                bool del = this._unitOfManger.DepartmentManager.Delete(id);
                if (!del)
                {
                    result.Add("msg", "Department is Not Exist");
                    result.Add("status", 404);
                    return Json(result);
                }
                transaction.Commit();
                result.Add("msg", "Department has been deleted Successfully!");
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

    public ActionResult Activate(Guid id)
    {
        var result = new Dictionary<string, object>();

        DepartmentDTO? department = _unitOfManger.DepartmentManager.GetByID(id);

        if (department is null)
        {
            TempData["error_msg"] = "Department Not Found";
            result.Add("msg", "Department is not found");
            result.Add("status", 404);
            return Json(result);
        }

        using (IDbContextTransaction transaction = vezeetaDB.Database.BeginTransaction())
        {
            try
            {
                bool active_found = this._unitOfManger.DepartmentManager.Activate(id);
                transaction.Commit();
                result.Add("msg", "Active of center has Changed Successfully!");
                result.Add("status", 202);
                return Json(result);
            }
            catch (Exception e)
            {
                transaction.Rollback();
                TempData["error_msg"] = e.Message;
                result.Add("msg", "Active of department has Changed Successfully!");
                result.Add("status", 202);
                return Json(result);
            }
           
        }
    }

    public ActionResult LoadData()
    {
        var iEData = _unitOfManger.DepartmentManager.LoadData();
        return this.DataTable(iEData);
    }
}
