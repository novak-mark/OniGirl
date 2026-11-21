using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

public class PlayerIdle : PlayerState
{
   
    private AnimatedSprite _idleAnimation;
    public override AnimatedSprite playerAnimation => _idleAnimation;

   


    public float Rotation, Scale, Depth;

    public Vector2 Origin;


    public PlayerIdle(Player player) : base(player)
    {
        Rotation = 0;

        Scale = 2;

        Depth = 0;

        Origin = Vector2.Zero;

        _idleAnimation  = player.playerAtlas.CreateAnimatedSprite("playeridle");

        _idleAnimation.Scale = new Vector2(2.0f,2.0f);

             
    }
    public override void Enter()
    {
        Console.WriteLine("Idle State");
    }

    public override void Update(GameTime gameTime)
    {
        player.velocity.X = 0;
        
        player.velocity.Y = 0;

        
        _idleAnimation.Update(gameTime);
        
    }

    public override void HandleInput(KeyboardState current, KeyboardState previous, MouseState mouse)
    {
        if (current.IsKeyDown(Keys.D))
        {
           
           player.SwitchState(player.runState);
        }
        else if(current.IsKeyDown(Keys.A))
        {
            player.SwitchState(player.runState);
        }
     
        else if (mouse.LeftButton == ButtonState.Pressed)
        {
            player.SwitchState(player.attackState);
        }
        else if (current.IsKeyDown(Keys.C) && previous.IsKeyUp(Keys.C))
        {
           player.SwitchState(player.crouchState);
           
        }
        else if(current.IsKeyDown(Keys.Space) && previous.IsKeyUp(Keys.Space) && player.isOnGround)
        {
            player.SwitchState(player.startJumpState);
        }
        else if(current.IsKeyDown(Keys.H) && previous.IsKeyUp(Keys.H))
        {
            player.SwitchState(player.healState);
        }
    }

    public override void Draw(SpriteBatch batch,SpriteEffects effects)
    {
        if(player.direction == 1)
        {
            _idleAnimation.Effects = SpriteEffects.FlipHorizontally;
        }
        else
        {
            _idleAnimation.Effects = SpriteEffects.None;
        }
        _idleAnimation.Draw(batch,player.position);

    }

    public override void Exit()
    {
        Console.WriteLine("exiting idleState");
    }
}