//
//
//

using UnityEngine;

namespace ArtTest
{
    public class EnemyVisTest
        : MonoBehaviour
    {
        //
        // members ////////////////////////////////////////////////////////////
        //

        public float maxRadius = 5f;
        public float minRadius = 1f;
        public float radiusSpeed = 3f;

        public float orbitSpeed = 2f;
        
        //
        // unity callbacks ////////////////////////////////////////////////////
        //

        protected virtual void Update()
        {
            float dist = Mathf.Sin(Time.time*radiusSpeed) * (maxRadius-minRadius) + minRadius;
            transform.position = new Vector3(dist * Mathf.Cos(Time.time*orbitSpeed), dist * Mathf.Sin(Time.time*orbitSpeed), 0f);
        }
    }
}
