using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Undead_Plague;
public static class Globals
{
    public static GraphicsDevice GraphicsDevice {get;set;}
    public static GraphicsDeviceManager Graphics {get;set;}
    
    // PRAWDOPODOBNIE w przyszłości nie będzie globalne żeby odizolowac potok contentu w róznych miejsach
    public static ContentManager Content { get; set; } 
    public static SpriteBatch SpriteBatch { get; set; }

}