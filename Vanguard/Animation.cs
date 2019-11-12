using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Vanguard
{
    class Animation
    {
        public Texture2D Texture { get; set; }
        
        public int Rows { get; set; }

        public int Columns { get; set; }

        public int FrameWidth
        {
            get { return Texture.Width / Columns; }
        }

        public int FrameHeight
        {
            get { return Texture.Height / Rows; }
        }

        private int currentFrame;

        private int totalFrames;

        public Animation(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
        }

        public void Update()
        {
            currentFrame++;
            if (currentFrame == totalFrames)
                currentFrame = 0;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            var sourceRect = new Rectangle(width * column, height * row, width, height);
            var destRect = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Draw(Texture, destRect, sourceRect, Color.White);
        }
    }
}
