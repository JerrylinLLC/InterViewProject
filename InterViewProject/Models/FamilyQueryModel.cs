namespace InterViewProject.Models
{
    public class FamilyQueryModel
    {
        public required string FamilyName { get; set; }
        public required string FamilySex { get; set; }
        public DateTime BirthDate { get; set; }
        public int? PhoneNumber { get; set; }
    }
}
