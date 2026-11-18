using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

public class PlayerIdle : PlayerState
{
    public override int Width => 32;
    

    public override AnimatedSprite playerAnimation => player.playerAtlas.CreateAnimatedSprite("playeridle");
    public override int Height => 64;


    public float Rotation, Scale, Depth;

    public Vector2 Origin;


    public PlayerIdle(Player player) : base(player)
    {
        Rotation = 0;

        Scale = 2;

        Depth = 0;

        Origin = Vector2.Zero;

             
    }
    public override void Enter()
    {
        Console.WriteLine("Idle State");
    }

    public override void Update(GameTime gameTime)
    {
        float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
        player.velocity = Vector2.Zero;
        
        playerAnimation.Update(gameTime);
        
    }

    public override void HandleInput(KeyboardState current, KeyboardState previous, MouseState mouse)
    {
        if (current.IsKeyDown(Keys.D))
        {
           player.SwitchState(player.walkState);


        }
        else if (current.IsKeyDown(Keys.A))
        {
          player.SwitchState(player.walkState);


        }
        else if (current.IsKeyDown(Keys.C) && previous.IsKeyUp(Keys.C))
        {
           //player.SwitchState(player.crouchState);
           
        }
    }

    public override void Draw(SpriteBatch batch,SpriteEffects effects)
    {
        playerAnimation.Draw(batch,player.position);

    }

    public override void Exit()
    {
        Console.WriteLine("exiting idleState");
    }
}