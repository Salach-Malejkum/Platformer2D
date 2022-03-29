using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPlayerMove : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D col)
    {
        col.gameObject.transform.SetParent(gameObject.transform,true);
    }

    void OnCollisionExit2D(Collision2D col)
    {
        col.gameObject.transform.parent = null;
    }
}
