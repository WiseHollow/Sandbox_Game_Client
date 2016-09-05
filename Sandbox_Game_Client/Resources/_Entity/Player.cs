using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sandbox_Game_Client.Resources._Control;
using Sandbox_Game_Client.Resources._Inventory;
using Sandbox_Game_Client.Resources._Menu;
using Sandbox_Game_Client.Resources._World;

namespace Sandbox_Game_Client.Resources._Entity
{
    public class Player : LivingEntity
    {
        public bool Active { get; set; }
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
        public MouseController MouseController { get; set; }
        public MenuPause MenuPause { get; set; }

        KeyboardState OldKeyboardState;
        KeyboardState CurrentKeyboardState = Keyboard.GetState();

        public Player(World World, Texture2D[] Textures, Vector2 Location, int Health, int MovementSpeed, string Name) : base(World, Textures, Location, Health, MovementSpeed)
        {
            this.Name = Name;
            this.World = World;

            this.Initialize();
        }
        public Player(World World, Texture2D Texture, Vector2 Location, int Health, int MovementSpeed, string Name) : base(World, new Texture2D[1] { Texture }, Location, Health, MovementSpeed)
        {
            this.Name = Name;
            this.World = World;

            this.Initialize();
        }
        private void Initialize()
        {
            this.Active = true;

            this.Inventory = new Inventory();
            this.MouseController = new MouseController();

            this.MenuPause = new MenuPause();
        }
        public override void Update()
        {
            OldKeyboardState = CurrentKeyboardState;
            CurrentKeyboardState = Keyboard.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed || (CurrentKeyboardState.IsKeyDown(Keys.Escape) && !OldKeyboardState.IsKeyDown(Keys.Escape)))
            {
                Active = !Active;
                return;
            }

            if (Alive && Active)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    if (OnGround) { Velocity.Y -= 14; }
                }
                if (GamePad.GetState(PlayerIndex.One).Buttons.RightStick == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    Velocity.X = MovementSpeed;
                }
                else if (GamePad.GetState(PlayerIndex.One).Buttons.LeftStick == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    Velocity.X = -MovementSpeed;
                }

                //
                // Apply physics
                //

                
            }
            
            if (!Active)
            {
                MenuPause.Update();
            }

            MouseController.Update();
            base.Update();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            if (Active)
                MouseController.Draw(spriteBatch);
            
            if (!Active)
            {
                MenuPause.Draw(spriteBatch);
            }

            base.Draw(spriteBatch);
        }
    }
}
