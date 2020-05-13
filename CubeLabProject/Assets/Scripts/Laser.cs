using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public bool isLaserActive = true;
    SpriteRenderer laserSprite;
    PolygonCollider2D laserCollider;

    private void Awake()
    {
        laserSprite = GetComponent<SpriteRenderer>();
        laserCollider = GetComponent<PolygonCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLaserActive)
        {
            laserSprite.enabled = false;
            laserCollider.enabled = false;
        }
        else
        {
            laserSprite.enabled = true;
            laserSprite.enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isLaserActive == true)
        {
            if (collision.CompareTag("Character"))
            {
                SceneController.gameState = GameState.GameOver;
            }
        }
        
    }
}
