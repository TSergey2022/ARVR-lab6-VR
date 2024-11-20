using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.FPS.Game;
using UnityEngine;

public class DisplayHpScript : MonoBehaviour
{
    [SerializeField] private Health health;
    [SerializeField] private TMP_Text text;

    // Update is called once per frame
    void Update()
    {
        text.text = ((int)health.CurrentHealth).ToString();
    }
}
