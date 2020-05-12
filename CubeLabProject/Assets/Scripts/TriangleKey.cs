using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriangleKey : MonoBehaviour
{
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
            if (Input.GetKeyDown(KeyCode.Space)&&other.GetComponentInParent<Character>().isHavingRoundKey == false)
            {
                gameObject.transform.SetParent(other.gameObject.transform);
                gameObject.transform.position = new Vector2(transform.position.x, transform.position.y + 1.5f);
                other.GetComponentInParent<Character>().isHavingTriangleKey = true;
            }
        }
    }
}
