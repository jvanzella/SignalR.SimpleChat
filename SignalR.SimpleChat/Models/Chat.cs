using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using SignalR.Hubs;

namespace SignalR.Chat.Models
{
    public class Chat
    {
        private static readonly Lazy<Chat> LazyInstance = new Lazy<Chat>(() => new Chat());
        public static readonly List<Client> Clients = new List<Client>();

        public static Chat Instance
        {
            get { return LazyInstance.Value; }
        }

        public void SpreadMessage(string message)
        {
            BroadCastMessage(message);
        }

        private void BroadCastMessage(string message)
        {
            var clients = Hub.GetClients<ChatHub>();

            clients.newMessage(message);
            clients.isAlive();
        }

        public void GetClients()
        {
            var serializer = new JavaScriptSerializer();
            var messageAsJson = serializer.Serialize(Clients);

            var clients = Hub.GetClients<ChatHub>();
            clients.userList(messageAsJson);
        }
    }
}