using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

// Just for tests having fun
public class GameScene : Scene
{
    TileMap GameMap;
    public GameScene()
    {
    }

    public override void LoadContent()
    {
        GameMap = new TileMap(Content);
    }

    public override void Update(GameTime gameTime)
    {
        InputManager.Update();
        if (InputManager.WasKeyTriggered(Keys.Escape)) quit = true;

    }

    public override void Draw()
    {
        GameMap.Draw();
    }
}