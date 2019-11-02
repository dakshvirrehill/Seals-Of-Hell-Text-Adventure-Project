#pragma once
#include "IInteractable.h"
#include "json.hpp"
/*
################
Pickable Items are (weapons,shields,giveables,wearables)
Their implementation is boolean based
################
*/
class PickableItem : public IInteractable
{
	bool mIsWeapon;
	bool mIsShield;
	bool mIsGiveable;
	bool mIsWearable;
	bool mIsPicked;
	bool mIsWorn;
	bool mIsGiven;
	bool mIsDropped;
public:
	PickableItem() : IInteractable(),mIsWeapon(false),mIsShield(false),mIsGiveable(false),mIsWearable(false),mIsPicked(false),mIsWorn(false),mIsGiven(false),mIsDropped(false) {}
	~PickableItem() {}
	void initialize(bool pIsWeapon,bool pIsShield,bool pIsGiveable,bool pIsWearable,bool pIsPicked = false,bool pIsWorn = false,bool pIsGiven = false,bool pIsDropped = false);
	void objectGiven();
	void pickObject() override;
	void wearObject() override;
	void dropObject() override;
	bool isWorn() override { return (mIsWearable && mIsWorn) || (!mIsWearable && mIsDropped); }
	bool isGiven() override { return mIsGiven; }
	bool isPickable() override { return true; }
	void resetPickable();
	json::JSON getItemJSON() override;
	std::string getType() override { return "PickableItem"; }
};

