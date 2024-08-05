using InterViewProject.Data.Entities;

namespace InterViewProject.Data.DAOs
{
    public class FamilyDAO
    {

        public List<FamilyEntities> GetWelfareLinkByMemNum(string familySex)
        {
            using (AppDbContext ctx = new AppDbContext())
            {
                var result = (from vb in ctx.FamilyEntities
                              where vb.FamilySex == familySex
                              select vb).OrderByDescending(t => t.BirthDate);
                return result.ToList();
            }
        }
    }
}
