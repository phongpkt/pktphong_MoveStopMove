using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Shield", menuName = "Shields")]
public class Shield : ScriptableObject
{
    public int index;
    public Sprite icon;
    public GameObject model;
}
