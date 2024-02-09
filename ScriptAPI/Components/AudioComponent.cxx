#include "AudioComponent.hxx"
#include "../TypeConversion.hxx"
#include "../EngineInterface.hxx"

namespace ScriptAPI
{
	AudioComponent::AudioComponent(TDS::EntityID ID) : entityID(ID)
	{
		gameObject = EngineInterface::GetGameObject(ID);
		soundInfo = TDS::GetSoundInfo(ID);
	}

	AudioComponent::AudioComponent(System::String^ pathing)
	{
		filePath = toStdString(pathing);
	}

	AudioComponent::AudioComponent(SI* si)
	{
		soundInfo = si;
	}

	void AudioComponent::SetEntityID(TDS::EntityID id)
	{
		entityID = id;
		transform = TransformComponent(id);
		gameObject = EngineInterface::GetGameObject(id);
	}

	TDS::EntityID AudioComponent::GetEntityID()
	{
		return entityID;
	}

	void AudioComponent::set3DCoords(float x, float y, float z)
	{
		pos = Vector3(x, y, z);
	}

	void AudioComponent::set3DCoords(Vector3 in_pos)
	{
		pos = in_pos;
	}

	bool AudioComponent::isLoaded()
	{
		return (whatState == TDS::SOUND_LOADED);
	}

	bool AudioComponent::is3D()
	{
		return isit3D;
	}

	bool AudioComponent::isLoop()
	{
		return isitLoop;
	}

	bool AudioComponent::isMuted()
	{
		return isitMuted;
	}

	Vector3 AudioComponent::get3DCoords()
	{
		return pos;
	}

	snd AudioComponent::getState()
	{
		return whatState;
	}

	unsigned int AudioComponent::getUniqueID()
	{
		return uniqueID;
	}

	unsigned int AudioComponent::getMSLength()
	{
		return MSLength;
	}

	std::string AudioComponent::getFilePath()
	{
		return filePath;
	}

	const char* AudioComponent::getFilePath_inChar()
	{
		return filePath.c_str();
	}

	void AudioComponent::setFilePath(System::String^ str_path)
	{
		filePath = toStdString(str_path);
	}

	int AudioComponent::getLoopCount()
	{
		return loopCount;
	}

	float AudioComponent::getX()
	{
		return pos.X;
	}

	float AudioComponent::getY()
	{
		return pos.Y;
	}

	float AudioComponent::getZ()
	{
		return pos.Z;
	}

	float AudioComponent::getReverbAmount()
	{
		return ReverbAmount;
	}

	float AudioComponent::getVolume()
	{
		return volume;
	}

	void AudioComponent::setVolume(float vol)
	{
		volume = vol;
	}

	void AudioComponent::setMSLength(unsigned int len)
	{
		MSLength = len;
	}

	void AudioComponent::setState(snd setting)
	{
		whatState = setting;
	}

	void AudioComponent::setLoop(bool condition)
	{
		isitLoop = condition;
	}

	void AudioComponent::setLoopCount(int count)
	{
		loopCount = count;
	}

	void AudioComponent::set3D(bool condition)
	{
		isit3D = condition;
	}

	void AudioComponent::setMute(bool condition)
	{
		isitMuted = condition;
	}

	/*void AudioComponent::tieWithSoundInfo(SI* _soundInfo)
	{
		soundInfo = _soundInfo;
	}*/

	void AudioComponent::SetEnabled(bool enabled)
	{
		TDS::setComponentIsEnable("Audio", GetEntityID(), enabled);
	}
	bool AudioComponent::GetEnabled()
	{
		return TDS::getComponentIsEnable("Audio", GetEntityID());
	}

	/*void AudioComponent::SetSoundInfoObject(SI* _soundInfo)
	{
		soundInfo = _soundInfo;
	}*/

	//unique ID
	unsigned int AudioComponent::uniqueID::get()
	{
		return TDS::GetSoundInfo(entityID)->uniqueID;
	}
	void AudioComponent::uniqueID::set(unsigned int value)
	{
		TDS::GetSoundInfo(entityID)->uniqueID = value;
	}

	//MS Length
	unsigned int AudioComponent::MSLength::get()
	{
		return TDS::GetSoundInfo(entityID)->MSLength;
	}
	void AudioComponent::MSLength::set(unsigned int value)
	{
		TDS::GetSoundInfo(entityID)->MSLength = value;
	}

	//file path
	std::string AudioComponent::filePath::get()
	{
		return TDS::GetSoundInfo(entityID)->getFilePath();
	}
	void AudioComponent::filePath::set(std::string value)
	{
		TDS::GetSoundInfo(entityID)->setFilePath(value);
	}

	//loop count
	int AudioComponent::loopCount::get()
	{
		return loopCount;
	}
	void AudioComponent::loopCount::set(int value)
	{
		loopCount = value;
	}

	//loop
	bool AudioComponent::isitLoop::get()
	{
		return TDS::GetSoundInfo(entityID)->isLoop();
	}
	void AudioComponent::isitLoop::set(bool value)
	{
		TDS::GetSoundInfo(entityID)->isitLoop = value;
	}

	//3D boolean
	bool AudioComponent::isit3D::get()
	{
		return TDS::GetSoundInfo(entityID)->is3D();
	}
	void AudioComponent::isit3D::set(bool value)
	{
		TDS::GetSoundInfo(entityID)->isit3D = value;
	}

	//muted
	bool AudioComponent::isitMuted::get()
	{
		return TDS::GetSoundInfo(entityID)->isMuted();
	}
	void AudioComponent::isitMuted::set(bool value)
	{
		TDS::GetSoundInfo(entityID)->isitmuted = value;
	}

	//state of sound info
	snd AudioComponent::whatState::get()
	{
		return TDS::GetSoundInfo(entityID)->whatState;
	}
	void AudioComponent::whatState::set(snd value)
	{
		TDS::GetSoundInfo(entityID)->whatState = value;
	}

	//3D position
	Vector3 AudioComponent::pos::get()
	{
		return Vector3(TDS::GetSoundInfo(entityID)->position);
	}
	void AudioComponent::pos::set(Vector3 value)
	{
		TDS::GetSoundInfo(entityID)->set3DCoords(value.X, value.Y, value.Z);
	}

	//volume
	float AudioComponent::volume::get()
	{
		return TDS::GetSoundInfo(entityID)->getVolume();
	}
	void AudioComponent::volume::set(float value)
	{
		TDS::GetSoundInfo(entityID)->setVolume(value);
	}

	//Reverb
	float AudioComponent::ReverbAmount::get()
	{
		return TDS::GetSoundInfo(entityID)->ReverbAmount;
	}
	void AudioComponent::ReverbAmount::set(float value)
	{
		TDS::GetSoundInfo(entityID)->ReverbAmount = value;
	}

	//soundInfo
	/*SI* AudioComponent::soundInfo::get()
	{
		return TDS::GetSoundInfo(entityID);
	}
	void AudioComponent::soundInfo::set(SI* si)
	{
		*TDS::GetSoundInfo(entityID) = *si;
	}*/
}