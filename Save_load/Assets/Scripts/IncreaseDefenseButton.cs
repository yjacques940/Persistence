using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseDefenseButton : MonoBehaviour {

    public void IncreaseDefense() {
        GameController.control.IncreaseDefense();
    }
}
