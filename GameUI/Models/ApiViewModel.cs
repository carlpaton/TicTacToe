namespace GameUI.Models
{
    public class ApiGameMoveModel
    {
        public string SquareNumber { get; set; }
    }

    public class ApiGameMoveResponseModel
    {
        public ApiGameMoveResponseModel() 
        {
            Computer = new ApiGameComputerModel();
        }

        public string Status { get; set; }
        public string CurrentPlayer { get; set; }
        public string CurrentGameLog { get; set; }
        public ApiGameComputerModel Computer { get; set; }
    }

    public class ApiGameComputerModel 
    {
        public string Player { get; set; }
        public int Square { get; set; }
    }
}
