using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneInfo : MonoBehaviour
{

    public static int remainingMoves;

    public int stageClearMinMoves;
    public int emotionMinMoves;

    // Start is called before the first frame update
    void Start()
    {
        if (stageClearMinMoves > emotionMinMoves)
        {
            Debug.LogError("the value of stage clear minimum moves is larger than the value of emotion moves");
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
