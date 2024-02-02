#ifndef AUDIOSOURCE_H_
#define AUDIOSOURCE_H_

#include <vector>
#include "fmod_engine/AudioEngine.h"
#include "Vector3.h"

namespace TDS
{
	/*DLL_API class AudioSource : public IComponent
	{
	public:
		AudioSource();
		~AudioSource();

		virtual bool Deserialize(const rapidjson::Value& obj);
		virtual bool Serialize(rapidjson::PrettyWriter<rapidjson::StringBuffer>* writer) const;

		void Play(SoundInfo* SI);
		void Stop(SoundInfo* SI);

		void Add(unsigned int ID, FMOD::Sound& clip);
		void remove(unsigned int ID);

		void Update();

	private:
		Vec3 position;
		float volume;
		std::map<unsigned int, FMOD::Sound*> audioclips;
	};*/
}

#endif