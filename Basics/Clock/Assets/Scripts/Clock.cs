using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
  const float hoursToDegrees = -30f, minutesToDegrees = -6f, secondsToDegrees = -6f;


  [SerializeField]
  Transform hoursPivot, minutesPivot, secondsPivot;

  void Update()
  {
    TimeSpan preciseTime = DateTime.Now.TimeOfDay;

    hoursPivot.localRotation =
      Quaternion.Euler(0f, 0f, hoursToDegrees * (float)preciseTime.TotalHours);
    minutesPivot.localRotation =
      Quaternion.Euler(0f, 0f, minutesToDegrees * (float)preciseTime.TotalMinutes);
    secondsPivot.localRotation = Quaternion.Euler(0f, 0f, secondsToDegrees * (float)preciseTime.TotalSeconds);
  }

}

