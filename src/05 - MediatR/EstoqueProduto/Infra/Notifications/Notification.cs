using System;

namespace EstoqueProduto.Infra.Notifications
{
    public class Notification
    {
        public string Menssage { get; }
        public Notification(string message)
        {
            Menssage = message;
        }        
    }
}