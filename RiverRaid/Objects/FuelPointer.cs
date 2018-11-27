using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using RiverRaid.ObjectTypes;

using System.Collections.Generic;

namespace RiverRaid.Objects
{
    class FuelPointer : IEntity
    {
        public Vector2 Position { get; set; } = new Vector2(122, 202);
        public Texture2D Texture { get; set; } = Globals.fuelPointer;
        public Rectangle BoundingBox { get; set; }

        private Airplane _airplane;
        private List<IEntity> _listOfFuels;
        private int _positionFlag;
        private int _refuelFlag;

        public IComponent Stage { get; private set; }

        public FuelPointer(IComponent stage)
        {
            _airplane = (Airplane)stage.DrawList.Find(x => x is Airplane);
            _listOfFuels = stage.DrawList.FindAll(x => x is Fuel);
            _positionFlag = 0;
            _refuelFlag = 0;

            Stage = stage;
        }

        public void Draw()
        {
            Globals.spriteBatch.Draw(Texture, Position, Color.White);
        }

        public void Update()
        {
            _positionFlag++;
            _refuelFlag++;

            foreach (Fuel fuel in _listOfFuels)
            {
                if (_airplane.BoundingBox.Intersects(fuel.BoundingBox) && _refuelFlag >= 5)
                {
                    _refuelFlag = 0;

                    if (Position.X < 122)
                    {
                        Position = new Vector2(Position.X + 1, Position.Y);
                        _positionFlag = 0;
                    }
                    else
                    {
                        Position = new Vector2(122, Position.Y);
                        _positionFlag = 0;
                    }
                }
            }
            
            if (_positionFlag >= 60)
            {
                Position = new Vector2(Position.X - Globals.fuelPointerSpeed, Position.Y);
                _positionFlag = 0;
            }

            if (Position.X < 60)
            {
                //TODO: GAMEOVER
                Position = new Vector2(60, Position.Y);
            }

            
        }
    }
}
