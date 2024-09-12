using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public List<Enigme> enigmes = new();
    
    public static GameManager Instance { get; private set; }
    [HideInInspector] public List<Enigme.FuseType> fuseObtained = new();

    public FuseStates fuses;
    public EnigmeLayout layout;

    private void Awake()
    {
        Instance = this;
        StartCoroutine(GameLoop());
    }

    public IEnumerator GameLoop()
    {
        int i = 0;
        while (i < enigmes.Count)
        {
            enigmes[i].gameObject.SetActive(true);
            yield return new WaitUntil(() => enigmes[i].isComplete);
            yield return new WaitForSecondsRealtime(2f);
            i++;
            fuses.gameObject.SetActive(true);
            fuses.UpdateFuses();
        }
    }
}
