#include "Collector.h"
#include "PickableItem.h"
#include "GameManager.h"
#include<iostream>
Collector::~Collector()
{
}
void Collector::onEnable()
{
	if (isInteractable())
	{
		resetConditionals();
	}
}
void Collector::update()
{
	if (isInteractable())
	{
		if (getConditionalObject()->isGiven())
		{
			endUpdate();
		}
		else
		{
			std::cout << getName() << std::endl;
			std::cout << getAttackStory() << std::endl;
			resetConditionals();
		}
	}
}

void Collector::endUpdate()
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
	GameManager::instance().lookInsideRoom();
}

void Collector::giveObject(IInteractable* pGiveable)
{
	if (getConditionalObject() == pGiveable)
	{
		PickableItem* aGivable = (PickableItem*)pGiveable;
		aGivable->objectGiven();
	}
	else
	{
		IInteractable::giveObject(pGiveable);
	}
}
