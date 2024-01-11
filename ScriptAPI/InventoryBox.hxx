#pragma once

#include "Components/UISpriteComponent.hxx"
#include "Components/ColliderComponent.hxx"
#include "Components/GraphicComponent.hxx"

#include "Components/ItemsTab.hxx"
#include "Components/PaintingTab.hxx"
#include "Components/NotesTab.hxx"
#include "Components/CameraComponent.hxx"

/**
 * @brief UI to display sub components such as Items, Paintings and Notes
 * It is an interface to interact with the sub components.
 * It should lock the camera and just use the mouse cursor.
*/

namespace ScriptAPI
{
	public ref class InventoryBox
	{
	public:
		bool show(bool set);

		void init();
		void draw();
		void update();

	internal:
		InventoryBox(TDS::EntityID ID);

	private:
		bool show_mouse, show_menu;
		Vector3 position;
		//Quaternion matrix;
		float opacity;
		Vector2 size;

		TDS::EntityID id;
	};
}