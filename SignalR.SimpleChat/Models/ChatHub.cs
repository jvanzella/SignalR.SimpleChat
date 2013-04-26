using System;
using System.Linq;
using SignalR.Hubs;

namespace SignalR.Chat.Models
{
    [HubName("chatHub")]
    public class ChatHub : Hub
    {
        private readonly Chat _chat;

        public ChatHub() : this(Chat.Instance)
        {
        }

        public ChatHub(Chat chat)
        {
            _chat = chat;
        }

        public void Join(string myName)
        {
            if (Chat.Clients.Any(x => x.Name.Equals(myName)))
            {
                throw new Exception("This login is already in use");
            }

            Chat.Clients.Add(new Client {Name = myName, LastResponse = DateTime.Now});
            SendMessageServer(string.Format("{0} entered the chat", myName));
            GetClients();
            Caller.Naam = myName;
        }

        public void Leave(string myName)
        {
            if (!Chat.Clients.Any(x => x.Name.Equals(myName)))
            {
                throw new Exception("This login is not in use");
            }

            Chat.Clients.RemoveAll(c => c.Name == myName);
        }

        private void GetClients()
        {
            _chat.GetClients();
        }

        public void SendMessageServer(string message)
        {
            _chat.SpreadMessage(message);
        }

        public void SendMessage(string message)
        {
            if (Chat.Clients.Any(x => x.Name.Equals(Caller.Naam)))
            {
                _chat.SpreadMessage(string.Format("({0}) <b>{1}</b>: {2}", DateTime.Now.ToString("HH:mm"), Caller.Naam,
                                                  message));
            }
        }
    }
}