using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using RiverRaid.ObjectTypes;

namespace RiverRaid.ObjectTypes
{
    class Bullet : IEntity
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; } = Globals.bullet;
        public Rectangle BoundingBox { get; set; }
        
        private Airplane _airplane;

        public bool ToDestroy { get; set; } = false;

        public IComponent Stage { get; private set; }

        public Bullet(IComponent stage)
        {
            Stage = stage;

            _airplane = (Airplane)stage.EntityList.Find(x => x is Airplane);

            Position = new Vector2(_airplane.Position.X + 6, _airplane.Position.Y);
            BoundingBox = new Rectangle((int)(Position.X * Globals.scaleX), (int)(Position.Y * Globals.scaleY),
                (int)(Texture.Width * Globals.scaleX), (int)(Texture.Height * Globals.scaleY));
        }

        public void Draw()
        {
            Globals.spriteBatch.Draw(Texture, Position, Color.White);
        }

        public void Update()
        {
            Position = new Vector2(_airplane.Position.X + 6, Position.Y - 5);
            BoundingBox = new Rectangle((int)(Position.X * Globals.scaleX), (int)(Position.Y * Globals.scaleY),
                (int)(Texture.Width * Globals.scaleX), (int)(Texture.Height * Globals.scaleY));

            if(Position.Y < 0 - Texture.Height)
            {
                ToDestroy = true;
            }
        }
    }
}