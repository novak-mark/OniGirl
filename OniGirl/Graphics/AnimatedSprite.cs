using System;
using System.Reflection;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;




public class AnimatedSprite : Sprite
{
    private int _currentFrame;
    private TimeSpan _totalElapsed;
    private Animation _animation;




    public AnimatedSprite(Animation animation)
    {

        this._animation = animation;

        sourceRegion = animation.Frames[0];
        _currentFrame = 0;

    }

    public void Update(GameTime gameTime)
    {
        _totalElapsed += gameTime.ElapsedGameTime;
        Console.WriteLine("halo" + _animation.Frames.Count);
        if(_totalElapsed > _animation.Delay)
        {
            _totalElapsed -= _animation.Delay;
            _currentFrame++;
            Console.WriteLine(_animation.Frames.Count);
            if(_currentFrame >= _animation.Frames.Count)
            {
                _currentFrame = 0;
            }

            sourceRegion = _animation.Frames[_currentFrame];
        }
    }

   
}