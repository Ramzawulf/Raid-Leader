﻿using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Collections;
using Assets.Scripts;
using Assets.Scripts.UI;

public class UIController : MonoBehaviour
{
    public static UIController Instance;
    public Text Debug;

    public HealthBar BossHealthBar;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    public void Update()
    {
        StringBuilder message = new StringBuilder();

        for (int i = 0; i < Character.Collection.Count; i++)
        {
            message.AppendLine(Character.Collection[i].ToString());
        }

        Debug.text = message.ToString();
    }

    public void OnCharacerSelected(Character character)
    {

    }

    public void OnCharDeselected()
    {
    }

}
