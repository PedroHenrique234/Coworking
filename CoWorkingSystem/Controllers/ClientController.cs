using CoWorkingSystem.Data;
using CoWorkingSystem.Models;
using CoWorkingSystem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CoWorkingSystem.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepository;
        public ClientController(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }
        public IActionResult Index()
        {
            List<ClientModel> clients = _clientRepository.FindAll();
            return View(clients);
        }

        public IActionResult ClientDetails(int Id)
        {
            ClientModel client = _clientRepository.FindById(Id);
            List<UseModel> uses = _clientRepository.FindAllUses();
            return View(client);
        }

        public IActionResult AddUse(int Id)
        {
            ClientModel client = _clientRepository.FindById(Id);
            UseModel use = new UseModel();
            use.ClientId = Id;
            return View(use);
        }

        [HttpPost]
        public IActionResult AddNewUse(UseModel use, int Id)
        {
            _clientRepository.AddUses(use, Id);
            return RedirectToAction("Index");
        }


        public IActionResult AddClient()
        {
            return View();
        }
        public IActionResult RemoveConfirm(int id)
        {
            ClientModel client = _clientRepository.FindById(id);
            return View(client);
        }
        public IActionResult RemoveClient(int id)
        {
            _clientRepository.DeletClient(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult AddClient(ClientModel client)
        {
            _clientRepository.AddClient(client);
            return RedirectToAction("Index");
        }
        public IActionResult ClientUpdate(int id)
        {
            ClientModel client = _clientRepository.FindById(id);
            return View(client);
        }
        [HttpPost]
        public IActionResult ClientUpdate(ClientModel client)
        {
            _clientRepository.ClientUpdate(client);
            return RedirectToAction("index");
        }
    }
}
