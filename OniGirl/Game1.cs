using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OniGirl;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;


    private TextureAtlas playerAtlas;
    private TextureAtlas gameAtlas;

    private TextureRegion _playerIdle;
    private TextureRegion _playerportrait;

    private TextureRegion _impIdle;

    

    

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _graphics.PreferredBackBufferWidth = 1920;
        _graphics.PreferredBackBufferHeight = 1080;
        _graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        playerAtlas = TextureAtlas.ReadFromFile(Content, "Content/playeratlas.xml");
        gameAtlas = TextureAtlas.ReadFromFile(Content,"Content/gameAtlas.xml");


        _playerIdle = playerAtlas.GetTextureRegion("playeridle");
        _playerportrait = playerAtlas.GetTextureRegion("portrait");

        _impIdle = gameAtlas.GetTextureRegion("impidle");

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin();
        _playerIdle.Draw
        (
            _spriteBatch,
            new Vector2(500,500),
            Color.White,
            0.0f,
            Vector2.Zero,
            new Vector2(2,2),
            SpriteEffects.FlipHorizontally,
            0.0f    
        );
        _playerportrait.Draw
        (
            _spriteBatch,
            new Vector2(0,0),
            Color.White,
            0.0f,
            Vector2.Zero,
            new Vector2(0.5f,0.5f),
            SpriteEffects.FlipHorizontally,
            0.0f    
        );

        _impIdle.Draw
        (
            _spriteBatch,
            new Vector2(600,500),
            Color.White,
            0.0f,
            Vector2.Zero,
            Vector2.One,
            SpriteEffects.None,
            0.0f    
        );

        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
