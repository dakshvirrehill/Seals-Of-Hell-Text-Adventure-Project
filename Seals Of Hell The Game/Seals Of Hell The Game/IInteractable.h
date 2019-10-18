#pragma once
#ifndef I_INTERACTABLE_H
#define I_INTERACTABLE_H
#include "BasicObject.h"
class IInteractable : public BasicObject
{
public:
	virtual bool teleportRegion() = 0;
	virtual bool pickObject() = 0;
	virtual bool goDirection() = 0;
	virtual bool blockAttack() = 0;
	virtual bool attackEnemy() = 0;
	virtual bool wearObject() = 0;
	virtual bool playObject() = 0;
	virtual bool giveObject() = 0;
	virtual bool eatObject() = 0;
	virtual bool moveObject() = 0;
	virtual bool answerRiddle() = 0;
	virtual bool dropObject() = 0;
//	virtual bool giveString() = 0;
};
#endif