﻿using UnityEngine;
using System.Collections;

public class ReplaySystem : MonoBehaviour {

    private const int bufferFrames = 500;
    private MyKeyFrame[] keyFrames = new MyKeyFrame[bufferFrames];
    private Rigidbody rigidBody;
    private GameManager manager;

	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        manager = FindObjectOfType<GameManager>();
	}
	
	// Update is called once per frame
	void Update () {
        if (manager.recording)
        {
            Record();
        }
        else {
            PlayBack();
        }
	}

    void PlayBack() {
        rigidBody.isKinematic = true;
        int frame = Time.frameCount % bufferFrames;
        transform.position = keyFrames[frame].position;
        transform.rotation = keyFrames[frame].rotation;
    }

    void Record() {
        rigidBody.isKinematic = true;
        int frame = Time.frameCount % bufferFrames;
        float time = Time.time;

        keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
    }
}

public class MyKeyFrame {
    public float frameTime;
    public Vector3 position;
    public Quaternion rotation;

    public MyKeyFrame(float aTime, Vector3 aPosition, Quaternion aRotation) {
        frameTime = aTime;
        position = aPosition;
        rotation = aRotation;
    }
}
