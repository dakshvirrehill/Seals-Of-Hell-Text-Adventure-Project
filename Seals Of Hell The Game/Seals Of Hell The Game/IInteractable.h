#pragma once
#ifndef I_INTERACTABLE_H
#define I_INTERACTABLE_H
#include "BasicObject.h"
class IInteractable : public BasicObject
{
	bool mVisible;
	bool mInteractable;
protected:
	IInteractable():BasicObject(), mVisible(false),mInteractable(false) {};
	virtual ~IInteractable() {};
public:
//	virtual void initialize() = 0;
	virtual bool lookObject();
	virtual bool teleportRegion();
	virtual bool pickObject();
	virtual bool goDirection();
	virtual bool blockAttack();
	virtual bool attackEnemy(IInteractable*);
	virtual bool wearObject();
	virtual bool playObject();
	virtual bool giveObject(IInteractable*);
	virtual bool eatObject();
	virtual bool moveObject();
	virtual bool answerRiddle();
	virtual bool dropObject();
	bool& isVisible() { return mVisible; }
	bool& isInteractable() { return mInteractable; }
	void makeVisible(bool pEnable = true) { mVisible = pEnable; }
	void makeInteractable(bool pEnable = true) { mInteractable = pEnable; }
//	virtual bool wakeUp();
//	virtual bool giveString() = 0;
};
#endif