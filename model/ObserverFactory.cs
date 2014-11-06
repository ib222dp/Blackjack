using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class ObserverFactory
    {
        public INewHandListener GetHandListeners()
        {
            return new GamePauser();
        }
    }
}
