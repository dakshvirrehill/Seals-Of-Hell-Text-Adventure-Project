#include "IInteractable.h"
#include "PlayerManager.h"
#include <string>

void PlayerManager::inventory()
{
	//print all interactable names in inventory
}

bool PlayerManager::wakeUp()
{
	return false;
}

IInteractable* PlayerManager::getInventoryObject(std::string&)
{
	//find inventory obj from map and return it
	return nullptr;
}
