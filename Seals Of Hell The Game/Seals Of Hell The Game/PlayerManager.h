#pragma once
#ifndef PLAYER_MANAGER_H
#define PLAYER_MANAGER_H
#include<string>
#include<map>
class IInteractable;
class Enemy;
class PlayerManager
{
private:
	inline explicit PlayerManager() : mInventory(),mInAttack(false) {}
	inline ~PlayerManager() {}
	inline explicit PlayerManager(PlayerManager const&) : mInventory(),mInAttack(false) {}
	inline PlayerManager& operator=(PlayerManager const&)
	{
		return *this;
	}
	std::map <std::string, IInteractable*> mInventory;
	bool mInAttack;
protected:
	void inventory();
public:
	inline static PlayerManager& instance()
	{
		static PlayerManager mInstance;
		return mInstance;
	}
	IInteractable* getInventoryObject(std::string&);
	void addInInventory(IInteractable*);
	void removeFromInventory(IInteractable*);
	void attackPlayer(Enemy*);
	void blockAttack();
	bool hasShield();
	friend class GameManager;
	friend class CommandManager;
};
#endif