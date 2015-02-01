using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Main : MonoBehaviour {

    public GameObject panel;
    public GameObject button;
	public float spawnRate;

	private List<GameObject> buttons;
    private float lastSpawnTime;
    private int buttonCount;

	void Start () {
		buttons = new List<GameObject>();
        lastSpawnTime = 0;
        buttonCount = 0;
	}
	
	void Update () {
        if (buttons.Count < 10 && Time.time - spawnRate >= lastSpawnTime)
        {
            Debug.Log("added button " + Time.time);
            GameObject newButton = (GameObject) GameObject.Instantiate(button);
            newButton.GetComponentInChildren<Text>().text = "Button " + (buttonCount + 1);
            newButton.GetComponent<Button>().onClick.AddListener(() => {
                buttons.Remove(newButton);
                GameObject.Destroy(newButton);
            });
            newButton.transform.SetParent(panel.transform);
            buttons.Add(newButton);
            lastSpawnTime = Time.time;
            buttonCount++;
        }
	}
}
