#pragma once
#include "IncludeFromEngine.hxx"
#include "Components/AudioComponent.hxx"
#include <fmod_engine/AudioEngine.h>
#include <components/SoundInfo.h>
#include <filesystem>

namespace ScriptAPI
{
    #define StringP System::String^
    
    public ref class AudioSource
    {
    public:
        /*static ref struct volume
        {
            float value;
        };
        
        static ref struct pitch
        {
            float value;
        };*/

    public:
        AudioSource();
        
        //void Play(unsigned long delay);
        void Play(StringP pathing);
        void Pause(StringP pathing);
        void Stop(StringP pathing);

        void Loop(StringP pathing, bool set);
        //bool enabled();

        /*template<typename T>
        T& operator=(float val);*/

        bool isLooping(StringP pathing);
        bool isMute(StringP pathing);
        bool is3D(StringP pathing);

        bool isAnyPlaying();
        bool isPlaying(StringP pathing);
        bool hasFinished(StringP pathing);
        void add_clips(StringP pathing);

        System::Collections::Hashtable^ clips; //AudioClips are attached to AudioSource
        TDS::AudioWerks::AudioEngine* audio_engine;
        unsigned long wait;
        float deltatime;
    };
}