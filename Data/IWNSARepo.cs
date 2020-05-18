using System.Collections.Generic;
using WNSA.Models;

namespace WNSA.Data
{
    public interface IWNSARepo
    {
        bool SaveChanges();
        IEnumerable<WNSAModel> GetAllCommands();
        WNSAModel GetCommandById(int Id);
        void CreateCommand(WNSAModel cmd);
        void UpdateCommand(WNSAModel cmd);
        void DeleteCommand(WNSAModel cmd);
    }

}