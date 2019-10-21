#include "IInteractable.h"
#include "PlayerManager.h"
#include <string>
#include <iostream>
#include <map>

void PlayerManager::inventory()
{
	std::cout << "==============================" << std::endl;
	std::cout << "Inventory" << std::endl;
	for (auto& iter : mInventory)
	{
		std::cout << iter.second->getName() << std::endl;
	}
	std::cout << "==============================" << std::endl;
}

bool PlayerManager::wakeUp()
{
	return false;
}

IInteractable* PlayerManager::getInventoryObject(std::string& pObjectName)
{
	if (mInventory.find(pObjectName) != mInventory.end())
	{
		return mInventory[pObjectName];
	}
	return nullptr;
}
