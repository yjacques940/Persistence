using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseAttackButton : MonoBehaviour {

    public void IncreaseAttack() {
        GameController.control.IncreaseAttack();
    }

   
}
