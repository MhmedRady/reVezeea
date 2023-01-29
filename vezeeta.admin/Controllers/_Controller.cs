using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using vezeeta.BL;
using vezeeta.BL.DTOs.Center;
using vezeeta.DBL;
using vezeeta.DBL.db.GenericModels;
using vezeeta.DBL.UnitOfWork;

namespace vezeeta.admin.Controllers
{
    public class _Controller : Controller
    {

        public  void TableColumns(bool createUrl = true, params string[] columns)
        {
            if(columns.Length == 0)
            {
               string[] Columns = { "name", "activate"};
               ViewBag.Columns = Columns;
            }
            else
            {
                ViewBag.Columns = columns;
            }

            ViewBag.CreateBtn = createUrl;
            
        }

      
        public ActionResult DataTable(IEnumerable<GenericNameDTOs>? ts)
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
                var getData = (ts);
                //Sorting    
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {
                    sortColumn = sortColumnDir == "#" ? "Id" : sortColumn;
                    getData = getData.OrderBy(d => d.name + " " + sortColumnDir);
                }

                //Search    
                if (!string.IsNullOrEmpty(searchValue))
                {
                    getData = getData.Where(d =>
                    d.name_ar.StartsWith(searchValue, StringComparison.InvariantCultureIgnoreCase) ||
                    d.name_en.StartsWith(searchValue, StringComparison.InvariantCultureIgnoreCase));
                }

                //total number of rows count     
                recordsTotal = getData.Count();
                //Paging     
                var data = getData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data    
                return Json(new 
                {   draw = draw, 
                    recordsFiltered = recordsTotal, 
                    recordsTotal = recordsTotal, 
                    data = data,
                    pageSize = pageSize,
                });

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
