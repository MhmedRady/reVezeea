using FluentValidation.Results;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Localization;
using vezeeta.admin.Validations;
using vezeeta.BL;
using vezeeta.DBL;

namespace vezeeta.admin.Controllers;

public class DepartmentController : Controller
{
    private readonly VezeetaDB vezeetaDB;
    private readonly IDepartmentManager departmentManager;

    private readonly IStringLocalizer<DepartmentController> localizer;

    public DepartmentController(VezeetaDB vezeetaDB, IDepartmentManager departmentManager,
        IStringLocalizer<DepartmentController> _localizer)
    {
        this.vezeetaDB = vezeetaDB;
        this.departmentManager = departmentManager;
        localizer = _localizer;
    }
    public ActionResult<IEnumerable<DepartmentDTO>> Index()
    {
        var dapartments = departmentManager.Index();

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

        bool find = departmentManager.Find(department);

        if(find)
        {
            TempData["error_msg"] = "Departmnet is exist";
            return View(department);
        }

        using (IDbContextTransaction transaction = vezeetaDB.Database.BeginTransaction())
        {
            try
            {
                departmentManager.Add(department);
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

    public ActionResult<DepartmentDTO> FindDepartment(Guid Id) 
    { 
        return departmentManager.GetByID(Id);
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

            // Getting all Customer data    
            var customData = (from dept in departmentManager.Index()
                              select dept);

            //Sorting    
            /*if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {
                customerData = customerData.OrderBy(sortColumn + " " + sortColumnDir);
            }*/
            //Search    
            if (!string.IsNullOrEmpty(searchValue))
            {
                customData = customData.Where(m => m.name.Contains(searchValue));
            }

            //total number of rows count     
            recordsTotal = customData.Count();
            //Paging     
            var data = customData.Skip(skip).Take(pageSize).ToList();
            //Returning Json Data    
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

        }
        catch (Exception)
        {
            throw;
        }

    }

}
