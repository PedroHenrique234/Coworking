using CoWorkingSystem.Models;

namespace CoWorkingSystem.Repositories
{
    public interface IClientRepository
    {
        public ClientModel AddClient(ClientModel client);
        public List<ClientModel> FindAll(); 
        public ClientModel FindById(int id);
        public ClientModel ClientUpdate(ClientModel client);
        public bool DeletClient(int id);
        public UseModel AddUses(UseModel use, int id);
        public List<UseModel> FindAllUses();
    }
}
