using System.Collections.Generic;
using System.Linq;
using WNSA.Models;

namespace WNSA.Data
{
    public class SqlWNSARepo : IWNSARepo
    {
        private readonly WNSADataContext _context;

        public SqlWNSARepo(WNSADataContext context)
        {
            _context = context;
        }

        public void CreateCommand(WNSAModel cmd)
        {
            if (cmd == null)
            {
                throw new System.ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Add(cmd);
            _context.SaveChanges();


        }

        public void DeleteCommand(WNSAModel cmd)
        {
            if(cmd == null)
            {
                throw new System.ArgumentNullException(nameof(cmd));
            }
            _context.Commands.Remove(cmd);
        }

        public IEnumerable<WNSAModel> GetAllCommands()
        {
           return  _context.Commands.ToList();
        }

        public WNSAModel GetCommandById(int id)
        {
           return _context.Commands.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
           return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand()
        {
           
        }

        public void UpdateCommand(WNSAModel command)
        {
            // Nothing
        }
    }

}