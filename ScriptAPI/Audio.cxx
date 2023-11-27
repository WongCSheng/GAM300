#include "Audio.hxx"
#include <ctime>
#include <msclr\marshal_cppstd.h>

using namespace TDS::AudioWerks;

static int id_num{ 0 };

namespace ScriptAPI
{
	AudioSource::AudioSource()
	{
		audio_engine = AudioEngine::AudioEngine::get_audioengine_instance();
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
	//		msclr::interop::marshal_context context;
	//		std::string str = context.marshal_as<std::string>(clip->clips[clip->sub]);
	//		
	//		TDS::SoundInfo temp(str);
	//		
	//		audio_engine->playSound(temp);
	//	}
	//}

	void AudioSource::Play(System::String^ pathing)
	{
		AudioComponent^ temp = dynamic_cast<AudioComponent^>(clips[pathing]);
		temp->play();
	}

	void AudioSource::Pause(System::String^ pathing)
	{
		AudioComponent^ temp = dynamic_cast<AudioComponent^>(clips[pathing]);
		temp->pause();
	}

	void AudioSource::Stop(System::String^ pathing)
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

	void AudioSource::Loop(System::String^ pathing, bool set)
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

	bool AudioSource::isPlaying()
	{
		return audio_engine->soundIsPlaying();
	}

	bool AudioSource::isPlaying(System::String^ pathing)
	{
		AudioComponent^ temp = dynamic_cast<AudioComponent^>(clips[pathing]);
		return temp->isPlaying();
	}

	bool AudioSource::hasFinished(System::String^ pathing)
	{
		AudioComponent^ temp = dynamic_cast<AudioComponent^>(clips[pathing]);
		return temp->finished();
	}

	void AudioSource::add_clips(System::String^ pathing)
	{
		AudioComponent^ temp = gcnew AudioComponent(pathing, id_num++);
		
		clips->Add(pathing, temp);
	}

	/*template<typename T>
	T& AudioSource::operator=(float val)
	{
		value = val;
	}*/

	/*void AudioClip::add_clips(std::filesystem::path file)
	{
		System::String^ temp = gcnew System::String(file.string().c_str());
		
		clips.Add(temp);
		++sub;
	}*/
}