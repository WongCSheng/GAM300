#pragma once

#include "ComponentBase.hxx"
#include "ColliderComponent.hxx"
#include "UISpriteComponent.hxx"

/**
 * @brief This is a sub component of an inventory system.
 * Stores the paintings that the player collected throughout the game.
*/

namespace ScriptAPI
{
	public value class PaintingTab : ComponentBase
	{
	public:

		virtual TDS::EntityID GetEntityID();
		virtual void SetEntityID(TDS::EntityID id);

	internal:
		PaintingTab(TDS::EntityID ID);

	private:

		TDS::EntityID id;
	};
}