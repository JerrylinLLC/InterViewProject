using InterViewProject.Data.Entities;
using InterViewProject.Models;
using System;

namespace InterViewProject.Data.DAOs
{
    public class FamilyDAO
    {
        public List<FamilyEntities> GetFamilysBySex(string familySex)
        {
            using (AppDbContext ctx = new AppDbContext())
            {
                if (string.IsNullOrEmpty(familySex))
                {
                    var result = (from vb in ctx.FamilyEntities
                                  select vb).OrderBy(t => t.BirthDate);
                    return result.ToList();
                }
                else
                {
                    var result = (from vb in ctx.FamilyEntities
                                  where vb.FamilySex == familySex
                                  select vb).OrderBy(t => t.BirthDate);
                    return result.ToList();
                }
            }
        }
        public int InsertFamily(FamilyQueryModel familyQueryModel)
        {
            int resultCount = 0;
            using (AppDbContext ctx = new AppDbContext())
            {
                ctx.FamilyEntities.Add(new FamilyEntities
                {
                    FamilyId = Guid.NewGuid().ToString(),
                    FamilyName = familyQueryModel.FamilyName,
                    FamilySex = familyQueryModel.FamilySex,
                    BirthDate = familyQueryModel.BirthDate,
                    PhoneNumber = familyQueryModel.PhoneNumber,
                });
                return resultCount = ctx.SaveChanges();
            }
        }
        public int UpdateFamily(string name,FamilyQueryModel familyQueryModel)
        {
            int resultCount = 0;
            using (AppDbContext ctx = new AppDbContext())
            {
                ctx.FamilyEntities.Add(new FamilyEntities
                {
                    FamilyId = Guid.NewGuid().ToString(),
                    FamilyName = familyQueryModel.FamilyName,
                    FamilySex = familyQueryModel.FamilySex,
                    BirthDate = familyQueryModel.BirthDate,
                    PhoneNumber = familyQueryModel.PhoneNumber,
                });

                var result = (from vb in ctx.FamilyEntities
                              where vb.FamilyName == name
                              select vb);
                result.FirstOrDefault().FamilyName = familyQueryModel.FamilyName;

                ctx.SaveChanges();
                return resultCount = ctx.SaveChanges();
            }
        }
    }
}
