﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{

    // NuGet : PyPi benzeri Paket sağlayacısı

    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryID equals c.CategoryID
                             select new ProductDetailDto
                             { ProductId = p.ProductID, ProductName = p.ProductName, 
                               CategoryName = c.CategoryName, UnitsInStock = p.UnitsInStock 
                             };
                return result.ToList();
            }

        }
    }
}
