using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionManager : MonoBehaviour {

    #region Singleton
    public static InfectionManager instance;
    void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject infection;

}
