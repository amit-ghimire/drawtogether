using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MeshBrush : NetworkBehaviour
{
    //[Server]
    //private void Start()
    //{
    //    var data = NetworkedTexturePaint.GetAllTextureData();
    //    var zippeddata = data.Compress();

    //    RpcSendFullTexture(zippeddata);
    //}

    //[ClientRpc]
    //private void RpcSendFullTexture(byte[] textureData)
    //{
    //    NetworkedTexturePaint.SetAllTextureData(textureData.Decompress());
    //}
    // Update is called once per frame
    void Update()
    {
        // ---------------------------------------------------------------------------
        // Setting up Mouse Parameters

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector4 mwp = Vector3.positiveInfinity;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject.tag == "PaintObject")
                mwp = hit.point;
        }

        mwp.w = Input.GetMouseButton(0) ? 1 : 0;
        Shader.SetGlobalVector("_Mouse", mwp);
        Camera.main.GetComponent<TexturePaint>().ApplyMeshPaint();
        BrushAreaWithColor(mwp);
        CmdBrushAreaWithColorOnServer(mwp);
    }

    [Command]
    private void CmdBrushAreaWithColorOnServer(Vector3 mousePosition)
    {
        RpcBrushAreaWithColorOnClients(mousePosition);
        BrushAreaWithColor(mousePosition);
    }

    [ClientRpc]
    private void RpcBrushAreaWithColorOnClients(Vector3 mousePosition)
    {
        BrushAreaWithColor(mousePosition);
    }

    private void BrushAreaWithColor(Vector3 mousePosition)
    {
        Debug.Log("called");
        Shader.SetGlobalVector("_Mouse", mousePosition);
        Camera.main.GetComponent<TexturePaint>().ApplyMeshPaint();
    }
}
