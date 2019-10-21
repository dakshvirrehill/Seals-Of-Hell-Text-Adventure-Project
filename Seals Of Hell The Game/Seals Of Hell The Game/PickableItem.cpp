#include "PlayerManager.h"
#include "PickableItem.h"

void PickableItem::initialize(bool& pIsWeapon, bool& pIsShield, bool& pIsGiveable, bool& pIsWearable, bool& pIsVisable, bool& pIsInteractable)
{
	makeInteractable(pIsInteractable);
	makeVisible(pIsVisable);
	mIsWeapon = pIsWeapon;
	mIsShield = pIsShield;
	mIsGiveable = pIsGiveable;
	mIsWearable = pIsWearable;
}

void PickableItem::pickObject()
{
	if (isInteractable() && isVisible() && !mIsPicked)
	{
		mIsPicked = true;
		PlayerManager::instance().addInInventory(this);
	}
}
