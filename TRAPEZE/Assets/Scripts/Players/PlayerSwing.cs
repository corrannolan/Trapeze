using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
    public PlayerMind p;

    public bool canSwing = true;
    public float swingForce;
    public float coolTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (p.otherPlayer.pGrab.grabbed == true && canSwing == true)
        {
            if (p.player.GetButton("RSwing"))
            {
                Swing(1);
                print("RSwing");
            }
            else if (p.player.GetButton("LSwing"))
            {
                Swing(-1);
                print("LSwing");
            }

            //StartCoroutine(coolDown());
        }
    }

    void Swing(int side)
    {
        //canSwing = false;

        Vector2 swingVec = new Vector2(gameObject.transform.up.x * swingForce * side, gameObject.transform.up.y * swingForce * side);
        p.rBody.AddForce(swingVec);

        print("swung, " + swingVec);
    }

    /*IEnumerator coolDown()
    {
        yield return new WaitForSeconds(coolTime);

        canSwing = true;
    }*/
}
