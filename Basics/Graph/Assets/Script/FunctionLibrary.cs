
using UnityEngine;
using static UnityEngine.Mathf;
public static class FunctionLibrary {

  public delegate float Function(float positionX, float positionZ, float time);

  public enum FunctionName { Wave, MultiWave, MorphWave, Ripple };
  static Function[] functions = { Wave, MultiWave, MorphWave, Ripple };
  public static Function GetFunction(FunctionName index) {
    return functions[(int)index];
  }
  public static float Wave(float positionX, float positionZ, float time) {
    return Sin(PI * (positionX + time));
  }

  public static float MultiWave(float positionX, float positionZ, float time) {
    float y = Sin(PI * (positionX + time));
    y += 0.5f * Sin(2 * PI * (positionX + time));
    return y * (2f / 3f);
  }

  public static float MorphWave(float positionX, float positionZ, float time) {
    float morphOffset = 0.5f;
    float y = Sin(PI * (positionX + morphOffset * time));
    y += 0.5f * Sin(2f * PI * (positionX + time));
    return y * (2f / 3f);
  }

  public static float Ripple(float positionX, float positionZ, float time) {
    float distance = Abs(positionX);
    float y = Sin(PI * (4 * distance - time));
    return y / (1f + 10f * distance);
  }
}

