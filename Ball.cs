/*namespace Workshop2;
using SFML.System;
using SFML.Graphics;

public class Ball
{
    
        private CircleShape shape;
        protected Vector2f direction => velocity / speed;
        protected float speed => MathF.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);

        protected Vector2f velocity;
        
        
        
        public Ball()
        {
            shape = new CircleShape(radius: 30);
            shape.FillColor = Color.Red;
            shape.Origin = new Vector2f(30, 30);
            shape.Position = new Vector2f(400, 300);
            RandomizeVelocity();

            Random rand = new Random();
            float X= rand.Next(0, 2);
            X *= 2;
            X -= 1;
            float Y = (rand.Next(0,2)* 2)- 1;
            velocity = new Vector2f(X, Y) * rand.Next(50, 200);
            

        }
        
        public void Update(float deltaTime)
        {
            shape.Position += direction * speed * deltaTime;
            if (shape.Position.X < 0) //Left side
            {
                shape.Position = new Vector2f(0, shape.Position.Y);
                velocity.X *= -1;
            }
            else  if(shape.Position.X > 800) //Right side
            {
                shape.Position = new Vector2f(800, shape.Position.Y);
                velocity.X *= -1;
            }
            if (shape.Position.Y < 0) //UP
            {
                shape.Position = new Vector2f(shape.Position.X, 0);
                velocity.Y *= -1;
            }
            else if(shape.Position.Y > 600) //Down
            {
                shape.Position = new Vector2f(shape.Position.X, 600);
                velocity.Y*= -1;
            }
        }

        public void UpdatePosition(float deltatime)
        {
            
        }

        public void RandomizeVelocity()
        {
            
        }
        
        public void Draw(RenderWindow rw)
        {
            rw.Draw((shape));
        }

        public void HandleCollision(Vector2f collsionDirection)
        {
            velocity = speed * (-collsionDirection)/ (MathF.Sqrt((collsionDirection.X * collsionDirection.X * collsionDirection.Y * collsionDirection.Y)));
        }
        
        
        public static float Distance(Ball a, Ball b)
        {
            Vector2f midPointDifference = (a.shape.Position = b.shape.Position);
            float midPoinDistance = MathF.Sqrt((midPointDifference.X * midPointDifference.X * midPointDifference.Y * midPointDifference.Y));
            float distance = midPoinDistance - (a.shape.Radius + b.shape.Radius);
            return distance;
        }

        public static Vector2f CollisionDirection(Ball a, Ball b)
        {
            return a.shape.Position - b.shape.Position; //Direction from b to a
        }
        
        
}*/