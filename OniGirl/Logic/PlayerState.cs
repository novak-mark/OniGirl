using System.Transactions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


public abstract class PlayerState
{
    protected Player player;

    public abstract int Width {get;}

    public abstract int Height {get; }

    public abstract AnimatedSprite playerAnimation {get; }

    
    protected PlayerState(Player player)
    {
        this.player = player;
    }

    public abstract void Enter();

    public abstract void Update(GameTime gameTime);

    public abstract void Draw(SpriteBatch batch,SpriteEffects effects);

    public abstract void HandleInput(KeyboardState current,KeyboardState previous, MouseState mouse);

    public abstract void Exit();

}




