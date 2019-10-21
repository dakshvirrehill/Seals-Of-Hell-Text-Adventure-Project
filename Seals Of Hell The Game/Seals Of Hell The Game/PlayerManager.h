#pragma once
#ifndef PLAYER_MANAGER_H
#define PLAYER_MANAGER_H
#include<string>
#include<map>
class IInteractable;
class PlayerManager
{
private:
	inline explicit PlayerManager() : mInventory() {}
	inline ~PlayerManager() {}
	inline explicit PlayerManager(PlayerManager const&) : mInventory() {}
	inline PlayerManager& operator=(PlayerManager const&)
	{
		return *this;
	}
	std::map < std::string, IInteractable*> mInventory;
protected:
	void inventory();
	void wakeUp();
public:
	inline static PlayerManager& instance()
	{
		static PlayerManager mInstance;
		return mInstance;
	}
	IInteractable* getInventoryObject(std::string&);
	void addInInventory(IInteractable*);
	void removeFromInventory(IInteractable*);
	friend class GameManager;
	friend class CommandManager;
};
#endif