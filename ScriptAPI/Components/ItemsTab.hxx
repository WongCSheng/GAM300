#pragma once

#include "ColliderComponent.hxx"
#include "UISpriteComponent.hxx"

/**
 * @brief This is a sub component of an inventory system.
 * Items are consumable, meaning is 1 time use and will disappear afterwards.
 * The layout is in grids of rows and cols.
*/

public value class ItemsTab
{
public:
	bool click();

private:
	int rows, cols;
    System::String^ item;
};