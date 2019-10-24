#include "OneInteractionItem.h"
#include <iostream>
void OneInteractionItem::initialize(bool& pIsMovable, bool& pIsPlayable, bool& pIsEatable, bool& pIsRiddle, bool& pIsInteractable, bool& pIsVisible)
{
	mIsMovable = pIsMovable;
	mIsPlayable = pIsPlayable;
	mIsRiddle = pIsRiddle;
	mIsEatable = pIsEatable;
	makeInteractable(pIsInteractable);
	makeVisible(pIsVisible);
}

void OneInteractionItem::lookObject()
{
	if (mIsRiddle)
	{
		std::cout << getStory() << std::endl;
	}
	else
	{
		IInteractable::lookObject();
	}
}

void OneInteractionItem::moveObject()
{
	if (isInteractable() && mIsPlayable)
	{
		std::cout << getName() << "moved." << std::endl;
		enemyDeath();
	}
	else
	{
		IInteractable::moveObject();
	}
}

void OneInteractionItem::playObject()
{
	if (isInteractable() && mIsPlayable)
	{
		std::cout << getName() << std::endl;
		std::cout << getDeathStory() << std::endl;
		enemyDeath();
	}
	else
	{
		IInteractable::playObject();
	}
}

void OneInteractionItem::eatObject()
{
	if (isInteractable() && mIsEatable)
	{
		std::cout << getName() << " eaten." << std::endl;
		enemyDeath();
	}
	else
	{
		IInteractable::eatObject();
	}
}

void OneInteractionItem::answerRiddle()
{
	if (isInteractable() && mIsRiddle)
	{
		std::cout << getName() << std::endl;
		std::cout << getDeathStory() << std::endl;
		enemyDeath();
	}
	else
	{
		IInteractable::answerRiddle();
	}
}

void OneInteractionItem::update()
{
	if (isInteractable())
	{
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
	}
}

void OneInteractionItem::enemyDeath()
{
	bool aInt = false;
	makeInteractable(aInt);
	bool aVal = true;
	for (auto& iter : getConditionUpdateObjects())
	{
		iter->makeInteractable(aVal);
		iter->makeVisible(aVal);
	}
}


