
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI insertHere;
    public GameObject imige, skippie;
    [TextArea(5, 5)] public List<string> objectives;
    public int textNumba;

    private void Start()
    {
        insertHere.text = objectives[textNumba];
    }
    public void NextLine()
    {
        textNumba++;
        insertHere.text = objectives[textNumba];
        if(textNumba > 3)
        {
            Invoke("AWAYYOUGO", 4);
        }
    }
    public void AWAYYOUGO()
    {
        insertHere.gameObject.SetActive(false);
        imige.SetActive(false);
        skippie.SetActive(false);
    }
    public void Skip()
    {
        textNumba = 10;
        NextLine();
    }
}
