using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

// Just for tests having fun
public class GameScene : Scene
{
    public GameScene()
    {
    }

    public override void LoadContent()
    {

    }

    public override void Update(GameTime gameTime)
    {
        InputManager.Update();
        if (InputManager.WasKeyTriggered(Keys.Escape)) quit = true;
    }

    public override void Draw()
    {
        
    }
}