using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;


public class Animation
{
    public List<TextureRegion> Frames;

    public TimeSpan Delay;

    public Animation()
    {
        Frames = new List<TextureRegion>();

        Delay = TimeSpan.FromMilliseconds(100);
    }

    public Animation(List<TextureRegion> frames, TimeSpan delay)
    {
        this.Frames = frames;
        this.Delay = delay;
    }


}