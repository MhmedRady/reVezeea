using FluentValidation.Results;

using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Localization;

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
            return RedirectToAction("Edit", department);
        }
        
        bool find = _unitOfManger.DepartmentManager.Index()
            .Where(dept => dept.Id != department.Id)
            .Any(dept => dept.name_en == department.name_en || dept.name_ar == department.name_ar);

        if (find)
        {
            TempData["error_msg"] = "Department already exist Before";
            return RedirectToAction("Edit", department.Id);
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

    public ActionResult Delete(Guid id)
    {
        DepartmentDTO? department = _unitOfManger.DepartmentManager.GetByID(id);

        if (department is null)
        {
            TempData["error_msg"] = "Department Not Found";
            return RedirectToAction("index");
        }

        using (IDbContextTransaction transaction = vezeetaDB.Database.BeginTransaction())
        {
            try
            {
                bool del = this._unitOfManger.DepartmentManager.Delete(id);
                if (!del)
                {
                    TempData["error_msg"] = "Department Not Found";
                    return RedirectToAction("index");
                }
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                TempData["error_msg"] = e.Message;
            }
            return RedirectToAction("Index");
        }
    }

    public ActionResult Activate(Guid id)
    {
        DepartmentDTO? department = _unitOfManger.DepartmentManager.GetByID(id);

        if (department is null)
        {
            TempData["error_msg"] = "Department Not Found";
            return RedirectToAction("index");
        }

        using (IDbContextTransaction transaction = vezeetaDB.Database.BeginTransaction())
        {
            try
            {
                bool del = this._unitOfManger.DepartmentManager.Activate(id);
                if (!del)
                {
                    TempData["error_msg"] = "Department Not Found";
                    return RedirectToAction("index");
                }
                transaction.Commit();
            }
            catch (Exception e)
            {
                transaction.Rollback();
                TempData["error_msg"] = e.Message;
            }
            return RedirectToAction("Index");
        }
    }
    
    public ActionResult LoadData()
    {
        var iEData = _unitOfManger.DepartmentManager.LoadData();
        return this.DataTable(iEData);
    }
}
