using CoWorkingSystem.Data;
using CoWorkingSystem.Models;

namespace CoWorkingSystem.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly BankContext _bankContext;
        public ClientRepository(BankContext bankContext)
        {
            _bankContext = bankContext;
        }
        public ClientModel AddClient(ClientModel client)
        {
            _bankContext.Clients.Add(client);
            _bankContext.SaveChanges();
            return client;
        }

        public ClientModel ClientUpdate(ClientModel client)
        {
            ClientModel clientDb = new ClientModel();

            if (client == null) throw new Exception("Impossível atualizar o cliente");

            clientDb.Name = client.Name;
            clientDb.CreatDate = client.CreatDate;
            clientDb.Id = client.Id;

            _bankContext.Update(clientDb);
            _bankContext.SaveChanges();
            return clientDb;
        }

        public bool DeletClient(int id)
        {
            ClientModel clientDb = FindById(id);

            if (clientDb == null) throw new Exception("Impossível apagar o cliente");

            _bankContext.Remove(clientDb);
            _bankContext.SaveChanges();
            return true;
        }

        public List<ClientModel> FindAll()
        {
            return _bankContext.Clients.ToList();
        }

        public ClientModel FindById(int id)
        {
            return _bankContext.Clients.FirstOrDefault(o => o.Id == id);
        }
    }
}
