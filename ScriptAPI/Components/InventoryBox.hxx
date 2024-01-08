#pragma once

#include "UISpriteComponent.hxx"
#include "ColliderComponent.hxx"

public value class InventoryBox
{
public:
	bool show(bool set);
	
	void init();
	void draw();
	void update();

internal:
	InventoryBox(TDS::EntityID ID);
};