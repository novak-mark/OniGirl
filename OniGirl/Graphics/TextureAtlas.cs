using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class TextureAtlas
{
    private Dictionary<string,TextureRegion> _textureRegions;

    public Texture2D textureAtlas;

    public TextureAtlas()
    {
        _textureRegions = new Dictionary<string, TextureRegion>();
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
            }
            return sourceAtlas;
        }
    }
    
}