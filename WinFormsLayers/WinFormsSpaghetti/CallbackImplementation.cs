using System;
using WinFormsSpaghetti.CrmRepositoryService;

namespace WinFormsSpaghetti
{
    public class CallbackImplementation : ICRMRepositoryCallback
    {
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

    public class SignalArgs : EventArgs
    {
        public bool ServerAlive { get; set; }
    }
}