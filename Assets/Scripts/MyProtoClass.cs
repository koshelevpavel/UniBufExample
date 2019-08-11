using ProtoBuf;
using UnityEngine;

[ProtoContract]
public class MyProtoClass
{
    [ProtoMember(1)]
    public Vector2 v2;

    [ProtoMember(2)]
    public Vector3 v3;
    
    [ProtoMember(3)]
    public Vector4 v4;
}