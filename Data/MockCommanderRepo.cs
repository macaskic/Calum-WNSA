using System.Collections.Generic;
using WNSA.Models;

namespace WNSA.Data
{
  public class MockWNSARepo : IWNSARepo
    {
        public void CreateCommand(WNSAModel command)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(WNSAModel cmd)
        {
            throw new System.NotImplementedException();
        }

        public  IEnumerable<WNSAModel> GetAllCommands()
        {

         
            var commands = new List<WNSAModel>
            {
                 new WNSAModel{ Id = 0, Name="Paul Dalhuisen", Role="Senior Software Engineer", Personal="Some Personal Data" },
                 new WNSAModel{ Id = 1, Name="Michael Bostock", Role="Solutions Architect", Personal="Some Personal Data 1"},
                 new WNSAModel{ Id = 2, Name="Calum G Macaskill", Role="Contractor", Personal="Some Personal Data 2"}
            };

            return commands;
        }

       public WNSAModel GetCommandById(int Id)
        {
            return new WNSAModel{Id = 0, Name = "Some Name", Role = "Some Role", Personal = "Some Persona Datal" };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(WNSAModel command)
        {
            throw new System.NotImplementedException();
        }
    }

}