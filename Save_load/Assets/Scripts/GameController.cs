using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static GameController control;

    public int Attack;
    public int Defense;
    public int Health;


    private void Awake() {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
            try{ LoadGame(); }
            catch { SetDefaultValue(); }

        } else if (control != this) {
            Destroy(gameObject);
        }
    }

    private void SetDefaultValue()
    {
        Attack = 5;
        Defense = 2;
        Health = 10;
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 56;
        print(Attack.ToString());
        GUI.Label(new Rect(10, 160, 100, 30), "Attack : " + Attack.ToString(), style);
        GUI.Label(new Rect(10, 110, 100, 30), "Defense : " + Defense.ToString(), style);
        GUI.Label(new Rect(10, 60, 100, 30), "Health : " + Health.ToString(), style);
       
    }

    public void IncreaseAttack()
    {
        Attack += 1;
    }

    public void IncreaseDefense()
    {
        Defense += 1;
    }

    public void IncreaseHealth()
    {
        Health += 10;
    }

    public void SaveGame()
    {
        FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat",FileMode.Create);
        PlayerData data = new PlayerData();
        data.sceneIndex = SceneController.sceneControl.GetSceneIndex();
        data.health = Health;
        data.defense = Defense;
        data.attack = Attack;
        BinaryFormatter bf = new BinaryFormatter();
        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        if(!File.Exists(Application.persistentDataPath + "/gameInfo.dat"))
        {
            throw new Exception("Game file does not exist");
        }
        FileStream file = File.Open(Application.persistentDataPath + "/gameInfo.dat", FileMode.Open);
        PlayerData data = (PlayerData)bf.Deserialize(file);
        SceneController.sceneControl.SetScene(data.sceneIndex);
        Health = data.health;
        Defense = data.defense ;
        Attack = data.attack;
        file.Close();
    }
}

[Serializable]
class PlayerData
{
    public int health;
    public int attack;
    public int defense;
    public int sceneIndex;
}
