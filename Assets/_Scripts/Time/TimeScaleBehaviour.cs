using UnityEngine;

public class TimeScaleBehaviour : MonoBehaviour
{
    private float lastUpdateFrame;
    public bool isSlowMotion;

    public void OnUpdate(float slomoTime)
    {
        if( isSlowMotion == true && Time.time < lastUpdateFrame + slomoTime)
        {
            Debug.Log("sloved down");
            return;
        }
        lastUpdateFrame = Time.time;
    }
}
