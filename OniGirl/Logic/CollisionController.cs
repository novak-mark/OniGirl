using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

public class CollisionController
{
    public CollisionController()
    {
        
    }

    public bool ScreenBounds(Rectangle screenBounds, Rectangle objectBounds)
    {
        if(objectBounds.Left < screenBounds.Left)
        {
            //Console.WriteLine("trk");
            return true;
        }
        if(objectBounds.Right > screenBounds.Right)
        {
            return true;
        }
        return false;
    }

    public bool DetectCollision(Rectangle playerBounds,Object obj)
    {
        if(obj is Projectile proj)
        {
            
            if(playerBounds.Intersects(proj.projectileBoundingBox))
            {
                Console.WriteLine("player hit");
                return true;
            }
        }

        return false;
    }

    public bool DetectAttackCollision(Rectangle attackBounds, Object obj)
    {
        if(obj is Enemy)
        {
            return false;
        }
        return false;
    }

}