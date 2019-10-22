#include "PlayerManager.h"
#include "KillZone.h"
#include <iostream>
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
		PlayerManager::instance().attackPlayer(this);
	}
	else if (!getConditionalObject()->isWorn())
	{
		std::cout << getName() << std::endl;
		std::cout << getAttackStory() << std::endl;
		PlayerManager::instance().attackPlayer(this);
	}
	else
	{
		enemyDeath();
	}
}

void KillZone::enemyDeath()
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
