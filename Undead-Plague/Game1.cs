using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using States;

namespace Undead_Plague;

public class Game1 : Game
{
    public static StatesManager statesManager;

    public Game1()
    {
        Globals.Graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        statesManager = new StatesManager();
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
        statesManager.addState(new MainMenuState());
    }

    protected override void Update(GameTime gameTime)
    {
        // TODO: Add your update logic here
        statesManager.Update(gameTime);

        if(statesManager.IsEmpty) Exit();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        // TODO: Add your drawing code here
        if(IsActive)
        {
            Globals.Graphics.GraphicsDevice.Clear(Color.Black);

            statesManager.Draw();
        }

        base.Draw(gameTime);
    }
}
