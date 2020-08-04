using UnityEngine;

public class TimeScaleBehaviour : MonoBehaviour
{
    private float lastUpdateFrame;
    public bool isSlowMotion;

    public bool OnUpdate(float slomoTime)
    {
        if( isSlowMotion == true && Time.time < lastUpdateFrame + slomoTime)
        {
            Debug.Log("sloved down");
            return false;
        }
        else
        {
            Debug.Log("passed");
            lastUpdateFrame = Time.time;
            return true;
        }
    }
}
