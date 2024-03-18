
using UnityEngine;
using static UnityEngine.Mathf;
public static class FunctionLibrary {

  public delegate float Function(float position, float time);
  public static Function GetFunction(int index) {
    switch (index) {
      case (1):
        return MultiWave;

      case (2):
        return MorphWave;

      case (3):
        return Ripple;

      default:
        return Wave;
    }
  }
  public static float Wave(float position, float time) {
    return Sin(PI * (position + time));
  }

  public static float MultiWave(float position, float time) {
    float y = Sin(PI * (position + time));
    y += 0.5f * Sin(2 * PI * (position + time));
    return y * (2f / 3f);
  }

  public static float MorphWave(float position, float time) {
    float morphOffset = 0.5f;
    float y = Sin(PI * (position + morphOffset * time));
    y += 0.5f * Sin(2f * PI * (position + time));
    return y * (2f / 3f);
  }

  public static float Ripple(float position, float time) {
    float distance = Abs(position);
    float y = Sin(PI * (4 * distance - time));
    return y / (1f + 10f * distance);
  }
}

