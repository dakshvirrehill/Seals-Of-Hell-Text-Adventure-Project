#include "TreasureCollector.h"
#include "GameManager.h"
#include "PickableItem.h"
#include <iostream>
#include <map>
#include <string>

TreasureCollector::~TreasureCollector()
{
}

void TreasureCollector::onEnable()
{
	if (!isInteractable())
	{
		resetConditionals();
	}
}

void TreasureCollector::update()
{
	if (!isInteractable())
	{
		bool aAllThr = true;
		for (auto& iter : mTreasures)
		{
			if (!GameManager::instance().hasInInventory(iter.second))
			{
				aAllThr = false;
				break;
			}
		}
		if (aAllThr)
		{
			endUpdate();
		}
		else
		{
			resetConditionals();
		}
	}
	else
	{
		if (mTreasures.size() <= 0)
		{
			std::cout << getDeathStory() << std::endl << std::endl;
		}
	}
}

void TreasureCollector::endUpdate()
{
	bool aItr = true;
	makeInteractable(aItr);
	std::cout << getAttackStory() << std::endl << std::endl;
	for (auto& iter : getConditionUpdateObjects())
	{
		iter->makeVisible(aItr);
		iter->makeInteractable(aItr);
	}
	GameManager::look();
}

void TreasureCollector::giveObject(IInteractable* pGiveable)
{
	if (isInteractable())
	{
		if (mTreasures.count(pGiveable->getName()) != 0)
		{
			PickableItem* aGiveable = (PickableItem*)pGiveable;
			aGiveable->objectGiven();
			mTreasures.erase(pGiveable->getName());
			GameManager::instance().removeFromInventory(pGiveable);
		}
		else
		{
			IInteractable::giveObject(pGiveable);
		}
	}
	else
	{
		std::cout << getAttackStory() << std::endl;
	}
}

void TreasureCollector::addTreasures(IInteractable* pTreasure)
{
	mTreasures.emplace(pTreasure->getName(), pTreasure);
}
