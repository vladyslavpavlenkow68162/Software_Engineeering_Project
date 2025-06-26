namespace TrainingReservationService.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public string ClientName { get; set; } = string.Empty;
        public string TrainerName { get; set; } = string.Empty;
        public DateTime TrainingDate { get; set; }
        public bool Confirmed { get; set; } = false;
    }
}
