using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using RiverRaid.ObjectTypes;

namespace RiverRaid.Objects
{
    class FuelBar : IEntity
    {
        public Vector2 Position { get; set; } = new Vector2(54, 202);
        public Texture2D Texture { get; set; } = Globals.fuelBar;
        public Rectangle BoundingBox { get; set; }

        public IComponent Stage { get; private set; }

        public FuelBar(IComponent stage)
        {
            Stage = stage;
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
