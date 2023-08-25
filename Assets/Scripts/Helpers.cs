using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Thank you to Tarodev for showing me this code!
public static class Helpers
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0,45,0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}
