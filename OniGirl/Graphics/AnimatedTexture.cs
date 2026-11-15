using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


public class AnimatedTexture
{
    private int _animationWidth;
    private int _animationHeight;
    private int _currentFrame;
    private float timePerFrame;
    private float totalElapsed;


    public int framesX;

    public int framesY;

    public TextureRegion animationTexture;

    public AnimatedTexture(int framesX, int framesY, TextureRegion texture, int framesPerSec)
    {
        this.framesX = framesX;
        this.framesY = framesY;

        this.animationTexture = texture;
        timePerFrame = (float)1 /framesPerSec;
        totalElapsed = 0;
        _currentFrame = 0;
        _animationWidth = animationTexture.sourceRect.Width;
        _animationHeight = animationTexture.sourceRect.Height;


    }

    public void UpdateFrame(float elapsed)
    {
        totalElapsed += elapsed;

        if(totalElapsed > timePerFrame)
        {
            _currentFrame++;
            _currentFrame %= framesX;

            totalElapsed -= timePerFrame;
        }
    }

    public void DrawFrame(SpriteBatch batch, Vector2 screenPos, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
    {
        DrawFrame(batch, _currentFrame, screenPos, color, rotation, origin, scale, effects, layerDepth);
    }

    public void DrawFrame(SpriteBatch batch, int frame, Vector2 screenPos, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
    {
        
        Rectangle sourcerect = new Rectangle(_animationWidth* frame, 0,
            _animationWidth, _animationHeight);

        batch.Draw
        (
            animationTexture.texture, 
            screenPos, 
            sourcerect, 
            Color.White,
            rotation, 
            origin, 
            scale, 
            SpriteEffects.None, 
            layerDepth
        );
    }


}