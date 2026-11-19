using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

public class PlayerHeal : PlayerState
{
   
    private AnimatedSprite _healAnimation;
    public override AnimatedSprite playerAnimation => _healAnimation;

   


    public float Rotation, Scale, Depth;

    public Vector2 Origin;


    public PlayerHeal(Player player) : base(player)
    {
      

        _healAnimation  = player.playerAtlas.CreateAnimatedSprite("playerheal",false);

        _healAnimation.Scale = new Vector2(2.0f,2.0f);

             
    }
    public override void Enter()
    {
        Console.WriteLine("heal State");
        
    }

    public override void Update(GameTime gameTime)
    {
        player.velocity = Vector2.Zero;
        
        if(_healAnimation.PlayOnce(gameTime))
        {
            player.SwitchState(player.idleState);
        }
       

        
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
            _healAnimation.Effects = SpriteEffects.FlipHorizontally;
        }
        else
        {
            _healAnimation.Effects = SpriteEffects.None;
        }
        _healAnimation.Draw(batch,player.position);

    }

    public override void Exit()
    {
        Console.WriteLine("exiting healState");
        

    }
}