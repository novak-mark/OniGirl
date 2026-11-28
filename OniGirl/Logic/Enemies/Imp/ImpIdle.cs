using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

public class ImpIdle : EnemyState
{
   
    private AnimatedSprite _idleAnimation;
    public override AnimatedSprite enemyAnimation => _idleAnimation;

   

    public ImpIdle(Enemy enemy) : base(enemy)
    {


        _idleAnimation  = enemy.gameAtlas.CreateAnimatedSprite("impidle");

        _idleAnimation.Origin = new Vector2(
            _idleAnimation.sourceRegion.textureWidth  / 2f,
            _idleAnimation.sourceRegion.textureHeight / 2f
        );

        _idleAnimation.Scale = new Vector2(2.0f,2.0f);

             
    }
    public override void Enter()
    {
        //Console.WriteLine("Idle State");
    }

    public override void Update(GameTime gameTime)
    {
        enemy.velocity.X = 0;
        
        enemy.velocity.Y = 0;

        
        _idleAnimation.Update(gameTime);
        
    }

    

    public override void Draw(SpriteBatch batch,SpriteEffects effects)
    {
        if(enemy.direction == 1)
        {
            _idleAnimation.Effects = SpriteEffects.FlipHorizontally;
        }
        else
        {
            _idleAnimation.Effects = SpriteEffects.None;
        }
        _idleAnimation.Draw(batch,enemy.position);

    }

    public override void Exit()
    {
        //Console.WriteLine("exiting idleState");
    }
}