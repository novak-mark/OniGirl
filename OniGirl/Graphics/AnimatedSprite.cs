using System;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;




public class AnimatedSprite : Sprite
{
    private int _currentFrame;

    private Boolean _loopable;


    private TimeSpan _totalElapsed;
    private Animation _animation;




    public AnimatedSprite(Animation animation, Boolean loopable = true)
    {

        this._animation = animation;
        this._loopable = loopable;

        sourceRegion = animation.Frames[0];
        _currentFrame = 0;

    }

    public void Update(GameTime gameTime)
    {
        _totalElapsed += gameTime.ElapsedGameTime;
        if(_totalElapsed >= _animation.Delay)
        {
            

            _totalElapsed -= _animation.Delay;
            _currentFrame++;
            
            if(_currentFrame >= _animation.Frames.Count)
            {
                if(_loopable)
                {
                    _currentFrame = 0;
                }
                else
                {
                    return;
                }
            }

            sourceRegion = _animation.Frames[_currentFrame];
        }
    }
   
}