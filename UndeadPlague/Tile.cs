using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UndeadPlague.Global;

// Prowizorka totalna
class Tile
{
    Vector2 size;
    Texture2D texture;
    Vector2 position;

    private Rectangle rect
    {
        get
        {
            return new Rectangle((int)position.X, (int)position.Y, (int)size.X, (int)size.Y);
        }
     }

    public Tile(Vector2 position, Vector2 size, Texture2D texture)
    {
        this.size = size;
        this.position = position;
        this.texture = texture;
    }
 
    public void Draw() 
    {
        GlobalData.SpriteBatch.Draw(texture,rect,Color.White);
    }
}