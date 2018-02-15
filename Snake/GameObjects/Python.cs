using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.GameObjects
{
    class Python : Drawable
    {
        Texture bodyTexture;
        Texture headTexture;
        List<Sprite> body;
        Texture head_up, head_down, head_left;
        public Sprite Head { get { return body.First(); } }
        Sprite head;

        private const int multiplier = 1;
        public float Speed { get; set; }
        public Python()
        {
            Speed = 30f;
            body = new List<Sprite>();
            LoadTextures();
            CreateSnake();
            
        }
        public void ResetSnake()
        {
            body.Clear();
            CreateSnake();
        }
        public void HeadUp()
        {
            head.Texture = head_up;
        }
        public void HeadDown()
        {
            head.Texture = head_down;
        }
        public void HeadLeft()
        {
            head.Texture = head_left;
        }
        public void HeadRight()
        {
            head.Texture = headTexture;
        }
        private void LoadTextures()
        {

            head_left = new Texture("Resources\\head_left.png");
            head_up = new Texture("Resources\\head_up.png");
            head_down = new Texture("Resources\\head_down.png");
            headTexture = new Texture("Resources\\head.png");
            bodyTexture = new Texture("Resources\\skin.png");
        }
        private void TransitionControl()
        {
            for (int i = body.Count - 1; i > 0; i--)
                (body[i]).Position = (body[i - 1]).Position;
        }

        private void CreateSnake()
        {
            
            Sprite tail = new Sprite(bodyTexture, new IntRect(0,0,30,30));
            //tail.FillColor = new Color(226, 244, 65, 100);
            Sprite center = new Sprite(bodyTexture, new IntRect(0, 0, 30, 30));
            //center.FillColor = new Color(226, 244, 65, 100);
            head = new Sprite(headTexture, new IntRect(0, 0, 30, 30));
            //head.FillColor = new Color(66, 244, 146, 100);
            tail.Position = new Vector2f(420f, 420f);
            center.Position = new Vector2f(450, 420);
            head.Position = new Vector2f(480, 420);
           // head.Origin = new Vector2f(head.Origin.X / 2, head.Origin.Y / 2);
            body.Add(head);
            body.Add(center);
            body.Add(tail);


        }

        public bool Canibalism(float x, float y)
        {
            for (int i = 1; i < body.Count; i++)
                if (body[i].Position.X == x && body[i].Position.Y == y)
                    return true;
            return false;
        }

        public void Grow()
        {
            Sprite component = new Sprite(bodyTexture);
            component.Position = new Vector2f(body.Last().Position.X - 30, body.Last().Position.Y);
            body.Add(component);
        }
        public void MoveUp()
        {
            TransitionControl();
            body.First().Position =new Vector2f(head.Position.X, head.Position.Y - Speed * multiplier);
            
            //Console.WriteLine(body.First().Position);
        }
        public void MoveDown()
        {
            TransitionControl();
            body.First().Position = new Vector2f(head.Position.X, head.Position.Y + Speed * multiplier);
            
           // Console.WriteLine(body.First().Position);
        }
        public void MoveLeft()
        {
            TransitionControl();
            body.First().Position = new Vector2f(head.Position.X - Speed * multiplier, head.Position.Y);
            
          //  Console.WriteLine(body.First().Position);
        }
        public void MoveRight()
        {
            TransitionControl();
            body.First().Position = new Vector2f(head.Position.X + Speed * multiplier, head.Position.Y);
            
           // Console.WriteLine(body.First().Position);
        }
        public void Draw(RenderTarget target, RenderStates states)
        {
            body.ForEach(x => target.Draw(x, RenderStates.Default));
        }
    }
}
