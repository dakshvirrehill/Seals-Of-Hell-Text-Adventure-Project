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
