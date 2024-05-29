using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessor : MonoBehaviour{

    PostProcessVolume PostProcessVolumes;
    Vignette vign;
    void Start(){
        PostProcessVolumes = GameObject.Find("PostProcesser").GetComponent<PostProcessVolume>();
        
        vign = PostProcessVolumes.profile.GetSetting<Vignette>();
        //vign.intensity.Override(1f);
        vign.enabled.Override(false);
    }

    void Update(){
        
    }

    public void takeDamage() {

        vign.enabled.Override(true);
        vign.intensity.value = 0.52f;
        StartCoroutine(reduceVignette());

    }
    IEnumerator reduceVignette(){
        
        while(vign.intensity.value > 0) {
            vign.intensity.value -= Time.deltaTime;
            yield return new WaitForSeconds(0.5f);
        }
        
    }
}
