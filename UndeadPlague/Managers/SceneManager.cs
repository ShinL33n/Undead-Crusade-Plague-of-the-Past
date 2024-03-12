using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System;

namespace UndeadPlague.Managers;
public class SceneManager
{
    private readonly Stack<Scene> ScenesStack;

    // Returns current number of Scenes
    public int Count {get {return ScenesStack.Count;}}
    public bool IsEmpty {get {return Count <= 0;}}
    public SceneManager()
    {
        ScenesStack = new Stack<Scene>();
    }

    public void addScene(Scene Scene)
    {
        if (IsEmpty)
            ScenesStack.Push(Scene);
        else if (ScenesStack.Peek().ToString() == Scene.ToString()) return;


        ScenesStack.Push(Scene);
        Console.Write(ScenesStack.Peek().ToString());

    }

    public void removeScene()
    {
        ScenesStack.Pop();
    }

    public Scene getCurrentScene()
    {
        return ScenesStack.Peek();
    }

    public void Update(GameTime gameTime)
    {
        if(!IsEmpty)
        {
            getCurrentScene().Update(gameTime);     
            
            if(getCurrentScene().quit)
            {
                //dispose of Scene data inside End maybe add destructor later
                getCurrentScene().End();
                removeScene();
            }
        }
    }

    public void Draw()
    {
        if(!IsEmpty)
        {
            getCurrentScene().Draw();
        }
    }
}