using System.IO;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools.Utils;

namespace UniBuf.Tests
{
    public class UniBufTests
    {
        [Test]
        public void TestUnityTypes()
        {
            float fl = 0.1f;
            var v2 = new Vector2(0.1f, -2);
            var v3 = new Vector3(0.1f, -2, 4);
            var v4 = new Vector4(3, 0.5f, -1, 8);
            var color = new Color(0.1f, 0.2f, 0.3f, 0.8f);
            var quaternion = new Quaternion(0.1f, 0.7f, 1, -1);

            TestUnityTypesObject testObj = new TestUnityTypesObject();
            testObj.fl = fl;
            testObj.v2 = v2;
            testObj.v3 = v3;
            testObj.v4 = v4;
            testObj.quaternion = quaternion;
            testObj.color = color;

            using (Stream stream = new MemoryStream(256))
            {
                UniBufSerializer.Serialize(stream, testObj);
                stream.Position = 0L;
                TestUnityTypesObject obj = UniBufSerializer.Deserialize<TestUnityTypesObject>(stream);

                Assert.That(fl, Is.EqualTo(obj.fl).Using(FloatEqualityComparer.Instance));
                Assert.That(v2, Is.EqualTo(obj.v2).Using(Vector2EqualityComparer.Instance));
                Assert.That(v3, Is.EqualTo(obj.v3).Using(Vector3EqualityComparer.Instance));
                Assert.That(v4, Is.EqualTo(obj.v4).Using(Vector4EqualityComparer.Instance));
                Assert.That(quaternion, Is.EqualTo(obj.quaternion).Using(QuaternionEqualityComparer.Instance));
                Assert.That(color, Is.EqualTo(obj.color).Using(ColorEqualityComparer.Instance));
            }
        }
    }
}
