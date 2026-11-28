using System;
using System.Transactions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Imp : Enemy
{

    public EnemyState idleState;
    public EnemyState hitState;


    public SpriteEffects effect;



     public Imp(TextureAtlas gameAtlas, Vector2 startPosition, int HP)
        : base(gameAtlas, startPosition, HP)
    {
        this.idleState = new ImpIdle(this);

        currentState = idleState;
    } 

    public override void Update(GameTime gameTime)
    {
        currentState.Update(gameTime);  
    }
    public override void Draw(SpriteBatch batch)
    {
        currentState?.Draw(batch,effect);     
    }
}