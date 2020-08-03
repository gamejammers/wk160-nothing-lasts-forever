using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseScript : MonoBehaviour
{
    #if UNITY_EDITOR
    [SerializeField]
    private bool debugMode = true;
    #endif

    [SerializeField, Range(1, 50)]
    private int updateInterval = 1;
    [SerializeField]
    private MouseWorldTracker mouseTracker = null;

    private void LateUpdate()
    {
        bool isUpdateFrame = (Time.frameCount % updateInterval) == 0;
        if (!mouseTracker.IsTracking || !isUpdateFrame || transform.position == (Vector3)mouseTracker.WorldSpaceMousePosition) return;
        transform.position = mouseTracker.WorldSpaceMousePosition;
        #if UNITY_EDITOR
        if(debugMode) Debug.Log($"Time: {Time.time} - Follower Position: {transform.position}");
        #endif
    }
}