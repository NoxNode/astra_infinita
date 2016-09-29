using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace astra_infinita
{
    public class Tile
    {
        public int X;
        public int Y;

        //add object holder so tiles can hold items/objects/things

       public Tile(int x, int y)
        {
            this.X = x;
            this.Y = y;

        }
        public virtual int getX()
        {
            return this.X;
        }
        public virtual int getY()
        {
            return this.Y;
        }

        public void update()
        {
            
        }


    }
}
