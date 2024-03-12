using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System;

// Just for tests having fun
public class MenuScene : Scene
{
    Button menuSceneButton, settingsSceneButton, gameSceneButton;
    Texture2D menuSceneTexture, settingsSceneTexture, gameSceneTexture;
    SpriteFont font;
    public MenuScene(){}

    public override void LoadContent()
    {
        font = Content.Load<SpriteFont>("Fonts/testFont");
        menuSceneTexture = Content.Load<Texture2D>("Textures/Gui/menu_example_texture");
        settingsSceneTexture = Content.Load<Texture2D>("Textures/Gui/settings_example_texture");
        gameSceneTexture = Content.Load<Texture2D>("Textures/Gui/game_example_texture");

        menuSceneButton = new Button(new Vector2(0, 100), new Vector2(300, 100), menuSceneTexture, font, "", Color.White, Color.White, Color.Gray, Color.DarkGray);
        settingsSceneButton = new Button(new Vector2(0, 300), new Vector2(300, 100), settingsSceneTexture, font, "", Color.White, Color.White, Color.Gray, Color.DarkGray);
        gameSceneButton = new Button(new Vector2(0, 500), new Vector2(300, 100), gameSceneTexture, font, "", Color.White, Color.White, Color.Gray, Color.DarkGray);
    }

    public override void Update(GameTime gameTime)
    {
        InputManager.Update();
        if(InputManager.WasKeyTriggered(Keys.Escape)) quit = true;

        menuSceneButton.Update();
        settingsSceneButton.Update();
        gameSceneButton.Update();

        if (menuSceneButton.Clicked())
        {
            Console.WriteLine(menuSceneButton.Clicked().ToString());
            Game1.SceneManager.addScene(new MenuScene());
        }
        if (gameSceneButton.Clicked())
        {
            Console.WriteLine(gameSceneButton.Clicked().ToString());
            Game1.SceneManager.addScene(new GameScene());
        }
        if (settingsSceneButton.Clicked())
        {
            Console.WriteLine(settingsSceneButton.Clicked().ToString());
            Game1.SceneManager.addScene(new SettingsScene());
        }
    }

    public override void Draw()
    {
        menuSceneButton.Draw();
        settingsSceneButton.Draw();
        gameSceneButton.Draw();
    }
}