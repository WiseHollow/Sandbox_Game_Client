using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sandbox_Game_Client.Content._Fonts;
using Sandbox_Game_Client.Resources._Entity;
using Sandbox_Game_Client.Resources._World;

namespace Sandbox_Game_Client.Resources._Menu
{
    public class MenuPause
    {
        private MenuButton Button_Continue;
        private MenuButton Button_Quit;

        public MenuPause()
        {
            float x = Properties.Settings.Default.Resolution.X * 0.5f - Textures.BUTTON_CONTINUE.Width * 0.5f;
            float y = Properties.Settings.Default.Resolution.Y * 0.5f + 50;

            Button_Continue = new MenuButtonContinue(Textures.BUTTON_CONTINUE, new Vector2(x, y));
            Button_Quit = new MenuButtonQuit(Textures.BUTTON_QUIT, new Vector2(x, y + Textures.BUTTON_CONTINUE.Height + 15));
        }

        public void Update()
        {
            if (World.Player.Active) { return; }

            Button_Continue.Update();
            Button_Quit.Update();
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (World.Player.Active) { return; }

            spriteBatch.Begin();
            spriteBatch.Draw(Sandbox_Game_Client.Resources.Textures.PAUSE, new Vector2(0, 0), Color.White);
            spriteBatch.End();

            Button_Continue.Draw(spriteBatch);
            Button_Quit.Draw(spriteBatch);

            World.Player.MouseController.Draw(spriteBatch);
        }
    }
}
