using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RiverRaid.ObjectTypes
{
    interface IEntity
    {
        Vector2 Position { get; set; }

        Texture2D Texture { get; set; }

        Rectangle BoundingBox { get; set; }

        IComponent Stage { get; }

        void Update();
        void Draw();
    }
}