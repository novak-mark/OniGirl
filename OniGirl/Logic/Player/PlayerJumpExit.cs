using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

public class PlayerJumpExit : PlayerState
{
   
    private AnimatedSprite _exitJumpAnimation;
    public override AnimatedSprite playerAnimation => _exitJumpAnimation;

   private float gravity = 0.5f;


    public float Rotation, Scale, Depth;

    public Vector2 Origin;


    public PlayerJumpExit(Player player) : base(player)
    {
      

        _exitJumpAnimation  = player.playerAtlas.CreateAnimatedSprite("playerjumpexit");

        _exitJumpAnimation.Scale = new Vector2(2.0f,2.0f);

        _exitJumpAnimation.Origin = new Vector2(
            _exitJumpAnimation.sourceRegion.textureWidth  / 2f,
            _exitJumpAnimation.sourceRegion.textureHeight / 2f
        );

             
    }
    public override void Enter()
    {
        Console.WriteLine("exit jump State");
        
        player.isOnGround = true;
        

    }

    public override void Update(GameTime gameTime)
    {
        player.velocity.Y = 0;


        if(_exitJumpAnimation.PlayOnce(gameTime))
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
            _exitJumpAnimation.Effects = SpriteEffects.FlipHorizontally;
        }
        else
        {
            _exitJumpAnimation.Effects = SpriteEffects.None;
        }
        _exitJumpAnimation.Draw(batch,player.position);

    }

    public override void Exit()
    {
        Console.WriteLine("exiting exit jumpState");
        

    }
}