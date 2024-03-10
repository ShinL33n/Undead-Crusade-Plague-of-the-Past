using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Undead_Plague;

// Base Class for Variety of States in App: MainMenu,Options,Game,Camera,Editor,Playground,Pause menu etc..
// Simple for handling and seperating diffrent parts of application
// Maybe in future we will need StateData class
namespace States;
public abstract class State
{
    public bool quit {get; protected set;}
    public State() 
    { 
        quit = false; 
        LoadContent();
        Console.WriteLine("Starting State" + Game1.states.Count.ToString());

    }

    public virtual void LoadContent(){}
    protected virtual void UnloadContent()
    {

        /* 
        // IDK IF ITS SAFE IT MIGHT DISPOSE EVERY CONTENT CAUSE
        // Globals.Content is static but it kinda should be global read docs and forums
        // unloadContent is for clearing memory and content pipeline ( mgcb editor ) for now we dont use it so..
        // But we create textures that we need dispose of
        */

        /*if (Globals.Content != null)
        {
            //Globals.Content.Unload(); // Through Manger
            //Globals.Content.Dispose(); // Outside Manager
            Globals.Content = null;
            Console.WriteLine("Clearing State content" + (Game1.states.Count-1).ToString());
        }*/
    }

    public virtual void Update(GameTime gameTime){}
    public virtual void Draw(){}

    public virtual void End()
    {
        this.UnloadContent();

        Console.WriteLine("Ending State" + (Game1.states.Count-1).ToString());
    }
}