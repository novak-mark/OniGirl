using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



public class Sprite 
{
    public Color Color { get; set; } = Color.White;

    public float LayerDepth { get; set; } = 0.0f;
    public float Rotation { get; set; } = 0.0f;

    public Vector2 Scale { get; set; } = Vector2.One;

    public Vector2 Origin { get; set; } = Vector2.Zero;

    public SpriteEffects Effects { get; set; } = SpriteEffects.None;

    public TextureRegion sourceRegion {get; set;}


    public float Width => sourceRegion.textureWidth * Scale.X;


    public float Height => sourceRegion.textureHeight * Scale.Y;


    public Sprite()
    {
    
    }

    public Sprite(TextureRegion region)
    {
        this.sourceRegion = region;

        
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position)
    {
        sourceRegion.Draw
        (
            spriteBatch, 
            position, 
            Color, 
            Rotation, 
            Origin, 
            Scale, 
            Effects, 
            LayerDepth
        );
    }



}