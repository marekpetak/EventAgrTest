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
                    Handle(new MyMessage { Number = number++ });

                    System.Threading.Thread.Sleep(10);
                }
            });
        }

        public void Handle(Message message)
        {
            if (this.handler != null)
            {
                handler(message);
            }
        }
    }
}