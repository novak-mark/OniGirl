using System;
using System.Collections.Concurrent;
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
                 _currentFrame = 0;
                
            }

            sourceRegion = _animation.Frames[_currentFrame];
        }
    }

    public Boolean PlayOnce(GameTime gameTime)
    {
        
        _totalElapsed += gameTime.ElapsedGameTime;
        if(_totalElapsed >= _animation.Delay)
        {
            
            _totalElapsed -= _animation.Delay;
            _currentFrame++;
            if(_currentFrame >= _animation.Frames.Count)
            {
                _currentFrame = 0;
                 return true; 
            }
            sourceRegion = _animation.Frames[_currentFrame];
        }
        return false;
    }
   
}