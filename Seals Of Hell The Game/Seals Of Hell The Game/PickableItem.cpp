#include "PickableItem.h"
#include "GameManager.h"
#include <iostream>
#include "AnalyticsManager.h"
void PickableItem::initialize(bool pIsWeapon, bool pIsShield, bool pIsGiveable, bool pIsWearable, bool pIsPicked, bool pIsWorn, bool pIsGiven, bool pIsDropped)
{
	mIsWeapon = pIsWeapon;
	mIsShield = pIsShield;
	mIsGiveable = pIsGiveable;
	mIsWearable = pIsWearable;
	mIsPicked = pIsPicked;
	mIsGiven = pIsGiven;
	mIsWorn = pIsWorn;
	mIsDropped = pIsDropped;
}

void PickableItem::objectGiven()
{
	if (isInteractable() && !mIsGiven)
	{
		mIsGiven = true;
		std::cout << getName() << " given." << std::endl;
	}
}

void PickableItem::pickObject()
{
	if (isInteractable() && !mIsPicked)
	{
		AnalyticsManager::instance().UpdateActionData("Pick");
		AnalyticsManager::instance().UpdatePickableData(getName(), true);
		mIsPicked = true;
		GameManager::instance().addInInventory(this);
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
			GameManager::instance().addInInventory(this);
		}
		AnalyticsManager::instance().UpdateActionData("Wear");
		mIsWorn = true;
		std::cout << getName() << " worn." << std::endl;
	}
}

void PickableItem::dropObject()
{
	if (mIsPicked && isInteractable())
	{
		AnalyticsManager::instance().UpdateActionData("Drop");
		AnalyticsManager::instance().UpdatePickableData(getName(), false);
		mIsWorn = false;
		mIsGiven = false;
		mIsPicked = false;
		mIsDropped = true;
		GameManager::instance().removeFromInventory(this);
		std::cout << getName() << " dropped." << std::endl;
	}
}

void PickableItem::resetPickable()
{
	if (!mIsGiveable)
	{
		mIsPicked = false;
		mIsWorn = false;
		mIsDropped = false;
	}
}

json::JSON PickableItem::getItemJSON()
{
	json::JSON myObj = json::JSON::Object();
	addCommons(myObj);
	myObj["mIsWeapon"] = mIsWeapon;
	myObj["mIsShield"] = mIsShield;
	myObj["mIsGiveable"] = mIsGiveable;
	myObj["mIsWearable"] = mIsWearable;
	myObj["mIsPicked"] = mIsPicked;
	myObj["mIsWorn"] = mIsWorn;
	myObj["mIsGiven"] = mIsGiven;
	myObj["mIsDropped"] = mIsDropped;
	myObj["mType"] = "PickableItem";
	myObj["mIntType"] = 5;
	return myObj;
}
