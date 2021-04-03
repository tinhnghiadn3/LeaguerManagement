namespace LeaguerManagement.Entities.ViewModels
{
    public class SingleFieldModel<T>
    {
        public int Id { get; set; }
        public T Value { get; set; }
    }
}
