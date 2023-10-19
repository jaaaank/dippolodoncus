using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class griddygoolio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(new Vector3 (0, 1,0));
        Destroy(gameObject, 6.0f);
    }
}
