﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WFFramework;

namespace VideoGameLibraryManager.Library
{
    public interface IGameLibraryView: IView
    {
        void ChangeView(IViewCollection viewCollection);
    }
}
