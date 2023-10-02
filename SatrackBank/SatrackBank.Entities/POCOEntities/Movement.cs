using SatrackBank.Entities.Enums;

namespace SatrackBank.Entities.POCOEntities
{
    public class Movement
    {
        public string Id { get; set; }
        public MovementType MovementType { get; set; }
        public double Value { get; set; }
        public double PreviousBalance { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string ProductId { get; set; }
    }
}
