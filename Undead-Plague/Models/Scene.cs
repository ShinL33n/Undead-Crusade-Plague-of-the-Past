using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using Undead_Plague;

// Base Class for Variety of Scenes in App: MainMenu,Options,Game,Camera,Editor,Playground,Pause menu etc..
// Simple for handling and seperating diffrent parts of application
// Maybe in future we will need SceneData class
namespace Scenes;
public abstract class Scene
{
    public bool quit {get; protected set;}
    protected ContentManager Content;
    
    public Scene() 
    { 
        quit = false; 
        // If we can use our own ServiceProvider then we could COMPLETELY eliminate Globals.Content !
        // We should try that
        Content = new ContentManager(Globals.Content.ServiceProvider,"Content");

        LoadContent();
        Console.WriteLine("Starting Scene" + Game1.SceneManager.Count.ToString());
    }

    public virtual void LoadContent(){}
    protected virtual void UnloadContent()
    {
        // need more testing
        if (Content != null)
        {
            Content.Unload(); 
            Content.Dispose(); 
            Content = null;
            Console.WriteLine("Clearing Scene content" + (Game1.SceneManager.Count-1).ToString());
        }
    }

    public virtual void Update(GameTime gameTime){}
    public virtual void Draw(){}

    public virtual void End()
    {
        UnloadContent();

        Console.WriteLine("Ending Scene" + (Game1.SceneManager.Count-1).ToString());
    }
}