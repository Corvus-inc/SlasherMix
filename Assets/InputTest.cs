using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    public bool jump;
    public bool sprint;
    public Vector2 move;

    // Update is called once per frame
    private void Update()
    {
        jump = Input.GetKeyDown(KeyCode.Space);
    }
}
