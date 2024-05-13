namespace BlackJack.Models
{
    public class Branches
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Direction { get; set; }


        //Relacion con Horarios
        public ICollection<Schedules> Schedules { get; set; }
    }
}
