using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TimeManager : MonoBehaviour
{
    public List<TimeScaleBehaviour> slowables;
    
    public void DoSlowmotion(InputAction.CallbackContext _ctx)
    {
        foreach (var item in slowables)
        {
            item.isSlowMotion = true;
            Debug.Log("item.name");
        }
    }
    public void BackToNormal(InputAction.CallbackContext _ctx)
    {
        foreach (var item in slowables)
        {
            item.isSlowMotion = false;
        }
    }

    /// <summary>
    /// call when a slowable created
    /// </summary>
    public void AddSlowable( TimeScaleBehaviour s)
    {
        slowables.Add(s);
    }
    /// <summary>
    /// call when a slowable removed
    /// </summary>
    public void RemoveSlowable( TimeScaleBehaviour s)
    {
        slowables.Remove(s);
    }
}
