public class GoldenApple : Food
{
    public override int Points => 5;

    public override void OnEaten(SnakeController snake)
    {
        base.OnEaten(snake);
        snake.Grow(2); 
    }
}