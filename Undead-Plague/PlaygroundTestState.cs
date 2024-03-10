using Microsoft.Xna.Framework;
using States;
using Gui;
using Microsoft.Xna.Framework.Input;
using System;
using Undead_Plague;


// Just for tests having fun
public class PlaygroundTestState : State
{
    Button btn;
    public PlaygroundTestState(){}

    public override void LoadContent()
    {
        btn = new Button(new Vector2(100,150),new Vector2(50,100),new Color(255,0,255),new Color(255,255,0),new Color(0,255,255));
    }

    public override void Update(GameTime gameTime)
    {
        InputManager.Update();
        if(InputManager.WasKeyTriggered(Keys.Escape)) quit = true;

        btn.Update();
        
        if(btn.Clicked()) Console.WriteLine(btn.Clicked().ToString());
    }

    public override void Draw()
    {
        btn.Draw();     
    }
}