using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using RiverRaid.ObjectTypes;
using System.Collections.Generic;

namespace RiverRaid.Objects.Tiles
{
    class NarrowingSmall : ITile
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle BoundingBox { get; set; }
        public bool ToDestroy { get; private set; }

        private Airplane _airplane;

        public IComponent Stage { get; private set; }

        public NarrowingSmall(IComponent stage, Texture2D texture, Vector2 position)
        {
            Stage = stage;

            Position = position;
            Texture = texture;
            BoundingBox = new Rectangle((int)(Position.X * Globals.scaleX), (int)(Position.Y * Globals.scaleY),
                (int)(Texture.Width * Globals.scaleX), (int)(0.4f * Texture.Height * Globals.scaleY));

            _airplane = (Airplane)Stage.EntityList.Find(x => x is Airplane);
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

            BoundingBox = new Rectangle((int)(Position.X * Globals.scaleX), (int)(Position.Y * Globals.scaleY),
                (int)(Texture.Width * Globals.scaleX), (int)(0.4f * Texture.Height * Globals.scaleY));

            if (_airplane.BoundingBox.Intersects(BoundingBox))
            {
                _airplane.CollisionFlag = true;
            }
        }
    }
}