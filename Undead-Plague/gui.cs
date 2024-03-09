using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ProjectGui;

namespace Gui
{
    public static class Gui
    {
        public static float _scalingFactor
        {
            get {return 1;}
        }
    }

    public enum button_states {IDLE = 0, HOVER, ACTIVE};
    public class Button
    {
        private int buttonState;
        private Texture2D btnTexture;
        private Color mask_color;
        public Color idle_color, hover_color, active_color;
        public Vector2 position;
        public Vector2 resolution;
        
        private Rectangle rect
        {
            get
            {
                return new Rectangle((int)position.X,(int)position.Y,(int)resolution.X,(int)resolution.Y);
            }
        }

        public Button(Vector2 position, Vector2 resolution,
        Color idle_color,Color hover_color,Color active_color)
        {
            buttonState = (int)button_states.IDLE;
            this.position = position;
            this.resolution = resolution;

            this.idle_color = idle_color;
            this.hover_color =hover_color;
            this.active_color = active_color;

            btnTexture = new Texture2D(Globals.GraphicsDevice,(int)resolution.X,(int)resolution.Y);
            Color[] data = new Color[(int)resolution.X*(int)resolution.Y];
            for(int i=0; i < data.Length; ++i) data[i] = Color.White;
            btnTexture.SetData(data);
        }

        public bool Clicked()
        {
            return buttonState == (int)button_states.ACTIVE;
        }

        public void Update()
        {
            buttonState = (int)button_states.IDLE;

            if (InputManager.MouseCursor.Intersects(rect))
            {
                buttonState = (int)button_states.HOVER;
                if(InputManager.MouseClicked)
                {
                    buttonState = (int)button_states.ACTIVE;
                }
            }

            // POTRZEBNY REFACTORING NIENAWIDZE SPOSOBU USTAWIANIA TEKSTUR TUTAJ :DD
            switch(buttonState)
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
            Globals.SpriteBatch.Begin();
            Globals.SpriteBatch.Draw(btnTexture,rect,mask_color);
            Globals.SpriteBatch.End();
        }
    }
}

   
