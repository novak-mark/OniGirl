using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

public class TileMap
{
    public TileSet tileSet;

    public int[] tiles;

    public int columns;

    public int rows;

    public int count;

    public Vector2 scale;

    public float tileWidth;

    public float tileHeight;


    public TileMap(TileSet tileSet, int columns, int rows)
    {
        this.tileSet = tileSet;
        this.columns = columns;
        this.rows = rows;
        scale = Vector2.One;

        this.count = columns * rows;
        tiles = new int[count];

        this.tileWidth = tileSet.tileWidth * scale.X;
        this.tileHeight = tileSet.tileHeight * scale.Y;

    }

    public void SetTile(int index, int tileSetID)
    {
        tiles[index] = tileSetID;
    }

    public void SetTile(int column,int row, int tileSetID)
    {
        int index = row * columns + column;
        SetTile(index,tileSetID);
    }

    public TextureRegion getTile(int index)
    {
        return tileSet.getTile(tiles[index]);
    }

    public void Draw(SpriteBatch spriteBatch)
    {

        for(int i=0; i < count; i++)
        {
            int tileSetIndex = tiles[i];
            TextureRegion tileTextureRegion = tileSet.getTile(tileSetIndex);

            int x = i % columns;
            int y = i / columns;

            Vector2 position = new Vector2((x * tileWidth), (y * tileHeight) + 850);

            tileTextureRegion.Draw(
                spriteBatch,
                position,
                Color.White,
                0.0f,
                Vector2.Zero,
                scale,
                SpriteEffects.None,
                1.0f
            );

        }
    }

    public static TileMap ReadFromFile(ContentManager content, string filePath)
    {

        using (Stream stream = TitleContainer.OpenStream(filePath))
        {
            using (XmlReader reader = XmlReader.Create(stream))
            {
                XDocument doc = XDocument.Load(reader);
                XElement root = doc.Root;

                string tileSetPath = root.Element("Tileset").Value;

                int tileWidht = int.Parse(root.Element("Tileset").Attribute("tileWidth")?.Value);

                int tileHeight = int.Parse(root.Element("Tileset").Attribute("tileHeight")?.Value);

                int sourceX = int.Parse(root.Element("Region").Attribute("x")?.Value);
                int sourceY = int.Parse(root.Element("Region").Attribute("y")?.Value);
                int sourceWidth = int.Parse(root.Element("Region").Attribute("width")?.Value);
                int sourceHeight = int.Parse(root.Element("Region").Attribute("height")?.Value);

                Texture2D tileSetTexture = content.Load<Texture2D>(tileSetPath);

                TextureRegion tileSetRegion = new TextureRegion(tileSetTexture,sourceX,sourceY,sourceWidth,sourceHeight);

                TileSet tileSet = new TileSet(tileSetRegion,tileWidht,tileHeight);

                XElement tilesElement = root.Element("Tiles");

                string[] rows = tilesElement.Value.Trim().Split('\n',StringSplitOptions.RemoveEmptyEntries);

                int columnCount = rows[0].Split(" ", StringSplitOptions.RemoveEmptyEntries).Length;

                TileMap tileMap = new TileMap(tileSet,columnCount,rows.Length);

                for(int i=0; i < rows.Length; i++)
                {
                    string[] columns = rows[i].Trim().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    for(int j=0; j < columns.Length; j++)
                    {
                        int tileSetIndex = int.Parse(columns[j]);

                        tileMap.SetTile(j,i,tileSetIndex);
                    }

                }
                return tileMap;
            }
        }
    }

}