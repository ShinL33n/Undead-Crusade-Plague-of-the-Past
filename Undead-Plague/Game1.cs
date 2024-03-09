using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using States;

namespace Undead_Plague;

// Only 1 class should inherit from Game
public class Game1 : Game
{
    private Stack<State> states;

    public Game1()
    {
        Globals.Graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    private void InitStates()
    {
        states = new Stack<State>();
        states.Push(new TestState());
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        InitStates();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        Globals.GraphicsDevice = GraphicsDevice;
        Globals.SpriteBatch = new SpriteBatch(Globals.GraphicsDevice);

        // TODO: use this.Content to load your game content here
        if(states.Count != 0)
        {  
            states.Peek().LoadContent();
        }
    }

    protected override void Update(GameTime gameTime)
    {
        // TODO: Add your update logic here
        if(states.Count != 0)
        {
            states.Peek().Update(gameTime);     
            
            if(states.Peek().quit)
            {
                //dispose of state data inside End i guess
                states.Peek().End();
                states.Pop();
            }
        }
        else 
        {
            Exit();
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        // TODO: Add your drawing code here
        if(base.IsActive)
        {
            //GraphicsDevice.Clear(Color.Black);
            if(states.Count != 0)
            {
                states.Peek().Draw();
            }
        }
        base.Draw(gameTime);
    }
}
