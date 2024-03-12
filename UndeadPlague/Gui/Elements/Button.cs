using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UndeadPlague.Global;

namespace UndeadPlague.Gui.Elements
{
    public class Button
    {
        private enum button_states { IDLE = 0, HOVER, ACTIVE };

        private int _buttonState;
        public Vector2 position;
        public Vector2 size;
        private Texture2D texture;
        public Color idle_color, hover_color, active_color;
        private Color mask_color;
        private SpriteFont font;
        private string text;
        private Vector2 textPos;
        public Color text_color;

        private Rectangle rect
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
            }
        }

        // No Texture pass
        public Button(Vector2 position, Vector2 size,
        SpriteFont font, string text, Color text_color,
        Color idle_color, Color hover_color, Color active_color)
        {
            // Button coord
            _buttonState = (int)button_states.IDLE;
            this.position = position;
            this.size = size;

            this.font = font;
            this.text = text;

            textPos = position + (size - font.MeasureString(text)) / 2;

            this.text_color = text_color;
            this.idle_color = idle_color;
            this.hover_color = hover_color;
            this.active_color = active_color;

            // Maybe there's better way to do this
            texture = new Texture2D(GlobalData.GraphicsDevice, (int)size.X, (int)size.Y);
            Color[] data = new Color[(int)size.X * (int)size.Y];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.White;
            texture.SetData(data);
        }

        // Texture pass
        public Button(Vector2 position, Vector2 size, Texture2D texture,
        SpriteFont font, string text, Color text_color,
        Color idle_color, Color hover_color, Color active_color)
        {
            // Button coord
            _buttonState = (int)button_states.IDLE;
            this.position = position;
            this.size = size;

            // Texts
            this.font = font;
            this.text = text;

            textPos = position + (size - font.MeasureString(text)) / 2;

            // Colors & Textures
            this.text_color = text_color;
            this.idle_color = idle_color;
            this.hover_color = hover_color;
            this.active_color = active_color;

            this.texture = texture;
        }



        public bool Clicked()
        {
            return _buttonState == (int)button_states.ACTIVE;
        }

        public void Update()
        {
            _buttonState = (int)button_states.IDLE;

            if (InputManager.MouseCursor.Intersects(rect))
            {
                _buttonState = (int)button_states.HOVER;
                if (InputManager.MouseClicked)
                {
                    _buttonState = (int)button_states.ACTIVE;
                }
            }

            // Maybe there's more versatile way than Mask_color
            switch (_buttonState)
            {
                case (int)button_states.IDLE:
                    mask_color = idle_color;
                    break;
                case (int)button_states.HOVER:
                    mask_color = hover_color;
                    break;
                case (int)button_states.ACTIVE:
                    mask_color = active_color;
                    break;
                default:
                    //ERROR
                    mask_color = Color.Black;
                    break;
            }

        }

        public void Draw()
        {
            GlobalData.SpriteBatch.Draw(texture, rect, mask_color);
            GlobalData.SpriteBatch.DrawString(font, text, textPos, text_color);
        }
    }
}


