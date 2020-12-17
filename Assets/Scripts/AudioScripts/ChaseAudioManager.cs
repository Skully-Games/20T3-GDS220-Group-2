using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseAudioManager : MonoBehaviour
{
    #region Singleton

    public static ChaseAudioManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
}
