using System.Transactions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


public abstract class EnemyState
{
    protected Enemy enemy;
   
    public abstract AnimatedSprite enemyAnimation {get; }

    
    protected EnemyState(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public abstract void Enter();

    public abstract void Update(GameTime gameTime);

    public abstract void Draw(SpriteBatch batch,SpriteEffects effects);

    

    public abstract void Exit();

}




