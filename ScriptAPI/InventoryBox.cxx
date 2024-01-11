#include "InventoryBox.hxx"
#include "Components/CameraComponent.hxx"

namespace ScriptAPI
{
	InventoryBox::InventoryBox(TDS::EntityID ID) : id(ID)
	{
		//nothing
	}

	bool InventoryBox::show(bool set)
	{
		show_menu = true;
		show_mouse = false;
	}

	void InventoryBox::init()
	{
		show_mouse = true;
		show_menu = false;
		position = Vector3(TDS::GetCameraComponent(id)->getPosition());

		float width, height;
		width = TDS::GetCameraComponent(id)->getForwardVector().y * TDS::GetCameraComponent(id)->getFOV();
	}
}