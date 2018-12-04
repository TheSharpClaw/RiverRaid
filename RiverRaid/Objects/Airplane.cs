using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using RiverRaid.ObjectTypes;

using System.Collections.Generic;

namespace RiverRaid.Objects
{
    class Airplane : IEntity
    {
        private int _velocityFlag;
        private bool _moveButtonTouchedFlag;
        private int _resetVelocityFlag;
        private int _buttonReloadFlag;
        private bool _onLoadFlag;

        private List<IEntity> _listOfIEButtons;
        private List<Button> _listOfButtons = new List<Button>();
        private List<Bullet> _listOfBullets = new List<Bullet>();
        private List<Bullet> _listOfBulletsToDestroy = new List<Bullet>();

        public Vector2 Position { get; set; } = new Vector2(73, 173);
        public Texture2D Texture { get; set; } = Globals.airplane;
        public Rectangle BoundingBox { get; set; }
        public float Velocity { get; set; }

        public IComponent Stage { get; private set; }

        public Airplane(IComponent stage)
        {
            Stage = stage;
            
            BoundingBox = new Rectangle((int)(Position.X * Globals.scaleX), (int)(Position.Y * Globals.scaleY), 
                (int)(Texture.Width * Globals.scaleX), (int)(Texture.Height * Globals.scaleY));
            Velocity = 0.5f;
            _velocityFlag = 0;
            _resetVelocityFlag = 0;
            _moveButtonTouchedFlag = false;
            _onLoadFlag = true;
        }

        public void OnLoad()
        {
            _onLoadFlag = false;

            _listOfIEButtons = Stage.DrawList.FindAll(x => x is Button);

            foreach (Button button in _listOfIEButtons)
            {
                _listOfButtons.Add(button);
            }
        }

        public void Draw()
        {
            if(_listOfBullets.Count > 0)
            {
                foreach (Bullet bullet in _listOfBullets)
                {
                    bullet.Draw();
                }
            }

            Globals.spriteBatch.Draw(Texture, Position, Color.White);
        }

        public void Update()
        {
            if (_onLoadFlag)
            {
                OnLoad();
            }

            _moveButtonTouchedFlag = false;

            if (_listOfBullets.Count > 0)
            {
                foreach (Bullet bullet in _listOfBullets)
                {
                    bullet.Update();
                    if (bullet.ToDestroy)
                    {
                        _listOfBulletsToDestroy.Add(bullet);
                    }
                }
                
                foreach(Bullet bullet in _listOfBulletsToDestroy)
                {
                    _listOfBullets.Remove(bullet);
                }
                _listOfBulletsToDestroy.Clear();
            }

            if (_listOfButtons.Count > 0)
            {
                if (_listOfButtons[0].IsTouched)
                {
                    Texture = Globals.airplaneLeft;

                    if (Velocity < 2 && _velocityFlag >= 1)
                    {
                        Velocity = Velocity + 0.1f;
                        _velocityFlag = 0;
                    }
                    _resetVelocityFlag = 0;

                    _moveButtonTouchedFlag = true;

                    Position = new Vector2(Position.X - Velocity, Position.Y);
                    if (Position.X < 0)
                    {
                        Position = new Vector2(0, Position.Y);
                    }
                    BoundingBox = new Rectangle((int)(Position.X * Globals.scaleX), (int)(Position.Y * Globals.scaleY),
                        (int)(Texture.Width * Globals.scaleX), (int)(Texture.Height * Globals.scaleY));
                }
                if (_listOfButtons[1].IsTouched)
                {
                    Texture = Globals.airplaneRight;

                    if (Velocity < 2 && _velocityFlag >= 5)
                    {
                        Velocity = Velocity + 0.1f;
                        _velocityFlag = 0;
                    }
                    _resetVelocityFlag = 0;

                    _moveButtonTouchedFlag = true;

                    Position = new Vector2(Position.X + Velocity, Position.Y);
                    if (Position.X > 146)
                    {
                        Position = new Vector2(146, Position.Y);
                    }
                    BoundingBox = new Rectangle((int)(Position.X * Globals.scaleX), (int)(Position.Y * Globals.scaleY),
                        (int)(Texture.Width * Globals.scaleX), (int)(Texture.Height * Globals.scaleY));
                }
                if (_listOfButtons[2].IsTouched)
                {
                    if(_listOfBullets.Count == 0)
                        _listOfBullets.Add(new Bullet(Stage));
                    _buttonReloadFlag = 0;
                }

                if (!_listOfButtons[0].IsTouched && !_listOfButtons[1].IsTouched)
                {
                    Texture = Globals.airplane;
                }
            }
            _velocityFlag++;
            _resetVelocityFlag++;
            _buttonReloadFlag++;

            if (_moveButtonTouchedFlag == false && _resetVelocityFlag >= 6)
            {
                Velocity = 0.5f;
                _velocityFlag = 0;
            }
        }
    }
}