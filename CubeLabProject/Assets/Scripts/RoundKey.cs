using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundKey : MonoBehaviour
{
    public float keyPosition;
    Animator roundKeyAnim;
    Vector2 originPos;
    SpriteRenderer sprite;
    bool isWithChar = false;

    private void Awake()
    {
        roundKeyAnim = GetComponentInChildren<Animator>();
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
            roundKeyAnim.SetInteger("State", 1);
            sprite.gameObject.transform.position = new Vector2(originPos.x, originPos.y + keyPosition);
            if (Input.GetKeyDown(KeyCode.Space) && other.GetComponentInParent<CharacterMovement>().isHavingTriangleKey == false)
            {
                isWithChar = true;
                roundKeyAnim.SetInteger("State", 2);
                gameObject.transform.SetParent(other.gameObject.transform);
                gameObject.transform.position = new Vector2(transform.position.x, transform.position.y + keyPosition);
                other.GetComponentInParent<CharacterMovement>().isHavingRoundKey = true;

            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Character" && !isWithChar)
        {
            roundKeyAnim.SetInteger("State", 0);
            sprite.gameObject.transform.position = originPos;
        }
    }

}
