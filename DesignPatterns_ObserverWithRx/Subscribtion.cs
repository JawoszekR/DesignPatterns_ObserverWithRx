using DesignPatterns_Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_ObserverWithRx
{
    class Subscribtion : IDisposable
    {
        private WetherStation parent;
        public IObserver<WetherStationDTO> Obserwer { get; set; }
        public Subscribtion(WetherStation parent, IObserver<WetherStationDTO> obserwer)
        {
            this.parent = parent;
            this.Obserwer = obserwer;
        }

        public void Dispose()
        {
            parent.RemoveSubscription(this);
            parent = null;
        }
    }
}
