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
	inline static PlayerManager& instance()
	{
		static PlayerManager mInstance;
		return mInstance;
	}
	void inventory();
	void wakeUp();
	IInteractable* getInventoryObject(std::string&);
	friend class GameManager;
	friend class CommandManager;
};
#endif