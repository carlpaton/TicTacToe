namespace GameUI.Models
{
    public class ApiGameMoveModel
    {
        public string SquareNumber { get; set; }
    }

    public class ApiGameMoveResponseModel
    {
        public string Status { get; set; }
        public string CurrentPlayer { get; set; }
    }
}
