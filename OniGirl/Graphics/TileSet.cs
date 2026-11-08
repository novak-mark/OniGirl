using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class TileSet
{
    private TextureRegion[] _tiles;

    public int tileWidth;
    public int tileHeight;

    public int columns;

    public int rows;

    public int numberOfTiles;

    public TextureRegion getTile(int index)
    {
        return _tiles[index];
    }
    public TextureRegion getTile(int column, int row)
    {
        int index = row * columns + column;
        return _tiles[index];
    }
    public TileSet(TextureRegion tileSetTexture, int tileWdith, int tileHeight)
    {
        this.tileWidth = tileWdith;
        this.tileHeight = tileHeight;

        columns = tileSetTexture.textureWidth / this.tileWidth;
        rows = tileSetTexture.textureHeight / this.tileHeight;

        numberOfTiles = columns * rows;

        _tiles = new TextureRegion[numberOfTiles];

        for(int i=0; i < numberOfTiles; i++)
        {
            int x = (i % columns) * this.tileWidth; 
            int y = (i / rows)* this.tileHeight;
            
            _tiles[i] = new TextureRegion(tileSetTexture.texture,tileSetTexture.sourceRect.X + x,tileSetTexture.sourceRect.Y + y,
            this.tileWidth,this.tileHeight);
        }
    }

    
}