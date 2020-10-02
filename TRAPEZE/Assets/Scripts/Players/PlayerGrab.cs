using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrab : MonoBehaviour
{
    public PlayerMind p;

    public SpringJoint2D sHinge;

    public string grabTag;
    GameObject bar;

    bool canGrab = false;
    public bool grabbed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (p.player.GetButtonDown("Grab"))
        {
            if (canGrab == true && grabbed == false)
                Grab();
        }
        else if (p.player.GetButtonUp("Grab"))
        {
            if (grabbed == true)
                LetGo();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(grabTag))
        {
            if(canGrab == true)
            {
                bar = null;
                canGrab = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(grabTag))
        {
            if(canGrab == false)
            {
                canGrab = true;
                bar = collision.gameObject;
            }
        }
    }

    void Grab()
    {
        sHinge.connectedBody = bar.GetComponent<Rigidbody2D>();
        sHinge.enabled = true;

        p.rBody.velocity = Vector2.zero;

        //p.rBody.constraints = RigidbodyConstraints2D.FreezePosition;

        grabbed = true;
        p.pSwing.canSwing = false;
        print("grabbed");
    }

    void LetGo()
    {
        //p.rBody.constraints = RigidbodyConstraints2D.None;
        grabbed = false;

        sHinge.connectedBody = null;
        sHinge.enabled = false;

        p.pSwing.canSwing = true;
        print("dropped");
    }
}
