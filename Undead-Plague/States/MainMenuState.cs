using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System;

using States;
using Gui;
using Undead_Plague;

// Just for tests having fun
public class MainMenuState : State
{
    Button btn_edytor;
    SpriteFont font;
    public MainMenuState(){}

    public override void LoadContent()
    {
        font = Content.Load<SpriteFont>("Fonts/testFont");

        btn_edytor = new Button(new Vector2(100,150),new Vector2(300,50), font,"Edytor", new Color(255,255,255), new Color(255,0,255),new Color(255,255,0),new Color(0,255,255));
    }

    public override void Update(GameTime gameTime)
    {
        InputManager.Update();
        if(InputManager.WasKeyTriggered(Keys.Escape)) quit = true;

        btn_edytor.Update();
        
        if(btn_edytor.Clicked())
        {
            Console.WriteLine(btn_edytor.Clicked().ToString());
            Game1.statesManager.addState(new TestState());
        } 
    }

    public override void Draw()
    {
        btn_edytor.Draw();     
    }
}