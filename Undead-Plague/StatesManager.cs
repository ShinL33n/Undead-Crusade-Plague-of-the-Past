using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace States;
public class StatesManager
{
    private readonly Stack<State> statesStack;

    // Returns current number of states
    public int Count {get {return statesStack.Count;}}
    public bool IsEmpty {get {return Count <= 0;}}
    public StatesManager()
    {
        statesStack = new Stack<State>();
    }

    public void addState(State state)
    {
        statesStack.Push(state);
    }

    public void removeState()
    {
        statesStack.Pop();
    }

    public State getCurrentState()
    {
        return statesStack.Peek();
    }

    public void Update(GameTime gameTime)
    {
        if(Count != 0)
        {
            getCurrentState().Update(gameTime);     
            
            if(getCurrentState().quit)
            {
                //dispose of state data inside End maybe add destructor later
                getCurrentState().End();
                removeState();
            }
        }
    }

    public void Draw()
    {
        if(Count != 0)
        {
            getCurrentState().Draw();
        }
    }
}