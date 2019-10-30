#include "IInteractable.h"
#include "PlayerManager.h"
#include "GameManager.h"
#include "Room.h"
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

void PlayerManager::addNewShield(std::string pShieldName)
{
	mShieldNames.push_back(pShieldName);
}


IInteractable* PlayerManager::getInventoryObject(std::string& pObjectName)
{
	if (mInventory.count(pObjectName) != 0)
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

void PlayerManager::attackPlayer(IInteractable* pAttacker)
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

void PlayerManager::dropInventory(Room* pDroppingRoom)
{
	std::map<std::string, IInteractable*>::iterator aIterator = mInventory.begin();
	while (aIterator != mInventory.end())
	{
		pDroppingRoom->addInteractable((*aIterator).second);
		aIterator = mInventory.erase(aIterator);
	}
}



void PlayerManager::blockAttack()
{
	mInAttack = false;
}

bool PlayerManager::hasShield()
{
	for (auto& iter : mShieldNames)
	{
		if (mInventory.count(iter) == 1)
		{
			return true;
		}
	}
	return false;
}

bool PlayerManager::hasInInventory(IInteractable* pObject)
{
	return mInventory.count(pObject->getName()) != 0;
}
