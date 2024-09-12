using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enigme : MonoBehaviour
{
    public enum FuseType{RED = 1, BLUE = 2, YELLOW = 3,WHITE = 4}
    
    public int code;
    public FuseType fuseType;
    public bool isComplete;

    public void ButtonClicked()
    {
        GameManager.Instance.layout.Init(code, this);
        GameManager.Instance.fuses.gameObject.SetActive(false);
        GameManager.Instance.layout.gameObject.SetActive(true);
    }

    public void Complete()
    {
        GameManager.Instance.fuseObtained.Add(fuseType);
        Destroy(gameObject);
        isComplete = true;
    }

}
