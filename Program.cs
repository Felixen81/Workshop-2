using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        using (RenderWindow win = new RenderWindow(new VideoMode(800, 600), "window"))
        {
            
            win.Closed += (o, e) => win.Close();
            
            

            Vector2f direction = new Vector2f(1, 1);
            float speed = 50f;


            List<Ball> balls = new List<Ball>();
           balls.Add(new Ball());

            Clock clock = new Clock();
           // bool isPressed = true;
           // bool wasPressed = false;
            

            while (win.IsOpen)
            {
                
                float deltaTime = clock.Restart().AsSeconds();
                win.DispatchEvents();
                foreach (Ball ball in balls)
                {
                    ball.Update((deltaTime));
                    
                }
                win.Clear(new Color(30, 250, 200));

                for (int i = 0; i < balls.Count; i++)
                {
                    for (int j = i + 1; j < balls.Count; j++)
                    {
                        if(Ball.Distance(balls[i], balls[j]) < 0)
                        {
                            Vector2f collisionDirection = Ball.CollisionDirection(balls[i], balls[j]);
                            balls[j].HandleCollision(collisionDirection);
                            balls[i].HandleCollision(-collisionDirection);
                            
                        }
                    }
                }
                
                foreach (Ball ball in balls)
                {
                   
                    ball.Draw(win);
                }
                
                if (Mouse.IsButtonPressed(Mouse.Button.Left))
                {
                    balls.Add((new Ball()));

                }
                
               
                
                
                win.Display();
                

            }

        }

    
    
     
    }
    public class Ball
    {
        private CircleShape shape;
        private Vector2f direction = new Vector2f(1,1);
        private float speed = 100f;


        public Ball()
        {
            shape = new CircleShape(radius: 30);
            shape.FillColor = Color.Red;
            shape.Origin = new Vector2f(30, 30);
            shape.Position = new Vector2f(400, 300);

            Random rand = new Random();
            float X= rand.Next(0, 2);
            X *= 2;
            X -= 1;
            float Y = (rand.Next(0,2)* 2)- 1;
            direction = new Vector2f(X, Y);
            speed = rand.Next(30, 100);

        }
        
        public void Update(float deltaTime)
        {
            shape.Position += direction * speed * deltaTime;
            if (shape.Position.X < 0) //Left side
            {
                shape.Position = new Vector2f(0, shape.Position.Y);
                direction.X = 1;
            }
            else  if(shape.Position.X > 800) //Right side
            {
                shape.Position = new Vector2f(800, shape.Position.Y);
                direction.X = -1;

            }
            if (shape.Position.Y < 0) //UP
            {
                shape.Position = new Vector2f(shape.Position.X, 0);
                direction.Y = 1;
            }
            else if(shape.Position.Y > 600) //Down
            {
                shape.Position = new Vector2f(shape.Position.X, 600);
                direction.Y = -1;
            }
        }

        public void Draw(RenderWindow rw)
        {
            rw.Draw((shape));
        }

        public void HandleCollision(Vector2f collsionDirection)
        {
            direction = (-collsionDirection)/ (MathF.Sqrt((collsionDirection.X * collsionDirection.X * collsionDirection.Y * collsionDirection.Y)));
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
        
    }

   
}