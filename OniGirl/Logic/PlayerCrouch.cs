using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

public class PlayerCrouch : PlayerState
{
   
    private AnimatedSprite _crouchAnimation;
    public override AnimatedSprite playerAnimation => _crouchAnimation;

   


    public float Rotation, Scale, Depth;

    public Vector2 Origin;


    public PlayerCrouch(Player player) : base(player)
    {
      

        _crouchAnimation  = player.playerAtlas.CreateAnimatedSprite("playercrouch",false);

        _crouchAnimation.Scale = new Vector2(2.0f,2.0f);

             
    }
    public override void Enter()
    {
        Console.WriteLine("Crouch State");
    }

    public override void Update(GameTime gameTime)
    {
        player.velocity = Vector2.Zero;
        
       

        
    }

    public override void HandleInput(KeyboardState current, KeyboardState previous, MouseState mouse)
    {
     
        if (current.IsKeyDown(Keys.C) && previous.IsKeyUp(Keys.C))
        {
           //player.SwitchState(player.crouchState);
           
        }
    }

    public override void Draw(SpriteBatch batch,SpriteEffects effects)
    {
        if(player.direction == 1)
        {
            _crouchAnimation.Effects = SpriteEffects.FlipHorizontally;
        }
        else
        {
            _crouchAnimation.Effects = SpriteEffects.None;
        }
        _crouchAnimation.Draw(batch,player.position);

    }

    public override void Exit()
    {
        Console.WriteLine("exiting crouchState");
        

    }
}