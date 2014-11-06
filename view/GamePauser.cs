using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class GamePauser : INewHandListener
    {
        public void OnNewHandEvent()
        {
            System.Threading.Thread.Sleep(1000);
        }
    }
}
