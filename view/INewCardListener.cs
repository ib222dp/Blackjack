﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.view
{
    interface INewCardListener
    {
        void OnNewCardEvent(model.Card c);
    }
}
