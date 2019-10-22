#pragma once
#ifndef I_UPDATABLE_H
#define I_UPDATABLE_H
#include <string>
#include <list>
class IInteractable;
class IUpdatable
{
	int mLife;
	std::string mAttackStory;	
	std::string mBlockStory;
	std::string mDeathStory;
	IInteractable* mConditionalObject;
	std::list<IInteractable*> mCondUpdtObjs;
public:
	IUpdatable() : mLife(0), mAttackStory(""), mBlockStory(""), mDeathStory(""),mConditionalObject(nullptr),mCondUpdtObjs() {}
	~IUpdatable() {}
	virtual void update() = 0;
	virtual void enemyDeath() = 0;
	int& getLife() { return mLife; }
	std::string& getAttackStory() { return mAttackStory; }
	std::string& getBlockStory() { return mBlockStory; }
	std::string& getDeathStory() { return mDeathStory; }
	IInteractable* getConditionalObject() { return mConditionalObject; }
	std::list<IInteractable*>& getConditionUpdateObjects() { return mCondUpdtObjs; }
	void setConditionalObject(IInteractable* pConditionalObject) { mConditionalObject = pConditionalObject; }
	void addConditionUpdateObjects(IInteractable* pCondUpdObjs) { mCondUpdtObjs.push_back(pCondUpdObjs); }
};
#endif