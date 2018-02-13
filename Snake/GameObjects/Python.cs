using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.GameObject
{
    class Python : Drawable
    {
        List<RectangleShape> body;
        public RectangleShape Head { get { return body.First(); } }
        RectangleShape head;

        private const int multiplier = 1;
        public float Speed { get; set; }
        public Python()
        {
            body = new List<RectangleShape>();
            CreateSnake();
            LoadTextures();
        }
        private void LoadTextures()
        {
            RectangleShape shape = new RectangleShape(new SFML.System.Vector2f(30f, 30f));
            
        }
        private void TransitionControl()
        {
            for (int i = body.Count - 1; i > 0; i--)
                body[i].Position = body[i - 1].Position;
        }

        private void CreateSnake()
        {
            RectangleShape tail = new RectangleShape(new SFML.System.Vector2f(30f, 30f));
            tail.FillColor = new Color(226, 244, 65, 100);
            RectangleShape center = new RectangleShape(new SFML.System.Vector2f(30f, 30f));
            center.FillColor = new Color(226, 244, 65, 100);
            head = new RectangleShape(new SFML.System.Vector2f(30f, 30f));
            head.FillColor = new Color(66, 244, 146, 100);
            tail.Position = new Vector2f(420f, 420f);
            center.Position = new Vector2f(450, 420);
            head.Position = new Vector2f(480, 420);
            body.Add(head);
            body.Add(center);
            body.Add(tail);


        }

        public bool Canibalism()
        {

        }

        public void Grow()
        {
            RectangleShape component = new RectangleShape(new Vector2f(30f, 30f));
            component.Position = new Vector2f(body.Last().Position.X - 30, body.Last().Position.Y);
            body.Add(component);
        }
        public void MoveUp()
        {
            body.First().Position =new Vector2f(head.Position.X, head.Position.Y - Speed * multiplier);
            TransitionControl();
            Console.WriteLine(body.First().Position);
        }
        public void MoveDown()
        {
            body.First().Position = new Vector2f(head.Position.X, head.Position.Y + Speed * multiplier);
            TransitionControl();
            Console.WriteLine(body.First().Position);
        }
        public void MoveLeft()
        {
            body.First().Position = new Vector2f(head.Position.X - Speed * multiplier, head.Position.Y);
            TransitionControl();
            Console.WriteLine(body.First().Position);
        }
        public void MoveRight()
        {
            body.First().Position = new Vector2f(head.Position.X + Speed * multiplier, head.Position.Y);
            TransitionControl();
            Console.WriteLine(body.First().Position);
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            body.ForEach(x => target.Draw(x, RenderStates.Default));
        }
    }
}
