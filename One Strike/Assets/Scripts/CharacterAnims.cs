using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sprite : int
{
    Standing = 0, Ready = 1, Attacking = 2, Injured = 3, Dead = 4
}

public class CharacterAnims : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    SpriteRenderer sRenderer;

    private void Awake()
    {
        sRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {

    }

    IEnumerator Anim()
    {
        yield return null;
    }
}

