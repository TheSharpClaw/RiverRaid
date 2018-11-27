using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using RiverRaid.ObjectTypes;
using RiverRaid.Objects;
using RiverRaid.Objects.Tiles;

using System;
using System.Collections.Generic;

namespace RiverRaid.States
{
    class GameState : IStateTemplate, IComponent
    {
        private bool _isLoaded = false;
        private int _levelRowIndex = 99;
        private bool _gameFreezeFlag = true;

        public List<IEntity> DrawList { get; set; } = new List<IEntity>();
        public List<IEntity> UpdateList { get; set; } = new List<IEntity>();

        private List<ITile> _listOfTiles = new List<ITile>();
        private List<ITile> _listOfTilesToDestroy = new List<ITile>();
        private List<IEntity> _listOfIEButtons = new List<IEntity>();
        private List<Button> _listOfButtons = new List<Button>();

        //LOAD OBJECTS AND OTHER STUFF IMPORTANT FOR THE GAMESTATE
        public void OnLoad()
        {
            LoadFirstRows();

            DrawList.Add(new Airplane(this));

            DrawList.Add(new Gui(this));
            DrawList.Add(new Button(this, new Vector2(2, 198), Globals.buttonLeft, "buttonLeft"));
            DrawList.Add(new Button(this, new Vector2(28, 198), Globals.buttonRight, "buttonRight"));
            DrawList.Add(new Button(this, new Vector2(134, 198), Globals.buttonShoot, "buttonShoot"));

            _listOfIEButtons = DrawList.FindAll(x => x is Button);

            foreach (Button button in _listOfIEButtons)
            {
                _listOfButtons.Add(button);
            }

            DrawList.Add(new FuelPointer(this));
            DrawList.Add(new FuelBar(this));
            
            //HACK: Do rozróżnienia?
            UpdateList = DrawList;
        }

        public void LoadFirstRows()
        {
            int x = 0;
            int y = 184;

            for (int i = 0; i < 24; i++)
            {
                string[] currentRowDivided = Globals.levelStartRows[_levelRowIndex].Split((char)44);

                for (int j = 0; j < 20; j++)
                {
                    int currentTile = Int32.Parse(currentRowDivided[j]);

                    switch (currentTile)
                    {
                        case 0:
                            _listOfTiles.Add(new EnlargmentSmall(this, Globals.enlargementRightSmall, new Vector2(x, y)));
                            break;
                        case 1:
                            _listOfTiles.Add(new EnlargmentBig(this, Globals.enlargementRightBig, new Vector2(x, y)));
                            break;
                        case 2:
                            _listOfTiles.Add(new GroundCollidable(this, Globals.roadUp, new Vector2(x, y)));
                            break;
                        case 3:
                            _listOfTiles.Add(new GroundUncollidable(this, Globals.ground, new Vector2(x, y)));
                            break;
                        case 4:
                            _listOfTiles.Add(new NarrowingSmall(this, Globals.narrowingRightSmall, new Vector2(x, y)));
                            break;
                        case 5:
                            _listOfTiles.Add(new NarrowingBig(this, Globals.narrowingRightBig, new Vector2(x, y)));
                            break;
                        case 6:
                            _listOfTiles.Add(new GroundCollidable(this, Globals.roadMiddle, new Vector2(x, y)));
                            break;
                        case 7:
                            _listOfTiles.Add(new GroundUncollidable(this, Globals.water, new Vector2(x, y)));
                            break;
                        case 8:
                            _listOfTiles.Add(new EnlargmentBig(this, Globals.enlargementLeftBig, new Vector2(x, y)));
                            break;
                        case 9:
                            _listOfTiles.Add(new EnlargmentSmall(this, Globals.enlargementLeftSmall, new Vector2(x, y)));
                            break;
                        case 10:
                            _listOfTiles.Add(new GroundCollidable(this, Globals.roadDown, new Vector2(x, y)));
                            break;
                        case 12:
                            _listOfTiles.Add(new NarrowingBig(this, Globals.narrowingLeftBig, new Vector2(x, y)));
                            break;
                        case 13:
                            _listOfTiles.Add(new NarrowingBig(this, Globals.narrowingLeftSmall, new Vector2(x, y)));
                            break;
                        case 15:
                            _listOfTiles.Add(new GroundCollidable(this, Globals.ground, new Vector2(x, y)));
                            break;
                    }
                    x = x + 8;
                }
                x = 0;
                y = y - 8;

                _levelRowIndex--;
            }

            foreach (ITile tile in _listOfTiles)
            {
                DrawList.Add(tile);
            }
        }


