#pragma once
#ifndef PLAYER_MANAGER_H
#define PLAYER_MANAGER_H
#include<string>
#include<map>
#include<list>
class IInteractable;
class Room;
/*
################
Current Player Class (Was a singleton Changed it as there can be more than one players in future iterations)
Has the inventory, and when attacked while in attack, the player dies and game ends
################
*/
class PlayerManager
{
private:
	std::map <std::string, IInteractable*> mInventory;
	std::list<std::string> mShieldNames;
	bool mInAttack;
protected:
	PlayerManager() : mInventory(),mShieldNames(), mInAttack(false) {}
	~PlayerManager();
	void inventory();
	void addNewShield(std::string);
	IInteractable* getInventoryObject(std::string&);
	void addInInventory(IInteractable*);
	void removeFromInventory(IInteractable*);
	void attackPlayer(IInteractable*);
	void dropInventory(Room*);
	void blockAttack();
	bool hasShield();
	bool hasInInventory(IInteractable*);
	std::map <std::string, IInteractable*>& getPlayerInventory() { return mInventory; }
	int getInventorySize() { return mInventory.size(); }
	friend class GameManager;
	friend class CommandManager;
};
#endif