using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoordinateUI : MonoBehaviour
{
    public char letter;

    public GameObject display;

    private TMP_Text displayText;

    private Button b;

    private int num;

    private GameObject tiles;

    private TileScript ts;

    // Start is called before the first frame update
    void Start()
    {
        displayText = display.GetComponent<TMP_Text>();
    }

    void OnTriggerEnter(Collider c)
    {
        gameObject.SetActive(false);
        b = gameObject.GetComponent<Button>();
        b.onClick.Invoke();
    }

    void Update()
    {
    }

    public void updateLetter()
    {
        displayText.text = letter.ToString();
    }

    public void updateNum()
    {
        if (displayText.text.Length == 2)
        {
            displayText.text = displayText.text[0] + num.ToString();
            num++;
        }
        else if (displayText.text.Length == 1)
        {
            num = 0;
            displayText.text += num.ToString();
            num++;
        }
        if (num == 8)
        {
            num = 0;
        }
    }

    public void submitHandler()
    {
        if (displayText.text.Length != 2)
        {
            return;
        }
        tiles = GameObject.FindGameObjectWithTag("Tiles");
        ts = tiles.GetComponent<TileScript>();
        ts.displaySpecificCoordinate(displayText.text);
    }
}
