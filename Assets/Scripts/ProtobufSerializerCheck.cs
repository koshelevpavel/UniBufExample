using System.IO;
using UniBuf;
using UnityEngine;

public class ProtobufSerializerCheck : MonoBehaviour
{
    private void Awake()
    {
        MyProtoClass myProtoClass = new MyProtoClass();
        myProtoClass.v2 = new Vector2(2,2);
        myProtoClass.v3 = new Vector3(2,2,0);
        myProtoClass.v4 = Vector4.negativeInfinity;

        using (Stream stream = new MemoryStream(1024))
        {
            UniBufSerializer.Serialize(stream, myProtoClass);
            stream.Position = 0L;
            MyProtoClass desClass = UniBufSerializer.Deserialize<MyProtoClass>(stream);
            
            Debug.Log(desClass.v2);
            Debug.Log(desClass.v3);
            Debug.Log(desClass.v4);

            transform.position = desClass.v3;
        }
        
    }
}
