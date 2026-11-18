using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class TextureAtlas
{
    private Dictionary<string,TextureRegion> _textureRegions;
    private Dictionary<string,Animation> _animations;

    public Texture2D textureAtlas;

    public TextureAtlas()
    {
        _textureRegions = new Dictionary<string, TextureRegion>();
        _animations = new Dictionary<string,Animation>();
    }

    public TextureAtlas(Texture2D textureAtlas)
    {
        this.textureAtlas = textureAtlas;
        _textureRegions = new Dictionary<string, TextureRegion>();
    }

    public TextureRegion GetTextureRegion(string name)
    {
        return _textureRegions[name];
    }

    public void AddRegion(Texture2D texture,string name,int x, int y, int width, int height)
    {
        TextureRegion region = new TextureRegion(texture,x,y,width,height);
        _textureRegions.Add(name,region);

    }

    public Animation GetAnimation(string animationName)
    {
        return _animations[animationName];
    }
    public void AddAnimation(string animationName, Animation animation)
    {
    
        _animations.Add(animationName,animation);
    }

    public Sprite CreateSprite(string regionName)
    {
        TextureRegion sourceRegion = GetTextureRegion(regionName);
        return new Sprite(sourceRegion);
    }

    public AnimatedSprite CreateAnimatedSprite(string animationName)
    {
        Animation sourceAnimation = GetAnimation(animationName);
        return new AnimatedSprite(sourceAnimation);
    }

    

    public static TextureAtlas ReadFromFile(ContentManager content,string filePath)
    {
        TextureAtlas sourceAtlas = new TextureAtlas();

        using (Stream stream = TitleContainer.OpenStream(filePath))
        {
            using (XmlReader reader = XmlReader.Create(stream))
            {
                XDocument doc = XDocument.Load(reader);
                XElement root = doc.Root;

                string texturePath = root.Element("Texture").Value;

                Texture2D playerTexture = content.Load<Texture2D>(texturePath);

                var regions = root.Element("Regions")?.Elements("Region");

                if(regions != null)
                {
                    foreach(var region in regions)
                    {
                        string name = region.Attribute("name")?.Value;
                        int x = int.Parse(region.Attribute("x")?.Value);
                        int y = int.Parse(region.Attribute("y")?.Value);
                        int width = int.Parse(region.Attribute("width")?.Value);
                        int height = int.Parse(region.Attribute("height")?.Value);

                        //TextureRegion playerTextureRegion = new TextureRegion(playerTexture,x,y,width,height);

                        if(!string.IsNullOrEmpty(name))
                        {
                            sourceAtlas.AddRegion(playerTexture,name,x,y,width,height);
                        }
                    }
                }

                var animationElements = root.Element("Animations")?.Elements("Animation");

                if(animationElements != null)
                {
                    foreach(var animationElement in animationElements)
                    {
                        string animationName = animationElement.Attribute("name")?.Value;
                        float delayMiliSecs = float.Parse(animationElement.Attribute("delay")?.Value ?? "0");
                        TimeSpan delay = TimeSpan.FromMilliseconds(delayMiliSecs);

                        List<TextureRegion> frames = new List<TextureRegion>();

                        var frameElements = animationElement.Elements("Frame");

                        if(frameElements != null)
                        {
                            foreach(var frameElement in frameElements)
                            {
                                string regionName = frameElement.Attribute("region").Value;
                                TextureRegion animationRegion = sourceAtlas.GetTextureRegion(regionName);
                                frames.Add(animationRegion);    
                            }
                            
                        }

                        Animation animation = new Animation(frames,delay);

                        sourceAtlas.AddAnimation(animationName,animation);
                    }
                }
            }
            return sourceAtlas;
        }
    }
    
}