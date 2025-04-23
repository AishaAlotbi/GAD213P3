using System;
using UnityEngine;

[CreateAssetMenu(fileName = "KeyDates", menuName = "Scriptable Objects/KeyDates")]
public class KeyDates : ScriptableObject
{
    public DateTime KeyDate;
    public bool yearly;
    public Sprite thumbnail;
    public string Description;
}
