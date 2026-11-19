using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

public class PlayerExitRun : PlayerState
{
   
   

    private AnimatedSprite _runStop;

    public override AnimatedSprite playerAnimation => _runStop;

    public float Rotation, Scale, Depth;

    public Vector2 Origin;


    public PlayerExitRun(Player player) : base(player)
    {
        Rotation = 0;

        Scale = 2;

        Depth = 0;

        Origin = Vector2.Zero;

    
        _runStop = player.playerAtlas.CreateAnimatedSprite("playerrunexit");
        _runStop.Scale = new Vector2(2.0f,2.0f);


     
    }
    public override void Enter()
    {
        Console.WriteLine("Run StopState");
        
       
    }

    public override void Update(GameTime gameTime)
    {
        player.velocity.X = 0;

        if(_runStop.PlayOnce(gameTime))
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
            _runStop.Effects = SpriteEffects.FlipHorizontally;
        }
        else
        {
            _runStop.Effects = SpriteEffects.None;
        }
        _runStop.Draw(batch,player.position);

    }

    public override void Exit()
    {
        Console.WriteLine("exiting runState");
        
    }
}