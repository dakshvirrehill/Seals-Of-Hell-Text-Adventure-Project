#include "TreasureCollector.h"
#include "GameManager.h"
#include "PickableItem.h"
#include <iostream>
#include <map>
#include <string>
#include "AnalyticsManager.h"
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
			GameManager::instance().playerWon();
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
	GameManager::instance().lookInsideRoom();
}

void TreasureCollector::giveObject(IInteractable* pGiveable)
{
	if (isInteractable())
	{
		if (mTreasures.count(pGiveable->getName()) != 0)
		{
			AnalyticsManager::instance().UpdateActionData("Give");
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

json::JSON TreasureCollector::getItemJSON()
{
	json::JSON aJSON = json::JSON::Object();
	IInteractable::addCommons(aJSON);
	IUpdatable::addCommons(aJSON);
	aJSON["mType"] = "TreasureCollector";
	aJSON["mTreasures"] = json::JSON::Array();
	for(auto& iter: mTreasures)
	{
		aJSON["mTreasures"].append(iter.first);
	}
	aJSON["mIntType"] = 7;
	return aJSON;
}
