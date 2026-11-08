using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class TextureRegion
{
    public Rectangle sourceRect;
    public Texture2D texture;

    public int textureWidth;
    public int textureHeight;


    public TextureRegion(Texture2D texture, int x,int y, int width, int height)
    {
        this.texture = texture;
        this.textureWidth = width;
        this.textureHeight = height;
        sourceRect = new Rectangle(x,y,width,height);
    }

    public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
    {
        spriteBatch.Draw(
            texture,
            position,
            sourceRect,
            color,
            rotation,
            origin,
            scale,
            effects,
            layerDepth
        );
    }


}