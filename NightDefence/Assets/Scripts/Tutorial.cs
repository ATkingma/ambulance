using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Tutorial : MonoBehaviour
{
    public TextMeshProUGUI insertHere;
    [TextArea(5, 5)] public List<string> objectives;
    private int textNumba;

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
            Invoke("AWAYYOUGO", 5);
        }
    }
    public void AWAYYOUGO()
    {
        insertHere.gameObject.SetActive(false);
    }
    public void Skip()
    {
        textNumba = 10;
        NextLine();
    }
}
