namespace SimpleSnake.GameObjects
{
    public interface IPoint
    {
        int CoordinateX { get; }

        int CoordinateY { get; }

        char Symbol { get; }
    }
}
