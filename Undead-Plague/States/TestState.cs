using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

using States;
using Gui;
using Undead_Plague;
using Microsoft.Xna.Framework.Graphics;


// Just for tests having fun
public class TestState : State
{
    Button btn;
    Button btn2;
    Button btn3;
    SpriteFont font;

    Texture2D texture;

    public TestState(){}

    public override void LoadContent()
    {
        font = Content.Load<SpriteFont>("Fonts/testFont");
        texture = Content.Load<Texture2D>("test");

        btn = new Button(new Vector2(50,50),new Vector2(100,50), texture, font, "Click ", new Color(255,255,255) ,new Color(255,0,0),new Color(0,255,0),new Color(0,0,255));
        btn2 = new Button(new Vector2(200,50),new Vector2(100,50), font, "Click ", new Color(255,255,255), new Color(128,0,0),new Color(0,255,0),new Color(0,0,255));
        btn3 = new Button(new Vector2(100,150),new Vector2(100,50), font, "Click ", new Color(255,255,255), new Color(196,32,196),new Color(150,32,150),new Color(0,0,255));
    }

    public override void Update(GameTime gameTime)
    {
        InputManager.Update();
        if(InputManager.WasKeyTriggered(Keys.Escape)) quit = true;

        btn.Update();
        btn2.Update();
        btn3.Update();
        
        if(btn.Clicked()) Console.WriteLine(btn.Clicked().ToString());

        if(btn2.Clicked())
        {
            Globals.Graphics.PreferredBackBufferHeight = 1600;
            Globals.Graphics.PreferredBackBufferWidth = 1080;
            Globals.Graphics.ApplyChanges();
        }

        if(btn3.Clicked())
        {
            Game1.statesManager.addState(new PlaygroundTestState());
        }
    }

    public override void Draw()
    {
        btn.Draw();     
        btn2.Draw();
        btn3.Draw();
    }
}