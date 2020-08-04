//
// (c) BLACKTRIANGLES 2020
// http://www.blacktriangles.com
//

using System.Collections.Concurrent;

namespace blacktriangles
{

    //
    // an unbounded memory monster of an object pool
    // but really easy to implement and use!
    //

    public class ObjectPool<T>
    {
        //
        // types //////////////////////////////////////////////////////////////
        //
        
        //
        // members ////////////////////////////////////////////////////////////
        //

        private System.Func<T> generator;
        private ConcurrentBag<T> pool;

        //
        // constructor ////////////////////////////////////////////////////////
        //

        public ObjectPool()
        {
            pool = new ConcurrentBag<T>();
            generator = ()=>{
                return (T)System.Activator.CreateInstance(typeof(T));
            };
        }

        //
        // --------------------------------------------------------------------
        //

        public ObjectPool(System.Func<T> _generator)
        {
            generator = _generator;
            pool = new ConcurrentBag<T>();
        }

        //
        // public methods /////////////////////////////////////////////////////
        //

        public T Take()
        {
            T item;
            if(pool.TryTake(out item)) return item;
            return generator();
        }

        //
        // --------------------------------------------------------------------
        //
        
        public void Return(T item)
        {
            pool.Add(item);
        }
    }
}
