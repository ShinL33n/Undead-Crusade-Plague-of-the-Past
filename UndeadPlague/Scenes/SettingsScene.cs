using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


public class SettingsScene : Scene
{
    public SettingsScene()
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