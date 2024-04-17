using Core.DataAccess.EntityFramework;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DataAccess.Concrete.EntityFramework;

public class EfCarDal:EfEntityRepositoryBase<Car,SqlServerContext>,ICarDal
{
    public List<CarDetailDto> GetCarDetails()
    {
        using (var context = new SqlServerContext())
        {
            var result = from c in context.Cars
                         join b in context.Brands on c.BrandId
                         equals b.Id
                         join co in context.Colors on c.ColorId equals co.Id
                         select new CarDetailDto
                         {
                             CarId = c.Id,
                             BrandName = b.BrandName,
                             ColorName = co.ColorName,
                             ModelYear = c.ModelYear,
                             DailyPrice = c.DailyPrice,
                             Description = c.Description

                         };
                         return result.ToList();
        }
        
    }
}
