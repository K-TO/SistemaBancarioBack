using SatrackBank.Entities.POCOEntities;

namespace SatrackBank.UseCasesPorts.Product
{
    public interface ICreateProductOutputPort
    {
        Task Handle(BasicResponse response);
    }
}
