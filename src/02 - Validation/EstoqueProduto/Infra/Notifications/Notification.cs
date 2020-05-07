using System;

namespace EstoqueProduto.Infra.Notifications
{
    public class Notification
    {
        public string Mensage { get; }
        public Notification(string message)
        {
            Mensage = message;
        }        
    }
}