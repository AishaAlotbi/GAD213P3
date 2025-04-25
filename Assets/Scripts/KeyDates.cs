using System;
using UnityEngine;
using Systems.DateTime;

[CreateAssetMenu(fileName = "KeyDates", menuName = "Scriptable Objects/KeyDates")]
public class KeyDates : ScriptableObject
{
    public Systems.DateTime.DateTime KeyDate;
    public bool yearly;
    public Sprite thumbnail;
    public string Description;
}
