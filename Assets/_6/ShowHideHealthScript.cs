using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideHealthScript : MonoBehaviour
{
    [SerializeField] private GameObject healthCanvas;
    private void OnTriggerExit(Collider other)
    {
        healthCanvas.SetActive(!healthCanvas.activeSelf);
        StartCoroutine(DisableForSeconds(other));
        Debug.Log("Toggle canvas");
    }
    
    public IEnumerator DisableForSeconds(Collider other)
    {
        other.enabled = false; // Отключаем скрипт
        yield return new WaitForSeconds(2.0f); // Ждём указанное количество секунд
        other.enabled = true; // Включаем скрипт обратно
    }
}
