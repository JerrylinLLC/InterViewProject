using InterViewProject.Data.Entities;

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
                                  select vb).OrderByDescending(t => t.BirthDate);
                    return result.ToList();
                }
                else
                {
                    var result = (from vb in ctx.FamilyEntities
                                  where vb.FamilySex == familySex
                                  select vb).OrderByDescending(t => t.BirthDate);
                    return result.ToList();
                }
            }
        }
    }
}
