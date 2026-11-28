using System;
using System.Transactions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public abstract class Enemy
{
    protected EnemyState currentState;
    private int _maxHP;

    public int currentHP;

    public int direction;

    public TextureAtlas gameAtlas;

   
    public Vector2 position;
    public Vector2 velocity;

    public Vector2 Origin;

    public SpriteEffects Effect;


    public Enemy(TextureAtlas gameAtlas,Vector2 startPosition, int HP)
    {
        this.gameAtlas = gameAtlas;
        this.position = startPosition;
        this._maxHP = HP;

        this.currentHP = _maxHP;

        this.direction = 0;
    }

    public abstract void Update(GameTime gameTime);

    public abstract void Draw(SpriteBatch batch);

    public void TakeDmg(int DMG)
    {
        currentHP =- DMG;
        if(currentHP <= 0)
        {
            //player dead
        }
    }

    public void SwitchState(EnemyState newState)
    {
        currentState?.Exit();

        currentState = newState;

        currentState.Enter();
    }

}