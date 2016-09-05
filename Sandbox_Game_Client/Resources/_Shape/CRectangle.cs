using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sandbox_Game_Client.Resources._Shape
{
    public class CRectangle
    {
        private BasicEffect BasicEffect { get; set; }

        public Vector2 PointA { get; set; }
        public Vector2 PointB { get; set; }
        public Vector2 PointC { get; set; }
        public Vector2 PointD { get; set; }

        public Color Color { get; set; }

        public float GetWidth()
        {
            Vector2 Left, Right;
            Left = PointA;
            if (PointB.X < Left.X) { Left = PointB; }
            if (PointC.X < Left.X) { Left = PointC; }
            if (PointD.X < Left.X) { Left = PointD; }

            Right = PointA;
            if (PointB.X > Right.X) { Right = PointB; }
            if (PointC.X > Right.X) { Right = PointC; }
            if (PointD.X > Right.X) { Right = PointD; }

            return (Math.Abs(Left.X - Right.X));
        }

        public float GetHeight()
        {
            Vector2 Top, Bottom;
            Top = PointA;
            if (PointB.Y < Top.Y) { Top = PointB; }
            if (PointC.Y < Top.Y) { Top = PointC; }
            if (PointD.Y < Top.Y) { Top = PointD; }

            Bottom = PointA;
            if (PointB.Y > Bottom.Y) { Bottom = PointB; }
            if (PointC.Y > Bottom.Y) { Bottom = PointC; }
            if (PointD.Y > Bottom.Y) { Bottom = PointD; }

            return (Math.Abs(Top.Y - Bottom.Y));
        }

        public CRectangle(Vector2 Location, int Width, int Height, Color Color)
        {
            PointA = Location;
            PointB = new Vector2(PointA.X + Width, PointA.Y);
            PointC = new Vector2(PointA.X, PointA.Y + Height);
            PointD = new Vector2(PointA.X + Width, PointA.Y + Height);
            this.Color = Color;
            
            BasicEffect = new BasicEffect(Game1.Instance.GraphicsDevice) { VertexColorEnabled = true };
        }
        public void Move(Vector2 Velocity)
        {
            PointA = new Vector2(PointA.X + Velocity.X, PointA.Y + Velocity.Y);
            PointB = new Vector2(PointB.X + Velocity.X, PointB.Y + Velocity.Y);
            PointC = new Vector2(PointC.X + Velocity.X, PointC.Y + Velocity.Y);
            PointD = new Vector2(PointD.X + Velocity.X, PointD.Y + Velocity.Y);
        }
        public void Draw(SpriteBatch sb)
        {
            DrawSquare(Game1.Instance.GraphicsDevice);

            sb.Begin();
            SpriteBatchEx.DrawLine(sb, PointA, PointB, Color.Black, 1);
            SpriteBatchEx.DrawLine(sb, PointB, PointD, Color.Black, 1);
            SpriteBatchEx.DrawLine(sb, PointD, PointC, Color.Black, 1);
            SpriteBatchEx.DrawLine(sb, PointC, PointA, Color.Black, 1);
            sb.End();

            //Vector2[] Points = new Vector2[4] { PointA, PointB, PointD, PointC };
            //SpriteBatchEx.DrawPolyLine(sb, Points, Color, 3, true);
        }
        private void DrawSquare(GraphicsDevice GraphicsDevice)
        {
            float x, y;
            x = (PointA.X - (GetWidth() / 2)) / GetWidth() - 1;
            y = (PointA.Y - (GetHeight() / 2)) / GetHeight() - 1;

            var colors = new[]
            {
                new VertexPositionColor(new Vector3((PointA.X - (GetWidth() / 2)) / GetWidth() - 1, (PointA.Y - (GetHeight() / 2)) / GetHeight() - 1, 0.0f), Color.White),
                new VertexPositionColor(new Vector3((PointB.X - (GetWidth() / 2)) / GetWidth() - 1, (PointB.Y - (GetHeight() / 2)) / GetHeight() - 1, 0.0f), Color.White),
                new VertexPositionColor(new Vector3((PointD.X - (GetWidth() / 2)) / GetWidth() - 1, (PointD.Y - (GetHeight() / 2)) / GetHeight() - 1, 0.0f), Color.White),

                new VertexPositionColor(new Vector3((PointA.X - (GetWidth() / 2)) / GetWidth() - 1, (PointA.Y - (GetHeight() / 2)) / GetHeight() - 1, 0.0f), Color.White),
                new VertexPositionColor(new Vector3((PointD.X - (GetWidth() / 2)) / GetWidth() - 1, (PointD.Y - (GetHeight() / 2)) / GetHeight() - 1, 0.0f), Color.White),
                new VertexPositionColor(new Vector3((PointC.X - (GetWidth() / 2)) / GetWidth() - 1, (PointC.Y - (GetHeight() / 2)) / GetHeight() - 1, 0.0f), Color.White)

                //new VertexPositionColor(new Vector3(-0.5f, -0.5f, 0.0f), Color.White),
                //new VertexPositionColor(new Vector3(+0.5f, -0.5f, 0.0f), Color.White),
                //new VertexPositionColor(new Vector3(+0.5f, +0.5f, 0.0f), Color.White),
                //new VertexPositionColor(new Vector3(-0.5f, -0.5f, 0.0f), Color.White),
                //new VertexPositionColor(new Vector3(+0.5f, +0.5f, 0.0f), Color.White),
                //new VertexPositionColor(new Vector3(-0.5f, +0.5f, 0.0f), Color.White)
            };
            Console.WriteLine(x + y);
            BasicEffect.World = // NOTE: the correct order for matrices is SRT (scale, rotate, translate)
                Matrix.CreateTranslation(0.5f, 0.5f, 0.0f) * // offset by half pixel to get pixel perfect rendering
                Matrix.CreateScale(GetWidth(), GetHeight(), 1.0f) * // set size
                Matrix.CreateTranslation(PointA.X, PointA.Y, 0.0f) * // set position
                Matrix.CreateOrthographicOffCenter // 2d projection
                    (
                        0.0f,
                        GraphicsDevice.Viewport.Width, // NOTE : here not an X-coordinate (i.e. width - 1)
                        GraphicsDevice.Viewport.Height,
                        0.0f,
                        0.0f,
                        1.0f
                    );

            // tint it however you like
            BasicEffect.DiffuseColor = Color.ToVector3();

            var passes = BasicEffect.CurrentTechnique.Passes;
            foreach (var pass in passes)
            {
                pass.Apply();
                GraphicsDevice.DrawUserPrimitives(PrimitiveType.TriangleList, colors, 0, colors.Length / 3);
            }
        }
        
    }
}
