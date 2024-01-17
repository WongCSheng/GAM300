#include "ItemsTab.hxx"

namespace ScriptAPI
{
	ItemsTab::ItemsTab(TDS::EntityID ID) : id(ID)
	{
		item = gcnew System::Collections::Hashtable();
	}

	bool ItemsTab::click()
	{

	}
}