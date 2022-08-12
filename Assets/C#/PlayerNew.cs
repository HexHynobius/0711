using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNew : MonoBehaviour
{
    public PlayControl PlayControls;
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        PlayControls=new PlayControl();
        PlayControls.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vector2d = PlayControls.Player.Movement.ReadValue<Vector2>();
        transform.Translate(vector2d.x * Speed * Time.deltaTime, 0, vector2d.y * Speed * Time.deltaTime);
    }
}
