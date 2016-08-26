using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sandbox_Game_Client.Content._Fonts;
using Sandbox_Game_Client.Resources._Entity;
using Sandbox_Game_Client.Resources._World;

namespace Sandbox_Game_Client.Resources._Menu
{
    public static class MenuPause
    {
        public static void Update()
        {
            if (World.Player.Active) { return; }
        }
        public static void Draw(SpriteBatch spriteBatch)
        {
            if (World.Player.Active) { return; }

            spriteBatch.Begin();
            spriteBatch.Draw(Sandbox_Game_Client.Resources.Textures.PAUSE, new Vector2(0, 0), Color.White);
            spriteBatch.End();



            World.Player.MouseController.Draw(spriteBatch);
        }
    }
}
