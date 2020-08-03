using UnityEngine;

public class MouseWorldTracker : MonoBehaviour
{
    #if UNITY_EDITOR
    [SerializeField]
    private bool debugMode = true;
    #endif

    [SerializeField, Range(1, 20)]
    private float updateInterval = 1;
    [SerializeField, Range(0, 200)] 
    private int minimumTrackingMovement = 1;
    [SerializeField]
    private Vector2 offset = Vector2.zero;
    [SerializeField]
    private bool isTracking = true;
    [SerializeField]
    private Camera cam = null;
    private Vector2 screenSpaceMousePosition = Vector2.zero, worldSpaceMousePosition = Vector2.zero;

    public bool IsTracking { get => isTracking; set => isTracking = value; }
    public float UpdateInterval { get => updateInterval; set => updateInterval = value; }
    public int MinimumTrackingMovement { get => minimumTrackingMovement; set => minimumTrackingMovement = value; }
    public Vector2 ScreenSpaceMousePosition => screenSpaceMousePosition;
    public Vector2 WorldSpaceMousePosition => worldSpaceMousePosition;

    private void Update()
    {
        bool isUpdateFrame = (Time.frameCount % UpdateInterval) == 0;
        if (!isUpdateFrame) return;

        Vector2 currenScreenSpaceMousePosition = Input.mousePosition + (Vector3)offset;
        Vector2 screenSpaceMouseDeltaPosition = (currenScreenSpaceMousePosition - screenSpaceMousePosition);
        if (IsTracking && screenSpaceMouseDeltaPosition.magnitude >= MinimumTrackingMovement)
        {
            screenSpaceMousePosition = currenScreenSpaceMousePosition;
            worldSpaceMousePosition = cam.ScreenToWorldPoint(currenScreenSpaceMousePosition, Camera.MonoOrStereoscopicEye.Mono);
            #if UNITY_EDITOR
            if(debugMode) Debug.Log($"Time: {Time.time}\nFrame: {Time.frameCount}\nPosition: {worldSpaceMousePosition}");
            #endif
        }
    }
}