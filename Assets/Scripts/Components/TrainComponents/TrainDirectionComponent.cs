namespace SampleProject
{
    public struct TrainDirectionComponent
    {
        public enum Direction
        {
            Forward,
            Left,
            Right
        }

        public Direction CurrentDirection;
    }
}