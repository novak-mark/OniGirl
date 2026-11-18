using System;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;




public class AnimatedTexture
{
    private int _currentFrame;
    private TimeSpan _totalElapsed;
    private Animation _animation;

    private int _animationWidth;
    private int _animationHeight;
    public TextureRegion animationRegion;
    public float Rotation, Scale, Depth;

    public Vector2 Origin;


    public AnimatedTexture(Animation animation, Vector2 origin,float rotation,float scale, float depth)
    {

        this.Origin = origin;
        this.Rotation = rotation;
        this.Scale = scale;
        this.Depth = depth;
        

        this._animation = animation;

    
        _currentFrame = 0;
        _animationWidth = animation.Frames[0].textureWidth;
        _animationHeight = animation.Frames[0].textureHeight;




    }

    public void UpdateFrame(GameTime gameTime)
    {
        _totalElapsed += gameTime.ElapsedGameTime;

        if(_totalElapsed > _animation.Delay)
        {
            _totalElapsed -= _animation.Delay;
            _currentFrame++;

            if(_currentFrame >= _animation.Frames.Count)
            {
                _currentFrame = 0;
            }

            animationRegion = _animation.Frames[_currentFrame];
        }
    }

    public void Draw(SpriteBatch batch, Vector2 screenPos,SpriteEffects effects)
    {
        batch.Draw
        (
            animationRegion.texture, 
            screenPos, 
            animationRegion.sourceRect, 
            Color.White,
            Rotation, 
            Origin, 
            new Vector2(Scale,Scale), 
            SpriteEffects.None, 
            Depth
        );
    }

    /*
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

    */


}