namespace LeaguerManagement.Entities.ViewModels
{
	public class AppErrorModel
    {
        public string Message { get; set; }
        public string Detail { get; set; }

        public AppErrorModel()
        {

        }

        public AppErrorModel(string message)
        {
            Message = message;
        }

        public AppErrorModel(string message, string detail) : this(message)
        {
            Detail = detail;
        }
    }
}
