using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using RiverRaid.ObjectTypes;

namespace RiverRaid.Objects.Tiles
{
    class GroundUncollidable : ITile
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle BoundingBox { get; set; }
        public bool ToDestroy { get; private set; }

        public IComponent Stage { get; private set; }

        public GroundUncollidable(IComponent stage, Texture2D texture, Vector2 position)
        {
            Stage = stage;

            Position = position;
            Texture = texture;
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