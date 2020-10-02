using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;
using System.Runtime.InteropServices.WindowsRuntime;

public class PlayerMind : MonoBehaviour
{
    public Player player;
    public int playerNum;

    public PlayerMind otherPlayer;

    public PlayerSwing pSwing;
    public PlayerGrab pGrab;

    public Rigidbody2D rBody;

    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(playerNum);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 Vec2Pos(Transform obj)
    {
        Vector2 objPos2D = new Vector2(obj.position.x, obj.position.y);

        return (objPos2D);
    }
}
