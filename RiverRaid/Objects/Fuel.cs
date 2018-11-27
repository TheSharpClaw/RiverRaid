using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using RiverRaid.ObjectTypes;

namespace RiverRaid.Objects
{
    class Fuel : IEntity
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; } = Globals.fuel;
        public Rectangle BoundingBox { get; set; }

        public IComponent Stage { get; private set; }

        public Fuel(IComponent stage, Vector2 position)
        {
            Stage = stage;
            Position = position;
            BoundingBox = new Rectangle((int)(Position.X * Globals.scaleX), (int)(Position.Y * Globals.scaleY),
                (int)(Texture.Width * Globals.scaleX), (int)(Texture.Height * Globals.scaleY));
        }

        public void Draw()
        {
            Globals.spriteBatch.Draw(Texture, Position, Color.White);
        }

        public void Update()
        {

        }
    }
}
