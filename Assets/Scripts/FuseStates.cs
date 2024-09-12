using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class FuseStates : MonoBehaviour
{
    public TMP_Text title;
    public List<TMP_Text> fuse = new();

    public void UpdateFuses()
    {
        for (var i = 0; i < fuse.Count; i++)
        {
            fuse[i].text = GameManager.Instance.fuseObtained.Contains((Enigme.FuseType)i) ? "<color=green>V" : "X";
        }

        if (fuse.All(x => x.text == "<color=green>V"))
        {
            title.text = "FUSIBLES DÉCONNECTÉS";
        }
    }
    
}
