using System;
using System.Collections.Generic;
using System.Text;

namespace OuroborosVandaleriaCore.Maps
{
    class AreaManager
    {
        Area area;
        Queue<string> mapFileNames;

        public Area LoadArea()
        {
            var name = mapFileNames.Dequeue();
            
            return area;
        }
    }
}