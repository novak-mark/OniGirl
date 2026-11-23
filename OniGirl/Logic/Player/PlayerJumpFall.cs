using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

public class PlayerJumpFall : PlayerState
{
   
    private AnimatedSprite _jumpFallAnimation;
    public override AnimatedSprite playerAnimation => _jumpFallAnimation;

   private float gravity = 0.5f;


    public float Rotation, Scale, Depth;

    public Vector2 Origin;


    public PlayerJumpFall(Player player) : base(player)
    {
      

        _jumpFallAnimation  = player.playerAtlas.CreateAnimatedSprite("playerjumpfall");

        _jumpFallAnimation.Scale = new Vector2(2.0f,2.0f);

         _jumpFallAnimation.Origin = new Vector2(
            _jumpFallAnimation.sourceRegion.textureWidth  / 2f,
            _jumpFallAnimation.sourceRegion.textureHeight / 2f
        );
             
    }
    public override void Enter()
    {
        Console.WriteLine("jump fall State");
        
    }

    public override void Update(GameTime gameTime)
    {
                
        Console.WriteLine("player VELOCITY Y: " + player.position.Y);
        Console.WriteLine("GROUND Y: " + player.groundY);
        if(!player.isOnGround)
        {
            player.velocity.Y += gravity;

        }
        if (player.position.Y >= player.groundY)
        {
            player.SwitchState(player.exitJumpState);
        }

        _jumpFallAnimation.Update(gameTime);
    }

    public override void HandleInput(KeyboardState current, KeyboardState previous, MouseState mouse)
    {
     
        
    }

    public override void Draw(SpriteBatch batch,SpriteEffects effects)
    {
        if(player.direction == 1)
        {
            _jumpFallAnimation.Effects = SpriteEffects.FlipHorizontally;
        }
        else
        {
            _jumpFallAnimation.Effects = SpriteEffects.None;
        }
        _jumpFallAnimation.Draw(batch,player.position);

    }

    public override void Exit()
    {
        Console.WriteLine("exiting fall jumpState");
        

    }
}