#include "OneInteractionItem.h"
#include "GameManager.h"
#include <iostream>
#include "AnalyticsManager.h"
void OneInteractionItem::initialize(bool pIsMovable, bool pIsPlayable, bool pIsEatable, bool pIsRiddle)
{
	mIsMovable = pIsMovable;
	mIsPlayable = pIsPlayable;
	mIsRiddle = pIsRiddle;
	mIsEatable = pIsEatable;
}

void OneInteractionItem::lookObject()
{
	if (mIsRiddle && isVisible())
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
	if (isInteractable() && mIsMovable)
	{
		AnalyticsManager::instance().UpdateActionData("Move");
		endUpdate();
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
		AnalyticsManager::instance().UpdateActionData("Play");
		endUpdate();
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
		AnalyticsManager::instance().UpdateActionData("Eat");
		endUpdate();
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
		AnalyticsManager::instance().UpdateActionData("Answer");
		endUpdate();
	}
	else
	{
		IInteractable::answerRiddle();
	}
}

void OneInteractionItem::onEnable()
{
	if (isInteractable())
	{
		resetConditionals();
	}
}

void OneInteractionItem::update()
{
	if (isInteractable())
	{
		if (!mIsRiddle)
		{
			std::cout << getName() << std::endl;
		}
		std::cout << getAttackStory() << std::endl;
		resetConditionals();
	}
}

void OneInteractionItem::endUpdate()
{
	std::cout << getName() << std::endl;
	std::cout << getDeathStory() << std::endl;
	bool aInt = false;
	makeInteractable(aInt);
	makeVisible(aInt);
	bool aVal = true;
	for (auto& iter : getConditionUpdateObjects())
	{
		iter->makeInteractable(aVal);
		iter->makeVisible(aVal);
	}
	GameManager::instance().lookInsideRoom();
}

json::JSON OneInteractionItem::getItemJSON()
{
	json::JSON aJSON = json::JSON::Object();
	aJSON["mType"] = "OneInteractionItem";
	IInteractable::addCommons(aJSON);
	IUpdatable::addCommons(aJSON);
	aJSON["mIsMovable"] = mIsMovable;
	aJSON["mIsPlayable"] = mIsPlayable;
	aJSON["mIsEatable"] = mIsEatable;
	aJSON["mIsRiddle"] = mIsRiddle;
	aJSON["mIntType"] = 4;
	return aJSON;
}


