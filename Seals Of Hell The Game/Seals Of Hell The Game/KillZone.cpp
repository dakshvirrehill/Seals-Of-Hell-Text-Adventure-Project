#include "GameManager.h"
#include "KillZone.h"
#include <iostream>
KillZone::~KillZone()
{
}
void KillZone::onEnable()
{
	if (isInteractable())
	{
		resetConditionals();
	}
}
void KillZone::update()
{
	if (!isInteractable() && !isVisible())
	{
		return;
	}
	if (getConditionalObject() == nullptr)
	{
		std::cout << getName() << std::endl;
		std::cout << getAttackStory() << std::endl;
		resetConditionals();
		GameManager::instance().attackPlayer(this);
		GameManager::instance().attackPlayer(this);
	}
	else if (!getConditionalObject()->isWorn())
	{
		std::cout << getName() << std::endl;
		std::cout << getAttackStory() << std::endl;
		bool aVal = false;
		for (auto& iter : getConditionUpdateObjects())
		{
			if (iter->isInteractable())
			{
				iter->makeInteractable(aVal);
			}
			if (iter->isVisible())
			{
				iter->makeVisible(aVal);
			}
		}
		GameManager::instance().attackPlayer(this);
	}
	else
	{
		endUpdate();
	}
}

void KillZone::endUpdate()
{
	bool aInt = false;
	makeInteractable(aInt);
	makeVisible(aInt);
	std::cout << getName() << std::endl;
	std::cout << getDeathStory() << std::endl;
	bool aVal = true;
	for (auto& iter : getConditionUpdateObjects())
	{
		iter->makeInteractable(aVal);
		iter->makeVisible(aVal);
	}
	GameManager::instance().lookInsideRoom();
	GameManager::instance().blockAttack();
}

json::JSON KillZone::getItemJSON()
{
	json::JSON aJSON = json::JSON::Object();
	aJSON["mType"] = "KillZone";
	aJSON["mIntType"] = 3;
	IInteractable::addCommons(aJSON);
	IUpdatable::addCommons(aJSON);
	return aJSON;
}
