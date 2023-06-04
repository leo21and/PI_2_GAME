using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinnedMesh : MonoBehaviour

{
    public ParticleSystem particles;

    public SkinnedMeshRenderer renderr;

    Mesh m;

    void Start()
    {
        m = new Mesh();
    }

    void LateUpdate()
    {
        renderr.BakeMesh(m);

        var sh = particles.shape;
        sh.mesh = m;
    }
}
