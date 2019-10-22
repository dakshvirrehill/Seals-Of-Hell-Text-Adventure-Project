#include "Collector.h"
#include<iostream>
void Collector::update()
{
	if (isInteractable())
	{
		if (getConditionalObject()->isGiven())
		{
			enemyDeath();
		}
		else
		{
			std::cout << getName() << std::endl;
			std::cout << getAttackStory() << std::endl;
		}
	}
}

void Collector::enemyDeath()
{
	bool aTemp = false;
	makeInteractable(aTemp);
	makeVisible(aTemp);
	std::cout << getName() << std::endl;
	std::cout << getDeathStory() << std::endl;
	bool aVal = true;
	for (auto& iter : getConditionUpdateObjects())
	{
		iter->makeInteractable(aVal);
		iter->makeVisible(aVal);
	}
}
