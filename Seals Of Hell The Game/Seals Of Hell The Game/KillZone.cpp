#include "PlayerManager.h"
#include "KillZone.h"
#include <iostream>
KillZone::~KillZone()
{
}
void KillZone::update()
{
	if (!isInteractable())
	{
		return;
	}
	if (getConditionalObject() == nullptr)
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
		PlayerManager::instance().attackPlayer(this);
		PlayerManager::instance().attackPlayer(this);
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
		PlayerManager::instance().attackPlayer(this);
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
}
