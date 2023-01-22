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
        return View();
    }
    [HttpGet]
    public ActionResult Create(CenterDTO? center)
    {
        return View(center);
    }
    
    [HttpPost]
    public ActionResult Store(CenterDTO center)
    {
        CenterValidation validator = new CenterValidation(localizer);
        ValidationResult result = validator.Validate(center);
        if (!result.IsValid)
        {
            foreach (var err in result.Errors)
            {
                TempData[err.PropertyName] = err.ErrorMessage;
            }
            return RedirectToAction("Create");
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
        CenterDTO? center = _unitOfManger.CenterManager.GetByID(id);

        if (center is null)
        {
            TempData["error_msg"] = "Center Not Found";
            return RedirectToAction("index");
        }
        return View(center);
    }
    [HttpPost]
    public ActionResult Update(Guid? id, CenterDTO center)
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
        CenterDTO? center = _unitOfManger.CenterManager.GetByID(id);

        if (center is null)
        {
            TempData["error_msg"] = "Center Not Found";
            return RedirectToAction("index");
        }

        using (IDbContextTransaction transaction = vezeetaDB.Database.BeginTransaction())
        {
            try
            {
                bool del = this._unitOfManger.CenterManager.Delete(id);
                if (!del)
                {
                    TempData["error_msg"] = "Center Not Found";
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
        CenterDTO? center = _unitOfManger.CenterManager.GetByID(id);

        if (center is null)
        {
            TempData["error_msg"] = "Center Not Found";
            return RedirectToAction("index");
        }

        using (IDbContextTransaction transaction = vezeetaDB.Database.BeginTransaction())
        {
            try
            {
                bool del = this._unitOfManger.CenterManager.Activate(id);
                if (!del)
                {
                    TempData["error_msg"] = "Center Not Found";
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
        var iEData = _unitOfManger.CenterManager.LoadData();
        return this.DataTable(iEData);
    }
}
