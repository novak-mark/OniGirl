using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


public class AnimatedTexture
{
    private int _animationWidth;
    private int _animationHeight;
    private int _currentFrame;

    private int _currentFrameY;
    private float timePerFrame;
    private float totalElapsed;


    public int framesX;

    public int framesY;

    public TextureRegion animationTexture;


    public float Rotation, Scale, Depth;

    public Vector2 Origin;


    public AnimatedTexture(int framesX, int framesY, TextureRegion texture, int framesPerSec,
    Vector2 origin,float rotation,float scale, float depth)
    {
        this.framesX = framesX;
        this.framesY = framesY;

        this.Origin = origin;
        this.Rotation = rotation;
        this.Scale = scale;
        this.Depth = depth;
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

            _currentFrameY++;
            _currentFrameY %= framesY;
            

            totalElapsed -= timePerFrame;
        }
    }

    public void DrawFrame(SpriteBatch batch, Vector2 screenPos,SpriteEffects effect)
    {
        DrawFrame(batch, _currentFrame,_currentFrameY, screenPos,effect);
    }

    public void DrawFrame(SpriteBatch batch, int frame,int frameY, Vector2 screenPos,SpriteEffects effects)
    {
        
        Rectangle sourcerect = new Rectangle(_animationWidth* frame, _animationHeight * frameY,
            _animationWidth, _animationHeight);

        batch.Draw
        (
            animationTexture.texture, 
            screenPos, 
            sourcerect, 
            Color.White,
            Rotation, 
            Origin, 
            Scale, 
            SpriteEffects.None, 
            Depth
        );
    }


}