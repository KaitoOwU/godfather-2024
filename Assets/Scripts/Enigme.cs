using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enigme : MonoBehaviour
{
    public enum FuseType
    {
        RED,
        BLUE,
        YELLOW,
        WHITE
    }

    public int code;
    public string hint;
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
