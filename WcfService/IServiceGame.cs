#region

using System.Collections.Generic;
using System.ServiceModel;
using System.Windows.Media;

#endregion

namespace WcfService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IServiceGame" в коде и файле конфигурации.
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IServiceGame
    {
        [OperationContract]
        bool Login(string login, Color color);

        [OperationContract]
        void SendCoord(double x, double y);

        [OperationContract]
        List<Player> GetAllPlayers();

        [OperationContract]
        Position GetPositionPlayer(string login);

        [OperationContract]
        void Test();

        [OperationContract]
        Point GetPoint();
    }
}