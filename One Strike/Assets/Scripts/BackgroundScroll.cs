using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    [SerializeField] float xSpeed = 1f;
    [SerializeField] float ySpeed = 1f;

    Vector2 pos = new Vector2(0.2f, 0.2f);
    Vector2 offset = Vector2.zero;
    Material mat;

    private void Awake()
    {
        mat = GetComponent<MeshRenderer>().material;
    }

    private void FixedUpdate()
    {
        Scroll(pos);
    }

    public void Scroll(Vector2 pos)
    {
        offset.x += pos.x * xSpeed;
        offset.y += pos.y * ySpeed;

        if(offset.x > 1f)
        {
            offset.x -= 1f;
        }
        else if(offset.x < 1f)
        {
            offset.x += 1f;
        }

        if(offset.y > 1f)
        {
            offset.y -= 1f;
        }
        else if(offset.y < 1f)
        {
            offset.y += 1f;
        }

        mat.mainTextureOffset = offset;
    }
}
