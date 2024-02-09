#ifndef SOUND
#define SOUND

#include <string>
#include <array>
#include <time.h>

#include "components/iComponent.h"
#include "Vector3.h"
#include "ecs/ecs.h"

namespace TDS
{

    static unsigned int ID_Count{ 1 };

    enum SOUND_STATE
    {
        SOUND_ERR = 0,
        SOUND_LOADED,
        OTHERS
    };

    /*namespace AudioWerks
    {
        class AudioEngine;
    }*/

    struct SoundInfo : public IComponent
    {
    private:
        std::string filePath;
        float volume;

    public:
        unsigned int uniqueID = 0, MSLength, sampleRate;
        bool isitLoop, isit3D, isitmuted;
        SOUND_STATE whatState;
        Vec3 position;
        int loopCount;
        float ReverbAmount;
        //std::map<Vec3*, SOUND_STATE*> position_events;

        /**
         * @brief Loading info from a file into SOUNDINFO.
         * @param obj
         * @return true when success.
        */
        //virtual bool Deserialize(const rapidjson::Value& obj)
        //{
        //    position = { obj["PositionX"].GetFloat(), obj["PositionY"].GetFloat(), obj["PositionZ"].GetFloat() };
        //    filePath = { obj["file"].GetString() };
        //    isitLoop = { obj["Loop"].GetBool() };
        //    isit3D = { obj["3D"].GetBool() };
        //    

        //    return true; //Change this to return based of whether it's really successful or not
        //}

        ///**
        // * @brief Storing info from SOUNDINFO into a file
        // * @param writer 
        // * @return true when success.
        //*/
        //virtual bool Serialize(rapidjson::PrettyWriter<rapidjson::StringBuffer>* writer) const
        //{
        //    writer->Key("PositionX");
        //    writer->Double(static_cast<float>(position[0]));

        //    return true; //Change this to return based of whether it's really successful or not
        //}

        // convenience method to set the 3D coordinates of the sound.
        DLL_API  void set3DCoords(float x, float y, float z);
        DLL_API  void set3DCoords(Vec3 set_this);
        DLL_API  void setFilePath(std::string _path);//, std::string _type);
        //DLL_API  void setEvents(Vec3* place, SOUND_STATE& type);

        DLL_API  bool isLoaded();
        DLL_API  bool is3D();
        DLL_API  bool isLoop();
        DLL_API  bool isMuted();

        //DLL_API  std::map<Vec3*, SOUND_STATE*> getEvents();
        DLL_API  std::string getFilePath();
        DLL_API  const char* getFilePath_inChar();
        DLL_API  float getX();
        DLL_API  float getY();
        DLL_API  float getZ();
        DLL_API  float getVolume();

        /**
        * Parameter takes in Volume values (0 - 100)
        */
        DLL_API  void setVolume(float vol);

        DLL_API  SoundInfo(std::string _filePath = "", bool _isLoop = false, bool _is3D = false, bool _muted = false, SOUND_STATE _theState = SOUND_ERR,
            float _x = 0.0f, float _y = 0.0f, float _z = 0.0f, int _loopcount = 0, float _volume = 1.f, float _reverbamount = 0.f,
            unsigned int _MSLength = 0, unsigned int _sampleRate = 0);

        // TODO  implement sound instancing
        // int instanceID = -1; 
        void operator=(const SoundInfo& rhs)
        {
            uniqueID = rhs.uniqueID;
            MSLength = rhs.MSLength;
            sampleRate = rhs.sampleRate;
            filePath = rhs.filePath;
            isitLoop = rhs.isitLoop;
            isit3D = rhs.isit3D;
            isitmuted = rhs.isitmuted;
            isitLoop = rhs.isitLoop;
            loopCount = rhs.loopCount;
            //whatState = rhs.whatState;
            position = rhs.position;
            volume = rhs.volume;
            ReverbAmount = rhs.ReverbAmount;
        }

        RTTR_ENABLE(IComponent);
        RTTR_REGISTRATION_FRIEND

    }; //end of SoundInfo struct

    DLL_API  SoundInfo* GetSoundInfo(EntityID ID);

} //end of namespace TDS

#endif