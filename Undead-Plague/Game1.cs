using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Scenes;

namespace Undead_Plague;

public class Game1 : Game
{
    public static SceneManager SceneManager;

    public Game1()
    {
        Globals.Graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        SceneManager = new SceneManager();
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        base.Initialize();
    }

    protected override void LoadContent()
    {
        // TODO: use this.Content to load your game content here
        Globals.GraphicsDevice = GraphicsDevice;

        Globals.SpriteBatch = new SpriteBatch(Globals.GraphicsDevice);

        Globals.Content = Content;

        // Entry Point
        SceneManager.addScene(new MainMenuScene());
    }

    protected override void Update(GameTime gameTime)
    {
        // TODO: Add your update logic here
        SceneManager.Update(gameTime);

        if(SceneManager.IsEmpty) Exit();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        // TODO: Add your drawing code here
        if(IsActive)
        {
            Globals.Graphics.GraphicsDevice.Clear(Color.Black);

            SceneManager.Draw();
        }

        base.Draw(gameTime);
    }
}
