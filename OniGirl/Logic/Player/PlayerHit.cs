using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

public class PlayerHit : PlayerState
{
   
    private AnimatedSprite _hitAnimation;
    public override AnimatedSprite playerAnimation => _hitAnimation;

   


    public float Rotation, Scale, Depth;

    public Vector2 Origin;


    public PlayerHit(Player player) : base(player)
    {
      

        _hitAnimation  = player.playerAtlas.CreateAnimatedSprite("playerhit");

          _hitAnimation.Origin = new Vector2(
            _hitAnimation.sourceRegion.textureWidth  / 2f,
            _hitAnimation.sourceRegion.textureHeight / 2f
        );

        _hitAnimation.Scale = new Vector2(2.0f,2.0f);

             
    }
    public override void Enter()
    {
        Console.WriteLine("Playerhit State");
        
    }

    public override void Update(GameTime gameTime)
    {
        player.velocity = Vector2.Zero;
        
        if(_hitAnimation.PlayOnce(gameTime))
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
            _hitAnimation.Effects = SpriteEffects.FlipHorizontally;
        }
        else
        {
            _hitAnimation.Effects = SpriteEffects.None;
        }
        _hitAnimation.Draw(batch,player.position);

    }

    public override void Exit()
    {
        Console.WriteLine("PlayerHit exit");
        

    }
}