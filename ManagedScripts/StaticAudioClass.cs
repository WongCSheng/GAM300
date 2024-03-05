using ScriptAPI;
using System;
using System.Collections.Generic;

public static class AudioClass
{
    private static AudioSource audioPlayer = new AudioSource();

    public static AudioSource getAudioPlayer()
    {
        return audioPlayer;
    }
}
