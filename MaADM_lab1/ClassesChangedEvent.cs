using System;
using System.Collections.Generic;

namespace MaADM_lab1
{
    public class ClassesChangedEvent : EventArgs
    {
        public List<Class> Classes { get; set; }

        public ClassesChangedEvent(List<Class> cl)
        {
            Classes = new List<Class>(cl);
        }
    }
}