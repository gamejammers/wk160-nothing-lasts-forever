//
// (c) BLACKTRIANGLES 2020
// http://www.blacktriangles.com
//

using System.Collections.Concurrent;
using UnityEngine;

namespace blacktriangles
{
    [System.Serializable]
    public class GameObjectPool
    {
        //
        // members ////////////////////////////////////////////////////////////
        //

        public GameObject prefab                                = null;
        public Transform root                                   = null;
        public int count                                        { get { return pool.Count; } }

        private ConcurrentBag<GameObject> pool                  = new ConcurrentBag<GameObject>();

        //
        // public methods /////////////////////////////////////////////////////
        //
        
        public GameObject Take(Vector3 position, Quaternion rotation, Transform parent)
        {
            if(prefab == null) return null;

            GameObject result = null;
            if(pool.TryTake(out result))
            {
                result.SetActive(true);
            }
            else
            {
                result = GameObject.Instantiate(prefab);
            }

            result.transform.SetParent(parent);
            result.transform.localPosition = position;
            result.transform.localRotation = rotation;

            ReturnToPool ret = result.GetComponent<ReturnToPool>();
            if(ret == null)
            {
                ret = result.AddComponent<ReturnToPool>();
                ret.type = ReturnToPool.Type.Manual;
            }
            ret.SetPool(this, prefab);

            return result;
        }

        //
        // --------------------------------------------------------------------
        //
        
        public void Return(GameObject item)
        {
            item.transform.SetParent(root);
            item.SetActive(false);
            pool.Add(item);
        }
    }
}
