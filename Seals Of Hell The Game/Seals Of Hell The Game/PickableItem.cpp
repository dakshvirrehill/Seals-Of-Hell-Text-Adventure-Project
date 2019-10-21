#include "PlayerManager.h"
#include "PickableItem.h"
#include <iostream>

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
	if (isInteractable() && !mIsPicked)
	{
		mIsPicked = true;
		PlayerManager::instance().addInInventory(this);
		std::cout << getName() << " picked." << std::endl;
	}
}

void PickableItem::wearObject()
{
	if (mIsWearable && isInteractable() && !mIsWorn)
	{
		if (!mIsPicked)
		{
			mIsPicked = true;
			PlayerManager::instance().addInInventory(this);
		}
		mIsWorn = true;
		std::cout << getName() << " worn." << std::endl;
	}
}

void PickableItem::giveObject(IInteractable* pCollector)
{
	//TODO: Add code to give object to collector and drop it from inventory
}

void PickableItem::dropObject()
{
	if (mIsPicked && isInteractable())
	{
		mIsWorn = false;
		mIsGiven = false;
		mIsPicked = false;
		PlayerManager::instance().removeFromInventory(this);
		std::cout << getName() << " dropped." << std::endl;
	}
}
