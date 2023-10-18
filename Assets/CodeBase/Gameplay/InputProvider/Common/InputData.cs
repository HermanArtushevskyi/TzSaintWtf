using Vector2 = UnityEngine.Vector2;

namespace CodeBase.Gameplay.InputProvider.Common
{
    public struct InputData
    {
        public Vector2 MovementDirection;
        
        public static InputData Empty => new InputData()
        {
            MovementDirection = Vector2.zero
        };
    }
}