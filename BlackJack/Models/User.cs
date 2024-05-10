namespace BlackJackk.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        //Relacion con la Membresia
        public int? MembershipId { get; set; }
        public Membership Membership { get; set; }

        //Relacion con el Metodo de Paago
        public ICollection<PaymentMethod> PaymentMethods { get; set; }

        //Relacion con los creditos
        public Credits Credits { get; set; }

        //Relacion con los tickets
        public ICollection<SupportTicket> SupportTicket { get; set; }
    }
}