        private void LoadNewTileLine()
        {
            int x = 0;
            int y = -8;

            string[] currentRowDivided = Globals.levelStartRows[_levelRowIndex].Split((char)44);

            for (int i = 0; i < 20; i++)
            {
                int currentTile = Int32.Parse(currentRowDivided[i]);

                switch (currentTile)
                {
                    case 0:
                        _listOfTiles.Add(new EnlargmentSmall(this, Globals.enlargementRightSmall, new Vector2(x, y)));
                        break;
                    case 1:
                        _listOfTiles.Add(new EnlargmentBig(this, Globals.enlargementRightBig, new Vector2(x, y)));
                        break;
                    case 2:
                        _listOfTiles.Add(new GroundCollidable(this, Globals.roadUp, new Vector2(x, y)));
                        break;
                    case 3:
                        _listOfTiles.Add(new GroundUncollidable(this, Globals.ground, new Vector2(x, y)));
                        break;
                    case 4:
                        _listOfTiles.Add(new NarrowingSmall(this, Globals.narrowingRightSmall, new Vector2(x, y)));
                        break;
                    case 5:
                        _listOfTiles.Add(new NarrowingBig(this, Globals.narrowingRightBig, new Vector2(x, y)));
                        break;
                    case 6:
                        _listOfTiles.Add(new GroundCollidable(this, Globals.roadMiddle, new Vector2(x, y)));
                        break;
                    case 7:
                        _listOfTiles.Add(new GroundUncollidable(this, Globals.water, new Vector2(x, y)));
                        break;
                    case 8:
                        _listOfTiles.Add(new EnlargmentBig(this, Globals.enlargementLeftBig, new Vector2(x, y)));
                        break;
                    case 9:
                        _listOfTiles.Add(new EnlargmentSmall(this, Globals.enlargementLeftSmall, new Vector2(x, y)));
                        break;
                    case 10:
                        _listOfTiles.Add(new GroundCollidable(this, Globals.roadDown, new Vector2(x, y)));
                        break;
                    case 12:
                        _listOfTiles.Add(new NarrowingBig(this, Globals.narrowingLeftBig, new Vector2(x, y)));
                        break;
                    case 13:
                        _listOfTiles.Add(new NarrowingBig(this, Globals.narrowingLeftSmall, new Vector2(x, y)));
                        break;
                    case 15:
                        _listOfTiles.Add(new GroundCollidable(this, Globals.ground, new Vector2(x, y)));
                        break;
                }
                x = x + 8;
            }
            _levelRowIndex--;

            foreach (ITile tile in _listOfTiles)
            {
                DrawList.Add(tile);
            }
        }

        //OBLICZENIA
        public void Update()
        {
            if (!_isLoaded)
            {
                OnLoad();
                _isLoaded = true;
            }

            if (_gameFreezeFlag)
            {
                foreach (Button button in _listOfButtons)
                {
                    if (button.IsTouched)
                    {
                        Globals.tileVelocity = 0.2f;
                        Globals.fuelPointerSpeed = 1;
                        _gameFreezeFlag = false;
                    }
                }
            }

            foreach(ITile tile in _listOfTiles)
            {
                if (tile.ToDestroy)
                {
                    _listOfTilesToDestroy.Add(tile);
                }
            }

            foreach (ITile tile in _listOfTilesToDestroy)
            {
                if (tile.ToDestroy)
                {
                    _listOfTiles.Remove(tile);
                    DrawList.Remove(tile);
                }
            }

            if (_listOfTilesToDestroy.Count > 0)
            {
                //LoadNewTileLine();
                _listOfTilesToDestroy.Clear();
            }

            foreach (IEntity entity in UpdateList)
            {
                entity.Update();
            }

            Draw();
        }

        //RYSOWANIE NA EKRANIE
        public void Draw()
        {
            Globals.spriteBatch.Begin(SpriteSortMode.Immediate, null, SamplerState.PointClamp, null, null, null, Globals.Scale);
            
            foreach (IEntity entity in DrawList)
            {
                entity.Draw();            
            }
            
            Globals.spriteBatch.End();
        }
    }
}

