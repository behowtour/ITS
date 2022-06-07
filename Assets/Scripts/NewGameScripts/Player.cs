using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public delegate void PlayerHandler(object sender, int ordDiff);
    public event PlayerHandler OnOrdinateChangedEvent;

    private float lastOrdValue;

    void Start()
    {
        lastOrdValue = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        int coordDiff = (int)(this.transform.position.y - lastOrdValue);
        if (coordDiff >= 1)
        {
            //ScoreUp(coordDiff);
            this.OnOrdinateChangedEvent?.Invoke(this, coordDiff);
            lastOrdValue = this.transform.position.y;
        }
    }
}
