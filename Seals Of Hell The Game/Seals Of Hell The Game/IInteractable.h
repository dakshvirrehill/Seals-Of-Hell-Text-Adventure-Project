#pragma once
#ifndef I_INTERACTABLE_H
#define I_INTERACTABLE_H
#include "BasicObject.h"
#include "json.hpp"
/*
################
ALL THE INTERACTABLE OBJECTS INHERIT FROM THIS CLASS IT HAS PROPERTIES LIKE VISIBLE AND INTERACTABLE 
COMMON TO ALL OF THEM AND VIRTUAL FUNCTION FOR EACH COMMAND
################
*/
class IInteractable : public BasicObject
{
	bool mVisible;
	bool mInteractable;
protected:
	IInteractable():BasicObject(), mVisible(false),mInteractable(false) {};
	void addCommons(json::JSON&);
public:
	virtual ~IInteractable() {};
	void initialize(bool, bool);
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
	virtual bool isGateway() { return false; }
	virtual bool isPortal() { return false; }
	virtual bool isPickable() { return false; }
	bool& isVisible() { return mVisible; }
	bool& isInteractable() { return mInteractable; }
	void makeVisible(bool pEnable) { mVisible = pEnable; }
	void makeInteractable(bool pEnable) { mInteractable = pEnable; }
	virtual json::JSON getItemJSON() = 0;
	virtual std::string getType() = 0;
};
#endif