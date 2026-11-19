using System.Transactions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Player
{
    private int _maxHP;

    private KeyboardState _currentKeyboard;

    private KeyboardState _previousKeyboard;
    public Vector2 velocity;

    public float SPEED = 2.5f;

    public int currentHP;

    public TextureAtlas playerAtlas;

    public int direction;

    public PlayerState currentState;
    
    public PlayerIdle idleState;

    public PlayerWalk walkState;

    public PlayerRun runState;

    public PlayerAttack attackState;

    public PlayerCrouch crouchState;

    public PlayerExitRun exitRunState;
    public PlayerRunTurn turnRunState;

    public PlayerHeal healState;
    public Vector2 position;

    public Vector2 playerOrigin;

    public SpriteEffects playerEffect;

    public Player(TextureAtlas playerAtlas,int HP, Vector2 startPosition)
    {
        this.playerAtlas = playerAtlas;
        this._maxHP = HP;
        this.position = startPosition;

        currentHP = _maxHP;

        playerEffect = SpriteEffects.None;

        velocity = Vector2.Zero;

        idleState = new PlayerIdle(this);
        walkState = new PlayerWalk(this);
        crouchState = new PlayerCrouch(this);
        runState = new PlayerRun(this);
        attackState = new PlayerAttack(this);
        exitRunState = new PlayerExitRun(this);
        turnRunState = new PlayerRunTurn(this);
        healState = new PlayerHeal(this);
        
        currentState = idleState;
    }

    public void SwitchState(PlayerState newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState?.Enter();
    }

    public void HandleInput()
    {
        _previousKeyboard = _currentKeyboard;
        _currentKeyboard = Keyboard.GetState();

        MouseState mouse = Mouse.GetState();

        currentState.HandleInput(_currentKeyboard,_previousKeyboard,mouse);
    
        
    }
    public void Update(GameTime gameTime)
    {
        currentState.Update(gameTime);
    }

    public void Draw(SpriteBatch batch)
    {
        currentState?.Draw(batch,playerEffect); 
         
    }

    public void TakeDMG(int DMG)
    {
        currentHP =- DMG;
        if(currentHP <= 0)
        {
            //player dead
        }
        
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if(currentHP >= _maxHP)
        {
            currentHP = _maxHP;
        }
    }


}