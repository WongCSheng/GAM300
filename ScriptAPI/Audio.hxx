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
        
        void Play(StringP pathing);
        void Pause(StringP pathing);
        void Stop(StringP pathing);
        void Load(AudioComponent^ pathing);
        void Unload(StringP pathing);
        TDS::SoundInfo* getSound(StringP pathing);
        AudioComponent^ getAudio(StringP pathing);
        unsigned int getUniqueID(StringP pathing);

        void Loop(StringP pathing, bool set);

        /*template<typename T>
        T& operator=(float val);*/

        bool isLooping(StringP pathing);
        bool isMute(StringP pathing);
        bool is3D(StringP pathing);

        bool isAnyPlaying();
        bool isPlaying(StringP pathing);
        bool hasFinished(StringP pathing);

        //Convert from AudioComponent to SoundInfo
        TDS::SoundInfo* convertAtS(AudioComponent^ clip);

        void add_clips(StringP pathing, TDS::EntityID id);

        System::Collections::Hashtable^ clips; //Equivalent of std::map<EntityID, AudioComponent^>
        //TDS::AudioWerks::AudioEngine* audio_engine;
        TDS::proxy_audio_system* proxy_audio;
        unsigned long wait;
        float deltatime;
    };
}