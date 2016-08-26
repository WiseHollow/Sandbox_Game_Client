using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sandbox_Game_Client.Resources._Control;
using Sandbox_Game_Client.Resources._Inventory;
using Sandbox_Game_Client.Resources._World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox_Game_Client.Resources._Entity
{
    public class Player : LivingEntity
    {
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
        public MouseController MouseController { get; set; }
        public Player(World World, Texture2D[] Textures, Vector2 Location, int Health, string Name) : base(World, Textures, Location, Health)
        {
            this.Name = Name;
            this.World = World;

            this.Inventory = new Inventory();
            this.MouseController = new MouseController();
        }
        public Player(World World, Texture2D Texture, Vector2 Location, int Health, string Name) : base(World, new Texture2D[1] { Texture }, Location, Health)
        {
            this.Name = Name;
            this.World = World;

            this.Inventory = new Inventory();
            this.MouseController = new MouseController();
        }
        public override void Update()
        {
            if (!Alive) { return; }

            if (GamePad.GetState(PlayerIndex.One).Buttons.X == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if (OnGround) { Velocity.Y -= 14; }
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.RightStick == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                Velocity.X = 3;
            }
            else if (GamePad.GetState(PlayerIndex.One).Buttons.LeftStick == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.A))
            {
                Velocity.X = -3;
            }

            MouseController.Update();
            base.Update();
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            MouseController.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }
    }
}
