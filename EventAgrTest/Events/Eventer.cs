using System;
using System.Threading.Tasks;
using SignalR.EventAggregatorProxy.EventAggregation;

namespace EventAgrTest.Events
{
    public class Eventer : IEventAggregator
    {
        private Action<object> handler;

        public Eventer()
        {
            StartPublishing();
        }
        
        public void Subscribe(Action<object> handler)
        {
            this.handler = handler;
        }

        private void StartPublishing()
        {
            Task.Factory.StartNew(() =>
            {
                int number = 0;

                while (true)
                {
                    Publish(new MyMessage { Number = number++ });

                    System.Threading.Thread.Sleep(1000);
                }
            });
        }

        private void Publish(Message myMessage)
        {
            // publish message to client here ...
            //Clients.All.publishEvent(new MyMessage { Number = number++ });
            throw new NotImplementedException();
        }

        private void Handle(Message message)
        {
            // handle message from client here
            if (this.handler != null)
            {
                handler(message);
                //do something with message from client
            }
        }
    }
}