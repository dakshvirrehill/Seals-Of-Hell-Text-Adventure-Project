#pragma once
#ifndef I_INTERACTABLE_H
#define I_INTERACTABLE_H
#include "BasicObject.h"
namespace json
{
	class JSON;
}
class IInteractable : public BasicObject
{
protected:
	IInteractable():BasicObject() {};
	virtual ~IInteractable() {};
public:
	virtual void initialize(json::JSON&) = 0;
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