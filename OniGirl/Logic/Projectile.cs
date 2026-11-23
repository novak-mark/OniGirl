using System;
using System.Transactions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

public class Projectile
{
  
    private Sprite _projectileSprite;
    public Vector2 velocity;

    public Vector2 position;

    public Rectangle projectileBoundingBox;


    public float SPEED = 1.2f;


    public TextureAtlas gameAtlas;

    public int direction;

    public int width;

    public int height;

    

    

    public Projectile(TextureAtlas gameAtlas, Vector2 startPosition)
    {
        this.gameAtlas = gameAtlas;

        this.position = startPosition;

        _projectileSprite = gameAtlas.CreateSprite("fireball");

        

    }

   
   
    public void Update(GameTime gameTime)
    {
        this.velocity.X = SPEED;

        this.position.X -= velocity.X;

        projectileBoundingBox = new Rectangle(
        (int)(position.X - (_projectileSprite.sourceRegion.textureWidth / 2f)),
        (int)(position.Y - (_projectileSprite.sourceRegion.textureHeight / 2f)),
        _projectileSprite.sourceRegion.textureWidth,
        _projectileSprite.sourceRegion.textureHeight
        );
       
    }

    public void Draw(SpriteBatch batch)
    {
        _projectileSprite.Draw
        (
            batch,
            position
        );
         
    }

  

}