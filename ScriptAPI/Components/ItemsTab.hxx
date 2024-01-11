#pragma once

#include "ComponentBase.hxx"
#include "ColliderComponent.hxx"
#include "UISpriteComponent.hxx"

#include <map>

/**
 * @brief This is a sub component of an inventory system.
 * Items are consumable, meaning is 1 time use and will disappear afterwards.
 * The layout is in grids of rows and cols.
*/

namespace ScriptAPI
{
	public value class ItemsTab : ComponentBase
	{
	public:
		bool click();

		virtual TDS::EntityID GetEntityID();
		virtual void SetEntityID(TDS::EntityID id);

	internal:
		ItemsTab(TDS::EntityID ID);

	private:
		int rows, cols;
		std::map<Vector2, System::String^> item; //Map of Vector2, System::String^


		TDS::EntityID id;
	};
}