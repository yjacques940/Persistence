using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static GameController control;

    public int Attack;
    public int Defense;
    public int Health;


    private void Awake() {
        if (control == null) {
            DontDestroyOnLoad(gameObject);
            control = this;
            Attack = 5;
            Defense = 2;
            Health = 10;
        } else if (control != this) {
            Destroy(gameObject);
        }
    }
    private void OnGUI() {
        GUIStyle style = new GUIStyle();
        style.fontSize = 56;
        print(Attack.ToString());
        GUI.Label(new Rect(10, 160, 100, 30), "Attack : " + Attack.ToString(), style);
        GUI.Label(new Rect(10, 110, 100, 30), "Defense : " + Defense.ToString(), style);
        GUI.Label(new Rect(10, 60, 100, 30), "Health : " + Health.ToString(), style);
       
    }

    public void IncreaseAttack() {
        Attack += 1;
    }

    public void IncreaseDefense() {
        Defense += 1;
    }

    public void IncreaseHealth() {
        Health += 10;
    }





}
