#pragma once
#include "IInteractable.h"
class PickableItem : public IInteractable
{
	bool mIsWeapon;
	bool mIsShield;
	bool mIsGiveable;
	bool mIsWearable;
public:
	void initialize();
	void pickObject() override;
	void wearObject() override;
	void giveObject(IInteractable*) override;
};

