using SatrackBank.Entities.POCOEntities;

namespace SatrackBank.UseCasesPorts.Product
{
    public interface ICancelProductOutputPort
    {
        Task Handle(BasicResponse response);
    }
}
