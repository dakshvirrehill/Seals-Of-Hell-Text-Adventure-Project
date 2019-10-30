#pragma once
#ifndef PLAYER_MANAGER_H
#define PLAYER_MANAGER_H
#include<string>
#include<map>
#include<list>
class IInteractable;
class Room;
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
	friend class GameManager;
	friend class CommandManager;
};
#endif