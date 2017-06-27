#define EXTENDED_LOG

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// karol.ryt@gmail.com
// ta klasa jest przykladem klasy DEBUG'owej która aż printuje w start nazwe obiektu
public class DEBUG_TestScript : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        #if EXTENDED_LOG
        Debug.Log(gameObject.name);
        #endif
    }
}
