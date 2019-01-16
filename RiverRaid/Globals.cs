using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System.Collections.Generic;

namespace RiverRaid
{
    public static class Globals
    {
        #region GameStateEnum
        public enum enGameStates
        {
            SPLASH,
            MENU,
            GAME,
            GAMEOVER,
            WIN,
            EXIT,
        }
        #endregion

        #region Cores
        public static SpriteBatch spriteBatch = null;
        public static GraphicsDeviceManager graphics = null;
        public static Vector2 gameWindowSize;
        public static Vector2 screenResolution;

        public static enGameStates activeState = enGameStates.GAME;
        
        public static float scaleX;
        public static float scaleY;
        public static Matrix Scale;

        public static bool exit = false;
        
        public static float fuelPointerSpeed = 0;
        public static float tileVelocity = 0;
        #endregion

        #region Fonts
        public static SpriteFont defaultFont;
        #endregion

        #region Level
        public static string levelStartPath;
        public static string level1Path;
        public static string level2Path;
        public static string level3Path;

        public static List<string> levelStartRows = new List<string>();
        public static List<string> level1Rows = new List<string>();
        public static List<string> level2Rows = new List<string>();
        public static List<string> level3Rows = new List<string>();
        #endregion

        #region Songs
        //public static Song battleBackgroundMusic;
        #endregion

        #region SoundEffects
        //public static SoundEffect wilhelmScreamSE;
        #endregion

        #region Textures2D
        public static Texture2D airplane;
        public static Texture2D airplaneLeft;
        public static Texture2D airplaneRight;
        public static Texture2D background;
        public static Texture2D buttonLeft;
        public static Texture2D buttonRight;
        public static Texture2D buttonShoot;
        public static Texture2D bullet;
        public static Texture2D enemyHelicopter;
        public static Texture2D enemyPlane;
        public static Texture2D enemyShip;
        public static Texture2D fuel;
        public static Texture2D fuelBar;
        public static Texture2D fuelPointer;
        public static Texture2D gui;

        #region Tiles
        public static Texture2D enlargementLeftBig;
        public static Texture2D enlargementLeftSmall;
        public static Texture2D enlargementRightBig;
        public static Texture2D enlargementRightSmall;
        public static Texture2D ground;
        public static Texture2D narrowingLeftBig;
        public static Texture2D narrowingLeftSmall;
        public static Texture2D narrowingRightBig;
        public static Texture2D narrowingRightSmall;
        public static Texture2D roadDown;
        public static Texture2D roadMiddle;
        public static Texture2D roadUp;
        public static Texture2D water;
        #endregion
        #endregion

    }
}