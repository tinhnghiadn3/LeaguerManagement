namespace LeaguerManagement.Entities.ViewModels
{
    public class MergeCellModel
    {
        public string Text { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public bool IsFontBold { get; set; }

        public MergeCellModel()
        {
            IsFontBold = false;
        }
    }
}
