using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using Undead_Plague;

// Base Class for Variety of States in App: MainMenu,Options,Game,Camera,Editor,Playground,Pause menu etc..
// Simple for handling and seperating diffrent parts of application
// Maybe in future we will need StateData class
namespace States;
public abstract class State
{
    public bool quit {get; protected set;}
    protected ContentManager Content;
    public State() 
    { 
        quit = false; 
        // If we can use our own ServiceProvider then we could COMPLETELY eliminate Globals.Content !
        // We should try that
        Content = new ContentManager(Globals.Content.ServiceProvider,"Content");

        LoadContent();
        Console.WriteLine("Starting State" + Game1.states.Count.ToString());
    }

    public virtual void LoadContent(){}
    protected virtual void UnloadContent()
    {
        if (Content != null)
        {
            Content.Unload(); // Through Manager DZIALA ! XD
            Content.Dispose(); // Outside Manager
            Content = null;
            Console.WriteLine("Clearing State content" + (Game1.states.Count-1).ToString());
        }
    }

    public virtual void Update(GameTime gameTime){}
    public virtual void Draw(){}

    public virtual void End()
    {
        this.UnloadContent();

        Console.WriteLine("Ending State" + (Game1.states.Count-1).ToString());
    }
}