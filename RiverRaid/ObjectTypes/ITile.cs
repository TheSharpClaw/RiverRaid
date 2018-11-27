using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using RiverRaid.ObjectTypes;

namespace RiverRaid.Objects.Tiles
{
    interface ITile : IEntity
    {
        Vector2 Position { get; set; }
        Texture2D Texture { get; set; }
        Rectangle BoundingBox { get; set; }
        bool ToDestroy { get; }

        IComponent Stage { get; }

        void Draw();
        void Update();
    }
}