using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

using RiverRaid.ObjectTypes;

namespace RiverRaid.Objects
{
    class Button : IEntity
    {
        private TouchCollection _touchCollection;
        
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public Rectangle BoundingBox { get; set; }
        public string Name { get; private set; }
        public bool IsTouched { get; private set; } = false;

        public IComponent Stage { get; private set; }

        public Button(IComponent stage, Vector2 position, Texture2D texture, string name)
        {
            Stage = stage;
            Position = position;
            Texture = texture;
            Name = name;
            BoundingBox = new Rectangle((int)(Position.X * Globals.scaleX), (int)(Position.Y * Globals.scaleY), 
                (int)(Texture.Width * Globals.scaleX), (int)(Texture.Height * Globals.scaleY));
        }

        public void Draw()
        {
            Globals.spriteBatch.Draw(Texture, Position, Color.White);
        }

        public void Update()
        {
            _touchCollection = TouchPanel.GetState();

            if (_touchCollection.Count > 0)
            {
                foreach(TouchLocation touchLocation in _touchCollection)
                {
                    if (BoundingBox.Intersects(new Rectangle((int)touchLocation.Position.X, (int)touchLocation.Position.Y, 1, 1)))
                        IsTouched = true;
                    else
                    {
                        IsTouched = false;
                    }
                }
            }
            else
            {
                IsTouched = false;
            }
        }
    }
}
