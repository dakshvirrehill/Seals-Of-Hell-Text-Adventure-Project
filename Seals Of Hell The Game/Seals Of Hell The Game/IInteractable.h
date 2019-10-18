#pragma once
#ifndef I_INTERACTABLE_H
#define I_INTERACTABLE_H
#include "BasicObject.h"
class IInteractable : public BasicObject
{
protected:
	IInteractable() {};
	virtual ~IInteractable() {};
public:
	virtual bool teleportRegion();
	virtual bool pickObject();
	virtual bool goDirection();
	virtual bool blockAttack();
	virtual bool attackEnemy();
	virtual bool wearObject();
	virtual bool playObject();
	virtual bool giveObject();
	virtual bool eatObject();
	virtual bool moveObject();
	virtual bool answerRiddle();
	virtual bool dropObject();
//	virtual bool giveString() = 0;
};
#endif