#pragma once
#ifndef PLAYER_MANAGER_H
#define PLAYER_MANAGER_H
#include<string>
#include<map>
class IInteractable;
class Room;
class PlayerManager
{
private:
	std::map <std::string, IInteractable*> mInventory;
	bool mInAttack;
protected:
	PlayerManager() : mInventory(), mInAttack(false) {}
	~PlayerManager() {}
	void inventory();
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