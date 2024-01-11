#include "PaintingTab.hxx"

namespace ScriptAPI
{
	PaintingTab::PaintingTab(TDS::EntityID ID) : id(ID)
	{
		//nothing
	}

	TDS::EntityID PaintingTab::GetEntityID()
	{
		return id;
	}

	void PaintingTab::SetEntityID(TDS::EntityID ID)
	{
		id = ID;
	}
}