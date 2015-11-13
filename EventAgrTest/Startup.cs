using System;
using EventAgrTest.Events;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using SignalR.EventAggregatorProxy.EventAggregation;
using SignalR.EventAggregatorProxy.Owin;

[assembly: OwinStartup(typeof(EventAgrTest.Startup))]
namespace EventAgrTest
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
            
            var eventAgregator = new Lazy<IEventAggregator>(() => new Eventer());
            GlobalHost.DependencyResolver.Register(typeof(IEventAggregator), () => eventAgregator.Value);

            app.MapEventProxy<Message>();
        }
    }
}