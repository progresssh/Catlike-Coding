
using System;
using UnityEngine;
using static UnityEngine.Mathf;
public static class FunctionLibrary {

  public delegate Vector3 Function(float u, float v, float time);

  public enum FunctionName { Wave, MultiWave, MorphWave, Ripple, Curves, Sphere };
  static Function[] functions = { Wave, MultiWave, MorphWave, Ripple, Curves, Sphere };
  public static Function GetFunction(FunctionName index) {
    return functions[(int)index];
  }
  public static Vector3 Wave(float u, float v, float time) {
    Vector3 position;
    position.x = u;
    position.y = Sin(PI * (u + v + time));
    position.z = v;
    return position;
  }

  public static Vector3 MultiWave(float u, float v, float time) {
    float y = Sin(PI * (u + time));
    y += 0.5f * Sin(2 * PI * (v + time));

    Vector3 position;
    position.x = u;
    position.y = y * (2f / 3f);
    position.z = v;

    return position;
  }

  public static Vector3 MorphWave(float u, float v, float time) {
    float morphOffset = 0.5f;
    float y = Sin(PI * (u + morphOffset * time));
    y += 0.5f * Sin(2f * PI * (u + time));

    Vector3 position;
    position.x = u;
    position.y = y * (2f / 3f);
    position.z = v;

    return position;
  }

  public static Vector3 Ripple(float u, float v, float time) {
    float distance = Sqrt(u * u + v * v);
    float y = Sin(PI * (4 * distance - time));

    Vector3 position;
    position.x = u;
    position.y = y / (1f + 10f * distance);
    position.z = v;

    return position;
  }

  public static Vector3 Curves(float u, float v, float time) {
    Vector3 position;

    position.x = u;
    position.y = Sin(PI * (time * v + u));
    position.z = v;

    return position;
  }

  public static Vector3 Sphere(float u, float v, float time) {
    float r = Cos(0.5f * PI * v);

    Vector3 position;

    position.x = r * Sin(PI * u);
    position.y = Sin(PI * 0.5f * v);
    position.z = r * Cos(PI * u);

    return position;
  }
}

