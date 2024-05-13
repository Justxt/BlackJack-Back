namespace BlackJack.Models
{
    public class Schedules
    {
        public int Id { get; set; }

        //Relacion con Horarios
        public int BranchesId { get; set; }
        public Branches Branches { get; set; }

        public TimeSpan OpeningTime { get; set; }
        public TimeSpan CloseTime { get; set; }

    }
}
