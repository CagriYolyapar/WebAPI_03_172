using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_0.ResponseModels.Categories
{
    public class CategoryResponseModel
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }

    }
}