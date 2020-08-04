//=============================================================================
//
// (C) BLACKTRIANGLES 2015
// http://www.blacktriangles.com
//
// Howard N Smith | hsmith | howard@blacktriangles.com
//
//=============================================================================

﻿using UnityEngine;
using System.Collections;

namespace blacktriangles
{
    public class DetachOnAwake
        : MonoBehaviour
    {
        // unity callbacks ////////////////////////////////////////////////////
        protected virtual void Awake()
        {
            transform.SetParent( null, true );
        }
    }
}
