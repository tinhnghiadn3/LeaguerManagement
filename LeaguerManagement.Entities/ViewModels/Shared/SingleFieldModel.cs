namespace LeaguerManagement.Entities.ViewModels.Shared
{
    public class SingleFieldModel<T>
    {
        public int Id { get; set; }
        public T Value { get; set; }
    }
}
