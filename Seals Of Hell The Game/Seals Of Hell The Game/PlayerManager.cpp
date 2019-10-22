#include "IInteractable.h"
#include "PlayerManager.h"
#include "GameManager.h"
#include "Enemy.h"
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


IInteractable* PlayerManager::getInventoryObject(std::string& pObjectName)
{
	if (mInventory.find(pObjectName) != mInventory.end())
	{
		return mInventory[pObjectName];
	}
	return nullptr;
}

void PlayerManager::addInInventory(IInteractable* pPickedObject)
{
	mInventory.emplace(pPickedObject->getName(), pPickedObject);
	GameManager::instance().removeFromRoom(pPickedObject);
}

void PlayerManager::removeFromInventory(IInteractable* pDroppedObject)
{
	mInventory.erase(pDroppedObject->getName());
	GameManager::instance().addInRoom(pDroppedObject);
}

void PlayerManager::attackPlayer(Enemy* pAttacker)
{
	if (mInAttack)
	{
		std::cout << " You Died at the hands of " << pAttacker->getName() << std::endl;
	}
	else
	{
		mInAttack = true;
	}
}

void PlayerManager::blockAttack()
{
	mInAttack = false;
}

bool PlayerManager::hasShield()
{
	return mInventory.find("SHIELD") != mInventory.end();
}
