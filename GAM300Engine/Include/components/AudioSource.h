#ifndef AUDIOSOURCE_H_
#define AUDIOSOURCE_H_

#include <vector>
#include "fmod_engine/AudioEngine.h"
#include "Vector3.h"

namespace TDS
{
	class DLL_API AudioSource : public IComponent
	{
	public:
		AudioSource();
		~AudioSource();

		virtual bool Deserialize(const rapidjson::Value& obj);
		virtual bool Serialize(rapidjson::PrettyWriter<rapidjson::StringBuffer>* writer) const;

		void Play();
		void Stop();

		void Add(unsigned int ID, FMOD::Sound& clip);
		void remove(unsigned int ID);

		void Update();

	private:
		Vec3 position;
		float volume;
		std::map<unsigned int, FMOD::Sound*> audioclips;
	};
}

#endif