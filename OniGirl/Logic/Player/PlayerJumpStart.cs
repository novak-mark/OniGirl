using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

public class PlayerJumpStart : PlayerState
{
   
    private AnimatedSprite _startJumpAnimation;
    public override AnimatedSprite playerAnimation => _startJumpAnimation;

   private float gravity = 0.5f;


    public float Rotation, Scale, Depth;

    public Vector2 Origin;


    public PlayerJumpStart(Player player) : base(player)
    {
      

        _startJumpAnimation  = player.playerAtlas.CreateAnimatedSprite("playerjumpstart");

        _startJumpAnimation.Scale = new Vector2(2.0f,2.0f);

         _startJumpAnimation.Origin = new Vector2(
            _startJumpAnimation.sourceRegion.textureWidth  / 2f,
            _startJumpAnimation.sourceRegion.textureHeight / 2f
        );

             
    }
    public override void Enter()
    {
        Console.WriteLine("start jump State");
        
        player.isOnGround = false;
        
        player.velocity.Y = -player.JUMP;

       
        
    }

    public override void Update(GameTime gameTime)
    {
        
     
        if(_startJumpAnimation.PlayOnce(gameTime))
        {
            player.SwitchState(player.fallJumpState);
        }
        
    }

    public override void HandleInput(KeyboardState current, KeyboardState previous, MouseState mouse)
    {
     
        
    }

    public override void Draw(SpriteBatch batch,SpriteEffects effects)
    {
        if(player.direction == 1)
        {
            _startJumpAnimation.Effects = SpriteEffects.FlipHorizontally;
        }
        else
        {
            _startJumpAnimation.Effects = SpriteEffects.None;
        }
        _startJumpAnimation.Draw(batch,player.position);

    }

    public override void Exit()
    {
        Console.WriteLine("exiting start jumpState");
        

    }
}