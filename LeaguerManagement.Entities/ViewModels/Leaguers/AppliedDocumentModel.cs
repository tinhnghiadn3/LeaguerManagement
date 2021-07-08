namespace LeaguerManagement.Entities.ViewModels
{
    public class AppliedDocumentModel
    {
        public int Id { get; set; }
        public int LeaguerId { get; set; }
        public string Name { get; set; }
        public int OfficialDocumentId { get; set; }
        public int ChangeOfficialDocumentTypeId { get; set; }
    }
}
