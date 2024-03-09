using Microsoft.Xna.Framework;


// Base Class for Variety of States in App: MainMenu,Options,Game,Camera,Editor,Playground,Pause menu etc..
// Simple for handling and seperating diffrent parts of application
// Maybe in future we will need StateData class
namespace States;
public abstract class State
{
    public bool quit {get; protected set;}
    public State() { quit = false; }

    public virtual void LoadContent(){}
    public virtual void Update(GameTime gameTime){}
    public virtual void Draw(){}

    public virtual void End(){}
}