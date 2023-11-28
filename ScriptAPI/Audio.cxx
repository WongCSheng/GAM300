#include "Audio.hxx"
#include <ctime>
#include <msclr\marshal_cppstd.h>

#define AW TDS::AudioWerks

static int id_num{ 0 };

namespace ScriptAPI
{
	AudioSource::AudioSource()
	{
		audio_engine = AW::AudioEngine::get_audioengine_instance();
		deltatime = 0.f;
		wait = 0;

		clips = gcnew System::Collections::Hashtable();
	}
	
	//void AudioSource::Play(unsigned long delay)
	//{
	//	if (delay > 0)
	//	{
	//		//deltatime = time(NULL);
	//	}
	//	else
	//	{			
	//		TDS::SoundInfo temp(toStdString(clips[]);
	//		
	//		audio_engine->playSound(temp);
	//	}
	//}

	void AudioSource::Play(StringP pathing)
	{
		AudioComponent^ temp = dynamic_cast<AudioComponent^>(clips[pathing]);
		temp->play();
	}

	void AudioSource::Pause(StringP pathing)
	{
		AudioComponent^ temp = dynamic_cast<AudioComponent^>(clips[pathing]);
		temp->pause();
	}

	void AudioSource::Stop(StringP pathing)
	{
		AudioComponent^ temp = dynamic_cast<AudioComponent^>(clips[pathing]);
		temp->stop();
	}

	/*void AudioSource::Pause()
	{
		msclr::interop::marshal_context context;
		std::string str = context.marshal_as<std::string>(clip->clips[clip->sub]);

		TDS::SoundInfo temp(str);

		audio_engine->pauseSound(temp);
	}

	void AudioSource::Stop()
	{
		msclr::interop::marshal_context context;
		std::string str = context.marshal_as<std::string>(clip->clips[clip->sub]);

		TDS::SoundInfo temp(str);

		audio_engine->stopSound(temp);
	}*/

	void AudioSource::Loop(StringP pathing, bool set)
	{
		AudioComponent^ temp = dynamic_cast<AudioComponent^>(clips[pathing]);
		temp->setLoop(set);
	}

	/*bool AudioSource::enabled()
	{
		msclr::interop::marshal_context context;
		std::string str = context.marshal_as<std::string>(clip->clips[clip->sub]);

		TDS::SoundInfo temp(str);

		return true;
	}*/

	bool AudioSource::isLooping(StringP pathing)
	{
		AudioComponent^ temp = dynamic_cast<AudioComponent^>(clips[pathing]);
		return temp->isLoop();
	}

	bool AudioSource::isMute(StringP pathing)
	{
		AudioComponent^ temp = dynamic_cast<AudioComponent^>(clips[pathing]);
		return temp->isMuted();
	}

	bool AudioSource::is3D(StringP pathing)
	{
		AudioComponent^ temp = dynamic_cast<AudioComponent^>(clips[pathing]);
		return temp->is3D();
	}

	bool AudioSource::isAnyPlaying()
	{
		return audio_engine->AnysoundPlaying();
	}

	bool AudioSource::isPlaying(StringP pathing)
	{
		AudioComponent^ temp = dynamic_cast<AudioComponent^>(clips[pathing]);
		return temp->isPlaying();
	}

	bool AudioSource::hasFinished(StringP pathing)
	{
		AudioComponent^ temp = dynamic_cast<AudioComponent^>(clips[pathing]);
		return temp->finished();
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