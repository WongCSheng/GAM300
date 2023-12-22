#include "Audio.hxx"
#include <ctime>
#include <msclr\marshal_cppstd.h>

#define AW TDS::AudioWerks

static int id_num{ 0 };

namespace ScriptAPI
{
	AudioSource::AudioSource()
	{
		//audio_engine = AW::AudioEngine::get_audioengine_instance();
		deltatime = 0.f;
		wait = 0;

		clips = gcnew System::Collections::Hashtable();
	}
	
	void AudioSource::Play(StringP pathing)
	{
		proxy_audio->ScriptPlay(toStdString(pathing));
	}

	void AudioSource::Pause(StringP pathing)
	{
		proxy_audio->ScriptPause(toStdString(pathing));
	}

	void AudioSource::Stop(StringP pathing)
	{
		proxy_audio->ScriptStop(toStdString(pathing));
	}

	void AudioSource::Load(AudioComponent^ pathing)
	{
		proxy_audio->ScriptLoad(dynamic_cast<TDS::SoundInfo*>(pathing));
	}

	void AudioSource::Unload(StringP pathing)
	{

	}

	void AudioSource::Loop(StringP pathing, bool set)
	{
		return dynamic_cast<AudioComponent^>(clips[pathing])->setLoop(set);
	}

	bool AudioSource::isLooping(StringP pathing)
	{
		return dynamic_cast<AudioComponent^>(clips[pathing])>isLoop();
	}

	bool AudioSource::isMute(StringP pathing)
	{
		return dynamic_cast<AudioComponent^>(clips[pathing])->isMuted();
	}

	bool AudioSource::is3D(StringP pathing)
	{
		return dynamic_cast<AudioComponent^>(clips[pathing])->is3D();
	}

	bool AudioSource::isAnyPlaying()
	{
		return audio_engine->AnysoundPlaying();
	}

	bool AudioSource::isPlaying(StringP pathing)
	{
		return dynamic_cast<AudioComponent^>(clips[pathing])->isPlaying();
	}

	bool AudioSource::hasFinished(StringP pathing)
	{
		return dynamic_cast<AudioComponent^>(clips[pathing])->finished();
	}

	TDS::SoundInfo* convertAtS(AudioComponent^ clip)
	{
		return reinterpret_cast<TDS::SoundInfo*>(clip);
	}

	void AudioSource::add_clips(StringP pathing, TDS::EntityID id)
	{
		AudioComponent^ temp = gcnew AudioComponent(id);
		
		clips->Add(pathing, temp);
	}

	/*template<typename T>
	T& AudioSource::operator=(float val)
	{
		value = val;
	}*/
}