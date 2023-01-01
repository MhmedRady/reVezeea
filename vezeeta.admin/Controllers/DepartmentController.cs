using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using vezeeta.admin.Validations;
using vezeeta.BL;
using vezeeta.DBL;

namespace vezeeta.admin.Controllers;

public class DepartmentController : Controller
{
    private readonly VezeetaDB vezeetaDB;
    private readonly IUnitOfManger _unitOfManger;

    private readonly IStringLocalizer<DepartmentController> localizer;

    public DepartmentController(VezeetaDB vezeetaDB, IUnitOfManger unitOfManger,
        IStringLocalizer<DepartmentController> _localizer)
    {
        this.vezeetaDB = vezeetaDB;
        this._unitOfManger = unitOfManger;
        localizer = _localizer;
    }
    public ActionResult<IEnumerable<DepartmentDTO>> Index()
    {
        var dapartments = _unitOfManger.DepartmentManager.Index();

        return View(dapartments);
    }
    [HttpGet]
    public ActionResult Create()
    {
        return View();
    }
    [HttpGet]
    public ActionResult Update()
    {
        return View();
    }
    [HttpPost]
    public ActionResult Create(SetDepartmentDTO department)
    {
        DepartmentValidation validator = new DepartmentValidation(localizer);
        ValidationResult result = validator.Validate(department);
        if (!result.IsValid)
        {
            foreach (var err in result.Errors)
            {
                TempData[err.PropertyName] = err.ErrorMessage;
            }
            return View(department);
        }

        bool find = _unitOfManger.DepartmentManager.Find(department);

        if(find)
        {
            TempData["error_msg"] = "Departmnet is exist";
            return View(department);
        }

        using (IDbContextTransaction transaction = vezeetaDB.Database.BeginTransaction())
        {
            try
            {
                _unitOfManger.DepartmentManager.Add(department);
                transaction.Commit();
                TempData["success_msg"] = "Departmnet is exist";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                TempData["error_msg"] = ex.Message;
            }
        }
        return View();
    }
    public ActionResult LoadData()
    {

        try
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            var start = Request.Form["start"].FirstOrDefault();
            var length = Request.Form["length"].FirstOrDefault();
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
            var sortColumnDir = Request.Form["order[0][dir]"].FirstOrDefault();
            var searchValue = Request.Form["search[value]"].FirstOrDefault();

            //Paging Size (10,20,50,100)    
            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            Debug.WriteLine(searchValue);
            // Getting all Customer data    
            var deptData = (from dept in _unitOfManger.DepartmentManager.Index()
                              select dept);

            //Sorting    
            /*if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                customerData = customerData.OrderBy(sortColumn + " " + sortColumnDir);
            }*/
            //Search    
            if (!string.IsNullOrEmpty(searchValue))
            {
                deptData = deptData.Where(d => d.name_en.Contains(searchValue));
            }

            //total number of rows count     
            recordsTotal = deptData.Count();
            //Paging     
            var data = deptData.Skip(skip).Take(pageSize).ToList();
            //Returning Json Data    
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

        }
        catch (Exception)
        {
            throw;
        }

    }

}
