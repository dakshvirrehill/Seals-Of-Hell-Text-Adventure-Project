#pragma once
#ifndef I_INTERACTABLE_H
#define I_INTERACTABLE_H
#include "BasicObject.h"
class IInteractable : public BasicObject
{
protected:
	IInteractable():BasicObject() {};
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
//	virtual bool wakeUp();
//	virtual bool giveString() = 0;
};
#endif