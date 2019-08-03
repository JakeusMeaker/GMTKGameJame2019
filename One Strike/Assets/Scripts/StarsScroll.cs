using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsScroll : MonoBehaviour
{
    float scrollSpeed = 0.01f;



    // Start is called before the first frame update
    void Update()
    {
        transform.position -= new Vector3(scrollSpeed * Time.deltaTime, 0, 0);
    }
    
}
