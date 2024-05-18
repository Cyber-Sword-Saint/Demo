using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MiniGameController : MonoBehaviour
{
    public KeyCode key;
    public float speed = 1f;
    public Vector3 posA;
    public Vector3 posB;
    public GameObject slider;
    public bool keyPressed = false;
    public TextMeshProUGUI miniGameResultUI;
    public GameObject hitPoint;
    public Sprite hitSprite;
    public Sprite origSprite;
    public float perfectLowerbound = -14.5f;
    public float perfectUpperbound = 14.5f;
    public float hitLowerbound = -44.5f ;
    public float hitUpperbound = 44.5f;
    public NPCStats currNPCStats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            keyPressed = true;
            hitPoint.GetComponent<Image>().sprite = hitSprite;
            if (slider.transform.localPosition.x >= perfectLowerbound && slider.transform.localPosition.x <= perfectUpperbound)
            {
                miniGameResultUI.text = "Perfect!";
                EventBus.Publish(new MiniGamePerfectEvent());
            }

            else if (slider.transform.localPosition.x >= hitLowerbound && slider.transform.localPosition.x <= hitUpperbound)
            {
                miniGameResultUI.text = "Hit!";
                EventBus.Publish(new MiniGameHitEvent());
            }

            else
            {
                miniGameResultUI.text = "Fail";
                EventBus.Publish(new MiniGameFailEvent());
            }
        }

        if (this.gameObject.activeSelf && !keyPressed)
        {
            float time = Mathf.PingPong(Time.time * speed, 1);

            // Interpolate the position of the GameObject between pointA and pointB
            slider.transform.localPosition = Vector3.Lerp(posA, posB, time);
        }
    }

    public void RestGame()
    {
        Debug.Log("Reset MiniGame");
        slider.transform.localPosition = posA;
        miniGameResultUI.text = "";
        slider.GetComponent<Image>().sprite = origSprite;
        keyPressed = false;
    }
}
