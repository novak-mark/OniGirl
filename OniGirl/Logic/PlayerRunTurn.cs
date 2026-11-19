using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

public class PlayerRunTurn : PlayerState
{
   
   

    private AnimatedSprite _runTurn;

    private int _newDirection;

    public override AnimatedSprite playerAnimation => _runTurn;

    public float Rotation, Scale, Depth;

    public Vector2 Origin;


    public PlayerRunTurn(Player player) : base(player)
    {
        Rotation = 0;

        Scale = 2;

        Depth = 0;

        Origin = Vector2.Zero;

    
        _runTurn = player.playerAtlas.CreateAnimatedSprite("playerrunturn");
        _runTurn.Scale = new Vector2(2.0f,2.0f);
    }

    public void SetNewDirection(int direction)
    {
       _newDirection = direction;
    }
    public override void Enter()
    {
        Console.WriteLine("Run TurnState");

        player.velocity.X = 0;
        
       
    }

    public override void Update(GameTime gameTime)
    {
        player.velocity.X = 0;

        if(_runTurn.PlayOnce(gameTime))
        {
            player.direction = _newDirection;
            player.SwitchState(player.runState);
        }
    }

    public override void HandleInput(KeyboardState current, KeyboardState previous, MouseState mouse)
    {
      
    }

    public override void Draw(SpriteBatch batch,SpriteEffects effects)
    {
        if(player.direction == 1)
        {
            _runTurn.Effects = SpriteEffects.FlipHorizontally;
        }
        else
        {
            _runTurn.Effects = SpriteEffects.None;
        }
        _runTurn.Draw(batch,player.position);

    }

    public override void Exit()
    {
        Console.WriteLine("exiting runTurnState");
        
    }
}