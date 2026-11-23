using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

public class PlayerAttack : PlayerState
{
   
    private AnimatedSprite _attackAnimation;

    private Texture2D _hitboxText;
    public override AnimatedSprite playerAnimation => _attackAnimation;

   
    public float Rotation, Scale, Depth;

    public Vector2 Origin;

    


    public PlayerAttack(Player player) : base(player)
    {
      

        _attackAnimation  = player.playerAtlas.CreateAnimatedSprite("playerattack");

         _attackAnimation.Scale = new Vector2(2.0f,2.0f);


        _attackAnimation.Origin = new Vector2(
            _attackAnimation.sourceRegion.textureWidth  / 2f,
            _attackAnimation.sourceRegion.textureHeight / 2f
        );

             
    }
    public override void Enter()
    {
        Console.WriteLine("Attack State");
        
    }

    public override void Update(GameTime gameTime)
    {
        player.velocity = Vector2.Zero;
        int current_frame = _attackAnimation.GetCurrentFrame();

        Console.WriteLine(current_frame);
        if(_attackAnimation.PlayOnce(gameTime))
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
            _attackAnimation.Effects = SpriteEffects.FlipHorizontally;
        }
        else
        {
            _attackAnimation.Effects = SpriteEffects.None;
        }
        _attackAnimation.Draw(batch,player.position);

        

    }

    public override void Exit()
    {
        Console.WriteLine("exiting attackState");
        

    }
}