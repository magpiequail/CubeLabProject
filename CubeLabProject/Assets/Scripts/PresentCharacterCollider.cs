using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresentCharacterCollider : MonoBehaviour
{
    public GameObject livingroom;
    public GameObject room1;
    public GameObject room2;

    public Cinemachine.CinemachineVirtualCamera cam;

    SpriteRenderer room1Sprite;
    SpriteRenderer room2Sprite;
    SpriteRenderer livingroomSprite;

    // Start is called before the first frame update
    void Start()
    {
        room1Sprite = room1.GetComponent<SpriteRenderer>();
        room2Sprite = room2.GetComponent<SpriteRenderer>();
        livingroomSprite = livingroom.GetComponent<SpriteRenderer>();

        room1Sprite.enabled = false;
        room2Sprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Room1")
        {
            cam.Follow = room1.transform;
            room1Sprite.enabled = true;
            room2Sprite.enabled = false;
            livingroomSprite.enabled = false;
        }
        if (collision.collider.tag == "Room2")
        {
            cam.Follow = room2.transform;
            room1Sprite.enabled = false;
            room2Sprite.enabled = true;
            livingroomSprite.enabled = false;
        }
        if (collision.collider.tag == "Living Room")
        {
            cam.Follow = transform.parent.transform;
            room1Sprite.enabled = false;
            room2Sprite.enabled = false;
            livingroomSprite.enabled = true;
        }
    }
}
