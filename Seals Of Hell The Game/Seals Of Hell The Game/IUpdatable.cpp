#include "IUpdatable.h"
#include "IInteractable.h"
void IUpdatable::initialize(std::string pAttackStory, std::string pDeathStory)
{
	mAttackStory = pAttackStory;
	mDeathStory = pDeathStory;
}

void IUpdatable::resetConditionals()
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

void IUpdatable::addCommons(json::JSON& pJSON)
{
	pJSON["mUpdateStory"] = mAttackStory;
	pJSON["mEndStory"] = mDeathStory;
	if (mConditionalObject != nullptr)
	{
		pJSON["mConditionalObject"] = mConditionalObject->getName();
	}
	pJSON["mUpdatableObjectsWithType"] = json::JSON::Object();
	for (auto& iter : mCondUpdtObjs)
	{
		pJSON["mUpdatableObjectsWithType"][iter->getName()] = iter->getType();
	}
}
