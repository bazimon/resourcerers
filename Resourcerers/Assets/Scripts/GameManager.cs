using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private RoomCreator roomCreator;

	void Awake () {
        roomCreator = GetComponent<RoomCreator>();
	}

    void InitGame()
    {
        //Call the SetupScene function of the BoardManager script, pass it current level number.
        roomCreator.SetupScene(1);

    }
}
