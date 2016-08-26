using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sandbox_Game_Client.Resources._World;

namespace Sandbox_Game_Client.Resources._Menu
{
    public class MenuButtonContinue : MenuButton
    {
        public MenuButtonContinue(Texture2D Texture, Vector2 Location) : base (Texture, Location)
        {

        }

        public override void Press()
        {
            World.Player.Active = true;
        }
    }
}
