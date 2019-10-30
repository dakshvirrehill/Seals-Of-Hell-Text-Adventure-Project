#pragma once
#ifndef I_UPDATABLE_H
#define I_UPDATABLE_H
#include <string>
#include <list>
class IInteractable;
class IUpdatable
{
	
	std::string mAttackStory;	
	std::string mDeathStory;
	IInteractable* mConditionalObject;
	std::list<IInteractable*> mCondUpdtObjs;
protected:
	IUpdatable() : mAttackStory(""), mDeathStory(""), mConditionalObject(nullptr), mCondUpdtObjs() {}
public:
	virtual ~IUpdatable() {}
	void initialize(std::string, std::string);
	virtual void onEnable() = 0;
	virtual void update() = 0;
	virtual void endUpdate() = 0;
	std::string& getAttackStory() { return mAttackStory; }
	std::string& getDeathStory() { return mDeathStory; }
	IInteractable* getConditionalObject() { return mConditionalObject; }
	std::list<IInteractable*>& getConditionUpdateObjects() { return mCondUpdtObjs; }
	void setConditionalObject(IInteractable* pConditionalObject) { mConditionalObject = pConditionalObject; }
	void addConditionUpdateObjects(IInteractable* pCondUpdObjs) { mCondUpdtObjs.push_back(pCondUpdObjs); }
	void resetConditionals();
};
#endif