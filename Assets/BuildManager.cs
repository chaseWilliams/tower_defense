using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    private GameObject turretToBuild;
    public static BuildManager instance;

    public GameObject standardTurretPrefab;

    void Awake() {
        if (instance != null) {
            Debug.LogError("More than one BuildManager");
        }
        instance = this;

    }

    void Start() {
        turretToBuild = standardTurretPrefab;
    }

	public GameObject GetTurretToBuild() {
        return turretToBuild;
    }
}
