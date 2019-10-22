#pragma once
#include "IInteractable.h"
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
	void initialize(bool&,bool&,bool&,bool&,bool&,bool&);
	void pickObject() override;
	void wearObject() override;
	void dropObject() override;
	bool isWorn() override { return mIsWorn || mIsDropped; }
	bool isGiven() override { return mIsGiven; }
};

