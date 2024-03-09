using Microsoft.Xna.Framework;

namespace States;
public abstract class State
{
    public bool quit {get;protected set;}
    public State() { quit = false; }

    public virtual void LoadContent(){}
    public virtual void Update(GameTime gameTime){}
    public virtual void Draw(){}

    public virtual void End(){}
}