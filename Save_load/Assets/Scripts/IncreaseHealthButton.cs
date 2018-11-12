using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseHealthButton : MonoBehaviour {

    public void IncreaseHealth() {
        GameController.control.IncreaseHealth();
    }
}
