using Microsoft.Xna.Framework;
using States;
using Gui;
using Microsoft.Xna.Framework.Input;
using System;

public class TestState : State
{
    Button btn;
    public TestState()
    {
        
    }

    public override void LoadContent()
    {
        btn = new Button(new Vector2(50,50),new Vector2(100,50),new Color(255,0,0),new Color(0,255,0),new Color(0,0,255));
    }

    public override void Update(GameTime gameTime)
    {
        InputManager.Update();
        if(InputManager.IsKeyPressed(Keys.Escape)) quit = true;
        btn.Update();
        if(btn.Clicked()) Console.WriteLine(btn.Clicked().ToString());
    }

    public override void Draw()
    {
        btn.Draw();     
    }
}