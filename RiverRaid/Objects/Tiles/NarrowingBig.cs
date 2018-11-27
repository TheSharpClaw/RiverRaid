using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using RiverRaid.ObjectTypes;

namespace RiverRaid.Objects.Tiles
{
    class NarrowingBig : ITile
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle BoundingBox { get; set; }
        public bool ToDestroy { get; private set; }

        public IComponent Stage { get; private set; }

        public NarrowingBig(IComponent stage, Texture2D texture, Vector2 position)
        {
            Stage = stage;

            Position = position;
            Texture = texture;
            BoundingBox = new Rectangle((int)(Position.X * Globals.scaleX), (int)(Position.Y * Globals.scaleY),
                (int)(Texture.Width * Globals.scaleX), (int)(0.8f * Texture.Height * Globals.scaleY));
        }

        public void Draw()
        {
            Globals.spriteBatch.Draw(Texture, Position, Color.White);
        }

        public void Update()
        {
            Position = new Vector2(Position.X, Position.Y + Globals.tileVelocity);
            if (Position.Y > 192)
                ToDestroy = true;
        }
    }
}