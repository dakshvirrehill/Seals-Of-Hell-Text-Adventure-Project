#include "TreasureCollector.h"
#include "PlayerManager.h"
#include "PickableItem.h"
#include <iostream>
#include <map>
#include <string>

TreasureCollector::~TreasureCollector()
{
}

void TreasureCollector::update()
{
	if (!isInteractable())
	{
		bool aAllThr = true;
		for (auto& iter : mTreasures)
		{
			if (!PlayerManager::instance().hasInInventory(iter.second))
			{
				aAllThr = false;
				break;
			}
		}
		if (aAllThr)
		{
			endUpdate();
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
	for (auto& iter : getConditionUpdateObjects())
	{
		iter->makeInteractable(aItr);
		iter->makeInteractable(aItr);
	}
}

void TreasureCollector::giveObject(IInteractable* pGiveable)
{
	if (isInteractable())
	{
		if (mTreasures.find(pGiveable->getName()) != mTreasures.end())
		{
			PickableItem* aGiveable = (PickableItem*)pGiveable;
			aGiveable->objectGiven();
			mTreasures.erase(pGiveable->getName());
			PlayerManager::instance().removeFromInventory(pGiveable);
		}
		else
		{
			IInteractable::giveObject(pGiveable);
		}
	}
	else
	{
		std::cout << "Collect all first" << std::endl;
	}
}

void TreasureCollector::addTreasures(IInteractable* pTreasure)
{
	mTreasures.emplace(pTreasure->getName(), pTreasure);
}
