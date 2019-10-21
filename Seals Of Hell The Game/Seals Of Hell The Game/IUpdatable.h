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

public:
	IUpdatable() : mLife(0), mAttackStory(""), mBlockStory(""), mDeathStory("") {}
	~IUpdatable() {}
	virtual void update() = 0;
	int& getLife() { return mLife; }
	std::string& getAttackStory() { return mAttackStory; }
	std::string& getBlockStory() { return mBlockStory; }
	std::string& getDeathStory() { return mDeathStory; }
};
#endif