using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleKey : MonoBehaviour
{
    public float keyPosition;

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
            if (Input.GetKeyDown(KeyCode.Space)&&other.GetComponentInParent<CharacterMovement>().isHavingRoundKey == false)
            {
                gameObject.transform.SetParent(other.gameObject.transform);
                gameObject.transform.position = new Vector2(transform.position.x, transform.position.y + keyPosition );
                other.GetComponentInParent<CharacterMovement>().isHavingTriangleKey = true;
            }
        }
    }
}
