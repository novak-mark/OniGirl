using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

public class PlayerWalk : PlayerState
{
    private AnimatedTexture walkAnimation;

    public override int Width => 45;
    public override TextureRegion animationTexture => player.playerAtlas.GetTextureRegion("playerwalk");
    public override int Height => 58;


    public float Rotation, Scale, Depth;

    public Vector2 Origin;


    public PlayerWalk(Player player) : base(player)
    {
        Rotation = 0;

        Scale = 2;

        Depth = 0;

        Origin = Vector2.Zero;

        walkAnimation = new AnimatedTexture(4,6,animationTexture,10,Origin,Rotation,Scale,Depth);

     
    }
    public override void Enter()
    {
        Console.WriteLine("Walk State");
    }

    public override void Update(GameTime gameTime)
    {
        float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
       
        walkAnimation.UpdateFrame(elapsed);
    }

    public override void HandleInput(KeyboardState current, KeyboardState previous, MouseState mouse)
    {
        if (current.IsKeyDown(Keys.D))
        {
           

           player.direction = 0;

           player.velocity.X = player.SPEED;
        }
        else if (current.IsKeyDown(Keys.A))
        {
          

          player.direction = 1;

          player.velocity.X = -player.SPEED;


        }
        else if (current.IsKeyDown(Keys.C) && previous.IsKeyUp(Keys.C))
        {
           //player.SwitchState(player.crouchState);
           
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
            player.playerEffect = SpriteEffects.FlipHorizontally;
        }
        else
        {
            player.playerEffect = SpriteEffects.None;
        }
        walkAnimation.DrawFrame(batch,player.position,effects);

    }

    public override void Exit()
    {
        Console.WriteLine("exiting walkState");
    }
}