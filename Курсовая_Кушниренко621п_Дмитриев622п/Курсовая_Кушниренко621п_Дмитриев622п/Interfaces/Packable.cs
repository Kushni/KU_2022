﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingHomunculus
{
    interface Packable
    {
        public bool GetIsPacked();
        public int GetSize();
        public void Pack();
        public void UnPack();
    }
}
