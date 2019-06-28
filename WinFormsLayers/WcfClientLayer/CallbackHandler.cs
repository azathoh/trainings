using System;
using Contracts;
using WcfClientLayer.CrmRepositoryClient;

namespace WcfClientLayer
{
    public class CallbackHandler : ICRMRepositoryCallback
    {
        private static readonly Lazy<CallbackHandler> callbackLazy = new Lazy<CallbackHandler>(()=>new CallbackHandler());
        public static CallbackHandler Instance => callbackLazy.Value;
        public event EventHandler<SignalArgs> SignalArrived;
        public void Signal()
        {
            if (SignalArrived != null)
            {
                SignalArgs args = new SignalArgs();
                args.ServerAlive = true;
                SignalArrived(this, args);
            }
        }
    }
}
