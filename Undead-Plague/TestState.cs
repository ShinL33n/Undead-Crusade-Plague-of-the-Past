using Microsoft.Xna.Framework;
using States;
using Gui;
using Microsoft.Xna.Framework.Input;
using System;
using Undead_Plague;


// Just for tests having fun
public class TestState : State
{
    Button btn;
    Button btn2;
    public TestState()
    {
    }

    public override void LoadContent()
    {
        btn = new Button(new Vector2(50,50),new Vector2(100,50),new Color(255,0,0),new Color(0,255,0),new Color(0,0,255));
        btn2 = new Button(new Vector2(200,50),new Vector2(100,50),new Color(128,0,0),new Color(0,255,0),new Color(0,0,255));
    }

    protected override void UnloadContent()
    {
        
        /* 
        // IDK IF ITS SAFE IT MIGHT DISPOSE EVERY CONTENT CAUSE
        // Globals.content is static but it kinda should be global read docs and forums
        // unloadContent is for clearing memory and content pipeline ( mgcb editor ) for now we dont use it so..
        if (Globals.content != null)
        {
            Globals.content.Unload();
            Globals.content.Dispose();
            Globals.content = null;
        }*/ 
    }

    public override void Update(GameTime gameTime)
    {
        InputManager.Update();
        if(InputManager.IsKeyPressed(Keys.Escape)) quit = true;

        btn.Update();
        btn2.Update();
        
        if(btn.Clicked()) Console.WriteLine(btn.Clicked().ToString());

        if(btn2.Clicked())
        {
            Globals.Graphics.PreferredBackBufferWidth = 1080;
            Globals.Graphics.PreferredBackBufferHeight = 1920;
            Globals.Graphics.ApplyChanges();
        }
    }

    public override void Draw()
    {
        btn.Draw();     
        btn2.Draw();
    }
}