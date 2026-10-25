using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;



public class TextureRegion
{
    Rectangle sourceRect;
    Texture2D texture;


    public TextureRegion(Texture2D texture, int x,int y, int width, int height)
    {
        this.texture = texture;
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