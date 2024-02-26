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
        AudioSource();
        
        void Play(AudioComponent^ clip);
        void Pause(AudioComponent^ clip);
        void Stop(AudioComponent^ clip);
        void Load(AudioComponent^ pathing);
        void Unload(AudioComponent^ clip);
        TDS::SoundInfo* getSound(StringP pathing);
        AudioComponent^ getAudio(StringP pathing);
        unsigned int getUniqueID(StringP pathing);
        static void Stop();
        static void StopAll();

        void Loop(AudioComponent^ clip, bool set);

        bool isLooping(AudioComponent^ clip);
        bool isMute(AudioComponent^ clip);
        bool is3D(AudioComponent^ clip);

        bool isAnyPlaying();
        bool isPlaying(AudioComponent^ clip);
        bool hasFinished(AudioComponent^ clip);

    internal:        
        TDS::EntityID GetEntityID()
        {
            return entityID;
        }
        void SetEntityID(TDS::EntityID ID)
        {
            entityID = ID;
        }

    public:

        //Convert from AudioComponent to SoundInfo
        //TDS::SoundInfo* convertAtS(AudioComponent^ clip);

        //System::Collections::Hashtable^ clips; //Equivalent of std::map<EntityID, AudioComponent^>
        //TDS::AudioWerks::AudioEngine* audio_engine;
        TDS::proxy_audio_system* proxy_audio;
        unsigned long wait;
        float deltatime;

        TDS::EntityID entityID;
    };
}