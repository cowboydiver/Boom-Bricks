using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetryButton : MonoBehaviour
{
    [SerializeField]
    GameObject text;

    public bool isMenuActive = false;

    public void Init()
    {
        text.SetActive(true);
        isMenuActive = true;
    }

    public void Close()
    {
        isMenuActive = false;
        text.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isMenuActive)
        {
            GameManager.Instance.OpenMainMenu();
        }
    }
}
