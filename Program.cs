﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            view.IView v = new view.SwedishView();//new view.SimpleView();
            model.Game g = new model.Game(v);
            controller.PlayGame ctrl = new controller.PlayGame();

            while (ctrl.Play(g, v));
        }
    }
}
