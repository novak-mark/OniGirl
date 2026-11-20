using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

public class PlayerJump : PlayerState
{
   
    private AnimatedSprite _jumpAnimation;
    public override AnimatedSprite playerAnimation => _jumpAnimation;

   private float gravity =0.5f;


    public float Rotation, Scale, Depth;

    public Vector2 Origin;


    public PlayerJump(Player player) : base(player)
    {
      

        _jumpAnimation  = player.playerAtlas.CreateAnimatedSprite("playerjump",false);

        _jumpAnimation.Scale = new Vector2(2.0f,2.0f);

             
    }
    public override void Enter()
    {
        Console.WriteLine("jump State");
        
        player.isGrounded = false;
        player.velocity.Y = player.jumpStrength;

       
        
    }

    public override void Update(GameTime gameTime)
    {
        

       
        
        _jumpAnimation.PlayOnce(gameTime);

        if(player.position.Y <= player.groundY)
        {
            player.velocity.Y += gravity;

           
        }
        else
        {
            player.SwitchState(player.idleState);
           
        }


       

        
    }

    public override void HandleInput(KeyboardState current, KeyboardState previous, MouseState mouse)
    {
     
        
    }

    public override void Draw(SpriteBatch batch,SpriteEffects effects)
    {
        if(player.direction == 1)
        {
            _jumpAnimation.Effects = SpriteEffects.FlipHorizontally;
        }
        else
        {
            _jumpAnimation.Effects = SpriteEffects.None;
        }
        _jumpAnimation.Draw(batch,player.position);

    }

    public override void Exit()
    {
        Console.WriteLine("exiting crouchState");
        

    }
}