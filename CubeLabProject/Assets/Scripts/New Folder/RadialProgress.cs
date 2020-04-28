using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialProgress : MonoBehaviour
{
    public GameObject radialBar;
    public Image fill;
    Dimension d;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        radialBar.SetActive(false);
        text.enabled = false;
        d = FindObjectOfType<Dimension>();
    }

    // Update is called once per frame
    void Update()
    {
        fill.fillAmount = d.timer*0.5f;
        StartCoroutine("ShowPercent");
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            radialBar.SetActive(true);
            text.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            radialBar.SetActive(false);
            text.enabled = false;
        }
        
    }

    IEnumerator ShowPercent()
    {
        text.text = "" + (int)((d.timer / 2)*100)+"%";
        yield return null;
    }
    
}
