using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System;

using Scenes;
using Gui;
using Undead_Plague;


// Just for tests having fun
public class PlaygroundTestScene : Scene
{
    Button btn;
    SpriteFont font;
    public PlaygroundTestScene(){}

    public override void LoadContent()
    {
        font = Content.Load<SpriteFont>("Fonts/testFont");

        btn = new Button(new Vector2(100,150),new Vector2(100,50), font,"flaku debil", new Color(255,255,255), new Color(255,0,255),new Color(255,255,0),new Color(0,255,255));
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