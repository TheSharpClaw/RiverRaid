﻿using System;
using System.Collections.Generic;

using RiverRaid.ObjectTypes;

namespace RiverRaid.States
{
    class MenuState : IStateTemplate, IComponent
    {
        public MenuState()
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