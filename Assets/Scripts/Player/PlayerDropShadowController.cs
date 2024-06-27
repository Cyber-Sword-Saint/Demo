using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDropShadowController : MonoBehaviour
{
    public float idleScale;
    public float movingScale;
    [SerializeField]
    private Rigidbody2D playerRB;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = FindObjectOfType<PlayerController>().gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerRB.velocity.magnitude != 0)
        {
            Vector3 curr_scale = transform.localScale;
            curr_scale.x = movingScale;
            curr_scale.y = (float)(curr_scale.x / 3);
            this.transform.localScale = curr_scale;
        }

        else
        {
            Vector3 curr_scale = transform.localScale;
            curr_scale.x = idleScale;
            curr_scale.y = (float)(curr_scale.x / 3);
            this.transform.localScale = curr_scale;

        }
    }
}
