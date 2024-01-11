#include "NotesTab.hxx"

namespace ScriptAPI
{
	NotesTab::NotesTab(TDS::EntityID ID) : id(ID)
	{
		//nothing
	}

	TDS::EntityID NotesTab::GetEntityID()
	{
		return id;
	}

	void NotesTab::SetEntityID(TDS::EntityID ID)
	{
		id = ID;
	}
}