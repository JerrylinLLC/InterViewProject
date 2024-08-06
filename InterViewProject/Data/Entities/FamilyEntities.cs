namespace InterViewProject.Data.Entities
{
    public partial class FamilyEntities
    {
        public required string FamilyId { get; set; }
        public required string FamilyName { get; set; }
        public required string FamilySex { get; set; }
        public DateTime BirthDate { get; set; }
        public int? PhoneNumber { get; set; }        
    }
}
