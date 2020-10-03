using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBuilder : MonoBehaviour
{
    public List<GameObject> stageBars = new List<GameObject>();
    public List<Vector2> barPos = new List<Vector2>();

    public PlayerMind p1, p2;
    float pFar;

    // Start is called before the first frame update
    void Start()
    {
        pFar = Mathf.Abs(Vector2.Distance(p1.Vec2Pos(p1.gameObject.transform), p2.Vec2Pos(p2.gameObject.transform)));

        foreach(GameObject bar in stageBars)
        {
            int barRef = stageBars.IndexOf(bar);

            bar.transform.position = new Vector3(barPos[barRef].x * pFar, barPos[barRef].y * pFar, bar.transform.position.z);
        }

        p1.canInput = true;
        p2.canInput = true;

        p1.StartBar(stageBars[0]);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
