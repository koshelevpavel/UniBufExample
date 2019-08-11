using System.Collections.Generic;
using ProtoBuf;
using UnityEngine;

namespace UniBuf.Tests
{
    [ProtoContract]
    public class TestUnityTypesObject
    {
        [ProtoMember(1)]
        public Vector2 v2;
        [ProtoMember(2)]
        public Vector3 v3;
        [ProtoMember(3)]
        public Vector4 v4;
        [ProtoMember(4)]
        public Color color;
        [ProtoMember(5)]
        public Quaternion quaternion;
        [ProtoMember(6)]
        public float fl;
    }
    
    [ProtoContract]
    public interface ITestInterface
    {
        string Name { get; }
    }

    [ProtoContract]
    public class TestAbstractCollection
    {
        [ProtoMember(1)]
        public ITestInterface array;
        [ProtoMember(2)]
        public List<ITestInterface> list;
        [ProtoMember(3)]
        public ITestInterface value;
    }

    [ProtoContract]
    public class TestObject1 : ITestInterface
    {
        public string Name => "TestObject1";
    }
    
    [ProtoContract]
    public class TestObject2 : ITestInterface
    {
        public string Name => "TestObject2";
    }
}