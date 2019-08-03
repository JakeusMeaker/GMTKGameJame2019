using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsScroll : MonoBehaviour
{
    [SerializeField]float scrollSpeed = 0.01f;
    [SerializeField]bool reverse = false;



    // Start is called before the first frame update
    void Update()
    {
        if (!reverse)
        {
            transform.position -= new Vector3(scrollSpeed * Time.deltaTime, 0, 0);
        }
        else if (reverse)
        {
            transform.position += new Vector3(scrollSpeed * Time.deltaTime, 0, 0);
        }
    }
    
}
