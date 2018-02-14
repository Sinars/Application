using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.GameObjects
{
    interface IBody:Drawable
    {
        Vector2f Position { get; set; }
    }
}
