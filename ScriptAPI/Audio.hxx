#pragma once
#include "IncludeFromEngine.hxx"
#include "Components/AudioComponent.hxx"
#include <fmod_engine/AudioEngine.h>
#include <components/SoundInfo.h>
#include <filesystem>

namespace ScriptAPI
{
    /*public ref class AudioClip
    {
    public:        
        void add_clips(std::filesystem::path file);
        
        System::Collections::Generic::List<System::String^> clips;
        int sub;
    };*/
    
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
        void Play(System::String^ pathing);
        //void Pause();
        void Pause(System::String^ pathing);
        //void Stop();
        void Stop(System::String^ pathing);

        void Loop(System::String^ pathing, bool set);
        //bool enabled();

        /*template<typename T>
        T& operator=(float val);*/

        bool isPlaying();
        bool isPlaying(System::String^ pathing);
        bool hasFinished(System::String^ pathing);
        void add_clips(System::String^ pathing);

        System::Collections::Hashtable^ clips; //AudioClips are attached to AudioSource
        TDS::AudioWerks::AudioEngine* audio_engine;
        unsigned long wait;
        float deltatime;
    };
}