using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour {

    public float speed = 1.5f;
    public GameObject object1;
    public GameObject object2;

    private Vector2 position1; //The Player
    private Vector2 position2; //The Cursor
    private Vector3 cameraPosition; //New Camera location
    private Vector3 lerp; //Lerp used for Camera
    private Vector3 offset; //

    void Start () {
        offset = transform.position - object1.transform.position; //Start the camera on the Position 1 (Player)
	}
	
	void LateUpdate () {
        position1 = new Vector2(
                object1.transform.position.x,
                object1.transform.position.y);

        if (!object2)
        {
            position2 = Input.mousePosition;
            position2 = Camera.main.ScreenToWorldPoint(position2);
        }
        else
        {
            position2 = new Vector2(
                object2.transform.position.x, 
                object2.transform.position.y);
        }

        cameraPosition.x = (position1.x + position2.x)*0.3f;
        cameraPosition.y = (position1.y + position2.y)*0.3f;
        lerp = Vector2.Lerp(transform.position, cameraPosition, speed);
		transform.position = (position1 + position2) / 2;
		transform.position += Vector3.back*10;
       // offset = new Vector3(lerp.x, lerp.y, -10);
       // transform.position = offset;
    }
}
