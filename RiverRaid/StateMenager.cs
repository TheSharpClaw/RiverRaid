using RiverRaid.States;

namespace RiverRaid
{
    class StateManager
    {
        SplashState splashState = new SplashState();
        MenuState menuState = new MenuState();
        GameState gameState = new GameState();
        GameOverState gameOverState = new GameOverState();
        WinState winState = new WinState();

        public void Update()
        {
            switch (Globals.activeState)
            {
                case Globals.enGameStates.SPLASH:
                    splashState.Update();
                    break;
                case Globals.enGameStates.MENU:
                    menuState.Update();
                    break;
                case Globals.enGameStates.GAME:
                    gameState.Update();
                    break;
                case Globals.enGameStates.GAMEOVER:
                    gameOverState.Update();
                    break;
                case Globals.enGameStates.WIN:
                    winState.Update();
                    break;
                case Globals.enGameStates.EXIT:
                    Globals.exit = true;
                    break;
            }
        }
    }
}