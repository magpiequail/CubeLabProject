using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleKey : MonoBehaviour
{
    public float keyPosition;
    Animator triangleKeyAnim;
    bool isWithChar = false;
    Vector2 originPos;
    SpriteRenderer sprite;

    private void Awake()
    {
        triangleKeyAnim = GetComponentInChildren<Animator>();
        originPos = transform.position;
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Character")
        {
            triangleKeyAnim.SetInteger("State", 1);
            sprite.gameObject.transform.position = new Vector2(originPos.x, originPos.y + keyPosition);
            if (Input.GetKeyDown(KeyCode.Space)&&other.GetComponentInParent<CharacterMovement>().isHavingRoundKey == false)
            {
                triangleKeyAnim.SetInteger("State", 2);
                isWithChar = true;
                gameObject.transform.SetParent(other.gameObject.transform);
                gameObject.transform.position = new Vector2(transform.position.x, transform.position.y + keyPosition );
                other.GetComponentInParent<CharacterMovement>().isHavingTriangleKey = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Character" && !isWithChar)
        {
            triangleKeyAnim.SetInteger("State", 0);
            sprite.gameObject.transform.position = originPos;
        }
    }
}
