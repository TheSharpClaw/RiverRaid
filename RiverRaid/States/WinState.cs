﻿using System;
using System.Collections.Generic;

using RiverRaid.ObjectTypes;

namespace RiverRaid.States
{
    class WinState : IStateTemplate, IComponent
    {
        public WinState()
        {

        }

        public List<IEntity> DrawList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<IEntity> UpdateList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Draw()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}