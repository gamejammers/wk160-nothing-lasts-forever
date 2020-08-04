//
// (c) BLACKTRIANGLES 2020
// http://www.blacktriangles.com
//

using System.Collections;
using UnityEngine;

namespace blacktriangles
{
    public class ReturnToPool
        : MonoBehaviour
    {
        //
        // types //////////////////////////////////////////////////////////////
        //

        public enum Type
        {
            Automatic,
            Manual,
        }
        
        //
        // members ////////////////////////////////////////////////////////////
        //

        public Type type                                        = Type.Automatic;
        public bool isAutomatic                                 { get { return type == Type.Automatic; } }
        public float delaySec                                   = 1.0f;
        public GameObjectPool pool                              { get; private set; }
        public GameObject prefab                                { get; private set; }

        //
        // public methods /////////////////////////////////////////////////////
        //

        public void SetPool(GameObjectPool pool, GameObject prefab)
        {
            this.pool = pool;
            this.prefab = prefab;
            if(isAutomatic)
            {
                StartCoroutine(ReturnInSec(delaySec));
            }
        }

        //
        // --------------------------------------------------------------------
        //

        public void Return()
        {
            if(pool != null)
            {
                pool.Return(gameObject);
            }
        }

        //
        // private methods ////////////////////////////////////////////////////
        //
        
        private IEnumerator ReturnInSec(float delay)
        {
            yield return new WaitForSeconds(delay);
            Return();
        }
    }
}
