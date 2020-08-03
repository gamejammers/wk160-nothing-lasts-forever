using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public List<ISlowable> slowables;
    
    public void DoSlowmotion()
    {
        foreach (var item in slowables)
        {
            item.SlowDown();
        }
    }
    public void BackToNormal()
    {
        foreach (var item in slowables)
        {
            item.BackToNormal();
        }
    }

    /// <summary>
    /// call when a slowable created
    /// </summary>
    public void AddSlowable( ISlowable s)
    {
        slowables.Add(s);
    }
    /// <summary>
    /// call when a slowable removed
    /// </summary>
    public void RemoveSlowable( ISlowable s)
    {
        slowables.Remove(s);
    }
}
