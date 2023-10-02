namespace SatrackBank.UseCasesPorts.Movements
{
    public interface IGetMovementsInputPort
    {
        Task Handle(string customerId);
    }
}
