using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

// PROWIZORYCZNA KLASA, RACZEJ TAK NIE BEDZIE WYGLADAC ALE OD CZEGOS TRZEBA ZACZAC
class TileMap
{

    private Point mapSize;
    private Tile[,] map;
    public Vector2  Size {get;private set;}
    public Vector2  tileSize {get;private set;}

    public TileMap(ContentManager content)
    {
        tileSize = new(240,240);
        mapSize = new(3,3);
        Size = new(tileSize.X*mapSize.X,tileSize.Y*mapSize.Y);
        map = new Tile[mapSize.X,mapSize.Y];

        for(int x = 0; x < mapSize.X; x++)
        {
            for(int y = 0; y <  mapSize.Y; y++)
            {
                map[x,y] = new Tile(new Vector2(x * tileSize.X,y * tileSize.Y),tileSize,content.Load<Texture2D>("Textures/tile"));
            }
        }
    }

    private void LoadMapFromFile(string path)
    {

    }

    public void Draw()
    {
        // do optymalizacji np. Od lewego gornego rogu do dolnego prawego rogu ( chodzi o okno )
        // Chcialbym zeby bylo to 3 wymiarowe x,y,layers
        for(int x = 0; x < mapSize.X; x++)
        {
            for(int y = 0; y <  mapSize.Y; y++)
            {
                map[x,y].Draw();
            }
        }
    }
}