using System.ServiceModel;

namespace WcfServerSample
{
    [ServiceContract]
    public interface IBuggyService
    {
        [OperationContract]
        string ThrowsException(int value);

        [OperationContract]
        string DoesNotRespond(int value);
    }
}