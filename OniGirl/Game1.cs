using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace OniGirl;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Imp _imp;

    private Texture2D _backgroundFrontLayer;

    private Texture2D _backgroundMiddleLayer;

    private Texture2D _backgroundBackLayer;

    private Texture2D _backgroundLayer;

    private Texture2D _rectTexture;

     private Texture2D _attackTexture;

    private int _screenWidth;
    private int _screenHeight;

    private Rectangle _playerBounds;

    private Rectangle _attackBounds;

    private Projectile _fireball;

    
    private TextureAtlas playerAtlas;
    private TextureAtlas gameAtlas;

    private Player _oniGirl;
    //Player regions
    
    private TextureRegion _playerportrait;

    private TileMap _tileMap;

    private TileSet _tileSet;

    private Vector2 _startPosition;


    private CollisionController _collisionController;

    

    

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
        _screenHeight = _graphics.PreferredBackBufferHeight;
        _screenWidth = _graphics.PreferredBackBufferWidth;
        _backgroundFrontLayer = Content.Load<Texture2D>("Images/Background/front layer");
        _backgroundMiddleLayer = Content.Load<Texture2D>("Images/Background/middle layer");
        _backgroundBackLayer = Content.Load<Texture2D>("Images/Background/back layer");
        _backgroundLayer = Content.Load<Texture2D>("Images/Background/Background layer");




        playerAtlas = TextureAtlas.ReadFromFile(Content, "Content/playeratlas.xml");
        gameAtlas = TextureAtlas.ReadFromFile(Content,"Content/gameAtlas.xml");
        _tileMap = TileMap.ReadFromFile(Content,"Content/tilemap.xml");
        _tileMap.scale = new Vector2(3.0f,3.0f);


        

        _oniGirl = new Player(playerAtlas,100,new Vector2(500,750));

        _fireball = new Projectile(gameAtlas,new Vector2(1500,720));

      

        
        _collisionController = new CollisionController();

        _playerportrait = playerAtlas.GetTextureRegion("portrait");

        

        _imp = new Imp(gameAtlas, new Vector2(1500,700),10);

        //for debuging collision
        _rectTexture = new Texture2D(GraphicsDevice, 1, 1);
        _rectTexture.SetData(new Color[] { Color.Green });

        _attackTexture = new Texture2D(GraphicsDevice, 1, 1);
        _attackTexture.SetData(new Color[] { Color.Red });

        

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

       
        Rectangle screenBounds = new Rectangle(
            0,
            0,
            GraphicsDevice.PresentationParameters.BackBufferWidth,
            GraphicsDevice.PresentationParameters.BackBufferHeight
        );

         _playerBounds = new Rectangle(
            (int)(_oniGirl.position.X - (_oniGirl.width / 2f)),
            (int)(_oniGirl.position.Y - (_oniGirl.height / 2f)),
            (int)_oniGirl.width,
            (int)_oniGirl.height
        );

         _attackBounds = new Rectangle(
            (int)(_oniGirl.position.X - (_oniGirl.width / 2f) + 125),
            (int)(_oniGirl.position.Y - (_oniGirl.height / 2f)),
            (int)_oniGirl.width,
            (int)_oniGirl.height
        );




        _oniGirl.HandleInput();

        if(_collisionController.ScreenBounds(screenBounds,_playerBounds))
        {
            _oniGirl.velocity.X *= -1;
            if(_playerBounds.Left < screenBounds.Left)
            {
                _oniGirl.position.X = screenBounds.Left + (_oniGirl.width / 2f);
            }
            else
            {
                _oniGirl.position.X = screenBounds.Right - (_oniGirl.width / 2f);
            }

            _playerBounds = new Rectangle(
            (int)(_oniGirl.position.X - (_oniGirl.width / 2f)),
            (int)(_oniGirl.position.Y - (_oniGirl.height / 2f)),
            (int)_oniGirl.width,
            (int)_oniGirl.height
            );
            
        }

        if(_collisionController.DetectCollision(_playerBounds,_fireball))
        {
            _fireball = null;
            _oniGirl.SwitchState(_oniGirl.hitState);
        }

            

        _oniGirl.Update(gameTime);
        _oniGirl.position.X += _oniGirl.velocity.X;
        _oniGirl.position.Y += _oniGirl.velocity.Y;

       

       


        

        _imp.Update(gameTime);

        if(_fireball != null)
        {
            _fireball.Update(gameTime);
        }


       
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        _spriteBatch.Draw(_backgroundLayer,      new Rectangle(0,0,_screenWidth,_screenHeight),Color.White);
        _spriteBatch.Draw(_backgroundBackLayer,  new Rectangle(0,0,_screenWidth,_screenHeight),Color.White);
        _spriteBatch.Draw(_backgroundMiddleLayer,new Rectangle(0,0,_screenWidth,_screenHeight),Color.White);
        _spriteBatch.Draw(_backgroundFrontLayer, new Rectangle(0,0,_screenWidth,_screenHeight),Color.White);



        _spriteBatch.Draw
            (
                _attackTexture,
                _attackBounds,
                Color.White
            );
        
        _tileMap.Draw(_spriteBatch);

        
         _spriteBatch.Draw
        (
            _rectTexture,
            _playerBounds,
            Color.White
        );
        
        _oniGirl.Draw(_spriteBatch);

        

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

    

        _imp.Draw(_spriteBatch);

        if(_fireball != null)
        {
            _fireball.Draw(_spriteBatch);                
        }

        

       

        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
