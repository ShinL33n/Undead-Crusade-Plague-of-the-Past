using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using UndeadPlague.Global;
using UndeadPlague.Managers;

namespace UndeadPlague.Core;

public class Game1 : Game
{
    public static SceneManager SceneManager;

    public Game1()
    {
        GlobalData.Graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        SceneManager = new SceneManager();
    }

    protected override void Initialize()
    {
        GlobalData.Graphics.PreferredBackBufferWidth = 1600;
        GlobalData.Graphics.PreferredBackBufferHeight = 900;
        GlobalData.Graphics.ApplyChanges(); 

        // TODO: Add your initialization logic here
        base.Initialize();
    }

    protected override void LoadContent()
    {
        // TODO: use this.Content to load your game content here
        GlobalData.GraphicsDevice = GraphicsDevice;

        GlobalData.SpriteBatch = new SpriteBatch(GlobalData.GraphicsDevice);

        GlobalData.Content = Content;

        // Entry Point
        SceneManager.addScene(new MenuScene());
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
            GlobalData.Graphics.GraphicsDevice.Clear(Color.Black);

            GlobalData.SpriteBatch.Begin();

            SceneManager.Draw();

            GlobalData.SpriteBatch.End();
        }

        base.Draw(gameTime);
    }
}
