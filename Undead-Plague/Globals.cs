using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace ProjectGui;
public static class Globals
{
    public static GraphicsDevice GraphicsDevice {get;set;}
    public static GraphicsDeviceManager Graphics {get;set;}
    public static ContentManager Content { get; set; }
    public static SpriteBatch SpriteBatch { get; set; }

}