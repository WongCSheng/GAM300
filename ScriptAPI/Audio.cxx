#include "Audio.hxx"
#include <ctime>

#define AW TDS::AudioWerks

static int id_num{ 0 };

namespace ScriptAPI
{
	AudioSource::AudioSource()
	{
		//audio_engine = AW::AudioEngine::get_audioengine_instance();
		deltatime = 0.f;
		wait = 0;

		//clips = gcnew System::Collections::Hashtable();
	}
	
	void AudioSource::Play(AudioComponent^ clip)
	{
		proxy_audio->ScriptPlay(clip->getFilePath());
	}

	void AudioSource::Pause(AudioComponent^ clip)
	{
		proxy_audio->ScriptPause(clip->getFilePath());
	}

	void AudioSource::Stop(AudioComponent^ clip)
	{
		proxy_audio->ScriptStop(clip->getFilePath());
	}

	void AudioSource::Load(AudioComponent^ pathing)
	{
		proxy_audio->ScriptLoad(pathing->getFilePath());
	}

	void AudioSource::Unload(AudioComponent^ clip)
	{
		proxy_audio->ScriptUnload(clip->getFilePath());
	}

	TDS::SoundInfo* AudioSource::getSound(StringP pathing)
	{
		return proxy_audio->ScriptGetSound(toStdString(pathing));
	}

	AudioComponent^ AudioSource::getAudio(StringP pathing)
	{
		return AudioComponent(proxy_audio->ScriptGetSound(toStdString(pathing)));
	}

	unsigned int AudioSource::getUniqueID(StringP pathing)
	{
		return proxy_audio->ScriptGetID(toStdString(pathing));
	}

	void AudioSource::Loop(AudioComponent^ clip, bool set)
	{
		return clip->setLoop(set);
	}

	bool AudioSource::isLooping(AudioComponent^ clip)
	{
		return clip->isLoop();
	}

	bool AudioSource::isMute(AudioComponent^ clip)
	{
		return clip->isMuted();
	}

	bool AudioSource::is3D(AudioComponent^ clip)
	{
		return clip->is3D();
	}

	bool AudioSource::isAnyPlaying()
	{
		return proxy_audio->ScriptCheckAnyPlaying();
	}

	bool AudioSource::isPlaying(AudioComponent^ clip)
	{
		return proxy_audio->CheckPlaying(clip->getFilePath());
	}

	bool AudioSource::hasFinished(AudioComponent^ clip)
	{
		return proxy_audio->checkifdone(clip->getFilePath());
	}

	/*TDS::SoundInfo* convertAtS(AudioComponent^ clip)
	{
		return (TDS::SoundInfo*)(clip);
	}*/

	/*template<typename T>
	T& AudioSource::operator=(float val)
	{
		value = val;
	}*/
}