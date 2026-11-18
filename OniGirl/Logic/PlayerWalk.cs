using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

public class PlayerWalk : PlayerState
{
    private AnimatedSprite _walkAnimation;
    public override AnimatedSprite playerAnimation => _walkAnimation;

    public float Rotation, Scale, Depth;

    public Vector2 Origin;


    public PlayerWalk(Player player) : base(player)
    {
        Rotation = 0;

        Scale = 2;

        Depth = 0;

        Origin = Vector2.Zero;

        _walkAnimation = player.playerAtlas.CreateAnimatedSprite("playerwalk");

        _walkAnimation.Scale = new Vector2(2.0f,2.0f);


     
    }
    public override void Enter()
    {
        Console.WriteLine("Walk State");
    }

    public override void Update(GameTime gameTime)
    {
        float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
       
        _walkAnimation.Update(gameTime);
    }

    public override void HandleInput(KeyboardState current, KeyboardState previous, MouseState mouse)
    {
        if (current.IsKeyDown(Keys.D))
        {
           

           player.direction = 1;

           player.velocity.X = player.SPEED;
        }
        else if (current.IsKeyDown(Keys.A))
        {
          

          player.direction = 0;

          player.velocity.X = -player.SPEED;


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
            _walkAnimation.Effects = SpriteEffects.FlipHorizontally;
        }
        else
        {
            _walkAnimation.Effects = SpriteEffects.None;
        }
        _walkAnimation.Draw(batch,player.position);

    }

    public override void Exit()
    {
        Console.WriteLine("exiting walkState");
    }
}