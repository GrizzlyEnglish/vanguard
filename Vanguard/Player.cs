using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace Vanguard
{
    class Player
    {
        public Vector2 Position { get; set; }

        public Vector2 Velocity { get; set; }

        public Texture2D Texture { get; set; }

        public Animation Animation { get; set; }

        private readonly Game _game;

        public Player(Game game, Vector2 startingPos)
        {
            _game = game;
            Position = startingPos;
            Velocity = new Vector2(3, 3);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Animation.Draw(spriteBatch, Position);
        }

        public void Load(string contentName)
        {
            Texture = _game.Content.Load<Texture2D>("smiley-walk");
            Animation = new Animation(Texture, 4, 4);
        }
        
        public void Update(GameTime gameTime)
        { 
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && IsInBoundsRight())
            {
                var newX = Position.X + Velocity.X;
                var newY = Position.Y;
                Position = new Vector2(newX, newY);
            }   

            if (Keyboard.GetState().IsKeyDown(Keys.Left) && IsInBoundsLeft())
            {
                var newX = Position.X - Velocity.X;
                var newY = Position.Y;
                Position = new Vector2(newX, newY);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Up) && IsInBoundsUp())
            {
                var newX = Position.X;
                var newY = Position.Y - Velocity.Y;
                Position = new Vector2(newX, newY);
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Down) && IsInBoundsDown())
            {
                var newX = Position.X;
                var newY = Position.Y + Velocity.Y;
                Position = new Vector2(newX, newY);
            }

            if(Keyboard.GetState().GetPressedKeys().Any())
                Animation.Update();
        }

        private bool IsInBoundsLeft() => Position.X >= 0;

        private bool IsInBoundsRight() => 
            Position.X <= _game.GraphicsDevice.PresentationParameters.Bounds.Width - Animation.FrameWidth;

        private bool IsInBoundsUp() => Position.Y >= 0;

        private bool IsInBoundsDown() => 
            Position.Y <= _game.GraphicsDevice.PresentationParameters.Bounds.Height - Animation.FrameHeight;
    }
}
