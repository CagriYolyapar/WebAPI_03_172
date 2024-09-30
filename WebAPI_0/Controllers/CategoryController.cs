using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_0.DesignPatterns.SingletonPattern;
using WebAPI_0.Models;
using WebAPI_0.RequestModels;
using WebAPI_0.ResponseModels.Categories;

namespace WebAPI_0.Controllers
{
    public class CategoryController : ApiController
    {
        NorthwindEntities _db;



        public CategoryController()
        {
            _db = DBTool.DbInstance;
        }


        List<CategoryResponseModel> ListCategories()
        {
            return _db.Categories.Select(x => new CategoryResponseModel
            {
                CategoryName = x.CategoryName,
                Description = x.Description,
                ID = x.CategoryID
            }).ToList();

        }


        [HttpGet]
        public List<CategoryResponseModel> GetCategories()
        {
            return ListCategories();
        }

        [HttpGet]
        public CategoryResponseModel GetCategory(int id)
        {
            return _db.Categories.Where(x => x.CategoryID == id).Select(x => new CategoryResponseModel
            {

                CategoryName = x.CategoryName,
                Description = x.Description,
                ID = x.CategoryID
            }).FirstOrDefault();
        }

        [HttpPost]
        public List<CategoryResponseModel> AddCategory(CreateCategoryRequestModel model)
        {
            Category c = new Category()
            {
                CategoryName = model.Name,
                Description = model.Description
            };

            _db.Categories.Add(c);
            _db.SaveChanges();
            return ListCategories();

        }

        [HttpPut]
        public List<CategoryResponseModel> UpdateCategory(UpdateCategoryRequestModel model)
        {
            Category original = _db.Categories.Find(model.ID);
            original.Description = model.Description;
            original.CategoryName = model.Name;
            _db.SaveChanges();
            return ListCategories();
        }

        [HttpDelete]
        public List<CategoryResponseModel> DeleteCategory(int id)
        {
            _db.Categories.Remove(_db.Categories.Find(id));
            _db.SaveChanges();
            return ListCategories();
        }

        [HttpGet]
        public List<CategoryResponseModel> SearchCategory(string item)
        {
            return _db.Categories.Where(x => x.CategoryName.Contains(item)).Select(x => new CategoryResponseModel
            {
                CategoryName=x.CategoryName,
                Description=x.Description,
                ID = x.CategoryID
            }).ToList();
        }
    }
}
