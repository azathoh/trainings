using System;

namespace Contracts
{
    public class SignalArgs : EventArgs
    {
        public bool ServerAlive { get; set; }
    }
}
