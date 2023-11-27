#pragma once

#include "ComponentBase.hxx"
#include "TransformComponent.hxx"
#include "../TypeConversion.hxx"

using si = TDS::SoundInfo;

namespace ScriptAPI
{
	public value class AudioComponent : ComponentBase
	{
	public:
		using snd = TDS::SOUND_STATE;

	public:
		void set3DCoords(float x, float y, float z);
		void set3DCoords(Vector3 in_pos);

		bool isLoaded();
		bool is3D();
		bool isLoop();
		bool isMuted();
		bool isPlaying();
		bool isPaused();
		//Check if that sound file finished playing
		bool finished();
		bool finished(System::String^ pathing);

		bool isPlaying(System::String^ pathing); //to be changed
		bool isPaused(System::String^ pathing); //to be changed

		Vector3 get3DCoords();
		snd getState();
		unsigned int getUniqueID();
		unsigned int getMSLength();
		std::string getFilePath();
		const char* getFilePath_inChar();

		void setFilePath(System::String^ str_path);

		float getX();
		float getY();
		float getZ();
		float getReverbAmount();
		float getVolume();

		void setVolume(float vol);
		void setMSLength(unsigned int len);
		void setState(snd setting);
		void setLoop(bool condition);
		void set3D(bool condition);
		void setMute(bool condition);

		//Pass in the audio file name without the extensions
		void play();
		void pause();
		void stop();

		void play(System::String^ pathing);
		void pause(System::String^ pathing);
		void stop(System::String^ pathing);

		//play the queue of sound sequentially
		void playQueue();
		void clearQueue();

		//Add to a queue of sound to be played sequentially
		void Queue(System::String^ str);

		std::function<void(snd)>* pass_in_setState;

		virtual void SetEntityID(TDS::EntityID ID);

		TransformComponent transform;

	internal:
		AudioComponent(System::String^ pathing, TDS::EntityID ID);
		TDS::EntityID GetEntityID();

	private:
		property unsigned int uniqueID
		{
			unsigned int get();
		}
		property unsigned int MSLength
		{
			unsigned int get();
			void set(unsigned int value);
		}
		property std::string filePath
		{
			std::string get();
			void set(std::string value);
		}
		property bool isitLoop
		{
			bool get();
			void set(bool value);
		}
		property bool isit3D
		{
			bool get();
			void set(bool value);
		}
		property bool isitMuted
		{
			bool get();
			void set(bool value);
		}
		property snd whatState
		{
			snd get();
			void set(snd value);
		}
		property Vector3 pos
		{
			Vector3 get();
			void set(Vector3 value);
		}
		property float volume
		{
			float get();
			void set(float value);
		}
		property float ReverbAmount
		{
			float get();
			void set(float value);
		}

		TDS::EntityID entityID;
	};
}