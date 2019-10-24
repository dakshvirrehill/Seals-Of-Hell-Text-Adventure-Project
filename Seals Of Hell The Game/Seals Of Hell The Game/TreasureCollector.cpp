#include "TreasureCollector.h"
#include "PlayerManager.h"
TreasureCollector::~TreasureCollector()
{
}

void TreasureCollector::update()
{
	if (!isInteractable())
	{
		bool aAllThr = true;
		for (auto& iter : mTreasures)
		{
			if (!PlayerManager::instance().hasInInventory(iter))
			{
				aAllThr = false;
				break;
			}
		}
		if (aAllThr)
		{
			endUpdate();
		}
	}
	
}

void TreasureCollector::endUpdate()
{

}

void TreasureCollector::giveObject(IInteractable*)
{
}

void TreasureCollector::addTreasures(IInteractable*)
{
}
