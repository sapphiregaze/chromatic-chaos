using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public AudioSource audSource;
    public AudioClip mouseDownClip;
    public AudioClip mouseUpClip;
    public AudioClip mouseOverClip;
    public AudioClip startupClip;

    void Start()
    {
        if (startupClip != null) {
            audSource.Play();
        }
    }

    public void OnMouseDown() {
        if (mouseDownClip != null) {
            audSource.PlayOneShot(mouseDownClip);
        }
    }

    public void OnMouseUp() {
        if (mouseUpClip != null) {
            audSource.PlayOneShot(mouseUpClip);
        }
    }

    public void OnMouseOver() {
        if (mouseOverClip != null) {
            audSource.PlayOneShot(mouseOverClip);
        }
    }
}