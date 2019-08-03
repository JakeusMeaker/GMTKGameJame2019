using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sprites : int
{
    Standing = 0, Ready = 1, Attacking = 2, Injured = 3, Dead = 4
}

public class CharacterAnims : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    SpriteRenderer sRenderer;
    public float newTimer;
    public static bool win;
    
    private void Awake()
    {
        sRenderer = GetComponent<SpriteRenderer>();      
    }

    void Start()
    {
        StartCoroutine(Anim());
    }

    public float SetTimer(float timer)
    {
        newTimer = timer;

        return newTimer;
    }

    IEnumerator Anim()
    {
        sRenderer.sprite = sprites[(int)Sprites.Standing];
        yield return new WaitForSeconds(2);

        sRenderer.sprite = sprites[(int)Sprites.Ready];
        yield return new WaitForSeconds(newTimer - 3f);

        sRenderer.sprite = sprites[(int)Sprites.Attacking];
        yield return new WaitForSeconds(1);

        if (!win)
        {
            if(this.tag == "Player")
            {
                sRenderer.sprite = sprites[(int)Sprites.Injured];
                yield return new WaitForSeconds(1);

                sRenderer.sprite = sprites[(int)Sprites.Dead];
                yield break;
            }
            else if(this.tag == "Enemy")
            {
                yield break;
            }
   
        }
        else if (win)
        {
            if (this.tag == "Enemy")
            {
                sRenderer.sprite = sprites[(int)Sprites.Injured];
                yield return new WaitForSeconds(1);

                sRenderer.sprite = sprites[(int)Sprites.Dead];
                yield break;
            }
            else if (this.tag == "Player")
            {
                yield break;
            }
        }
    }
}

