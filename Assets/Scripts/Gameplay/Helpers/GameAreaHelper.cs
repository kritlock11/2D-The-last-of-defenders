using UnityEngine;

namespace Gameplay.Helpers
{
    public static class GameAreaHelper
    {
        public static int LeftBound { get; } = -9;
        public static int RightBound { get; } = 9;
        public static int DownBound { get; } = -18;
        public static int TopBound { get; } = 18;

        public static bool CheckPlayArea(Transform obj, Bounds objectBounds)
        {
            var y = obj.position.y;
            var x = obj.position.x;

            return x < LeftBound - objectBounds.extents.x || x > RightBound + objectBounds.extents.x ||
                   y < DownBound - objectBounds.extents.y || y > TopBound + objectBounds.extents.y;
        }

        public static int CheckBorders(Transform obj)
        {
            var x = obj.position.x;
            return x < LeftBound ? -1 : x > RightBound ? 1 : 0;
        }
    }
}
