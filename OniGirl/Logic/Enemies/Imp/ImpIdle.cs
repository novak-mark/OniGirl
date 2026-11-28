using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

public class ImpIdle : EnemyState
{
   
    private AnimatedSprite _hitAnimation;
    public override AnimatedSprite enemyAnimation => _hitAnimation;

   

    public ImpIdle(Enemy enemy) : base(enemy)
    {


        _hitAnimation  = enemy.gameAtlas.CreateAnimatedSprite("impidle");

        _hitAnimation.Origin = new Vector2(
            _hitAnimation.sourceRegion.textureWidth  / 2f,
            _hitAnimation.sourceRegion.textureHeight / 2f
        );

        _hitAnimation.Scale = new Vector2(2.0f,2.0f);

             
    }
    public override void Enter()
    {
        //Console.WriteLine("Idle State");
    }

    public override void Update(GameTime gameTime)
    {
        enemy.velocity.X = 0;
        
        enemy.velocity.Y = 0;

        
        _hitAnimation.Update(gameTime);
        
    }

    

    public override void Draw(SpriteBatch batch,SpriteEffects effects)
    {
        if(enemy.direction == 1)
        {
            _hitAnimation.Effects = SpriteEffects.FlipHorizontally;
        }
        else
        {
            _hitAnimation.Effects = SpriteEffects.None;
        }
        _hitAnimation.Draw(batch,enemy.position);

    }

    public override void Exit()
    {
        //Console.WriteLine("exiting idleState");
    }
}