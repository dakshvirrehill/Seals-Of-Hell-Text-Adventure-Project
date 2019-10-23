#pragma once
#ifndef I_INTERACTABLE_H
#define I_INTERACTABLE_H
#include "BasicObject.h"
class IInteractable : public BasicObject
{
	bool mVisible;
	bool mInteractable;
	bool mIsNameVisible;
protected:
	IInteractable():BasicObject(), mVisible(false),mInteractable(false),mIsNameVisible(false) {};
	virtual ~IInteractable() {};
public:
	virtual void lookObject();
	virtual void teleportRegion();
	virtual void pickObject();
	virtual void goDirection();
	virtual void blockAttack();
	virtual void attackEnemy(IInteractable*);
	virtual void wearObject();
	virtual void playObject();
	virtual void giveObject(IInteractable*);
	virtual void eatObject();
	virtual void moveObject();
	virtual void answerRiddle();
	virtual void dropObject();
	virtual bool isWorn() { return false; }
	virtual bool isGiven() { return false; }
	bool& isVisible() { return mVisible; }
	bool& isInteractable() { return mInteractable; }
	bool& isNameVisible() { return mIsNameVisible; }
	//TODO : maybe remove these functions to keep reference functions to manipulate only
	void makeVisible(bool& pEnable) { mVisible = pEnable; }
	void makeInteractable(bool& pEnable) { mInteractable = pEnable; }
	void makeNameVisible(bool& pEnable) { mIsNameVisible = pEnable; }
};
#endif