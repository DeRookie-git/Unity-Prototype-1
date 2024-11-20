using System;
using UnityEngine;

public class CheckpointsCounter
{
    public static Range GetActiveWaypointRange(int currentIndex, int totalCheckpoints)
    {
        Index start = currentIndex >= 0 ? new Index(currentIndex, fromEnd: false) : Index.Start;
        Index end = currentIndex + 1 < totalCheckpoints ? new Index(currentIndex + 1, fromEnd: false) : Index.End;
        return start..end;
    }
}
