using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

public class PlayerRun : PlayerState
{
   
    private AnimatedSprite _runAnimation;

    public override AnimatedSprite playerAnimation => _runAnimation;

    public float Rotation, Scale, Depth;

    public Vector2 Origin;


    public PlayerRun(Player player) : base(player)
    {
        Rotation = 0;

        Scale = 2;

        Depth = 0;

        Origin = Vector2.Zero;

     
      
        _runAnimation = player.playerAtlas.CreateAnimatedSprite("playerrun");

    
        _runAnimation.Scale = new Vector2(2.0f,2.0f);


     
    }
    public override void Enter()
    {
        Console.WriteLine("Run State");
        
       
    }

    public override void Update(GameTime gameTime)
    {
        float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
       
        _runAnimation.Update(gameTime);
    }

    public override void HandleInput(KeyboardState current, KeyboardState previous, MouseState mouse)
    {
        if (current.IsKeyDown(Keys.T))
        {
           
           player.direction = 1;

           player.velocity.X = player.SPEED;
        }
        else
        {
            player.SwitchState(player.idleState);
        }
    }

    public override void Draw(SpriteBatch batch,SpriteEffects effects)
    {
        if(player.direction == 1)
        {
            _runAnimation.Effects = SpriteEffects.FlipHorizontally;
        }
        else
        {
            _runAnimation.Effects = SpriteEffects.None;
        }
        _runAnimation.Draw(batch,player.position);

    }

    public override void Exit()
    {
        Console.WriteLine("exiting runState");
    }
}